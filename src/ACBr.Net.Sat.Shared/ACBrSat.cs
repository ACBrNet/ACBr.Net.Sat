// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 03-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 02-16-2017
// ***********************************************************************
// <copyright file="ACBrSat.cs" company="ACBr.Net">
//		        		   The MIT License (MIT)
//	     		    Copyright (c) 2016 Grupo ACBr.Net
//
//	 Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//	 The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//	 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
// </copyright>
// <summary></summary>
// ***********************************************************************

using ACBr.Net.Core;
using ACBr.Net.Core.Exceptions;
using ACBr.Net.Core.Extensions;
using ACBr.Net.Core.Logging;
using ACBr.Net.DFe.Core.Common;
using ACBr.Net.Sat.Events;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using ACBr.Net.Integrador;

namespace ACBr.Net.Sat
{
    // ReSharper disable once InconsistentNaming
    /// <summary>
    /// Classe ACBrSat, responsavel por comunicar com o CF-e-SAT.
    /// </summary>
    /// <seealso cref="ACBrComponent" />
    /// <seealso cref="IACBrLog" />
#if !NETSTANDARD2_0
    [ToolboxBitmap(typeof(ACBrSat), "ACBr.Net.Sat.ACBrSat")]
#endif

    public sealed class ACBrSat : ACBrComponent, IACBrLog
    {
        #region Fields

        private ISatLibrary satLibrary;
        private Encoding encoding;
        private ModeloSat modelo;
        private string pathDll;
        private string signAC;
        private string codigoAtivacao;
        private ExtratoSat extrato;
        private bool aguardandoResposta;

        #endregion Fields

        #region Events

        /// <summary>
        /// Ocorre quando é necessario pegar o valor do Codigo de Ativação.
        /// </summary>
        public event EventHandler<ChaveEventArgs> OnGetCodigoDeAtivacao;

        /// <summary>
        /// Ocorre quando é necessario pegar o valor do SignAC.
        /// </summary>
        public event EventHandler<ChaveEventArgs> OnGetSignAC;

        /// <summary>
        /// Ocorre que é necessario pegar o número da sessão.
        /// </summary>
        public event EventHandler<NumeroSessaoEventArgs> OnGetNumeroSessao;

        /// <summary>
        /// Ocorre antes de enviar os dados da venda para o Sat.
        /// </summary>
        public event EventHandler<EventoDadosEventArgs> OnEnviarDadosVenda;

        /// <summary>
        /// Ocorre antes de cancelar uma venda.
        /// </summary>
        public event EventHandler<EventoDadosEventArgs> OnCancelarUltimaVenda;

        /// <summary>
        /// Ocorre quando é chamado o comando ConsultarSat para caso o usuario queria tratar esta função.
        /// </summary>
        public event EventHandler<EventoEventArgs> OnConsultarSat;

        /// <summary>
        /// Ocorre quando é chamado o comando ConsultaStatusOperacional para caso o usuario queria tratar esta função.
        /// </summary>
        public event EventHandler<EventoEventArgs> OnConsultaStatusOperacional;

        /// <summary>
        /// Ocorre quando é chamado o comando ExtrairLogs para caso o usuario queria tratar esta função.
        /// </summary>
        public event EventHandler<EventoEventArgs> OnExtrairLogs;

        /// <summary>
        /// Ocorre quando é chamado o comando ConsultarNumeroSessao para caso o usuario queria tratar esta função.
        /// </summary>
        public event EventHandler<EventoDadosEventArgs> OnConsultarNumeroSessao;

        /// <summary>
        /// Ocorre quando tem alguma mensagem da Sefaz no retorno do SAT.
        /// </summary>
        public event EventHandler<SatMensagemEventArgs> OnMensagemSefaz;

        /// <summary>
        /// Ocorre quando é necessario calcular o Path para salvar os Xmls.
        /// </summary>
        public event EventHandler<CalcPathEventEventArgs> OnCalcPath;

        /// <summary>
        /// Ocorre quando o componente entra ou sai de um processamento.
        /// </summary>
        public event EventHandler<EventArgs> AguardandoRespostaChanged;

        #endregion Events

        #region Properties

        /// <summary>
        /// Configurações do ACBrSat
        /// </summary>
        /// <value>The configuracoes.</value>
        [Category("Configurações")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SatConfig Configuracoes { get; private set; }

        /// <summary>
        /// Configurações de como ACBrSat vai se comportar com os arquivos gerado e recebido.
        /// </summary>
        /// <value>The arquivos.</value>
        [Category("Configurações")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CfgArquivos Arquivos { get; private set; }

        /// <summary>
        /// Enconding usado para tratar as string que são enviadas/recebidas.
        /// </summary>
        /// <value>O Enconder</value>
        /// <exception cref="Exception">Não é possível definir a propriedade com o componente ativo</exception>
        [Browsable(false)]
        public Encoding Encoding
        {
            get => encoding;
            set
            {
                Guard.Against<ACBrException>(Ativo, "Não é possível definir a propriedade com o componente ativo");
                encoding = value;
            }
        }

        /// <summary>
        /// Componente para comunicação com o Integrador Fiscal do Ceará.
        /// </summary>
        /// <value>O Integrador.</value>
        [DefaultValue(null)]
        [Category("Componentes ACBr.Net")]
        [TypeConverter(typeof(ReferenceConverter))]
        public ACBrIntegrador IntegradorFiscal { get; set; }

        /// <summary>
        /// Define/retorna a classe responsável por imprimir o Extrato do Sat.
        /// </summary>
        /// <value>The extrato.</value>
        [DefaultValue(null)]
        [Category("Componentes ACBr.Net")]
        [TypeConverter(typeof(ReferenceConverter))]
        public ExtratoSat Extrato
        {
            get => extrato;
            set
            {
                extrato = value;
                if (extrato.Parent != this)
                    extrato.Parent = this;
            }
        }

        /// <summary>
        /// Define/retorna o modelo a ser utilizado pelo ACBrSat.
        /// </summary>
        /// <value>The modelo.</value>
        [Category("Configurações")]
        public ModeloSat Modelo
        {
            get => modelo;
            set
            {
                Guard.Against<ACBrException>(Ativo, "Não é possível definir a propriedade com o componente ativo");
                modelo = value;
            }
        }

        /// <summary>
        /// Retorna o indicador se o componente esta ativo ou não.
        /// </summary>
        /// <value><c>true</c> se está ativo; senão, <c>false</c>.</value>
        [Browsable(false)]
        public bool Ativo { get; private set; }

        /// <summary>
        /// Retorna o indicador se o componente esta em aguardando uma resposta ou não.
        /// </summary>
        /// <value><c>true</c> se estiver aguardando uma resposta; senão, <c>false</c>.</value>
        [Browsable(false)]
        public bool AguardandoResposta
        {
            get => aguardandoResposta;
            private set
            {
                if (aguardandoResposta == value) return;

                aguardandoResposta = value;
                AguardandoRespostaChanged.Raise(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Retorna o número da sessão atual.
        /// </summary>
        /// <value>The sessao.</value>
        [Browsable(false)]
        public int Sessao { get; private set; }

        /// <summary>
        /// Define/retorna o código usado para ativar o Sat
        /// </summary>
        /// <value>Código ativacao.</value>
        [Category("Configurações")]
        public string CodigoAtivacao
        {
            get
            {
                var e = new ChaveEventArgs { Chave = codigoAtivacao };
                if (!DesignMode) OnGetCodigoDeAtivacao.Raise(this, e);

                codigoAtivacao = e.Chave;
                return codigoAtivacao;
            }
            set => codigoAtivacao = value;
        }

        /// <summary>
        /// Define/retorna a assinatura de (CNPJ Software House + CNPJ Emitente) que gerou o CF-e </summary>
        /// <value>SignAC.</value>
        [Category("Configurações")]
        public string SignAC
        {
            get
            {
                var e = new ChaveEventArgs { Chave = signAC };

                if (!DesignMode) OnGetSignAC.Raise(this, e);

                signAC = e.Chave;
                return signAC;
            }
            set => signAC = value;
        }

        /// <summary>
        /// Define/retorna o caminho onde se encontra a biblioteca do Sat.
        /// </summary>
        /// <value>O caminho da dll.</value>
        [Category("Configurações")]
        public string PathDll
        {
            get => pathDll;
            set
            {
                Guard.Against<ACBrException>(Ativo, "Não é possível definir a propriedade com o componente ativo");
                pathDll = value;
            }
        }

        #endregion Properties

        #region Methods

        #region Public

        /// <summary>
        /// Ativa o ACBrSat, obrigatorio antes de chamar qualquer metodo.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Ativar()
        {
            Guard.Against<ArgumentNullException>(Modelo == ModeloSat.MFeIntegrador && IntegradorFiscal == null, "Integrador fiscal não disponivel.");

            satLibrary = SatManager.GetLibrary(Modelo, Configuracoes, PathDll, Encoding);
            Ativo = true;
        }

        /// <summary>
        /// Desativa o ACBrSat e libera a lib nativa
        /// </summary>
        public void Desativar()
        {
            if (satLibrary != null)
            {
                satLibrary.Dispose();
                satLibrary = null;
            }

            Ativo = false;
        }

        /// <summary>
        /// Retorna uma nova instancia da classe CFe com os dados inciais preenchidos.
        /// </summary>
        /// <returns>CFe Iniciada.</returns>
        public CFe NewCFe()
        {
            var ret = new CFe();
            ret.InfCFe.Ide.CNPJ = Configuracoes.IdeCNPJ;
            ret.InfCFe.Ide.TpAmb = null;
            ret.InfCFe.Ide.NumeroCaixa = Configuracoes.IdeNumeroCaixa;
            ret.InfCFe.Ide.SignAC = SignAC;
            ret.InfCFe.Emit.CNPJ = Configuracoes.EmitCNPJ;
            ret.InfCFe.Emit.IM = Configuracoes.EmitIM;
            ret.InfCFe.Emit.IE = Configuracoes.EmitIE;
            ret.InfCFe.Emit.CRegTribISSQN = Configuracoes.EmitCRegTribISSQN;
            ret.InfCFe.Emit.IndRatISSQN = Configuracoes.EmitIndRatISSQN;
            ret.InfCFe.VersaoDadosEnt = Configuracoes.InfCFeVersaoDadosEnt;

            return ret;
        }

        /// <summary>
        /// Associa a sua assinatura ao Sat
        /// </summary>
        /// <param name="cnpj">The CNPJ.</param>
        /// <param name="assinaturaCnpj">The assinatura CNPJ.</param>
        /// <returns>SatResposta.</returns>
        public SatResposta AssociarAssinatura(string cnpj, string assinaturaCnpj)
        {
            Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");

            IniciaComando($"AssociarAssinatura({cnpj}, {assinaturaCnpj})");
            var ret = satLibrary.AssociarAssinatura(Sessao, CodigoAtivacao, cnpj, assinaturaCnpj);
            return FinalizaComando<SatResposta>(ret);
        }

        /// <summary>
        /// Função para ativa o Sat.
        /// </summary>
        /// <param name="subComando">The sub comando.</param>
        /// <param name="cnpj">The CNPJ.</param>
        /// <param name="uf">The uf.</param>
        /// <returns>SatResposta.</returns>
        public SatResposta AtivarSAT(int subComando, string cnpj, int uf)
        {
            Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");

            IniciaComando($"AtivarSAT({subComando}, {cnpj}, {uf})");
            var ret = satLibrary.AtivarSAT(Sessao, subComando, CodigoAtivacao, cnpj.OnlyNumbers(), uf);
            return FinalizaComando<SatResposta>(ret);
        }

        /// <summary>
        /// Envia um comando para o Sat se atualizar.
        /// </summary>
        /// <returns>SatResposta.</returns>
        public SatResposta AtualizarSoftwareSAT()
        {
            Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");

            IniciaComando("AtualizarSoftwareSAT()");
            var ret = satLibrary.AtualizarSoftwareSAT(Sessao, CodigoAtivacao);
            return FinalizaComando<SatResposta>(ret);
        }

        /// <summary>
        /// Bloquea o Sat.
        /// </summary>
        /// <returns>SatResposta.</returns>
        public SatResposta BloquearSAT()
        {
            Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");

            IniciaComando("BloquearSAT()");
            var ret = satLibrary.BloquearSAT(Sessao, CodigoAtivacao);
            return FinalizaComando<SatResposta>(ret);
        }

        /// <summary>
        /// Libera o Sat.
        /// </summary>
        /// <returns>SatResposta.</returns>
        public SatResposta DesbloquearSAT()
        {
            Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");

            IniciaComando($"DesbloquearSAT()");
            var ret = satLibrary.DesbloquearSAT(Sessao, CodigoAtivacao);
            return FinalizaComando<SatResposta>(ret);
        }

        /// <summary>
        /// Cancelar o CFe Informado
        /// </summary>
        /// <param name="cfe">CFe para cancelar.</param>
        /// <returns>CancelamentoSatResposta.</returns>
        public CancelamentoSatResposta CancelarUltimaVenda(CFe cfe)
        {
            Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");
            Guard.Against<ArgumentNullException>(cfe == null, nameof(cfe));

            var cfeCanc = new CFeCanc(cfe);
            return CancelarUltimaVenda(cfeCanc);
        }

        /// <summary>
        /// Cancela a venda relacionada a classe de cancelamento informada.
        /// </summary>
        /// <param name="cfeCanc">The cfe canc.</param>
        /// <returns>CancelamentoSatResposta.</returns>
        public CancelamentoSatResposta CancelarUltimaVenda(CFeCanc cfeCanc)
        {
            Guard.Against<ArgumentNullException>(cfeCanc == null, nameof(cfeCanc));

            var options = DFeSaveOptions.OmitDeclaration | DFeSaveOptions.DisableFormatting;
            if (Configuracoes.RemoverAcentos)
                options |= DFeSaveOptions.RemoveAccents;

            var dados = cfeCanc.GetXml(options);
            return CancelarUltimaVenda(cfeCanc.InfCFe.ChCanc, dados);
        }

        /// <summary>
        /// Cancela a venda
        /// </summary>
        /// <param name="chave">A chave da CFe pra cancelar.</param>
        /// <param name="dadosCancelamento">XML de cancelamento.</param>
        /// <returns>CancelamentoSatResposta.</returns>
        public CancelamentoSatResposta CancelarUltimaVenda(string chave, string dadosCancelamento)
        {
            Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");
            Guard.Against<ArgumentException>(chave.IsEmpty(), "Chave não informada.");
            Guard.Against<ArgumentException>(dadosCancelamento.IsEmpty(), "Dados de cancelamento não informado.");

            IniciaComando($"CancelarUltimaVenda({chave}, {dadosCancelamento})");

            if (Arquivos.SalvarEnvio)
            {
                var envioPath = Arquivos.PastaEnvio;
                var fullName = Path.Combine(envioPath, $"{Arquivos.PrefixoArqCFeCanc}{DateTime.Now:yyyyMMddHHmmss}-{Sessao.ZeroFill(6)}-env.xml");
                if (!Directory.Exists(envioPath))
                    Directory.CreateDirectory(envioPath);

                File.WriteAllText(fullName, dadosCancelamento);
            }

            var e = new EventoDadosEventArgs { Dados = dadosCancelamento };
            OnCancelarUltimaVenda.Raise(this, e);

            var ret = satLibrary.CancelarUltimaVenda(Sessao, CodigoAtivacao, chave, dadosCancelamento);
            var resp = FinalizaComando<CancelamentoSatResposta>(ret);

            if (!Arquivos.SalvarCFeCanc || resp.CodigoDeRetorno != 7000)
                return resp;

            var cnpj = Arquivos.SepararPorCNPJ ? resp.Cancelamento.InfCFe.Emit.CNPJ : "";
            var data = Arquivos.SepararPorMes ? $"{resp.Cancelamento.InfCFe.Ide.DEmi:yyyy}\\{resp.Cancelamento.InfCFe.Ide.DEmi:MM}" : "";
            var path = Path.Combine(Arquivos.PastaCFeCancelamento, cnpj, data);
            var calcPathEventEventArgs = new CalcPathEventEventArgs
            {
                CNPJ = resp.Cancelamento.InfCFe.Emit.CNPJ,
                Data = resp.Cancelamento.InfCFe.Ide.DEmi,
                Path = path
            };

            OnCalcPath.Raise(this, calcPathEventEventArgs);

            if (!Directory.Exists(calcPathEventEventArgs.Path))
                Directory.CreateDirectory(calcPathEventEventArgs.Path);

            var nomeArquivo = $"{Arquivos.PrefixoArqCFeCanc}{resp.Cancelamento.InfCFe.Id.OnlyNumbers()}.xml";
            var fullPath = Path.Combine(calcPathEventEventArgs.Path, nomeArquivo);
            resp.Cancelamento.Save(fullPath);
            return resp;
        }

        /// <summary>
        /// Seta o certificado para o Sat usa.
        /// So use caso você utiliza certificado Icp Brasil (NFe).
        /// </summary>
        /// <param name="certificado">The certificado.</param>
        /// <returns>SatResposta.</returns>
        public SatResposta ComunicarCertificadoIcpBrasil(string certificado)
        {
            Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");

            IniciaComando($"ComunicarCertificadoICPBRASIL({certificado})");
            var ret = satLibrary.ComunicarCertificadoIcpBrasil(Sessao, CodigoAtivacao, certificado);
            return FinalizaComando<SatResposta>(ret);
        }

        /// <summary>
        /// Configura a interface de rede do Sat.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <returns>SatResposta.</returns>
        public SatResposta ConfigurarInterfaceDeRede(SatRede config)
        {
            Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");
            Guard.Against<ArgumentNullException>(config == null, nameof(config));

            var configuracao = config.GetXml();
            IniciaComando($"ConfigurarInterfaceDeRede({configuracao})");
            var ret = satLibrary.ConfigurarInterfaceDeRede(Sessao, CodigoAtivacao, configuracao);
            return FinalizaComando<SatResposta>(ret);
        }

        /// <summary>
        /// Consulta os dados da sessão informada.
        /// </summary>
        /// <param name="numeroSessao">The numero sessao.</param>
        /// <returns>SatResposta.</returns>
        public ConsultaSessaoResposta ConsultarNumeroSessao(int numeroSessao)
        {
            Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");

            IniciaComando($"ConsultarNumeroSessao({numeroSessao})");
            var e = new EventoDadosEventArgs
            {
                Dados = numeroSessao.ToString(),
                Retorno = string.Empty
            };
            OnConsultarNumeroSessao.Raise(this, e);

            if (e.Retorno.IsEmpty())
                e.Retorno = satLibrary.ConsultarNumeroSessao(Sessao, CodigoAtivacao, numeroSessao);

            return FinalizaComando<ConsultaSessaoResposta>(e.Retorno);
        }

        /// <summary>
        /// Consulta a situação do Sat.
        /// </summary>
        /// <returns>SatResposta.</returns>
        public SatResposta ConsultarSAT()
        {
            Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");
            IniciaComando("ConsultarSAT()");
            var e = new EventoEventArgs { Retorno = string.Empty };
            OnConsultarSat.Raise(this, e);

            if (e.Retorno.IsEmpty())
                e.Retorno = satLibrary.ConsultarSAT(Sessao);

            return FinalizaComando<SatResposta>(e.Retorno);
        }

        /// <summary>
        /// Consulta a situação operacional do Sat.
        /// </summary>
        /// <returns>SatResposta.</returns>
        public StatusOperacionalResposta ConsultarStatusOperacional()
        {
            Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");

            IniciaComando("ConsultarStatusOperacional()");
            var e = new EventoEventArgs { Retorno = string.Empty };
            OnConsultaStatusOperacional.Raise(this, e);

            if (e.Retorno.IsEmpty())
                e.Retorno = satLibrary.ConsultarStatusOperacional(Sessao, CodigoAtivacao);

            return FinalizaComando<StatusOperacionalResposta>(e.Retorno);
        }

        /// <summary>
        /// Envia os dados da venda para o Sat.
        /// </summary>
        /// <param name="cfe">The cfe.</param>
        /// <returns>VendaSatResposta.</returns>
        public VendaSatResposta EnviarDadosVenda(CFe cfe)
        {
            Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");
            Guard.Against<ArgumentNullException>(cfe == null, nameof(cfe));

            var options = DFeSaveOptions.OmitDeclaration | DFeSaveOptions.DisableFormatting;
            if (Configuracoes.RemoverAcentos)
                options |= DFeSaveOptions.RemoveAccents;

            var dadosVenda = cfe.GetXml(options);

            IniciaComando($"EnviarDadosVenda({dadosVenda})");

            if (Arquivos.SalvarEnvio)
            {
                var envioPath = Arquivos.PastaEnvio;
                var fullName = Path.Combine(envioPath, $"{Arquivos.PrefixoArqCFe}{DateTime.Now:yyyyMMddHHmmss}-{Sessao.ZeroFill(6)}-env.xml");
                if (!Directory.Exists(envioPath))
                    Directory.CreateDirectory(envioPath);

                File.WriteAllText(fullName, dadosVenda);
            }

            var e = new EventoDadosEventArgs { Dados = dadosVenda };
            OnEnviarDadosVenda.Raise(this, e);

            var ret = satLibrary.EnviarDadosVenda(Sessao, CodigoAtivacao, e.Dados);
            var resp = FinalizaComando<VendaSatResposta>(ret);

            if (!Arquivos.SalvarCFe || resp.CodigoDeRetorno != 6000)
                return resp;

            var cnpj = Arquivos.SepararPorCNPJ ? resp.Venda.InfCFe.Emit.CNPJ : "";
            var data = Arquivos.SepararPorMes ? $"{resp.Venda.InfCFe.Ide.DEmi:yyyy}\\{resp.Venda.InfCFe.Ide.DEmi:MM}" : "";
            var path = Path.Combine(Arquivos.PastaCFeVenda, cnpj, data);
            var calcPathEventEventArgs = new CalcPathEventEventArgs
            {
                CNPJ = resp.Venda.InfCFe.Emit.CNPJ,
                Data = resp.Venda.InfCFe.Ide.DEmi,
                Path = path
            };

            OnCalcPath.Raise(this, calcPathEventEventArgs);

            if (!Directory.Exists(calcPathEventEventArgs.Path)) Directory.CreateDirectory(calcPathEventEventArgs.Path);

            var nomeArquivo = $"{Arquivos.PrefixoArqCFe}{resp.Venda.InfCFe.Id.OnlyNumbers()}.xml";
            var fullPath = Path.Combine(calcPathEventEventArgs.Path, nomeArquivo);
            resp.Venda.Save(fullPath);

            return resp;
        }

        /// <summary>
        /// Extrai os logs do Sat.
        /// </summary>
        /// <returns>SatResposta.</returns>
        public LogResposta ExtrairLogs()
        {
            Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");

            IniciaComando("ExtrairLogs()");

            var e = new EventoEventArgs { Retorno = string.Empty };
            OnExtrairLogs.Raise(this, e);

            if (e.Retorno.IsEmpty())
                e.Retorno = satLibrary.ExtrairLogs(Sessao, CodigoAtivacao);

            return FinalizaComando<LogResposta>(e.Retorno);
        }

        /// <summary>
        /// Realiza um teste de fim a fim no Sat.
        /// </summary>
        /// <param name="cfe">The cfe.</param>
        /// <returns>SatResposta.</returns>
        public TesteResposta TesteFimAFim(CFe cfe)
        {
            Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");

            var options = DFeSaveOptions.OmitDeclaration | DFeSaveOptions.DisableFormatting;
            if (Configuracoes.RemoverAcentos)
                options |= DFeSaveOptions.RemoveAccents;

            var dadosVenda = cfe.GetXml(options);
            IniciaComando($"TesteFimAFim({dadosVenda})");

            if (Arquivos.SalvarEnvio)
            {
                var envioPath = Arquivos.PastaEnvio;
                var fullName = Path.Combine(envioPath, $"{Arquivos.PrefixoArqCFe}{DateTime.Now:yyyyMMddHHmmss}-{Sessao.ZeroFill(6)}-teste-env.xml");
                if (!Directory.Exists(envioPath))
                    Directory.CreateDirectory(envioPath);

                File.WriteAllText(fullName, dadosVenda);
            }

            var ret = satLibrary.TesteFimAFim(Sessao, CodigoAtivacao, dadosVenda);
            var resp = FinalizaComando<TesteResposta>(ret);
            if (!Arquivos.SalvarCFe || resp.CodigoDeRetorno != 9000)
                return resp;

            var cnpj = Arquivos.SepararPorCNPJ ? resp.VendaTeste.InfCFe.Emit.CNPJ : "";
            var data = Arquivos.SepararPorMes ? $"{resp.VendaTeste.InfCFe.Ide.DEmi:yyyy}\\{resp.VendaTeste.InfCFe.Ide.DEmi:MM}" : "";
            var path = Path.Combine(Arquivos.PastaCFeVenda, cnpj, data);
            var calcPathEventEventArgs = new CalcPathEventEventArgs
            {
                CNPJ = resp.VendaTeste.InfCFe.Emit.CNPJ,
                Data = resp.VendaTeste.InfCFe.Ide.DEmi,
                Path = path
            };

            OnCalcPath.Raise(this, calcPathEventEventArgs);

            if (!Directory.Exists(calcPathEventEventArgs.Path)) Directory.CreateDirectory(calcPathEventEventArgs.Path);

            var nomeArquivo = $"{Arquivos.PrefixoArqCFe}{resp.VendaTeste.InfCFe.Id}.xml";
            var fullPath = Path.Combine(calcPathEventEventArgs.Path, nomeArquivo);
            resp.VendaTeste.Save(fullPath);

            return resp;
        }

        /// <summary>
        /// Troca o codigo de ativação do Sat.
        /// </summary>
        /// <param name="codigo">The novo codigo.</param>
        /// <param name="opcao">The opcao.</param>
        /// <param name="novoCodigo">The conf novo codigo.</param>
        /// <returns>SatResposta.</returns>
        public SatResposta TrocarCodigoDeAtivacao(string codigo, int opcao, string novoCodigo)
        {
            Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");

            IniciaComando($"TrocarCodigoDeAtivacao({codigo}, {opcao}, {novoCodigo})");
            var ret = satLibrary.TrocarCodigoDeAtivacao(Sessao, codigo, opcao, novoCodigo, novoCodigo);
            return FinalizaComando<SatResposta>(ret);
        }

        /// <summary>
        /// Imprime o extrato do Cfe.
        /// </summary>
        /// <param name="cfe">The cfe.</param>
        public void ImprimirExtrato(CFe cfe)
        {
            Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");
            Guard.Against<ArgumentNullException>(Extrato == null, "Componente de Impressão não definido !");

            Extrato.ImprimirExtrato(cfe);
        }

        /// <summary>
        /// Imprime o extrato resumido do CFe.
        /// </summary>
        /// <param name="cfe">The cfe.</param>
        public void ImprimirExtratoResumido(CFe cfe)
        {
            Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");
            Guard.Against<ArgumentNullException>(Extrato == null, "Componente de Impressão não definido !");

            Extrato.ImprimirExtratoResumido(cfe);
        }

        /// <summary>
        /// Imprimir o extrato de cancelamento do CFe.
        /// </summary>
        /// <param name="ambiente">The cfe.</param>
        /// <param name="cFeCanc">The c fe canc.</param>
        public void ImprimirExtratoCancelamento(CFeCanc cFeCanc, DFeTipoAmbiente ambiente)
        {
            Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");
            Guard.Against<ArgumentNullException>(Extrato == null, "Componente de Impressão não definido !");

            Extrato.ImprimirExtratoCancelamento(cFeCanc, ambiente);
        }

        /// <summary>
        /// Gera o SignAC usando o certificado informado.
        /// </summary>
        /// <param name="certificado">O certificado.</param>
        /// <param name="CNPJSoftwareHouse">O CNPJ da software house.</param>
        /// <param name="CNPJEstbComercial">O CNPJ do estabelecimento comercial.</param>
        /// <returns>System.String.</returns>
        public string GerarSignAc(X509Certificate2 certificado, string CNPJSoftwareHouse, string CNPJEstbComercial)
        {
            Guard.Against<ArgumentNullException>(certificado == null, nameof(certificado));
            Guard.Against<ArgumentException>(CNPJSoftwareHouse.IsEmpty(), nameof(CNPJSoftwareHouse));
            Guard.Against<ArgumentException>(CNPJEstbComercial.IsEmpty(), nameof(CNPJEstbComercial));

            this.Log().Info($"GerarSignAc: Certificado: {certificado.SerialNumber} - CNPJSoftwareHouse: {CNPJSoftwareHouse} - CNPJEstbComercial: {CNPJEstbComercial}");

            var privateProvider = certificado.PrivateKey as RSACryptoServiceProvider;
            if (privateProvider == null) return null;

            var cspParameters = new CspParameters
            {
                KeyContainerName = privateProvider.CspKeyContainerInfo.KeyContainerName,
                KeyNumber = privateProvider.CspKeyContainerInfo.KeyNumber == KeyNumber.Exchange ? 1 : 2
            };

            var rsa = new RSACryptoServiceProvider(cspParameters) { PersistKeyInCsp = false };

            try
            {
                var data = Encoding.UTF8.GetBytes(CNPJSoftwareHouse + CNPJEstbComercial);
                var signData = rsa.SignData(data, "SHA256");

                var sign = signData.ToBase64();

                this.Log().Info($"GerarSignAc: Sign: {sign}");

                return sign;
            }
            catch (Exception exception)
            {
                this.Log().Error(exception);
                throw new ACBrException("Erro ao gerar a assinatura.", exception);
            }
            finally
            {
                rsa.Dispose();
            }
        }

        #endregion Public

        #region Private

        private void IniciaComando(string comandoLog)
        {
            AguardandoResposta = true;
            GerarNumeroSessao();
            this.Log().Info($"NumeroSessao: {Sessao} - Comando: {comandoLog}");
        }

        private T FinalizaComando<T>(string resposta) where T : SatResposta
        {
            this.Log().Info($"NumeroSessao: {Sessao} - Resposta: {resposta}");
            var resp = (T)Activator.CreateInstance(typeof(T), resposta, Encoding);

            if (resp.NumeroSessao != Sessao)
            {
                this.Log().Error($"Sessao retornada pelo SAT [{resp.NumeroSessao}], diferente da enviada [{Sessao}].");
                if (Configuracoes.ValidarNumeroSessaoResposta)
                {
                    var fsSessaoAVerificar = Sessao;
                    var consultaCount = 0;

                    do
                    {
                        consultaCount++;
                        Guard.Against<ACBrException>(consultaCount > Configuracoes.NumeroTentativasValidarSessao,
                            $"Sessao retornada pelo SAT [{resp.NumeroSessao}], diferente da enviada [{fsSessaoAVerificar}].");

                        IniciaComando($"ConsultarNumeroSessao({fsSessaoAVerificar})");
                        var ret = satLibrary.ConsultarNumeroSessao(Sessao, CodigoAtivacao, fsSessaoAVerificar);
                        this.Log().Info($"NumeroSessao: {Sessao} - Resposta: {ret}");
                        resp = (T)Activator.CreateInstance(typeof(T), ret, Encoding);
                    } while (resp.NumeroSessao != fsSessaoAVerificar);
                }
            }

            if (resp.CodigoSEFAZ <= 0 || resp.MensagemSEFAZ.IsEmpty()) return resp;

            var e = new SatMensagemEventArgs(resp.CodigoSEFAZ, resp.MensagemSEFAZ);
            OnMensagemSefaz.Raise(this, e);
            AguardandoResposta = false;
            return resp;
        }

        private void GerarNumeroSessao()
        {
            Sessao = StaticRandom.Next(1, 999999);

            var e = new NumeroSessaoEventArgs(Sessao);
            OnGetNumeroSessao.Raise(this, e);
            Sessao = e.Sessao;
        }

        #endregion Private

        #region Override

        protected override void OnInitialize()
        {
            Configuracoes = new SatConfig(this);
            Arquivos = new CfgArquivos();
            Encoding = Encoding.UTF8;

            PathDll = @"C:\SAT\SAT.dll";
            CodigoAtivacao = "123456";
            signAC = string.Empty;
        }

        protected override void OnDisposing()
        {
            if (Ativo)
            {
                Desativar();
            }
        }

        #endregion Override

        #endregion Methods
    }
}
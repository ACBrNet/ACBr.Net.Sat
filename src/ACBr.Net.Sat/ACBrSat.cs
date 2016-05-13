// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 03-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-05-2016
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
using ACBr.Net.DFe.Core.Serializer;
using ACBr.Net.Sat.Events;
using ACBr.Net.Sat.Interfaces;
using System;
using System.IO;
using System.Text;
using System.Xml;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Classe do componente ACBrSat.
	/// </summary>
	/// <seealso cref="ACBr.Net.Core.ACBrComponent" />
	public class ACBrSat : ACBrComponent
	{
		#region Fields

		internal readonly IInternalLogger Logger = LoggerProvider.LoggerFor(typeof(ACBrSat));

		private ISatLibrary sat;
		private Encoding encoding;
		private ModeloSat modelo;
		private string pathDll;
		private string signAC;
		private string codigoAtivacao;

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

		public event EventHandler<EventoEventArgs> OnConsultaStatusOperacional;

		public event EventHandler<EventoEventArgs> OnExtrairLogs;

		public event EventHandler<EventoDadosEventArgs> OnConsultarNumeroSessao;

		/// <summary>
		/// Ocorre quando tem alguma mensagem da Sefaz no retorno do SAT.
		/// </summary>
		public event EventHandler<SatMensagemEventArgs> OnMensagemSefaz;

		/// <summary>
		/// Ocorre quando é necessario calcular o Path para salvar os Xmls.
		/// </summary>
		public event EventHandler<CalcPathEventEventArgs> OnCalcPath;

		#endregion Events

		#region Constructor

		/// <summary>
		/// Inicializa uma nova instancia da classe <see cref="ACBrSat"/>.
		/// </summary>
		public ACBrSat()
		{
			Configuracoes = new SatConfig();
			Arquivos = new CfgArquivos();
			Encoding = Encoding.UTF8;

			PathDll = @"C:\SAT\SAT.dll";
			CodigoAtivacao = "123456";
			signAC = string.Empty;
		}

		#endregion Constructor

		#region Properties

		/// <summary>
		/// Indica se o componente esta ativo ou não.
		/// </summary>
		/// <value><c>true</c> if ativo; otherwise, <c>false</c>.</value>
		public bool Ativo { get; private set; }

		/// <summary>
		/// Número da sessão atual.
		/// </summary>
		/// <value>The sessao.</value>
		public int Sessao { get; private set; }

		/// <summary>
		/// Configurações do ACBrSat
		/// </summary>
		/// <value>The configuracoes.</value>
		public SatConfig Configuracoes { get; private set; }

		/// <summary>
		/// Configurações de como ACBrSat vai se comportar com os arquivos gerado e recebido.
		/// </summary>
		/// <value>The arquivos.</value>
		public CfgArquivos Arquivos { get; private set; }

		/// <summary>
		/// Modelo a ser utilizado pelo ACBrSat.
		/// </summary>
		/// <value>The modelo.</value>
		public ModeloSat Modelo
		{
			get
			{
				return modelo;
			}
			set
			{
				Guard.Against<ACBrException>(Ativo, "Não é possível definir a propriedade com o componente ativo");
				modelo = value;
			}
		}

		/// <summary>
		/// Código usado para ativar o Sat
		/// </summary>
		/// <value>Código ativacao.</value>
		public string CodigoAtivacao
		{
			get
			{
				var e = new ChaveEventArgs { Chave = codigoAtivacao };
				OnGetCodigoDeAtivacao.Raise(this, e);

				codigoAtivacao = e.Chave;
				return codigoAtivacao;
			}
			set
			{
				codigoAtivacao = value;
			}
		}

		/// <summary>
		/// Assinatura de (CNPJ Software House + CNPJ Emitente) que gerou o CF-e </summary>
		/// <value>SignAC.</value>
		public string SignAC
		{
			get
			{
				var e = new ChaveEventArgs { Chave = signAC };
				OnGetSignAC.Raise(this, e);

				signAC = e.Chave;
				return signAC;
			}
			set
			{
				signAC = value;
			}
		}

		/// <summary>
		/// Caminho onde se encontra a biblioteca do Sat.
		/// </summary>
		/// <value>O caminho da dll.</value>
		public string PathDll
		{
			get
			{
				return pathDll;
			}
			set
			{
				Guard.Against<ACBrException>(Ativo, "Não é possível definir a propriedade com o componente ativo");
				pathDll = value;
			}
		}

		/// <summary>
		/// Enconding usado para tratar as string que são enviadas/recebidas.
		/// </summary>
		/// <value>O Enconder</value>
		/// <exception cref="Exception">Não é possível definir a propriedade com o componente ativo</exception>
		public Encoding Encoding
		{
			get
			{
				return encoding;
			}
			set
			{
				Guard.Against<ACBrException>(Ativo, "Não é possível definir a propriedade com o componente ativo");
				encoding = value;
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
			switch (Modelo)
			{
				case ModeloSat.Cdecl:
					sat = new SatCdecl(PathDll, encoding);
					break;

				case ModeloSat.StdCall:
					sat = new SatStdCall(PathDll, encoding);
					break;

				default:
					throw new NotImplementedException("Modelo não impementado !");
			}

			Ativo = true;
		}

		/// <summary>
		/// Desativa o ACBrSat e libera a lib nativa
		/// </summary>
		public void Desativar()
		{
			if (sat != null)
			{
				sat.Dispose();
				sat = null;
			}

			Ativo = false;
		}

		/// <summary>
		/// Retorna uma nova instancia da classe CFe com os dados inciais preenchidos.
		/// </summary>
		/// <returns>CFe.</returns>
		public CFe NewCFe()
		{
			var ret = new CFe();
			ret.InfCFe.Ide.CNPJ = Configuracoes.IdeCNPJ;
			ret.InfCFe.Ide.TpAmb = Configuracoes.IdeTpAmb;
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

		public SatResposta AssociarAssinatura(string cnpj, string assinaturaCnpj)
		{
			Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");

			IniciaComando($"AssociarAssinatura({cnpj}, {assinaturaCnpj})");
			var ret = sat.AssociarAssinatura(Sessao, CodigoAtivacao, cnpj, assinaturaCnpj);
			return FinalizaComando<SatResposta>(ret);
		}

		public SatResposta AtivarSAT(int subComando, string cnpj, int uf)
		{
			Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");

			IniciaComando($"AtivarSAT({subComando}, {cnpj}, {uf})");
			var ret = sat.AtivarSAT(Sessao, subComando, CodigoAtivacao, cnpj.OnlyNumbers(), uf);
			return FinalizaComando<SatResposta>(ret);
		}

		public SatResposta AtualizarSoftwareSAT()
		{
			Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");

			IniciaComando("AtualizarSoftwareSAT()");
			var ret = sat.AtualizarSoftwareSAT(Sessao, CodigoAtivacao);
			return FinalizaComando<SatResposta>(ret);
		}

		public SatResposta BloquearSAT()
		{
			Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");

			IniciaComando("BloquearSAT()");
			var ret = sat.BloquearSAT(Sessao, CodigoAtivacao);
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

			var cfeCanc = new CFeCanc(cfe);
			return CancelarUltimaVenda(cfeCanc.InfCFe.ChCanc, cfeCanc);
		}

		/// <summary>
		/// Cancela a venda
		/// </summary>
		/// <param name="chave">A chave da CFe pra cancelar.</param>
		/// <param name="cfeCanc">Instancia da classe de cancelamento.</param>
		/// <returns>CancelamentoSatResposta.</returns>
		public CancelamentoSatResposta CancelarUltimaVenda(string chave, CFeCanc cfeCanc)
		{
			Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");
			Guard.Against<ArgumentException>(chave.IsEmpty(), "Chave não informada.");
			Guard.Against<ArgumentNullException>(cfeCanc.IsNull(), "Dados da venda não informado.");

			var dadosCancelamento = GetXml(cfeCanc);
			IniciaComando($"CancelarUltimaVenda({chave}, {dadosCancelamento})");

			if (Arquivos.SalvarEnvio)
			{
				var envioPath = Path.Combine(Arquivos.PastaEnvio, Arquivos.PrefixoArqCFe, $"{DateTime.Now:yyyyMMddHHmmss}-{Sessao.ZeroFill(6)}-env.xml");
				SalvarCFeCanc(cfeCanc, envioPath);
			}

			var e = new EventoDadosEventArgs { DadosVenda = dadosCancelamento };
			OnCancelarUltimaVenda.Raise(this, e);

			var ret = sat.CancelarUltimaVenda(Sessao, CodigoAtivacao, chave, dadosCancelamento);
			var resposta = FinalizaComando<CancelamentoSatResposta>(ret);

			if (!Arquivos.SalvarCFe)
				return resposta;

			var path = Path.Combine(Arquivos.PastaCFeVenda, resposta.Cancelamento.Emit.CNPJ, $"{resposta.Cancelamento.Ide.DEmi:yyyyMM}");
			var calcPathEventEventArgs = new CalcPathEventEventArgs
			{
				CNPJ = resposta.Cancelamento.Emit.CNPJ,
				Data = resposta.Cancelamento.Ide.DEmi,
				Path = path
			};

			OnCalcPath.Raise(this, calcPathEventEventArgs);

			if (!Directory.Exists(calcPathEventEventArgs.Path))
				Directory.CreateDirectory(calcPathEventEventArgs.Path);

			var nomeArquivo = $"{Arquivos.PrefixoArqCFe}{resposta.Cancelamento.InfCFe.Id}";
			var fullPath = Path.Combine(calcPathEventEventArgs.Path, nomeArquivo);
			SalvarCFeCanc(resposta.Cancelamento, fullPath);
			return resposta;
		}

		public SatResposta ComunicarCertificadoIcpBrasil(string certificado)
		{
			Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");

			IniciaComando($"ComunicarCertificadoICPBRASIL({certificado})");
			var ret = sat.ComunicarCertificadoIcpBrasil(Sessao, CodigoAtivacao, certificado);
			return FinalizaComando<SatResposta>(ret);
		}

		public SatResposta ConfigurarInterfaceDeRede(string dadosConfiguracao)
		{
			Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");

			IniciaComando($"ConfigurarInterfaceDeRede({dadosConfiguracao})");
			var ret = sat.ConfigurarInterfaceDeRede(Sessao, CodigoAtivacao, dadosConfiguracao);
			return FinalizaComando<SatResposta>(ret);
		}

		public SatResposta ConsultarNumeroSessao(int numeroSessao)
		{
			Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");

			IniciaComando($"ConsultarNumeroSessao({numeroSessao})");
			var ret = sat.ConsultarNumeroSessao(Sessao, CodigoAtivacao, numeroSessao);
			return FinalizaComando<SatResposta>(ret);
		}

		public SatResposta ConsultarSAT()
		{
			Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");

			IniciaComando($"ConsultarSAT()");
			var ret = sat.ConsultarSAT(Sessao);
			return FinalizaComando<SatResposta>(ret);
		}

		public SatResposta ConsultarStatusOperacional()
		{
			Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");

			IniciaComando("ConsultarStatusOperacional()");
			var ret = sat.ConsultarStatusOperacional(Sessao, CodigoAtivacao);
			return FinalizaComando<SatResposta>(ret);
		}

		public SatResposta DesbloquearSAT()
		{
			Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");

			IniciaComando($"DesbloquearSAT()");
			var ret = sat.DesbloquearSAT(Sessao, CodigoAtivacao);
			return FinalizaComando<SatResposta>(ret);
		}

		/// <summary>
		/// Envia os dados da venda para o Sat.
		/// </summary>
		/// <param name="cfe">The cfe.</param>
		/// <returns>VendaSatResposta.</returns>
		public VendaSatResposta EnviarDadosVenda(CFe cfe)
		{
			Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");

			var dadosVenda = GetXml(cfe);

			IniciaComando($"EnviarDadosVenda({dadosVenda})");

			if (Arquivos.SalvarEnvio)
			{
				var envioPath = Path.Combine(Arquivos.PastaEnvio, Arquivos.PrefixoArqCFe, $"{DateTime.Now:yyyyMMddHHmmss}-{Sessao.ZeroFill(6)}-env.xml");
				SalvarCFe(cfe, envioPath);
			}

			var e = new EventoDadosEventArgs { DadosVenda = dadosVenda };
			OnEnviarDadosVenda.Raise(this, e);

			var ret = sat.EnviarDadosVenda(Sessao, CodigoAtivacao, e.DadosVenda);
			var resposta = FinalizaComando<VendaSatResposta>(ret);

			if (Arquivos.SalvarCFe)
			{
				var path = Path.Combine(Arquivos.PastaCFeVenda, resposta.Venda.InfCFe.Emit.CNPJ, $"{resposta.Venda.InfCFe.Ide.DEmi:yyyyMM}");

				var calcPathEventEventArgs = new CalcPathEventEventArgs
				{
					CNPJ = resposta.Venda.InfCFe.Emit.CNPJ,
					Data = resposta.Venda.InfCFe.Ide.DEmi,
					Path = path
				};

				OnCalcPath.Raise(this, calcPathEventEventArgs);

				if (!Directory.Exists(calcPathEventEventArgs.Path)) Directory.CreateDirectory(calcPathEventEventArgs.Path);

				var nomeArquivo = $"{Arquivos.PrefixoArqCFe}{resposta.Venda.InfCFe.Id}";
				var fullPath = Path.Combine(calcPathEventEventArgs.Path, nomeArquivo);
				SalvarCFe(resposta.Venda, fullPath);
			}

			return resposta;
		}

		public SatResposta ExtrairLogs()
		{
			Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");

			IniciaComando($"ExtrairLogs()");
			var ret = sat.ExtrairLogs(Sessao, CodigoAtivacao);
			return FinalizaComando<LogResposta>(ret);
		}

		public SatResposta TesteFimAFim(CFe cfe)
		{
			Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");

			var dadosVenda = GetXml(cfe);
			IniciaComando($"TesteFimAFim({dadosVenda})");

			var ret = sat.TesteFimAFim(Sessao, CodigoAtivacao, dadosVenda);
			return FinalizaComando<SatResposta>(ret);
		}

		public SatResposta TrocarCodigoDeAtivacao(int opcao, string novoCodigo, string confNovoCodigo)
		{
			Guard.Against<ACBrException>(!Ativo, "Componente não está ativo.");

			IniciaComando($"TrocarCodigoDeAtivacao({opcao}, {novoCodigo}, {confNovoCodigo})");
			var ret = sat.TrocarCodigoDeAtivacao(Sessao, CodigoAtivacao, opcao, novoCodigo, confNovoCodigo);
			return FinalizaComando<SatResposta>(ret);
		}

		public string GetXml(CFe cfe)
		{
			using (var stream = new MemoryStream())
			{
				SalvarCFe(cfe, stream);

				var xml = new XmlDocument();
				xml.Load(stream);

				return xml.AsString(true, true, Encoding.UTF8);
			}
		}

		public string GetXml(CFeCanc cfeCanc)
		{
			using (var stream = new MemoryStream())
			{
				SalvarCFeCanc(cfeCanc, stream);

				var xml = new XmlDocument();
				xml.Load(stream);

				return xml.AsString(true, true, Encoding.UTF8);
			}
		}

		public int GerarNumeroSessao()
		{
			if (OnGetNumeroSessao == null)
			{
				Sessao = StaticRandom.Next(1, 999999);
			}
			else
			{
				var e = new NumeroSessaoEventArgs(Sessao);
				OnGetNumeroSessao.Raise(this, e);

				Sessao = e.Sessao;
			}

			return Sessao;
		}

		#endregion Public

		#region Private

		private void IniciaComando(string comandoLog)
		{
			GerarNumeroSessao();
			Logger.Info($"NumeroSessao: {Sessao} - Comando: {comandoLog}");
		}

		private T FinalizaComando<T>(string resposta) where T : SatResposta
		{
			Logger.Info($"NumeroSessao: {Sessao} - Resposta: {resposta}");
			var resp = (T)Activator.CreateInstance(typeof(T), resposta, Encoding);

			if (OnMensagemSefaz != null)
			{
				if (resp.CodigoSEFAZ > 0 && !resp.MensagemSEFAZ.IsEmpty())
				{
					var e = new SatMensagemEventArgs(resp.CodigoSEFAZ, resp.MensagemSEFAZ);
					OnMensagemSefaz.Raise(this, e);
				}
			}

			return resp;
		}

		private DFeSerializer<T> GetSerializer<T>() where T : class
		{
			var serializer = DFeSerializer.CreateSerializer<T>();
			serializer.Options.RemoverAcentos = Configuracoes.RemoverAcentos;
			serializer.Options.FormatarXml = Configuracoes.FormatarXml;
			return serializer;
		}

		private void SalvarCFe(CFe cfe, string path)
		{
			var serializer = GetSerializer<CFe>();
			serializer.Serialize(cfe, path);
		}

		private void SalvarCFe(CFe cfe, Stream stream)
		{
			var serializer = GetSerializer<CFe>();
			serializer.Serialize(cfe, stream);
		}

		private void SalvarCFeCanc(CFeCanc cfeCanc, string path)
		{
			var serializer = GetSerializer<CFeCanc>();
			serializer.Serialize(cfeCanc, path);
			return;
		}

		private void SalvarCFeCanc(CFeCanc cfeCanc, Stream stream)
		{
			var serializer = GetSerializer<CFeCanc>();
			serializer.Serialize(cfeCanc, stream);
			return;
		}

		#endregion Private

		#region Override

		protected override void OnInitialize()
		{
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
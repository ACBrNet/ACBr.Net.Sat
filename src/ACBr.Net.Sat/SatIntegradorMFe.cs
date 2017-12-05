// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 03-30-2016
//
// Last Modified By : marcosgerene
// Last Modified On : 07-17-2017
// ***********************************************************************
// <copyright file="SatIntegradorMFe.cs" company="ACBr.Net">
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

using System;
using System.IO;
using System.Text;
using System.Threading;
using ACBr.Net.Core;
using System.Diagnostics;
using ACBr.Net.Core.Exceptions;
using ACBr.Net.Core.Extensions;

namespace ACBr.Net.Sat
{
    internal sealed class SatIntegradorMFe : SatLibrary
    {
        #region Constructors

        public SatIntegradorMFe(SatConfig config, string pathDll, Encoding encoding) : base(config, pathDll, encoding)
        {
            ModeloStr = "SatIntegradorMFe";

            if (!Directory.Exists(Path.Combine(Config.MFePathEnvio, "Enviados")))
                Directory.CreateDirectory(Path.Combine(Config.MFePathEnvio, "Enviados"));

            if (!Directory.Exists(Path.Combine(Config.MFePathResposta, "Processados")))
                Directory.CreateDirectory(Path.Combine(Config.MFePathResposta, "Processados"));
        }

        #endregion Constructors

        #region Methods

        public override string AssociarAssinatura(int numeroSessao, string codigoDeAtivacao, string cnpjValue, string assinaturacnpj)
        {
            try
            {
                var envio = NovoEnvio("AssociarAssinatura", numeroSessao.ToString());

                var parametros = envio.Componente.Metodo.Parametros;
                parametros.AddParametro("numeroSessao", numeroSessao.ToString());
                parametros.AddParametro("codigoDeAtivacao", codigoDeAtivacao);
                parametros.AddParametro("cnpjValue", cnpjValue);
                parametros.AddParametro("assinaturaCNPJs", assinaturacnpj);

                EnviarComando(envio);

                var resposta = MFeIntegradorResp.Load(AguardarResposta(numeroSessao.ToString()));

                return resposta.Resposta.Retorno;
            }
            catch (Exception exception)
            {
                throw new ACBrException(exception, exception.Message);
            }
        }

        public override string AtivarSAT(int numeroSessao, int subComando, string codigoDeAtivacao, string cnpj, int cUF)
        {
            try
            {
                var envio = NovoEnvio("AtivarMFe", numeroSessao.ToString());

                var parametros = envio.Componente.Metodo.Parametros;
                parametros.AddParametro("numeroSessao", numeroSessao.ToString());
                parametros.AddParametro("subComando", subComando.ToString());
                parametros.AddParametro("codigoDeAtivacao", codigoDeAtivacao);
                parametros.AddParametro("CNPJ", cnpj);
                parametros.AddParametro("cUF", cUF.ToString());

                EnviarComando(envio);

                var resposta = MFeIntegradorResp.Load(AguardarResposta(numeroSessao.ToString()));

                return resposta.Resposta.Retorno;
            }
            catch (Exception exception)
            {
                throw new ACBrException(exception, exception.Message);
            }
        }

        public override string AtualizarSoftwareSAT(int numeroSessao, string codigoDeAtivacao)
        {
            try
            {
                var envio = NovoEnvio("AtualizarSoftwareMFe", numeroSessao.ToString());

                var parametros = envio.Componente.Metodo.Parametros;
                parametros.AddParametro("numeroSessao", numeroSessao.ToString());
                parametros.AddParametro("codigoDeAtivacao", codigoDeAtivacao);

                EnviarComando(envio);

                var resposta = MFeIntegradorResp.Load(AguardarResposta(numeroSessao.ToString()));

                return resposta.Resposta.Retorno;
            }
            catch (Exception exception)
            {
                throw new ACBrException(exception, exception.Message);
            }
        }

        public override string BloquearSAT(int numeroSessao, string codigoDeAtivacao)
        {
            try
            {
                var envio = NovoEnvio("BloquearMFe", numeroSessao.ToString());

                var parametros = envio.Componente.Metodo.Parametros;
                parametros.AddParametro("numeroSessao", numeroSessao.ToString());
                parametros.AddParametro("codigoDeAtivacao", codigoDeAtivacao);

                EnviarComando(envio);

                var resposta = MFeIntegradorResp.Load(AguardarResposta(numeroSessao.ToString()));

                return resposta.Resposta.Retorno;
            }
            catch (Exception exception)
            {
                throw new ACBrException(exception, exception.Message);
            }
        }

        public override string CancelarUltimaVenda(int numeroSessao, string codigoDeAtivacao, string chave, string dadosCancelamento)
        {
            try
            {
                var envio = NovoEnvio("CancelarUltimaVenda", numeroSessao.ToString());

                var parametros = envio.Componente.Metodo.Parametros;
                parametros.AddParametro("numeroSessao", numeroSessao.ToString());
                parametros.AddParametro("codigoDeAtivacao", codigoDeAtivacao);
                parametros.AddParametro("chave", chave);
                parametros.AddParametro("dadosCancelamento", $"<![CDATA[{dadosCancelamento}]]>");

                EnviarComando(envio);

                var resposta = MFeIntegradorResp.Load(AguardarResposta(numeroSessao.ToString()));

                return resposta.Resposta.Retorno;
            }
            catch (Exception exception)
            {
                throw new ACBrException(exception, exception.Message);
            }
        }

        public override string ComunicarCertificadoIcpBrasil(int numeroSessao, string codigoDeAtivacao, string certificado)
        {
            try
            {
                var envio = NovoEnvio("ComunicarCertificadoICPBRASIL", numeroSessao.ToString());

                var parametros = envio.Componente.Metodo.Parametros;
                parametros.AddParametro("numeroSessao", numeroSessao.ToString());
                parametros.AddParametro("codigoDeAtivacao", codigoDeAtivacao);
                parametros.AddParametro("certificado", certificado);

                EnviarComando(envio);

                var resposta = MFeIntegradorResp.Load(AguardarResposta(numeroSessao.ToString()));

                return resposta.Resposta.Retorno;
            }
            catch (Exception exception)
            {
                throw new ACBrException(exception, exception.Message);
            }
        }

        public override string ConfigurarInterfaceDeRede(int numeroSessao, string codigoDeAtivacao, string dadosConfiguracao)
        {
            throw new NotImplementedException();
        }

        public override string ConsultarNumeroSessao(int numeroSessao, string codigoDeAtivacao, int cNumeroDeSessao)
        {
            try
            {
                var envio = NovoEnvio("ConsultarNumeroSessao", numeroSessao.ToString());

                var parametros = envio.Componente.Metodo.Parametros;
                parametros.AddParametro("numeroSessao", numeroSessao.ToString());
                parametros.AddParametro("codigoDeAtivacao", codigoDeAtivacao);
                parametros.AddParametro("cNumeroDeSessao", cNumeroDeSessao.ToString());

                EnviarComando(envio);

                var resposta = MFeIntegradorResp.Load(AguardarResposta(numeroSessao.ToString()));

                return resposta.Resposta.Retorno;
            }
            catch (Exception exception)
            {
                throw new ACBrException(exception, exception.Message);
            }
        }

        public override string ConsultarSAT(int numeroSessao)
        {
            try
            {
                var envio = NovoEnvio("ConsultarMFe", numeroSessao.ToString());

                var parametros = envio.Componente.Metodo.Parametros;
                parametros.AddParametro("numeroSessao", numeroSessao.ToString());

                EnviarComando(envio);

                var resposta = MFeIntegradorResp.Load(AguardarResposta(numeroSessao.ToString()));

                return resposta.Resposta.Retorno;
            }
            catch (Exception exception)
            {
                throw new ACBrException(exception, exception.Message);
            }
        }

        public override string ConsultarStatusOperacional(int numeroSessao, string codigoDeAtivacao)
        {
            try
            {
                var envio = NovoEnvio("ConsultarStatusOperacional", numeroSessao.ToString());

                var parametros = envio.Componente.Metodo.Parametros;
                parametros.AddParametro("numeroSessao", numeroSessao.ToString());
                parametros.AddParametro("codigoDeAtivacao", codigoDeAtivacao);

                EnviarComando(envio);

                var resposta = MFeIntegradorResp.Load(AguardarResposta(numeroSessao.ToString()));

                return resposta.Resposta.Retorno;
            }
            catch (Exception exception)
            {
                throw new ACBrException(exception, exception.Message);
            }
        }

        public override string DesbloquearSAT(int numeroSessao, string codigoDeAtivacao)
        {
            try
            {
                var envio = NovoEnvio("DesbloquearMFe", numeroSessao.ToString());

                var parametros = envio.Componente.Metodo.Parametros;
                parametros.AddParametro("numeroSessao", numeroSessao.ToString());
                parametros.AddParametro("codigoDeAtivacao", codigoDeAtivacao);

                EnviarComando(envio);

                var resposta = MFeIntegradorResp.Load(AguardarResposta(numeroSessao.ToString()));

                return resposta.Resposta.Retorno;
            }
            catch (Exception exception)
            {
                throw new ACBrException(exception, exception.Message);
            }
        }

        public override string EnviarDadosVenda(int numeroSessao, string codigoDeAtivacao, string dadosVenda)
        {
            try
            {
                var envio = NovoEnvio("EnviarDadosVenda", numeroSessao.ToString());

                var parametros = envio.Componente.Metodo.Parametros;
                parametros.AddParametro("numeroSessao", numeroSessao.ToString());
                parametros.AddParametro("codigoDeAtivacao", codigoDeAtivacao);
                parametros.AddParametro("dadosVenda", $"<![CDATA[{dadosVenda}]]>");
                parametros.AddParametro("nrDocumento", numeroSessao.ToString());

                EnviarComando(envio);

                var resposta = MFeIntegradorResp.Load(AguardarResposta(numeroSessao.ToString()));

                return resposta.Resposta.Retorno;
            }
            catch (Exception exception)
            {
                throw new ACBrException(exception, exception.Message);
            }
        }

        public override string ExtrairLogs(int numeroSessao, string codigoDeAtivacao)
        {
            try
            {
                var envio = NovoEnvio("ExtrairLogs", numeroSessao.ToString());

                var parametros = envio.Componente.Metodo.Parametros;
                parametros.AddParametro("numeroSessao", numeroSessao.ToString());
                parametros.AddParametro("codigoDeAtivacao", codigoDeAtivacao);

                EnviarComando(envio);

                var resposta = MFeIntegradorResp.Load(AguardarResposta(numeroSessao.ToString()));

                return resposta.Resposta.Retorno;
            }
            catch (Exception exception)
            {
                throw new ACBrException(exception, exception.Message);
            }
        }

        public override string TesteFimAFim(int numeroSessao, string codigoDeAtivacao, string dadosVenda)
        {
            try
            {
                var envio = NovoEnvio("TesteFimAFim", numeroSessao.ToString());

                var parametros = envio.Componente.Metodo.Parametros;
                parametros.AddParametro("numeroSessao", numeroSessao.ToString());
                parametros.AddParametro("codigoDeAtivacao", codigoDeAtivacao);
                parametros.AddParametro("dadosVenda", $"<![CDATA[{dadosVenda}]]>");

                EnviarComando(envio);

                var resposta = MFeIntegradorResp.Load(AguardarResposta(numeroSessao.ToString()));

                return resposta.Resposta.Retorno;
            }
            catch (Exception exception)
            {
                throw new ACBrException(exception, exception.Message);
            }
        }

        public override string TrocarCodigoDeAtivacao(int numeroSessao, string codigoDeAtivacao, int opcao, string novoCodigo, string confNovoCodigo)
        {
            try
            {
                var envio = NovoEnvio("TrocarCodigoDeAtivacao", numeroSessao.ToString());

                var parametros = envio.Componente.Metodo.Parametros;
                parametros.AddParametro("numeroSessao", numeroSessao.ToString());
                parametros.AddParametro("codigoDeAtivacao", codigoDeAtivacao);
                parametros.AddParametro("opcao", opcao.ToString());
                parametros.AddParametro("novoCodigo", novoCodigo);
                parametros.AddParametro("confNovoCodigo", confNovoCodigo);

                EnviarComando(envio);

                var resposta = MFeIntegradorResp.Load(AguardarResposta(numeroSessao.ToString()));

                return resposta.Resposta.Retorno;
            }
            catch (Exception exception)
            {
                throw new ACBrException(exception, exception.Message);
            }
        }

        public override RetSatIntegradorMFe EnviarPagamento(int numeroSessao, string chaveAcessoValidador, string chaveRequisicao, string estabelecimento, string serialPOS, string cnpj,
            decimal icmsBase, decimal valorTotalVenda, string origemPagamento, bool habilitarMultiplosPagamentos = true, bool habilitarControleAntiFraude = false,
            string codigoMoeda = "BRL", bool emitirCupomNFCE = false)
        {
            try
            {
                var envio = NovoEnvio("EnviarPagamento", numeroSessao.ToString());

                envio.Componente.Nome = "VFP-e";
                envio.Componente.Metodo.Construtor = new MFeConstrutor();
                envio.Componente.Metodo.Construtor.Parametros.AddParametro("chaveAcessoValidador", chaveAcessoValidador);

                var parametros = envio.Componente.Metodo.Parametros;
                parametros.AddParametro("ChaveRequisicao", chaveRequisicao);
                parametros.AddParametro("Estabelecimento", estabelecimento);
                parametros.AddParametro("SerialPOS", serialPOS);
                parametros.AddParametro("Cnpj", cnpj);
                parametros.AddParametro("IcmsBase", string.Format("{0:0.00}", icmsBase).Replace('.', ','));
                parametros.AddParametro("ValorTotalVenda", string.Format("{0:0.00}", valorTotalVenda).Replace('.', ','));
                parametros.AddParametro("HabilitarMultiplosPagamentos", habilitarMultiplosPagamentos ? "true" : "false");
                parametros.AddParametro("HabilitarControleAntiFraude", habilitarControleAntiFraude ? "true" : "false");
                parametros.AddParametro("CodigoMoeda", codigoMoeda);
                parametros.AddParametro("OrigemPagamento", origemPagamento);
                parametros.AddParametro("EmitirCupomNFCE", emitirCupomNFCE ? "true" : "false");

                EnviarComando(envio);

                var xmlEnvio = envio.GetXml();
                var xmlRetorno = AguardarResposta(numeroSessao.ToString());

                return new RetSatIntegradorMFe
                {
                    XmlEnvio = xmlEnvio,
                    XmlRetorno = xmlRetorno
                };
            }
            catch (Exception exception)
            {
                throw new ACBrException(exception, exception.Message);
            }
        }

        public override RetSatIntegradorMFe VerificarStatusValidador(int numeroSessao, string chaveAcessoValidador, int idFila, string cnpj)
        {
            try
            {
                var envio = NovoEnvio("VerificarStatusValidador", numeroSessao.ToString());

                envio.Componente.Nome = "VFP-e";
                envio.Componente.Metodo.Construtor = new MFeConstrutor();
                envio.Componente.Metodo.Construtor.Parametros.AddParametro("chaveAcessoValidador", chaveAcessoValidador);

                var parametros = envio.Componente.Metodo.Parametros;
                parametros.AddParametro("idFila", idFila.ToString());
                parametros.AddParametro("cnpj", cnpj);

                EnviarComando(envio);

                var xmlEnvio = envio.GetXml();
                var xmlRetorno = AguardarResposta(numeroSessao.ToString());

                return new RetSatIntegradorMFe
                {
                    XmlEnvio = xmlEnvio,
                    XmlRetorno = xmlRetorno
                };
            }
            catch (Exception exception)
            {
                throw new ACBrException(exception, exception.Message);
            }
        }

        public override RetSatIntegradorMFe EnviarStatusPagamento(int numeroSessao, string chaveAcessoValidador, string codigoAutorizacao, string bin, string donoCartao,
            string dataExpiracao, string instituicaoFinanceira, int parcelas, string codigoPagamento, decimal valorPagamento, int idFila, string tipo, int ultimosQuatroDigitos)
        {
            try
            {
                var envio = NovoEnvio("EnviarStatusPagamento", numeroSessao.ToString());

                envio.Componente.Nome = "VFP-e";
                envio.Componente.Metodo.Construtor = new MFeConstrutor();
                envio.Componente.Metodo.Construtor.Parametros.AddParametro("chaveAcessoValidador", chaveAcessoValidador);

                var parametros = envio.Componente.Metodo.Parametros;
                parametros.AddParametro("CodigoAutorizacao", codigoAutorizacao);
                parametros.AddParametro("Bin", bin);
                parametros.AddParametro("DonoCartao", donoCartao);
                parametros.AddParametro("DataExpiracao", dataExpiracao);
                parametros.AddParametro("InstituicaoFinanceira", instituicaoFinanceira);
                parametros.AddParametro("Parcelas", parcelas.ToString());
                parametros.AddParametro("CodigoPagamento", codigoPagamento);
                parametros.AddParametro("ValorPagamento", string.Format("{0:0.00}", valorPagamento).Replace('.', ','));
                parametros.AddParametro("IdFila", idFila.ToString());
                parametros.AddParametro("Tipo", tipo);
                parametros.AddParametro("UltimosQuatroDigitos", ultimosQuatroDigitos.ToString());

                EnviarComando(envio);

                var xmlEnvio = envio.GetXml();
                var xmlRetorno = AguardarResposta(numeroSessao.ToString());

                return new RetSatIntegradorMFe
                {
                    XmlEnvio = xmlEnvio,
                    XmlRetorno = xmlRetorno
                };
            }
            catch (Exception exception)
            {
                throw new ACBrException(exception, exception.Message);
            }
        }

        public override RetSatIntegradorMFe RespostaFiscal(int numeroSessao, string chaveAcessoValidador, int idFila, string chaveAcesso, string nsu,
            string numeroAprovacao, string bandeira, string adquirinte, string cnpj, string impressaofiscal, string numeroDocumento)
        {
            try
            {
                var envio = NovoEnvio("RespostaFiscal", numeroSessao.ToString());

                envio.Componente.Nome = "VFP-e";
                envio.Componente.Metodo.Construtor = new MFeConstrutor();
                envio.Componente.Metodo.Construtor.Parametros.AddParametro("chaveAcessoValidador", chaveAcessoValidador);

                var parametros = envio.Componente.Metodo.Parametros;
                parametros.AddParametro("idFila", idFila.ToString());
                parametros.AddParametro("ChaveAcesso", chaveAcesso);
                parametros.AddParametro("Nsu", nsu);
                parametros.AddParametro("NumerodeAprovacao", numeroAprovacao);
                parametros.AddParametro("Bandeira", bandeira);
                parametros.AddParametro("Adquirente", adquirinte);
                parametros.AddParametro("Cnpj", cnpj);
                parametros.AddParametro("ImpressaoFiscal", impressaofiscal);
                parametros.AddParametro("NumeroDocumento", numeroDocumento);

                EnviarComando(envio);

                var xmlEnvio = envio.GetXml();
                var xmlRetorno = AguardarResposta(numeroSessao.ToString());

                return new RetSatIntegradorMFe
                {
                    XmlEnvio = xmlEnvio,
                    XmlRetorno = xmlRetorno
                };
            }
            catch (Exception exception)
            {
                throw new ACBrException(exception, exception.Message);
            }
        }

        private MFeIntegradorEnvio NovoEnvio(string metodo, string identificacao)
        {
            var envio = new MFeIntegradorEnvio
            {
                Identificador = { Valor = identificacao },
                Componente =
                {
                    Nome = "MF-e",
                    Metodo = {Nome = metodo}
                }
            };

            return envio;
        }

        private void EnviarComando(MFeIntegradorEnvio envio)
        {
            envio.Save(Path.Combine(Config.MFePathEnvio, "Enviados", $"{envio.Componente.Metodo.Nome}_{envio.Identificador.Valor}.xml"));

            string file = Path.Combine(Config.MFePathEnvio, $"{envio.Componente.Metodo.Nome}_{envio.Identificador.Valor}.tmp");
            envio.Save(file);

            File.Move(file, $"{file.Substring(0, file.Length - 4)}.xml");
        }

        private string AguardarResposta(string identificacao)
        {
            var resposta = string.Empty;

            var timeLimit = DateTime.Now.AddMilliseconds(Config.MFeTimeOut);
            var identificacaoXML = $"<Valor>{identificacao}</Valor>";

            do
            {
                Guard.Against<TimeoutException>(Config.MFeTimeOut > 0 && resposta.IsEmpty() && DateTime.Now >= timeLimit);

                var files = Directory.GetFiles(Config.MFePathResposta, "*.xml");
                if (files.Length < 1) continue;

                foreach (var file in files)
                {
                    try
                    {
                        var resp = File.ReadAllText(file);
                        if (!resp.Contains(identificacaoXML)) continue;

                        resposta = resp;
                        File.Move(file, Path.Combine(Config.MFePathResposta, "Processados", $"{new FileInfo(file).Name}.xml"));
                        break;
                    }
                    catch (Exception)
                    {
                        //
                    }
                }

                Thread.Sleep(500);
            } while (resposta.IsEmpty());

            return resposta;
        }

        #endregion Methods
    }
}
// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 03-30-2016
//
// Last Modified By : RFTD
// Last Modified On : 02-20-2018
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

using System.Text;

namespace ACBr.Net.Sat
{
    internal sealed class SatIntegradorMFe : ISatLibrary
    {
        #region Fields

        private const string MFe = "MF-e";

        #endregion Fields

        #region Constructors

        public SatIntegradorMFe(SatConfig config, string pathDll, Encoding encoding)
        {
            ModeloStr = "SatIntegradorMFe";
            PathDll = pathDll;
            Encoding = encoding;
            Config = config;
        }

        #endregion Constructors

        #region Propriedades

        public Encoding Encoding { get; private set; }

        public string PathDll { get; private set; }

        public string ModeloStr { get; }

        public SatConfig Config { get; private set; }

        #endregion Propriedades

        #region Methods

        public string AssociarAssinatura(int numeroSessao, string codigoDeAtivacao, string cnpjValue, string assinaturacnpj)
        {
            var integrador = Config.Parent.IntegradorFiscal;
            integrador.NomeComponente = MFe;
            integrador.NomeMetodo = "AssociarAssinatura";

            var parametros = integrador.Parametros;
            parametros.AddParametro("numeroSessao", numeroSessao.ToString());
            parametros.AddParametro("codigoDeAtivacao", codigoDeAtivacao);
            parametros.AddParametro("cnpjValue", cnpjValue);
            parametros.AddParametro("assinaturaCNPJs", assinaturacnpj);

            var resposta = integrador.Enviar(false);
            return resposta.Resposta.Retorno;
        }

        public string AtivarSAT(int numeroSessao, int subComando, string codigoDeAtivacao, string cnpj, int cUF)
        {
            var integrador = Config.Parent.IntegradorFiscal;
            integrador.NomeComponente = MFe;
            integrador.NomeMetodo = "AtivarMFe";

            var parametros = integrador.Parametros;
            parametros.AddParametro("numeroSessao", numeroSessao.ToString());
            parametros.AddParametro("subComando", subComando.ToString());
            parametros.AddParametro("codigoDeAtivacao", codigoDeAtivacao);
            parametros.AddParametro("CNPJ", cnpj);
            parametros.AddParametro("cUF", cUF.ToString());

            var resposta = integrador.Enviar(false);
            return resposta.Resposta.Retorno;
        }

        public string AtualizarSoftwareSAT(int numeroSessao, string codigoDeAtivacao)
        {
            var integrador = Config.Parent.IntegradorFiscal;
            integrador.NomeComponente = MFe;
            integrador.NomeMetodo = "AtualizarSoftwareMFe";

            var parametros = integrador.Parametros;
            parametros.AddParametro("numeroSessao", numeroSessao.ToString());
            parametros.AddParametro("codigoDeAtivacao", codigoDeAtivacao);

            var resposta = integrador.Enviar(false);
            return resposta.Resposta.Retorno;
        }

        public string BloquearSAT(int numeroSessao, string codigoDeAtivacao)
        {
            var integrador = Config.Parent.IntegradorFiscal;
            integrador.NomeComponente = MFe;
            integrador.NomeMetodo = "BloquearMFe";

            var parametros = integrador.Parametros;
            parametros.AddParametro("numeroSessao", numeroSessao.ToString());
            parametros.AddParametro("codigoDeAtivacao", codigoDeAtivacao);

            var resposta = integrador.Enviar(false);
            return resposta.Resposta.Retorno;
        }

        public string CancelarUltimaVenda(int numeroSessao, string codigoDeAtivacao, string chave, string dadosCancelamento)
        {
            var integrador = Config.Parent.IntegradorFiscal;
            integrador.NomeComponente = MFe;
            integrador.NomeMetodo = "CancelarUltimaVenda";

            var parametros = integrador.Parametros;
            parametros.AddParametro("numeroSessao", numeroSessao.ToString());
            parametros.AddParametro("codigoDeAtivacao", codigoDeAtivacao);
            parametros.AddParametro("chave", chave);
            parametros.AddParametro("dadosCancelamento", $"<![CDATA[{dadosCancelamento}]]>");

            var resposta = integrador.Enviar(false);
            return resposta.Resposta.Retorno;
        }

        public string ComunicarCertificadoIcpBrasil(int numeroSessao, string codigoDeAtivacao, string certificado)
        {
            var integrador = Config.Parent.IntegradorFiscal;
            integrador.NomeComponente = MFe;
            integrador.NomeMetodo = "ComunicarCertificadoICPBRASIL";

            var parametros = integrador.Parametros;
            parametros.AddParametro("numeroSessao", numeroSessao.ToString());
            parametros.AddParametro("codigoDeAtivacao", codigoDeAtivacao);
            parametros.AddParametro("certificado", certificado);

            var resposta = integrador.Enviar(false);
            return resposta.Resposta.Retorno;
        }

        public string ConfigurarInterfaceDeRede(int numeroSessao, string codigoDeAtivacao, string dadosConfiguracao)
        {
            var integrador = Config.Parent.IntegradorFiscal;
            integrador.NomeComponente = MFe;
            integrador.NomeMetodo = "ConfigurarInterfaceDeRede";

            var parametros = integrador.Parametros;
            parametros.AddParametro("numeroSessao", numeroSessao.ToString());
            parametros.AddParametro("codigoDeAtivacao", codigoDeAtivacao);
            parametros.AddParametro("dadosConfiguracao", dadosConfiguracao);

            var resposta = integrador.Enviar(false);
            return resposta.Resposta.Retorno;
        }

        public string ConsultarNumeroSessao(int numeroSessao, string codigoDeAtivacao, int cNumeroDeSessao)
        {
            var integrador = Config.Parent.IntegradorFiscal;
            integrador.NomeComponente = MFe;
            integrador.NomeMetodo = "ConsultarNumeroSessao";

            var parametros = integrador.Parametros;
            parametros.AddParametro("numeroSessao", numeroSessao.ToString());
            parametros.AddParametro("codigoDeAtivacao", codigoDeAtivacao);
            parametros.AddParametro("cNumeroDeSessao", cNumeroDeSessao.ToString());

            var resposta = integrador.Enviar(false);
            return resposta.Resposta.Retorno;
        }

        public string ConsultarUltimaSessaoFiscal(int numeroSessao, string codigoDeAtivacao)
        {
            throw new System.NotImplementedException();
        }

        public string ConsultarSAT(int numeroSessao)
        {
            var integrador = Config.Parent.IntegradorFiscal;
            integrador.NomeComponente = MFe;
            integrador.NomeMetodo = "ConsultarMFe";

            var parametros = integrador.Parametros;
            parametros.AddParametro("numeroSessao", numeroSessao.ToString());

            var resposta = integrador.Enviar(false);
            return resposta.Resposta.Retorno;
        }

        public string ConsultarStatusOperacional(int numeroSessao, string codigoDeAtivacao)
        {
            var integrador = Config.Parent.IntegradorFiscal;
            integrador.NomeComponente = MFe;
            integrador.NomeMetodo = "ConsultarStatusOperacional";

            var parametros = integrador.Parametros;
            parametros.AddParametro("numeroSessao", numeroSessao.ToString());
            parametros.AddParametro("codigoDeAtivacao", codigoDeAtivacao);

            var resposta = integrador.Enviar(false);
            return resposta.Resposta.Retorno;
        }

        public string DesbloquearSAT(int numeroSessao, string codigoDeAtivacao)
        {
            var integrador = Config.Parent.IntegradorFiscal;
            integrador.NomeComponente = MFe;
            integrador.NomeMetodo = "DesbloquearMFe";

            var parametros = integrador.Parametros;
            parametros.AddParametro("numeroSessao", numeroSessao.ToString());
            parametros.AddParametro("codigoDeAtivacao", codigoDeAtivacao);

            var resposta = integrador.Enviar(false);
            return resposta.Resposta.Retorno;
        }

        public string EnviarDadosVenda(int numeroSessao, string codigoDeAtivacao, string dadosVenda)
        {
            var integrador = Config.Parent.IntegradorFiscal;
            integrador.NomeComponente = MFe;
            integrador.NomeMetodo = "EnviarDadosVenda";

            var parametros = integrador.Parametros;
            parametros.AddParametro("numeroSessao", numeroSessao.ToString());
            parametros.AddParametro("codigoDeAtivacao", codigoDeAtivacao);
            parametros.AddParametro("dadosVenda", $"<![CDATA[{dadosVenda}]]>");
            parametros.AddParametro("nrDocumento", numeroSessao.ToString());

            var resposta = integrador.Enviar(false);
            return resposta.Resposta.Retorno;
        }

        public string ExtrairLogs(int numeroSessao, string codigoDeAtivacao)
        {
            var integrador = Config.Parent.IntegradorFiscal;
            integrador.NomeComponente = MFe;
            integrador.NomeMetodo = "ExtrairLogs";

            var parametros = integrador.Parametros;
            parametros.AddParametro("numeroSessao", numeroSessao.ToString());
            parametros.AddParametro("codigoDeAtivacao", codigoDeAtivacao);

            var resposta = integrador.Enviar(false);
            return resposta.Resposta.Retorno;
        }

        public string TesteFimAFim(int numeroSessao, string codigoDeAtivacao, string dadosVenda)
        {
            var integrador = Config.Parent.IntegradorFiscal;
            integrador.NomeComponente = MFe;
            integrador.NomeMetodo = "TesteFimAFim";

            var parametros = integrador.Parametros;
            parametros.AddParametro("numeroSessao", numeroSessao.ToString());
            parametros.AddParametro("codigoDeAtivacao", codigoDeAtivacao);
            parametros.AddParametro("dadosVenda", $"<![CDATA[{dadosVenda}]]>");

            var resposta = integrador.Enviar(false);
            return resposta.Resposta.Retorno;
        }

        public string TrocarCodigoDeAtivacao(int numeroSessao, string codigoDeAtivacao, int opcao, string novoCodigo, string confNovoCodigo)
        {
            var integrador = Config.Parent.IntegradorFiscal;
            integrador.NomeComponente = MFe;
            integrador.NomeMetodo = "TrocarCodigoDeAtivacao";

            var parametros = integrador.Parametros;
            parametros.AddParametro("numeroSessao", numeroSessao.ToString());
            parametros.AddParametro("codigoDeAtivacao", codigoDeAtivacao);
            parametros.AddParametro("opcao", opcao.ToString());
            parametros.AddParametro("novoCodigo", novoCodigo);
            parametros.AddParametro("confNovoCodigo", confNovoCodigo);

            var resposta = integrador.Enviar(false);
            return resposta.Resposta.Retorno;
        }

        public void Dispose()
        {
        }

        #endregion Methods
    }
}
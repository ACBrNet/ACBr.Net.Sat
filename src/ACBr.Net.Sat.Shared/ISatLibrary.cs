// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 11-24-2016
//
// Last Modified By : RFTD
// Last Modified On : 11-24-2016
// ***********************************************************************
// <copyright file="ISatLibrary.cs" company="ACBr.Net">
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
using System.Text;

namespace ACBr.Net.Sat
{
    public interface ISatLibrary : IDisposable
    {
        #region Properties

        SatConfig Config { get; }

        Encoding Encoding { get; }

        string ModeloStr { get; }

        string PathDll { get; }

        #endregion Properties

        #region Methods

        string AssociarAssinatura(int numeroSessao, string codigoAtivacao, string cnpjValue, string assinaturacnpj);

        string AtivarSAT(int numeroSessao, int subComando, string codigoDeAtivacao, string cnpj, int cUF);

        string AtualizarSoftwareSAT(int numeroSessao, string codigoDeAtivacao);

        string BloquearSAT(int numeroSessao, string codigoDeAtivacao);

        string CancelarUltimaVenda(int numeroSessao, string codigoDeAtivacao, string chave, string dadosCancelamento);

        string ComunicarCertificadoIcpBrasil(int numeroSessao, string codigoDeAtivacao, string certificado);

        string ConfigurarInterfaceDeRede(int numeroSessao, string codigoDeAtivacao, string dadosConfiguracao);

        string ConsultarNumeroSessao(int numeroSessao, string codigoDeAtivacao, int cNumeroDeSessao);

        string ConsultarUltimaSessaoFiscal(int numeroSessao, string codigoDeAtivacao);

        string ConsultarSAT(int numeroSessao);

        string ConsultarStatusOperacional(int numeroSessao, string codigoDeAtivacao);

        string DesbloquearSAT(int numeroSessao, string codigoDeAtivacao);

        string EnviarDadosVenda(int numeroSessao, string codigoDeAtivacao, string dadosVenda);

        string ExtrairLogs(int numeroSessao, string codigoDeAtivacao);

        string TesteFimAFim(int numeroSessao, string codigoDeAtivacao, string dadosVenda);

        string TrocarCodigoDeAtivacao(int numeroSessao, string codigoDeAtivacao, int opcao, string novoCodigo, string confNovoCodigo);

        #endregion Methods
    }
}
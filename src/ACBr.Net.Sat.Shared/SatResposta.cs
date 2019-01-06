// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 03-31-2016
//
// Last Modified By : RFTD
// Last Modified On : 03-31-2016
// ***********************************************************************
// <copyright file="SatResposta.cs" company="ACBr.Net">
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
// <summary>
// Classe feita para tratar o retorno do SAT
// </summary>
// ***********************************************************************

using ACBr.Net.Core.Extensions;
using System.Collections.Generic;

namespace ACBr.Net.Sat
{
    public class SatResposta
    {
        #region Constructors

        public SatResposta(string resposta)
        {
            /*
			***** RETORNOS DO SAT POR COMANDO *****
			AtivarSAT....................: numeroSessao, EEEEE, mensagem, cod, mensagemSEFAZ, CSR
			ComunicarCertificadoICPBRASIL: numeroSessao, EEEEE, mensagem, cod, mensagemSEFAZ
			EnviarDadosVenda.............: numeroSessao, EEEEE, CCCC, mensagem, cod, mensagemSEFAZ, base64, timeStamp, chaveConsulta, valorTotalCFe, CPFCNPJValue, assinaturaQRCOD
			CancelarUltimaVenda..........: numeroSessao, EEEEE, CCCC, mensagem, cod, mensagemSEFAZ, base64, timeStamp, chaveConsulta, valorTotalCFe, CPFCNPJValue, assinaturaQRCOD
			ConsultarSAT.................: numeroSessao, EEEEE, mensagem, cod, mensagemSEFAZ
			TesteFimAFim.................: numeroSessao, EEEEE, mensagem, cod, mensagemSEFAZ, base64, timeStamp, numDocFiscal, chaveConsulta
			ConsultarStatusOperacional...: numeroSessao, EEEEE, mensagem, cod, mensagemSEFAZ, ConteudoRetorno
			ConsultarNumeroSessao........: numeroSessao, EEEEE, mensagem, cod, mensagemSEFAZ   (ou retorno da Sessão consultada)
            ConsultarUltimaSessaoFiscal..: numeroSessao, EEEEE, mensagem, cod, mensagemSEFAZ   (ou retorno da ultima Sessão fiscal)
			ConfigurarInterfaceDeRede....: numeroSessao, EEEEE, mensagem, cod, mensagemSEFAZ
			AssociarAssinatura...........: numeroSessao, EEEEE, mensagem, cod, mensagemSEFAZ
			AtualizarSoftwareSAT.........: numeroSessao, EEEEE, mensagem, cod, mensagemSEFAZ
			ExtrairLogs..................: numeroSessao, EEEEE, mensagem, cod, mensagemSEFAZ, base64
			BloquearSAT..................: numeroSessao, EEEEE, mensagem, cod, mensagemSEFAZ
			DesbloquearSAT...............: numeroSessao, EEEEE, mensagem, cod, mensagemSEFAZ
			TrocarCodigoDeAtivacao.......: numeroSessao, EEEEE, mensagem, cod, mensagemSEFAZ
			*/

            RetornoStr = resposta;
            RetornoLst = new List<string>();
            RetornoLst.AddRange(resposta.Split('|'));

            if (RetornoLst.Count > 1)
            {
                NumeroSessao = RetornoLst[0].ToInt32();
                CodigoDeRetorno = RetornoLst[1].ToInt32();
            }

            var idx = 2;
            if (RetornoLst.Count <= idx) return;

            //Enviar e Cancelar venda tem um campo a mais no inicio da resposta(CCCC)
            var value = RetornoLst[idx].Trim();
            if (value.Length == 4 && value.IsNumeric())
            {
                CodigoDeErro = RetornoLst[idx].ToInt32();
                idx = 3;
            }

            if (RetornoLst.Count > idx + 2)
            {
                MensagemRetorno = RetornoLst[idx];
                CodigoSEFAZ = RetornoLst[idx + 1].ToInt32();
                MensagemSEFAZ = RetornoLst[idx + 2];
            }
            else
            {
                MensagemRetorno = resposta;
            }
        }

        #endregion Constructors

        #region Propriedades

        public int NumeroSessao { get; }

        public int CodigoDeRetorno { get; }

        public int CodigoDeErro { get; }

        public string MensagemRetorno { get; }

        public int CodigoSEFAZ { get; }

        public string MensagemSEFAZ { get; }

        public List<string> RetornoLst { get; }

        public string RetornoStr { get; }

        #endregion Propriedades
    }
}
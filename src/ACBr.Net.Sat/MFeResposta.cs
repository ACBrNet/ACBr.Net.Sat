// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 05-30-2017
//
// Last Modified By : marcosgerene
// Last Modified On : 05-31-2017
// ***********************************************************************
// <copyright file="MFeIntegradorResposta.cs" company="ACBr.Net">
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

using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Serializer;

namespace ACBr.Net.Sat
{
    [DFeRoot("Resposta")]
    public sealed class MFeResposta
    {
        [DFeAttribute(TipoCampo.Str, "retorno", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public string Retorno { get; set; }

        [DFeAttribute(TipoCampo.Int, "IdPagamento", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public int? IdPagamento { get; set; }

        [DFeAttribute(TipoCampo.Str, "Mensagem", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public string Mensagem { get; set; }

        [DFeAttribute(TipoCampo.Str, "StatusPagamento", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public string StatusPagamento { get; set; }

        [DFeAttribute(TipoCampo.Str, "CodigoAutorizacao", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public string CodigoAutorizacao { get; set; }

        [DFeAttribute(TipoCampo.Str, "Bin", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public string Bin { get; set; }

        [DFeAttribute(TipoCampo.Str, "DonoCartao", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public string DonoCartao { get; set; }

        [DFeAttribute(TipoCampo.Str, "DataExpiracao", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public string DataExpiracao { get; set; }

        [DFeAttribute(TipoCampo.Str, "InstituicaoFinanceira", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public string InstituicaoFinanceira { get; set; }

        [DFeAttribute(TipoCampo.Str, "Parcelas", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public string Parcelas { get; set; }

        [DFeAttribute(TipoCampo.Str, "UltimosQuatroDigitos", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public string UltimosQuatroDigitos { get; set; }

        [DFeAttribute(TipoCampo.Str, "CodigoPagamento", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public string CodigoPagamento { get; set; }

        [DFeAttribute(TipoCampo.De2, "ValorPagamento", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public decimal? ValorPagamento { get; set; }

        [DFeAttribute(TipoCampo.Str, "IdFila", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public string IdFila { get; set; }

        [DFeAttribute(TipoCampo.Str, "Tipo", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public string Tipo { get; set; }

        [DFeAttribute(TipoCampo.Str, "chaveAcessoValidador", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public string ChaveAcessoValidador { get; set; }

        [DFeAttribute(TipoCampo.Str, "chaveRequisicao", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public string ChaveRequisicao { get; set; }

        [DFeAttribute(TipoCampo.Str, "Estabelecimento", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public string Estabelecimento { get; set; }

        [DFeAttribute(TipoCampo.Str, "CNPJ", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public string Cnpj { get; set; }

        [DFeAttribute(TipoCampo.Str, "SerialPOS", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public string SerialPOS { get; set; }

        [DFeAttribute(TipoCampo.De2, "IcmsBase", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public decimal? IcmsBase { get; set; }

        [DFeAttribute(TipoCampo.De2, "ValorTotalVenda", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public decimal? ValorTotalVenda { get; set; }
    }
}

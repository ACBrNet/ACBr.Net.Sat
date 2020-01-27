// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 03-31-2016
//
// Last Modified By : RFTD
// Last Modified On : 03-31-2016
// ***********************************************************************
// <copyright file="SATConfig.cs" company="ACBr.Net">
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

using System.ComponentModel;
using ACBr.Net.Core;
using ACBr.Net.DFe.Core.Common;

namespace ACBr.Net.Sat
{
    /// <summary>
    /// Class SATConfig. This class cannot be inherited.
    /// </summary>
    [TypeConverter(typeof(ACBrExpandableObjectConverter))]
    public sealed class SatConfig
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SatConfig"/> class.
        /// </summary>
        internal SatConfig(ACBrSat parent)
        {
            Parent = parent;
            InfCFeVersaoDadosEnt = 0.07M;
            IdeCNPJ = @"11111111111111";
            IdeNumeroCaixa = 1;
            IdeTpAmb = DFeTipoAmbiente.Homologacao;
            EmitCNPJ = @"11111111111111";
            EmitIE = string.Empty;
            EmitIM = string.Empty;
            EmitCRegTrib = RegTrib.Normal;
            EmitCRegTribISSQN = RegTribIssqn.Nenhum;
            EmitIndRatISSQN = RatIssqn.Nao;
            IsUtf8 = false;
            ValidarNumeroSessaoResposta = false;
            NumeroTentativasValidarSessao = 1;
        }

        #endregion Constructor

        #region Propriedades

        internal ACBrSat Parent { get; }

        public decimal InfCFeVersaoDadosEnt { get; set; }

        public string IdeCNPJ { get; set; }

        public int IdeNumeroCaixa { get; set; }

        public DFeTipoAmbiente IdeTpAmb { get; set; }

        public string EmitCNPJ { get; set; }

        public string EmitIE { get; set; }

        public string EmitIM { get; set; }

        public RegTrib EmitCRegTrib { get; set; }

        public RegTribIssqn EmitCRegTribISSQN { get; set; }

        public RatIssqn EmitIndRatISSQN { get; set; }

        public bool IsUtf8 { get; set; }

        public bool ValidarNumeroSessaoResposta { get; set; }

        public int NumeroTentativasValidarSessao { get; set; }

        public bool RemoverAcentos { get; set; }

        #endregion Propriedades
    }
}
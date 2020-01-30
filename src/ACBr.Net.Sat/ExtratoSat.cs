// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 03-31-2016
//
// Last Modified By : RFTD
// Last Modified On : 02-16-2017
// ***********************************************************************
// <copyright file="ExtratoSat.cs" company="ACBr.Net">
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

using ACBr.Net.Core.Extensions;
using System;
using System.Globalization;
using ACBr.Net.DFe.Core.Common;

#if NETFULL

using System.Drawing;

#endif

namespace ACBr.Net.Sat
{
    public abstract class ExtratoSat : DFeReportClass<ACBrSat>
    {
        #region Propriedades

        public ExtratoLayOut LayOut { get; set; }

#if NETFULL
        public Image Logo { get; set; }

#else
        public byte[] Logo { get; set; }
#endif

        #endregion Propriedades

        #region Methods

        public string CalcularConteudoQRCode(string id, DateTime dhEmissao, decimal valor, string cpfcnpj, string assinaturaQrcode)
        {
            return $"{id}|{dhEmissao:yyyyMMddHHmmss}|{valor.ToString(CultureInfo.InvariantCulture)}" +
                   $"|{cpfcnpj.OnlyNumbers()}|{assinaturaQrcode}";
        }

        public abstract void ImprimirExtrato(CFe cfe);

        public abstract void ImprimirExtratoResumido(CFe cfe);

        public abstract void ImprimirExtratoCancelamento(CFeCanc cFeCanc, DFeTipoAmbiente ambiente);

        /// <inheritdoc />
        protected override void ParentChanged(ACBrSat oldParent, ACBrSat newParent)
        {
            if (oldParent != null && oldParent.Extrato == this) oldParent.Extrato = null;
            if (newParent != null && newParent.Extrato != this) newParent.Extrato = this;
        }

        #endregion Methods
    }
}
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
using ACBr.Net.Core;
using ACBr.Net.DFe.Core.Common;

namespace ACBr.Net.Sat
{
    public abstract partial class ExtratoSat : ACBrComponent
    {
        #region Fields

        private ACBrSat parent;

        #endregion Fields

        #region Propriedades

        public ACBrSat Parent
        {
            get => parent;
            set
            {
                parent = value;
                if (parent.Extrato != this)
                    parent.Extrato = this;
            }
        }

        public ExtratoLayOut LayOut { get; set; }

        public ExtratoFiltro Filtro { get; set; }

        public bool MostrarPreview { get; set; }

        public bool MostrarSetup { get; set; }

        public string PrinterName { get; set; }

        public int NumeroCopias { get; set; }

        public string NomeArquivo { get; set; }

        public string SoftwareHouse { get; set; }

        public string Site { get; set; }

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

        #endregion Methods
    }
}
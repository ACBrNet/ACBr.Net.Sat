// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 05-11-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-11-2016
// ***********************************************************************
// <copyright file="CFeCancDest.cs" company="ACBr.Net">
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
using ACBr.Net.Core.Extensions;
using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Collection;
using ACBr.Net.DFe.Core.Serializer;

namespace ACBr.Net.Sat
{
    /// <summary>
    /// Class CFeCancDest. This class cannot be inherited.
    /// </summary>
    public sealed class CFeCancDest : DFeParentItem<CFeCancDest, CancInfCFe>, INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Propriedades

        /// <summary>
        /// Gets or sets the CPF.
        /// </summary>
        /// <value>The CPF.</value>
        [DFeElement(TipoCampo.StrNumberFill, "CPF", Id = "E02", Min = 11, Max = 11, Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public string CPF { get; set; }

        /// <summary>
        /// Gets or sets the CNPJ.
        /// </summary>
        /// <value>The CNPJ.</value>
        [DFeElement(TipoCampo.StrNumberFill, "CNPJ", Id = "E03", Min = 14, Max = 14, Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public string CNPJ { get; set; }

        #endregion Propriedades

        #region Methods

        /// <summary>
        /// Shoulds the serialize CPF.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeCPF()
        {
            return Parent.Versao < 0.07M && CNPJ.IsEmpty();
        }

        /// <summary>
        /// Shoulds the serialize CNPJ.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeCNPJ()
        {
            return Parent.Versao < 0.07M && CPF.IsEmpty();
        }

        #endregion Methods
    }
}
// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 05-11-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-11-2016
// ***********************************************************************
// <copyright file="CFeCancEmit.cs" company="ACBr.Net">
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
using ACBr.Net.Core.Generics;
using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Serializer;

namespace ACBr.Net.Sat
{
    /// <summary>
    /// Class CFeCancEmit. This class cannot be inherited.
    /// </summary>
    public sealed class CFeCancEmit : GenericClone<CFeCancEmit>, INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CFeEmit" /> class.
        /// </summary>
        public CFeCancEmit()
        {
            EnderEmit = new CFeEnderEmit();
        }

        #endregion Constructors

        #region Propriedades

        /// <summary>
        /// Gets or sets the CNPJ.
        /// </summary>
        /// <value>The CNPJ.</value>
        [DFeElement(TipoCampo.StrNumberFill, "CNPJ", Id = "C02", Min = 14, Max = 14, Ocorrencia = Ocorrencia.Obrigatoria)]
        public string CNPJ { get; set; }

        /// <summary>
        /// Gets or sets the x nome.
        /// </summary>
        /// <value>The x nome.</value>
        [DFeElement(TipoCampo.Str, "xNome", Id = "C03", Min = 1, Max = 60, Ocorrencia = Ocorrencia.Obrigatoria)]
        public string XNome { get; set; }

        /// <summary>
        /// Gets or sets the x fant.
        /// </summary>
        /// <value>The x fant.</value>
        [DFeElement(TipoCampo.Str, "xFant", Id = "C04", Min = 1, Max = 60, Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public string XFant { get; set; }

        /// <summary>
        /// Gets the ender emit.
        /// </summary>
        /// <value>The ender emit.</value>
        [DFeElement("enderEmit", Id = "C05", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public CFeEnderEmit EnderEmit { get; set; }

        /// <summary>
        /// Gets or sets the ie.
        /// </summary>
        /// <value>The ie.</value>
        [DFeElement(TipoCampo.Str, "IE", Id = "C12", Min = 12, Max = 12, Ocorrencia = Ocorrencia.Obrigatoria)]
        public string IE { get; set; }

        /// <summary>
        /// Gets or sets the im.
        /// </summary>
        /// <value>The im.</value>
        [DFeElement(TipoCampo.Str, "IM", Id = "C13", Min = 1, Max = 15, Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public string IM { get; set; }

        #endregion Propriedades

        #region Methods

        private bool ShouldSerializeCNPJ()
        {
            return !CNPJ.IsEmpty();
        }

        private bool ShouldSerializeXNome()
        {
            return !XNome.IsEmpty();
        }

        private bool ShouldSerializeXFant()
        {
            return !XFant.IsEmpty();
        }

        private bool ShouldSerializeEnderEmit()
        {
            return !EnderEmit.CEP.IsEmpty() ||
                   !EnderEmit.Nro.IsEmpty() ||
                   !EnderEmit.XBairro.IsEmpty() ||
                   !EnderEmit.XCpl.IsEmpty() ||
                   !EnderEmit.XLgr.IsEmpty() ||
                   !EnderEmit.XMun.IsEmpty();
        }

        private bool ShouldSerializeIE()
        {
            return !IE.IsEmpty();
        }

        private bool ShouldSerializeIM()
        {
            return !IM.IsEmpty();
        }

        #endregion Methods
    }
}
// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-27-2016
//
// Last Modified By : RFTD
// Last Modified On : 04-28-2016
// ***********************************************************************
// <copyright file="CFeDet.cs" company="ACBr.Net">
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
using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Collection;
using ACBr.Net.DFe.Core.Serializer;

namespace ACBr.Net.Sat
{
    /// <summary>
    /// Class CFeDet.
    /// </summary>
    public sealed class CFeDet : DFeParentItem<CFeDet, CFe>, INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Fields

        private CFeDetProd prod;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CFeDet"/> class.
        /// </summary>
        public CFeDet()
        {
            Imposto = new CFeDetImposto();
            Prod = new CFeDetProd();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CFeDet"/> class.
        /// </summary>
        public CFeDet(CFe parent) : this()
        {
            Parent = parent;
            Prod = new CFeDetProd(Parent);
        }

        #endregion Constructors

        #region Propriedades

        /// <summary>
        /// Gets or sets the n item.
        /// </summary>
        /// <value>The n item.</value>
        [DFeAttribute(TipoCampo.Int, "nItem", Id = "H02", Min = 1, Max = 3, Ocorrencia = Ocorrencia.Obrigatoria)]
        public int NItem { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>The product.</value>
        [DFeElement("prod", Id = "I01", Ocorrencia = Ocorrencia.Obrigatoria)]
        public CFeDetProd Prod
        {
            get => prod;
            set
            {
                prod = value;
                if (prod.Parent != Parent)
                    prod.Parent = Parent;
            }
        }

        /// <summary>
        /// Gets or sets the imposto.
        /// </summary>
        /// <value>The imposto.</value>
        [DFeElement("imposto", Id = "M01", Ocorrencia = Ocorrencia.Obrigatoria)]
        public CFeDetImposto Imposto { get; set; }

        /// <summary>
        /// Gets or sets the inf ad product.
        /// </summary>
        /// <value>The inf ad product.</value>
        [DFeElement(TipoCampo.Str, "infAdProd", Id = "V01", Min = 1, Max = 500, Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public string InfAdProd { get; set; }

        #endregion Propriedades

        #region Methods

        /// <inheritdoc />
        protected override void OnParentChanged()
        {
            Prod.Parent = Parent;
        }

        #endregion Methods
    }
}
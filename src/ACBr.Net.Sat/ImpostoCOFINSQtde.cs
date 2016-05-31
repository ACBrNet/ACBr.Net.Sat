// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-02-2016
// ***********************************************************************
// <copyright file="ImpostoCOFINSQtde.cs" company="ACBr.Net">
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
using ACBr.Net.Sat.Interfaces;
using PropertyChanged;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Class ImpostoCOFINSQtde. This class cannot be inherited.
	/// </summary>
	/// <seealso cref="ACBr.Net.Sat.Interfaces.ICFeCofins" />
	[ImplementPropertyChanged]
	public sealed class ImpostoCofinsQtde : ICFeCofins
	{
		#region Propriedades

		/// <summary>
		/// Gets or sets the Cst.
		/// </summary>
		/// <value>The Cst.</value>
		[DFeElement(TipoCampo.Str, "CST", Id = "S07", Min = 2, Max = 2, Ocorrencias = 1)]
		public string Cst { get; set; }

		/// <summary>
		/// Gets or sets the q bc product.
		/// </summary>
		/// <value>The q bc product.</value>
		[DFeElement(TipoCampo.De4, "qBCProd", Id = "S11", Min = 1, Max = 16, Ocorrencias = 1)]
		public decimal QBcProd { get; set; }

		/// <summary>
		/// Gets or sets the v aliq product.
		/// </summary>
		/// <value>The v aliq product.</value>
		[DFeElement(TipoCampo.De4, "vAliqProd", Id = "S12", Min = 5, Max = 15, Ocorrencias = 1)]
		public decimal VAliqProd { get; set; }

		/// <summary>
		/// Gets or sets the vcofins.
		/// </summary>
		/// <value>The vcofins.</value>
		[DFeElement(TipoCampo.De2, "vCOFINS", Id = "S10", Min = 1, Max = 15, Ocorrencias = 1)]
		public decimal VCofins { get; set; }

		#endregion Propriedades

		#region Methods

		/// <summary>
		/// Shoulds the serialize vcofins.
		/// </summary>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		private bool ShouldSerializeVCofins()
		{
			return VCofins > 0;
		}

		#endregion Methods
	}
}
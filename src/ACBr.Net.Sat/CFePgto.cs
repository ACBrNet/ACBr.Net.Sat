// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-02-2016
// ***********************************************************************
// <copyright file="CFePgto.cs" company="ACBr.Net">
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
using ACBr.Net.DFe.Core.Collection;
using ACBr.Net.DFe.Core.Serializer;
using PropertyChanged;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Class CFePgto. This class cannot be inherited.
	/// </summary>
	[ImplementPropertyChanged]
	public sealed class CFePgto
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="CFePgto"/> class.
		/// </summary>
		public CFePgto()
		{
			Pagamentos = new DFeCollection<CFePgtoMp>();
		}

		#endregion Constructors

		#region Propriedades

		/// <summary>
		/// Gets or sets the pagamentos.
		/// </summary>
		/// <value>The pagamentos.</value>
		[DFeElement("MP", Id = "WA02", Min = 1, Max = 50, Ocorrencias = 1)]
		public DFeCollection<CFePgtoMp> Pagamentos { get; set; }

		/// <summary>
		/// Gets or sets the v troco.
		/// </summary>
		/// <value>The v troco.</value>
		[DFeElement(TipoCampo.De2, "vTroco", Id = "WA06", Min = 3, Max = 15, Ocorrencias = 1)]
		public decimal VTroco { get; set; }

		#endregion Propriedades

		#region Methods

		private bool ShouldSerializeVTroco()
		{
			return VTroco > 0;
		}

		#endregion Methods
	}
}
// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-02-2016
// ***********************************************************************
// <copyright file="CFePgtoMP.cs" company="ACBr.Net">
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
using PropertyChanged;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Class CFePgtoMp. This class cannot be inherited.
	/// </summary>
	[ImplementPropertyChanged]
	public sealed class CFePgtoMp
	{
		#region Properties

		/// <summary>
		/// Gets or sets the c mp.
		/// </summary>
		/// <value>The c mp.</value>
		[DFeElement(TipoCampo.Enum, "cMP", Id = "WA04", Min = 2, Max = 2, Ocorrencias = 0)]
		public CodigoMP CMp { get; set; }

		/// <summary>
		/// Gets or sets the v mp.
		/// </summary>
		/// <value>The v mp.</value>
		[DFeElement(TipoCampo.De2, "vMP", Id = "WA05", Min = 3, Max = 15, Ocorrencias = 1)]
		public decimal VMp { get; set; }

		/// <summary>
		/// Gets or sets the c adm c.
		/// </summary>
		/// <value>The c adm c.</value>
		[DFeElement(TipoCampo.Int, "cAdmC", Id = "WA06", Min = 3, Max = 3, Ocorrencias = 0)]
		public int? CAdmC { get; set; }

		#endregion Properties

		#region Methods

		private bool ShouldSerializeCAdmC()
		{
			return CAdmC != null;
		}

		#endregion Methods
	}
}
// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 04-29-2016
// ***********************************************************************
// <copyright file="CFeEntrega.cs" company="ACBr.Net">
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
	/// Class CFeEntrega. This class cannot be inherited.
	/// </summary>
	[ImplementPropertyChanged]
	public sealed class CFeEntrega
	{
		#region Propriedades

		/// <summary>
		/// Gets or sets the x LGR.
		/// </summary>
		/// <value>The x LGR.</value>
		[DFeElement(TipoCampo.Str, "xLgr", Id = "G02", Min = 2, Max = 60, Ocorrencia = Ocorrencia.Obrigatoria)]
		public string XLgr { get; set; }

		/// <summary>
		/// Gets or sets the nro.
		/// </summary>
		/// <value>The nro.</value>
		[DFeElement(TipoCampo.Str, "nro", Id = "G03", Min = 1, Max = 60, Ocorrencia = Ocorrencia.Obrigatoria)]
		public string Nro { get; set; }

		/// <summary>
		/// Gets or sets the x CPL.
		/// </summary>
		/// <value>The x CPL.</value>
		[DFeElement(TipoCampo.Str, "xCpl", Id = "G04", Min = 1, Max = 60, Ocorrencia = Ocorrencia.NaoObrigatoria)]
		public string XCpl { get; set; }

		/// <summary>
		/// Gets or sets the x bairro.
		/// </summary>
		/// <value>The x bairro.</value>
		[DFeElement(TipoCampo.Str, "xBairro", Id = "G05", Min = 1, Max = 60, Ocorrencia = Ocorrencia.Obrigatoria)]
		public string XBairro { get; set; }

		/// <summary>
		/// Gets or sets the x mun.
		/// </summary>
		/// <value>The x mun.</value>
		[DFeElement(TipoCampo.Str, "xMun", Id = "G06", Min = 2, Max = 60, Ocorrencia = Ocorrencia.Obrigatoria)]
		public string XMun { get; set; }

		/// <summary>
		/// Gets or sets the uf.
		/// </summary>
		/// <value>The uf.</value>
		[DFeElement(TipoCampo.Str, "UF", Id = "G07", Min = 2, Max = 2, Ocorrencia = Ocorrencia.Obrigatoria)]
		public string UF { get; set; }

		#endregion Propriedades

		#region Methods
		#endregion Methods
	}
}
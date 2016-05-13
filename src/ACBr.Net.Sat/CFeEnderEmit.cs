// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-23-2016
//
// Last Modified By : RFTD
// Last Modified On : 04-23-2016
// ***********************************************************************
// <copyright file="CFeEnderEmit.cs" company="ACBr.Net">
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

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Class CFeEnderEmit. This class cannot be inherited.
	/// </summary>
	public sealed class CFeEnderEmit
	{
		/// <summary>
		/// Gets or sets the x LGR.
		/// </summary>
		/// <value>The x LGR.</value>
		[DFeElement(TipoCampo.Str, "xLgr", Id = "C06", Min = 2, Max = 60, Ocorrencias = 0)]
		public string XLgr { get; set; }

		/// <summary>
		/// Gets or sets the nro.
		/// </summary>
		/// <value>The nro.</value>
		[DFeElement(TipoCampo.Str, "nro", Id = "C07", Min = 1, Max = 60, Ocorrencias = 0)]
		public string Nro { get; set; }

		/// <summary>
		/// Gets or sets the x CPL.
		/// </summary>
		/// <value>The x CPL.</value>
		[DFeElement(TipoCampo.Str, "xCpl", Id = "C08", Min = 1, Max = 60, Ocorrencias = 0)]
		public string XCpl { get; set; }

		/// <summary>
		/// Gets or sets the x bairro.
		/// </summary>
		/// <value>The x bairro.</value>
		[DFeElement(TipoCampo.Str, "xBairro", Id = "C09", Min = 2, Max = 60, Ocorrencias = 0)]
		public string XBairro { get; set; }

		/// <summary>
		/// Gets or sets the x mun.
		/// </summary>
		/// <value>The x mun.</value>
		[DFeElement(TipoCampo.Str, "xMun", Id = "C10", Min = 2, Max = 60, Ocorrencias = 0)]
		public string XMun { get; set; }

		/// <summary>
		/// Gets or sets the cep.
		/// </summary>
		/// <value>The cep.</value>
		[DFeElement(TipoCampo.StrNumber, "CEP", Id = "C11", Min = 8, Max = 8, Ocorrencias = 0)]
		public string CEP { get; set; }
	}
}
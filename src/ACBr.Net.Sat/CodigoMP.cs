// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 05-07-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-07-2016
// ***********************************************************************
// <copyright file="CodigoMP.cs" company="ACBr.Net">
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

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Enum CodigoMP
	/// </summary>
	public enum CodigoMP
	{
		/// <summary>
		/// The dinheiro
		/// </summary>
		[DFeEnum("01")]
		Dinheiro,

		/// <summary>
		/// The cheque
		/// </summary>
		[DFeEnum("02")]
		Cheque,

		/// <summary>
		/// The cartaode credito
		/// </summary>
		[DFeEnum("03")]
		CartaodeCredito,

		/// <summary>
		/// The cartaode debito
		/// </summary>
		[DFeEnum("04")]
		CartaodeDebito,

		/// <summary>
		/// The credito loja
		/// </summary>
		[DFeEnum("05")]
		CreditoLoja,

		/// <summary>
		/// The vale alimentacao
		/// </summary>
		[DFeEnum("10")]
		ValeAlimentacao,

		/// <summary>
		/// The vale refeicao
		/// </summary>
		[DFeEnum("11")]
		ValeRefeicao,

		/// <summary>
		/// The vale presente
		/// </summary>
		[DFeEnum("12")]
		ValePresente,

		/// <summary>
		/// The vale combustivel
		/// </summary>
		[DFeEnum("13")]
		ValeCombustivel,

		/// <summary>
		/// The outros
		/// </summary>
		[DFeEnum("99")]
		Outros
	};
}
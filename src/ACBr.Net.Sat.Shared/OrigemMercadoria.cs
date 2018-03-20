// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 05-07-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-07-2016
// ***********************************************************************
// <copyright file="OrigemMercadoria.cs" company="ACBr.Net">
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
	/// Enum OrigemMercadoria
	/// </summary>
	public enum OrigemMercadoria
	{
		/// <summary>
		/// The nacional
		/// </summary>
		[DFeEnum("0")]
		Nacional,
		/// <summary>
		/// The estrangeira importacao direta
		/// </summary>
		[DFeEnum("1")]
		EstrangeiraImportacaoDireta,
		/// <summary>
		/// The estrangeira adquirida brasil
		/// </summary>
		[DFeEnum("2")]
		EstrangeiraAdquiridaBrasil,
		/// <summary>
		/// The nacional conteudo importacao superior40
		/// </summary>
		[DFeEnum("3")]
		NacionalConteudoImportacaoSuperior40,
		/// <summary>
		/// The nacional processos basicos
		/// </summary>
		[DFeEnum("4")]
		NacionalProcessosBasicos,
		/// <summary>
		/// The nacional conteudo importacao inferior igual40
		/// </summary>
		[DFeEnum("5")]
		NacionalConteudoImportacaoInferiorIgual40,
		/// <summary>
		/// The estrangeira importacao direta sem similar
		/// </summary>
		[DFeEnum("6")]
		EstrangeiraImportacaoDiretaSemSimilar,
		/// <summary>
		/// The estrangeira adquirida brasil sem similar
		/// </summary>
		[DFeEnum("7")]
		EstrangeiraAdquiridaBrasilSemSimilar,
		/// <summary>
		/// The nacional conteudo importacao superior70
		/// </summary>
		[DFeEnum("8")]
		NacionalConteudoImportacaoSuperior70
	}
}
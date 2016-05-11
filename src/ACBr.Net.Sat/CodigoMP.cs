// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 05-07-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-07-2016
// ***********************************************************************
// <copyright file="CodigoMP.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
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
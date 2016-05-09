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
		[DFeEnum("00")]
		Dinheiro,
		/// <summary>
		/// The cheque
		/// </summary>
		[DFeEnum("01")]
		Cheque,
		/// <summary>
		/// The cartaode credito
		/// </summary>
		[DFeEnum("02")]
		CartaodeCredito,
		/// <summary>
		/// The cartaode debito
		/// </summary>
		[DFeEnum("03")]
		CartaodeDebito,
		/// <summary>
		/// The credito loja
		/// </summary>
		[DFeEnum("04")]
		CreditoLoja,
		/// <summary>
		/// The vale alimentacao
		/// </summary>
		[DFeEnum("05")]
		ValeAlimentacao,
		/// <summary>
		/// The vale refeicao
		/// </summary>
		[DFeEnum("06")]
		ValeRefeicao,
		/// <summary>
		/// The vale presente
		/// </summary>
		[DFeEnum("07")]
		ValePresente,
		/// <summary>
		/// The vale combustivel
		/// </summary>
		[DFeEnum("08")]
		ValeCombustivel,
		/// <summary>
		/// The outros
		/// </summary>
		[DFeEnum("09")]
		Outros
	};
}
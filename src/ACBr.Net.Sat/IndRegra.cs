// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-30-2016
//
// Last Modified By : RFTD
// Last Modified On : 04-30-2016
// ***********************************************************************
// <copyright file="IndRegra.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using ACBr.Net.DFe.Core.Attributes;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Enum IndRegra
	/// </summary>
	public enum IndRegra
	{
		/// <summary>
		/// The arredondamento
		/// </summary>
		[DFeEnum("A")]
		Arredondamento,
		/// <summary>
		/// The truncamento
		/// </summary>
		[DFeEnum("T")]
		Truncamento
	}
}
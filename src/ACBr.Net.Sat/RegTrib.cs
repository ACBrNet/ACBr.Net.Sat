// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 03-31-2016
//
// Last Modified By : RFTD
// Last Modified On : 03-31-2016
// ***********************************************************************
// <copyright file="RegTrib.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using ACBr.Net.DFe.Core.Attributes;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Enum RegTrib
	/// </summary>
	public enum RegTrib
	{
		/// <summary>
		/// The normal
		/// </summary>
		[DFeEnum("0")]
		Normal,
		/// <summary>
		/// The simples nacional
		/// </summary>
		[DFeEnum("1")]
		SimplesNacional
	}
}
// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 03-31-2016
//
// Last Modified By : RFTD
// Last Modified On : 03-31-2016
// ***********************************************************************
// <copyright file="RatISSQN.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using ACBr.Net.DFe.Core.Attributes;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Enum RatISSQN
	/// </summary>
	public enum RatISSQN
	{
		/// <summary>
		/// The sim
		/// </summary>
		[DFeEnum("S")]
		Sim,
		/// <summary>
		/// The nao
		/// </summary>
		[DFeEnum("N")]
		Nao
	}
}
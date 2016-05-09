// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 03-31-2016
//
// Last Modified By : RFTD
// Last Modified On : 03-31-2016
// ***********************************************************************
// <copyright file="TipoAmbiente.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using ACBr.Net.DFe.Core.Attributes;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Enum TipoAmbiente
	/// </summary>
	public enum TipoAmbiente
	{
		/// <summary>
		/// The producao
		/// </summary>
		[DFeEnum("1")]
		Producao,
		/// <summary>
		/// The homologacao
		/// </summary>
		[DFeEnum("2")]
		Homologacao
	}
}
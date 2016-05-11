// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 03-31-2016
//
// Last Modified By : RFTD
// Last Modified On : 03-31-2016
// ***********************************************************************
// <copyright file="RegTribISSQN.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using ACBr.Net.DFe.Core.Attributes;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Enum RegTribISSQN
	/// </summary>
	public enum RegTribIssqn
	{
		/// <summary>
		/// The nenhum
		/// </summary>
		[DFeEnum("0")]
		Nenhum,
		/// <summary>
		/// The microempresa municipal
		/// </summary>
		[DFeEnum("1")]
		MicroempresaMunicipal,
		/// <summary>
		/// The estimativa
		/// </summary>
		[DFeEnum("2")]
		Estimativa,
		/// <summary>
		/// The sociedade profissionais
		/// </summary>
		[DFeEnum("3")]
		SociedadeProfissionais,
		/// <summary>
		/// The cooperativa
		/// </summary>
		[DFeEnum("4")]
		Cooperativa,
		/// <summary>
		/// The mei
		/// </summary>
		[DFeEnum("5")]
		MEI,
		/// <summary>
		/// The meepp
		/// </summary>
		[DFeEnum("6")]
		MEEPP
	}
}
// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 03-31-2016
//
// Last Modified By : RFTD
// Last Modified On : 03-31-2016
// ***********************************************************************
// <copyright file="EstadoOperacao.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ACBr.Net.Sat
{
	/// <summary>
	/// Enum EstadoOperacao
	/// </summary>
	public enum EstadoOperacao
	{
		/// <summary>
		/// The desbloqueado
		/// </summary>
		Desbloqueado,
		/// <summary>
		/// The bloqueio sefaz
		/// </summary>
		BloqueioSEFAZ,
		/// <summary>
		/// The bloqueio comtribuinte
		/// </summary>
		BloqueioComtribuinte,
		/// <summary>
		/// The bloqueio autonomo
		/// </summary>
		BloqueioAutonomo,
		/// <summary>
		/// The bloqueio desativacao
		/// </summary>
		BloqueioDesativacao
	}
}
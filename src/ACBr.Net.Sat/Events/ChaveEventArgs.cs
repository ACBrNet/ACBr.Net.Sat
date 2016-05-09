// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 03-31-2016
//
// Last Modified By : RFTD
// Last Modified On : 03-31-2016
// ***********************************************************************
// <copyright file="ChaveEventArgs.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace ACBr.Net.Sat.Events
{
	/// <summary>
	/// Class ChaveEventArgs.
	/// </summary>
	/// <seealso cref="System.EventArgs" />
	public class ChaveEventArgs : EventArgs
	{
		/// <summary>
		/// Gets or sets the chave.
		/// </summary>
		/// <value>The chave.</value>
		public string Chave { get; set; }
	}
}
// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 03-31-2016
//
// Last Modified By : RFTD
// Last Modified On : 03-31-2016
// ***********************************************************************
// <copyright file="NumeroSessaoEventArgs.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace ACBr.Net.Sat.Events
{
	/// <summary>
	/// Class NumeroSessaoEventArgs.
	/// </summary>
	/// <seealso cref="System.EventArgs" />
	public class NumeroSessaoEventArgs : EventArgs
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="NumeroSessaoEventArgs"/> class.
		/// </summary>
		/// <param name="sessao">The sessao.</param>
		public NumeroSessaoEventArgs(int sessao)
		{
			Sessao = sessao;
		}

		/// <summary>
		/// Gets or sets the sessao.
		/// </summary>
		/// <value>The sessao.</value>
		public int Sessao { get; set; }
	}
}
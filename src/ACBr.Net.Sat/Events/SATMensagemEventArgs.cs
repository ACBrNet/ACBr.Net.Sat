// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 03-31-2016
//
// Last Modified By : RFTD
// Last Modified On : 03-31-2016
// ***********************************************************************
// <copyright file="SATMensagemEventArgs.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace ACBr.Net.Sat.Events
{
	/// <summary>
	/// Class SATMensagemEventArgs.
	/// </summary>
	/// <seealso cref="System.EventArgs" />
	public class SatMensagemEventArgs : EventArgs
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SatMensagemEventArgs"/> class.
		/// </summary>
		/// <param name="codigo">The codigo.</param>
		/// <param name="mensagem">The mensagem.</param>
		public SatMensagemEventArgs(int codigo, string mensagem)
		{
			Codigo = codigo;
			Mensagem = mensagem;
		}

		/// <summary>
		/// Gets or sets the dados.
		/// </summary>
		/// <value>The dados.</value>
		public int Codigo { get; set; }

		/// <summary>
		/// Gets or sets the retorno.
		/// </summary>
		/// <value>The retorno.</value>
		public string Mensagem { get; set; }
	}
}
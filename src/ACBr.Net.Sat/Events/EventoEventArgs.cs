// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 03-31-2016
//
// Last Modified By : RFTD
// Last Modified On : 03-31-2016
// ***********************************************************************
// <copyright file="EventoEventArgs.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace ACBr.Net.Sat.Events
{
	/// <summary>
	/// Class EventoEventArgs.
	/// </summary>
	/// <seealso cref="System.EventArgs" />
	public class EventoEventArgs : EventArgs
	{
		/// <summary>
		/// Gets or sets the retorno.
		/// </summary>
		/// <value>The retorno.</value>
		public string Retorno { get; set; }
	}
}
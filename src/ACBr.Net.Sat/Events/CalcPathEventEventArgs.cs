// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 03-31-2016
//
// Last Modified By : RFTD
// Last Modified On : 03-31-2016
// ***********************************************************************
// <copyright file="CalcPathEventEventArgs.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace ACBr.Net.Sat.Events
{
	/// <summary>
	/// Class CalcPathEventEventArgs.
	/// </summary>
	/// <seealso cref="System.EventArgs" />
	public class CalcPathEventEventArgs : EventArgs
	{
		/// <summary>
		/// Gets or sets the dados.
		/// </summary>
		/// <value>The dados.</value>
		public string Path { get; set; }

		/// <summary>
		/// Gets or sets the retorno.
		/// </summary>
		/// <value>The retorno.</value>
		public string CNPJ { get; set; }

		/// <summary>
		/// Gets or sets the data.
		/// </summary>
		/// <value>The data.</value>
		public DateTime Data { get; set; }
	}
}
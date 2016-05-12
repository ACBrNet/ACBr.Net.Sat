// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 03-31-2016
//
// Last Modified By : RFTD
// Last Modified On : 03-31-2016
// ***********************************************************************
// <copyright file="EventoDadosEventArgs.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace ACBr.Net.Sat.Events
{
	public class EventoDadosEventArgs : EventArgs
	{
		#region Property

		public string DadosVenda { get; set; }

		#endregion Property
	}
}
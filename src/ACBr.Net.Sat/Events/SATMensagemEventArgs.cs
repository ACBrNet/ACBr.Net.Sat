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
	public class SatMensagemEventArgs : EventArgs
	{
		#region Constructor

		public SatMensagemEventArgs(int codigo, string mensagem)
		{
			Codigo = codigo;
			Mensagem = mensagem;
		}

		#endregion Constructor

		#region Properties

		public int Codigo { get; private set; }

		public string Mensagem { get; private set; }

		#endregion Properties
	}
}
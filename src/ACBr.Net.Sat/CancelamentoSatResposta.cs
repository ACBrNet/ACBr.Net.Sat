// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 05-10-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-10-2016
// ***********************************************************************
// <copyright file="CancelamentoSatResposta.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;

namespace ACBr.Net.Sat
{
	public class CancelamentoSatResposta : SatResposta
	{
		#region Constructors

		public CancelamentoSatResposta(string retorno) : base(retorno)
		{
			if (CodigoDeRetorno != 7000) return;

			using (var stream = new MemoryStream(Convert.FromBase64String(RetornoLst[5])))
			{
				Cancelamento = CFeCanc.Load(stream);
			}
		}

		#endregion Constructors

		#region Properties

		public CFeCanc Cancelamento { get; set; }

		#endregion Properties
	}
}
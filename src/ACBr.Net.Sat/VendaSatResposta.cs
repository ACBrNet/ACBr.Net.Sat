// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 05-10-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-10-2016
// ***********************************************************************
// <copyright file="VendaSatResposta.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;

namespace ACBr.Net.Sat
{
	public class VendaSatResposta : SatResposta
	{
		#region Constructors

		public VendaSatResposta(string retorno) : base(retorno)
		{
			if (CodigoDeRetorno != 6000) return;

			if (RetornoLst.Count >= 7)
			{
				using (var stream = new MemoryStream(Convert.FromBase64String(RetornoLst[6])))
				{
					Venda = CFe.Load(stream);
				}
			}

			if (RetornoLst.Count >= 9)
			{
				ChaveConsulta = RetornoLst[8];
			}

			if (RetornoLst.Count >= 12)
			{
				//O QRCode é montado a partir dos últimos campos do retorno

				var indexOf = -1;
				for (int i = 0; i < 8; i++)
				{
					indexOf = RetornoStr.IndexOf('|', indexOf + 1);
					if (indexOf == -1) break;
				}

				QRCode = RetornoStr.Substring(indexOf + 1);
			}
		}

		#endregion Constructors

		#region Propriedades

		public CFe Venda { get; private set; }

		public string ChaveConsulta { get; private set; }

		public string QRCode { get; private set; }

		#endregion Propriedades
	}
}
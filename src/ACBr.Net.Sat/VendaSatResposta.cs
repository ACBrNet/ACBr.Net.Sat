// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 05-10-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-10-2016
// ***********************************************************************
// <copyright file="VendaSatResposta.cs" company="ACBr.Net">
//		        		   The MIT License (MIT)
//	     		    Copyright (c) 2016 Grupo ACBr.Net
//
//	 Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//	 The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//	 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using System.Text;

namespace ACBr.Net.Sat
{
	public class VendaSatResposta : SatResposta
	{
		#region Constructors

		public VendaSatResposta(string retorno, Encoding encoding) : base(retorno, encoding)
		{
			if (CodigoDeRetorno != 6000 || RetornoLst.Count < 6)
				return;

			using (var stream = new MemoryStream(Convert.FromBase64String(RetornoLst[6])))
			{
				Venda = CFe.Load(stream, encoding);
			}

			if (RetornoLst.Count > 8) ChaveConsulta = RetornoLst[8];

			//O QRCode � montado a partir dos �ltimos campos do retorno
			var indexOf = -1;
			for (var i = 0; i < 8; i++)
			{
				indexOf = RetornoStr.IndexOf('|', indexOf + 1);
				if (indexOf == -1) break;
			}

			QRCode = RetornoStr.Substring(indexOf + 1);
		}

		#endregion Constructors

		#region Propriedades

		public CFe Venda { get; private set; }

		public string ChaveConsulta { get; private set; }

		public string QRCode { get; private set; }

		#endregion Propriedades
	}
}
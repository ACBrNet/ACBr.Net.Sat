// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 05-10-2016
//
// Last Modified By : RFTD
// Last Modified On : 02-16-2017
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
using ACBr.Net.Core.Extensions;
using System;
using System.IO;
using System.Text;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Classe que retorna a resposta do Sat quando usado o metodo de venda.
	/// </summary>
	/// <seealso cref="ACBr.Net.Sat.SatResposta" />
	public class VendaSatResposta : SatResposta
	{
		#region Constructors

		/// <summary>
		/// Inicializa uma nova instancia da classe <see cref="VendaSatResposta"/>.
		/// </summary>
		/// <param name="retorno">O retorno.</param>
		/// <param name="encoding">O encoding.</param>
		public VendaSatResposta(string retorno, Encoding encoding) : base(retorno, encoding)
		{
			if (CodigoDeRetorno != 6000 || RetornoLst.Count < 6) return;

			using (var stream = new MemoryStream(Convert.FromBase64String(RetornoLst[6])))
			{
				Venda = CFe.Load(stream, encoding);
			}

			if (RetornoLst.Count > 8) ChaveConsulta = RetornoLst[8];

			#region Comments

			//O QRCode é montado a partir dos valores retornados pelo SAT

			//Posições dos campos de retorno
			//numeroSessao, EEEEE, CCCC, mensagem, cod, mensagemSEFAZ, base64, timeStamp, chaveConsulta, valorTotalCFe, CPFCNPJValue, assinaturaQRCOD

			//Cadeia para o QRCode
			//chaveConsulta|timeStamp|valorTotal|CPFCNPJValue|assinaturaQRCODE

			#endregion Comments

			QRCode = $"{RetornoLst[8].OnlyNumbers()}|{RetornoLst[7]}|{RetornoLst[9]}|{RetornoLst[10]}|{RetornoLst[11]}";
		}

		#endregion Constructors

		#region Propriedades

		/// <summary>
		/// Retorna o CFe caso tenha sido realizado com sucesso.
		/// </summary>
		/// <value>The venda.</value>
		public CFe Venda { get; private set; }

		/// <summary>
		/// Retorna a chave de consulta do CFe caso tenha sido realizado com sucesso.
		/// </summary>
		/// <value>The chave consulta.</value>
		public string ChaveConsulta { get; private set; }

		/// <summary>
		/// Retorna o QRCode caso tenha sido realizado com sucesso.
		/// </summary>
		/// <value>The qr code.</value>
		public string QRCode { get; private set; }

		#endregion Propriedades
	}
}
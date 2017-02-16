// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 05-10-2016
//
// Last Modified By : RFTD
// Last Modified On : 02-16-2017
// ***********************************************************************
// <copyright file="CancelamentoSatResposta.cs" company="ACBr.Net">
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
	/// <summary>
	/// Classe que retorna a resposta do Sat quando usado o metodo de cancelamento.
	/// </summary>
	/// <seealso cref="ACBr.Net.Sat.SatResposta" />
	public class CancelamentoSatResposta : SatResposta
	{
		#region Constructors

		/// <summary>
		/// Inicializar uma nova instancida da classe <see cref="CancelamentoSatResposta"/>.
		/// </summary>
		/// <param name="retorno">O retorno.</param>
		/// <param name="encoding">O encoding.</param>
		public CancelamentoSatResposta(string retorno, Encoding encoding) : base(retorno, encoding)
		{
			if (CodigoDeRetorno != 7000 || RetornoLst.Count < 6) return;

			using (var stream = new MemoryStream(Convert.FromBase64String(RetornoLst[6])))
			{
				Cancelamento = CFeCanc.Load(stream, encoding);
			}
		}

		#endregion Constructors

		#region Properties

		/// <summary>
		/// Retorna o cancelamento caso tenha ocorrido com sucesso.
		/// </summary>
		/// <value>The cancelamento.</value>
		public CFeCanc Cancelamento { get; private set; }

		#endregion Properties
	}
}
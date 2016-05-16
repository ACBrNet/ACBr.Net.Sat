// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 03-31-2016
//
// Last Modified By : RFTD
// Last Modified On : 03-31-2016
// ***********************************************************************
// <copyright file="SATStatus.cs" company="ACBr.Net">
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

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Class SATStatus.
	/// </summary>
	public class SatStatus
	{
		/// <summary>
		/// Gets or sets the nserie.
		/// </summary>
		/// <value>The nserie.</value>
		public string NSerie { get; set; }

		/// <summary>
		/// Gets or sets the lan mac.
		/// </summary>
		/// <value>The lan mac.</value>
		public string LanMac { get; set; }

		/// <summary>
		/// Gets or sets the status lan.
		/// </summary>
		/// <value>The status lan.</value>
		public StatusLan StatusLan { get; set; }

		/// <summary>
		/// Gets or sets the nivel bateria.
		/// </summary>
		/// <value>The nivel bateria.</value>
		public NivelBateria NivelBateria { get; set; }

		/// <summary>
		/// Gets or sets the mt total.
		/// </summary>
		/// <value>The mt total.</value>
		public string MTTotal { get; set; }

		/// <summary>
		/// Gets or sets the mt usada.
		/// </summary>
		/// <value>The mt usada.</value>
		public string MTUsada { get; set; }

		/// <summary>
		/// Gets or sets the dh atual.
		/// </summary>
		/// <value>The dh atual.</value>
		public DateTime DhAtual { get; set; }

		/// <summary>
		/// Gets or sets the ver sb.
		/// </summary>
		/// <value>The ver sb.</value>
		public string VerSb { get; set; }

		/// <summary>
		/// Gets or sets the ver layout.
		/// </summary>
		/// <value>The ver layout.</value>
		public string VerLayout { get; set; }

		/// <summary>
		/// Gets or sets the ultimo c fe.
		/// </summary>
		/// <value>The ultimo c fe.</value>
		public string UltimoCFe { get; set; }

		/// <summary>
		/// Gets or sets the lista inicial.
		/// </summary>
		/// <value>The lista inicial.</value>
		public string ListaInicial { get; set; }

		/// <summary>
		/// Gets or sets the lista final.
		/// </summary>
		/// <value>The lista final.</value>
		public string ListaFinal { get; set; }

		/// <summary>
		/// Gets or sets the dh c fe.
		/// </summary>
		/// <value>The dh c fe.</value>
		public DateTime DhCFe { get; set; }

		/// <summary>
		/// Gets or sets the dh ultima.
		/// </summary>
		/// <value>The dh ultima.</value>
		public DateTime DhUltima { get; set; }

		/// <summary>
		/// Gets or sets the cert emissao.
		/// </summary>
		/// <value>The cert emissao.</value>
		public DateTime CertEmissao { get; set; }

		/// <summary>
		/// Gets or sets the cert vencimento.
		/// </summary>
		/// <value>The cert vencimento.</value>
		public DateTime CertVencimento { get; set; }

		/// <summary>
		/// Gets or sets the estado operacao.
		/// </summary>
		/// <value>The estado operacao.</value>
		public EstadoOperacao EstadoOperacao { get; set; }
	}
}
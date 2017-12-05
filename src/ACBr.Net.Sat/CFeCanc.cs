// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 03-31-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-07-2016
// ***********************************************************************
// <copyright file="CFeCanc.cs" company="ACBr.Net">
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
using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Common;
using ACBr.Net.DFe.Core.Document;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Class CFeCanc. This class cannot be inherited.
	/// </summary>
	[DFeRoot("CFeCanc")]
	public sealed class CFeCanc : DFeDocument<CFeCanc>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="CFe" /> class.
		/// </summary>
		public CFeCanc()
		{
			InfCFe = new CancInfCFe();
			Signature = new DFeSignature();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CFeCanc"/> class.
		/// </summary>
		/// <param name="cfe">The cfe.</param>
		public CFeCanc(CFe cfe) : this()
		{
			InfCFe.ChCanc = $"CFe{cfe.InfCFe.Id.OnlyNumbers()}";
			InfCFe.Versao = cfe.InfCFe.Versao;
			InfCFe.Ide.CNPJ = cfe.InfCFe.Ide.CNPJ;
			InfCFe.Ide.SignAC = cfe.InfCFe.Ide.SignAC;
			InfCFe.Ide.NumeroCaixa = cfe.InfCFe.Ide.NumeroCaixa;
			InfCFe.Dest.CPF = cfe.InfCFe.Dest.CPF;
			InfCFe.Dest.CNPJ = cfe.InfCFe.Dest.CNPJ;
		}

		#endregion Constructors

		#region Propriedades

		/// <summary>
		/// Gets or sets the inf c fe.
		/// </summary>
		/// <value>The inf c fe.</value>
		[DFeElement("infCFe", Ocorrencia = Ocorrencia.Obrigatoria)]
		public CancInfCFe InfCFe { get; set; }

		/// <summary>
		/// Gets or sets the signature.
		/// </summary>
		/// <value>The signature.</value>
		public DFeSignature Signature { get; set; }

		#endregion Propriedades

		#region Methods

		/// <summary>
		/// Retorna o valor do QrCode
		/// </summary>
		/// <returns>C�digo QrCode</returns>
		public string GetQRCode()
		{
			var documento = InfCFe.Dest.CNPJ.IsEmpty() ? InfCFe.Dest.CPF.OnlyNumbers() : InfCFe.Dest.CNPJ.OnlyNumbers();
			return $"{InfCFe.Id.OnlyNumbers()}|{InfCFe.Ide.DhEmissao:yyyyMMddHHmmss}|{InfCFe.Total.VCFe:0.00}|{documento}|{InfCFe.Ide.AssinaturaQrcode}";
		}

		private bool ShouldSerializeSignature()
		{
			return !Signature.SignatureValue.IsEmpty();
		}

		#endregion Methods
	}
}
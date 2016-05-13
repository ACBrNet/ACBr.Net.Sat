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
using System.IO;
using ACBr.Net.Core.Extensions;
using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Document;
using ACBr.Net.DFe.Core.Serializer;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Class CFeCanc. This class cannot be inherited.
	/// </summary>
	[DFeRoot("CFeCanc")]
	public sealed class CFeCanc
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="CFe" /> class.
		/// </summary>
		public CFeCanc()
		{
			InfCFe = new CancInfCFe();
			Ide = new CFeCancIde();
			Emit = new CFeCancEmit();
			Dest = new CFeCancDest();
			Total = new CFeCancTotal();
			InfAdic = new CFeCancInfAdic();
			Signature = new Signature();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CFeCanc"/> class.
		/// </summary>
		/// <param name="cfe">The cfe.</param>
		public CFeCanc(CFe cfe):this()
		{
			InfCFe.ChCanc = $"CFe{cfe.InfCFe.Id}";
			InfCFe.DhEmissao = cfe.InfCFe.Ide.DhEmissao;
			Ide.CNPJ = cfe.InfCFe.Ide.CNPJ;
			Ide.SignAC = cfe.InfCFe.Ide.SignAC;
			Ide.NumeroCaixa = cfe.InfCFe.Ide.NumeroCaixa;
			Dest.CPF = cfe.InfCFe.Dest.CPF;
			Dest.CNPJ = cfe.InfCFe.Dest.CNPJ;
		}

		#endregion Constructors

		#region Propriedades

		/// <summary>
		/// Gets or sets the inf c fe.
		/// </summary>
		/// <value>The inf c fe.</value>
		[DFeElement("infCFe", Ocorrencias = 1)]
		public CancInfCFe InfCFe { get; set; }

		/// <summary>
		/// Gets the IDE.
		/// </summary>
		/// <value>The IDE.</value>
		[DFeElement("ide", Id = "B01", Ocorrencias = 1)]
		public CFeCancIde Ide { get; set; }

		/// <summary>
		/// Gets the emit.
		/// </summary>
		/// <value>The emit.</value>
		[DFeElement("emit", Id = "C01", Ocorrencias = 1)]
		public CFeCancEmit Emit { get; set; }

		/// <summary>
		/// Gets the dest.
		/// </summary>
		/// <value>The dest.</value>
		[DFeElement("dest", Id = "E01", Ocorrencias = 1)]
		public CFeCancDest Dest { get; set; }

		/// <summary>
		/// Gets the total.
		/// </summary>
		/// <value>The total.</value>
		[DFeElement("total", Id = "W01", Ocorrencias = 1)]
		public CFeCancTotal Total { get; set; }

		/// <summary>
		/// Gets the inf adic.
		/// </summary>
		/// <value>The inf adic.</value>
		[DFeElement("infAdic", Id = "Z01", Ocorrencias = 1)]
		public CFeCancInfAdic InfAdic { get; set; }

		/// <summary>
		/// Gets or sets the signature.
		/// </summary>
		/// <value>The signature.</value>
		public Signature Signature { get; set; }

		#endregion Propriedades

		#region Methods

		private bool ShouldSerializeSignature()
		{
			return !Signature.SignatureValue.IsEmpty();
		}

		/// <summary>
		/// Loads the c fe.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <returns>CFe.</returns>
		public static CFeCanc Load(string path)
		{
			var serializer = DFeSerializer.CreateSerializer<CFeCanc>();
			return serializer.Deserialize(path);
		}

		/// <summary>
		/// Loads the c fe.
		/// </summary>
		/// <param name="stream">The stream.</param>
		/// <returns>CFe.</returns>
		public static CFeCanc Load(Stream stream)
		{
			var serializer = DFeSerializer.CreateSerializer<CFeCanc>();
			return serializer.Deserialize(stream);
		}

		#endregion Methods
	}
}
// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-23-2016
//
// Last Modified By : RFTD
// Last Modified On : 04-28-2016
// ***********************************************************************
// <copyright file="CFe.cs" company="ACBr.Net">
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
using ACBr.Net.DFe.Core.Document;
using ACBr.Net.DFe.Core.Serializer;
using System.IO;
using System.Text;

namespace ACBr.Net.Sat
{
	[DFeRoot("CFe")]
	public sealed class CFe
	{
		#region Fields

		private InfCFe infCFe;

		#endregion Fields

		#region Constructors

		public CFe()
		{
			infCFe = new InfCFe(this);
			Signature = new Signature();
		}

		#endregion Constructors

		#region Propriedades

		[DFeElement("infCFe", Ocorrencias = 1)]
		public InfCFe InfCFe
		{
			get { return infCFe; }
			set
			{
				infCFe = value;
				if (value != null && value.Parent == null)
					value.Parent = this;
			}
		}

		public Signature Signature { get; set; }

		#endregion Propriedades

		#region Methods

		public static CFe Load(string path, Encoding encoding = null)
		{
			var serializer = DFeSerializer.CreateSerializer<CFe>();
			return serializer.Deserialize(path);
		}

		public static CFe Load(Stream stream, Encoding encoding = null)
		{
			var serializer = DFeSerializer.CreateSerializer<CFe>();
			return serializer.Deserialize(stream);
		}

		private bool ShouldSerializeSignature()
		{
			return !Signature.SignatureValue.IsEmpty() &&
				   !Signature.SignedInfo.Reference.DigestValue.IsEmpty() &&
				   !Signature.KeyInfo.X509Data.X509Certificate.IsEmpty();
		}

		#endregion Methods
	}
}
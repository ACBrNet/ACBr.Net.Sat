// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-23-2016
//
// Last Modified By : RFTD
// Last Modified On : 04-28-2016
// ***********************************************************************
// <copyright file="CFe.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using ACBr.Net.Core.Extensions;
using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Document;
using ACBr.Net.DFe.Core.Serializer;
using System.IO;

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

		public static CFe Load(string path)
		{
			var serializer = DFeSerializer.CreateSerializer<CFe>();
			return serializer.Deserialize(path);
		}

		public static CFe Load(Stream stream)
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
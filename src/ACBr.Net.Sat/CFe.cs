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

using System.IO;
using System.Text;
using System.Xml;
using ACBr.Net.Core.Extensions;
using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Document;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Class CFe. This class cannot be inherited.
	/// </summary>
	[DFeRoot("CFe")]
	public sealed class CFe
	{
		#region Fields

		private InfCFe infCFe;

		#endregion Fields

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="CFe"/> class.
		/// </summary>
		public CFe()
		{
			infCFe = new InfCFe(this);
			Signature = new Signature();
		}

		#endregion Constructors

		#region Propriedades

		/// <summary>
		/// Gets or sets the inf c fe.
		/// </summary>
		/// <value>The inf c fe.</value>
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

		/// <summary>
		/// Gets or sets the signature.
		/// </summary>
		/// <value>The signature.</value>
		public Signature Signature { get; set; }

		#endregion Propriedades

		#region Methods
		
		private bool ShouldSerializeSignature()
		{
			return !Signature.SignatureValue.IsEmpty() && 
				   !Signature.SignedInfo.Reference.DigestValue.IsEmpty() &&
				   !Signature.KeyInfo.X509Data.X509Certificate.IsEmpty();
		}

		/// <summary>
		/// Salvars the c fe.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public bool SalvarCFe(string path)
		{
			var serializer = ACBrSat.GetSerializer<CFe>();
			return serializer.Serialize(this, path);
		}

		/// <summary>
		/// Salvars the c fe.
		/// </summary>
		/// <param name="stream">The stream.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public bool SalvarCFe(Stream stream)
		{
			var serializer = ACBrSat.GetSerializer<CFe>();
			return serializer.Serialize(this, stream);
		}
		
		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>A <see cref="System.String" /> that represents this instance.</returns>
		public override string ToString()
		{
			var ms = new MemoryStream();
			SalvarCFe(ms);
			var xml = new XmlDocument();
			xml.Load(ms);
			return xml.AsString(true, true, Encoding.UTF8);
		}

		/// <summary>
		/// Loads the c fe.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <returns>CFe.</returns>
		public static CFe LoadCFe(string path)
		{
			var serializer = ACBrSat.GetSerializer<CFe>();
			return serializer.Deserialize(path);
		}

		/// <summary>
		/// Loads the c fe.
		/// </summary>
		/// <param name="stream">The stream.</param>
		/// <returns>CFe.</returns>
		public static CFe LoadCFe(Stream stream)
		{
			var serializer = ACBrSat.GetSerializer<CFe>();
			return serializer.Deserialize(stream);
		}
		
		#endregion Methods
	}
}
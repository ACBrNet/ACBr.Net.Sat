// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 03-31-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-07-2016
// ***********************************************************************
// <copyright file="CFeCanc.cs" company="ACBr.Net">
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
	/// <summary>
	/// Class CFeCanc. This class cannot be inherited.
	/// </summary>
	public sealed class CFeCanc
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="CFe" /> class.
		/// </summary>
		public CFeCanc()
		{
			InfCFe = new CancInfCFe();
			Ide = new CFeIde();
			Emit = new CFeEmit();
			Dest = new CFeDest();
			Total = new CFeTotal();
			InfAdic = new CFeInfAdic();
			Signature = new Signature();
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
		public CFeIde Ide { get; set; }

		/// <summary>
		/// Gets the emit.
		/// </summary>
		/// <value>The emit.</value>
		[DFeElement("emit", Id = "C01", Ocorrencias = 1)]
		public CFeEmit Emit { get; set; }

		/// <summary>
		/// Gets the dest.
		/// </summary>
		/// <value>The dest.</value>
		[DFeElement("dest", Id = "E01", Ocorrencias = 1)]
		public CFeDest Dest { get; set; }

		/// <summary>
		/// Gets the total.
		/// </summary>
		/// <value>The total.</value>
		[DFeElement("total", Id = "W01", Ocorrencias = 1)]
		public CFeTotal Total { get; set; }

		/// <summary>
		/// Gets the inf adic.
		/// </summary>
		/// <value>The inf adic.</value>
		[DFeElement("infAdic", Id = "Z01", Ocorrencias = 1)]
		public CFeInfAdic InfAdic { get; set; }

		/// <summary>
		/// Gets or sets the signature.
		/// </summary>
		/// <value>The signature.</value>
		public Signature Signature { get; set; }

		#endregion Propriedades

		#region Methods

		public static CFeCanc Load(string path)
		{
			var serializer = DFeSerializer.CreateSerializer<CFeCanc>();
			return serializer.Deserialize(path);
		}

		public static CFeCanc Load(Stream stream)
		{
			var serializer = DFeSerializer.CreateSerializer<CFeCanc>();
			return serializer.Deserialize(stream);
		}

		private bool ShouldSerializeSignature()
		{
			return !Signature.SignatureValue.IsEmpty();
		}

		#endregion Methods
	}
}
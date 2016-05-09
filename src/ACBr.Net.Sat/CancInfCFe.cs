// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 05-07-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-07-2016
// ***********************************************************************
// <copyright file="CancInfCFe.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Serializer;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Class CancInfCFe. This class cannot be inherited.
	/// </summary>
	public sealed class CancInfCFe
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>The identifier.</value>
		[DFeAttribute(TipoCampo.Str, "Id")]
		public string Id { get; set; }

		/// <summary>
		/// Gets the versao.
		/// </summary>
		/// <value>The versao.</value>
		[DFeAttribute(TipoCampo.De2, "versao")]
		public decimal Versao { get; set; }

		/// <summary>
		/// Gets or sets the ch canc.
		/// </summary>
		/// <value>The ch canc.</value>
		public string ChCanc { get; set; }

		/// <summary>
		/// Gets or sets the d emi.
		/// </summary>
		/// <value>The d emi.</value>
		public DateTime DEmi { get; set; }

		/// <summary>
		/// Gets or sets the h emi.
		/// </summary>
		/// <value>The h emi.</value>
		public DateTime HEmi { get; set; }
	}
}
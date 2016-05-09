// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-02-2016
// ***********************************************************************
// <copyright file="ImpostoCOFINS.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.Sat.Interfaces;
using PropertyChanged;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Class ImpostoCOFINS. This class cannot be inherited.
	/// </summary>
	[ImplementPropertyChanged]
	public sealed class ImpostoCOFINS
	{
		/// <summary>
		/// Gets or sets the cofins.
		/// </summary>
		/// <value>The cofins.</value>
		[DFeItem(typeof(ImpostoCOFINSAliq), "COFINSAliq")]
		[DFeItem(typeof(ImpostoCOFINSNT), "COFINSNT")]
		[DFeItem(typeof(ImpostoCOFINSOutr), "COFINSOutr")]
		[DFeItem(typeof(ImpostoCOFINSQtde), "COFINSQtde")]
		[DFeItem(typeof(ImpostoCOFINSSN), "COFINSSN")]
		public ICFeCOFINS COFINS { get; set; }
	}
}
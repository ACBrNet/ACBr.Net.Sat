// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-01-2016
// ***********************************************************************
// <copyright file="ImpostoPIS.cs" company="ACBr.Net">
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
	/// Class ImpostoPIS. This class cannot be inherited.
	/// </summary>
	[ImplementPropertyChanged]
	public sealed class ImpostoPIS
	{
		/// <summary>
		/// Gets or sets the pis.
		/// </summary>
		/// <value>The pis.</value>
		[DFeItem(typeof(ImpostoPisAliq), "PISAliq")]
		[DFeItem(typeof(ImpostoPisNt), "PISNT")]
		[DFeItem(typeof(ImpostoPisOutr), "PISOutr")]
		[DFeItem(typeof(ImpostoPisQtde), "PISQtde")]
		[DFeItem(typeof(ImpostoPisSn), "PISSN")]
		public ICFePis PIS { get; set; }
	}
}
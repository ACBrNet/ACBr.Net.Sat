// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 04-30-2016
// ***********************************************************************
// <copyright file="ImpostoICMS.cs" company="ACBr.Net">
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
	/// Class ImpostoICMS. This class cannot be inherited.
	/// </summary>
	[ImplementPropertyChanged]
	public sealed class ImpostoICMS : ICFeImposto
	{
		/// <summary>
		/// Gets or sets the item.
		/// </summary>
		/// <value>The item.</value>
		[DFeItem(typeof(ImpostoICMS00), "ICMS00")]
		[DFeItem(typeof(ImpostoICMS40), "ICMS40")]
		[DFeItem(typeof(ImpostoICMSSN102), "ICMSSN102")]
		[DFeItem(typeof(ImpostoICMSSN900), "ICMSSN900")]
		public ICFeICMS ICMS { get; set; }
	}
}
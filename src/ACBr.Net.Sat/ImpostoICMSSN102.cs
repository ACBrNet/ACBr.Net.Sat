// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-01-2016
// ***********************************************************************
// <copyright file="ImpostoICMSSN102.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Serializer;
using PropertyChanged;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Class ImpostoICMSSN102. Classe para os imposto com CSOSN 102, 300 ou 500.
	/// </summary>
	[ImplementPropertyChanged]
	public sealed class ImpostoICMSSN102
	{
		/// <summary>
		/// Gets or sets the original.
		/// </summary>
		/// <value>The original.</value>
		[DFeElement(TipoCampo.Str, "Orig", Id = "N06", Min = 1, Max = 1, Ocorrencias = 1)]
		public string Orig { get; set; }

		/// <summary>
		/// Gets or sets the csosn.
		/// </summary>
		/// <value>The csosn.</value>
		[DFeElement(TipoCampo.Str, "CSOSN", Id = "N10", Min = 3, Max = 3, Ocorrencias = 1)]
		public string CSOSN { get; set; }
	}
}
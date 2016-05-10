// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-01-2016
// ***********************************************************************
// <copyright file="ImpostoICMS40.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Serializer;
using ACBr.Net.Sat.Interfaces;
using PropertyChanged;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Classe ImpostoICMS40. Classe para os imposto com CST 40, 41, 50 ou 60.
	/// </summary>
	[ImplementPropertyChanged]
	public sealed class ImpostoICMS40 : ICFeICMS
	{
		/// <summary>
		/// Gets or sets the original.
		/// </summary>
		/// <value>The original.</value>
		[DFeElement(TipoCampo.Str, "Orig", Id = "N06", Min = 1, Max = 1, Ocorrencias = 1)]
		public string Orig { get; set; }

		/// <summary>
		/// Gets or sets the CST.
		/// </summary>
		/// <value>The CST.</value>
		[DFeElement(TipoCampo.Str, "CST", Id = "N07", Min = 2, Max = 2, Ocorrencias = 1)]
		public string CST { get; set; }
	}
}
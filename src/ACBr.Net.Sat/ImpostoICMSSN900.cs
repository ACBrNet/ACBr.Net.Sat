// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-01-2016
// ***********************************************************************
// <copyright file="ImpostoICMSSN900.cs" company="ACBr.Net">
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
	/// Class ImpostoICMSSN900. This class cannot be inherited.
	/// </summary>
	[ImplementPropertyChanged]
	public sealed class ImpostoIcmsSn900 : ICFeIcms
	{
		#region Propriedades

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

		/// <summary>
		/// Gets or sets the p icms.
		/// </summary>
		/// <value>The p icms.</value>
		[DFeElement(TipoCampo.De2, "pICMS", Id = "N08", Min = 3, Max = 5, Ocorrencias = 1)]
		public decimal PICMS { get; set; }

		/// <summary>
		/// Gets or sets the v icms.
		/// </summary>
		/// <value>The v icms.</value>
		[DFeElement(TipoCampo.De2, "vICMS", Id = "N09", Min = 3, Max = 15, Ocorrencias = 1)]
		public decimal VICMS { get; set; }

		#endregion Propriedades

		#region Methods

		private bool ShouldSerializeVICMS()
		{
			return VICMS > 0;
		}

		#endregion Methods
	}
}
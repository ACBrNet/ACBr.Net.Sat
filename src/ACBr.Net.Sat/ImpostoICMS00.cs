// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-01-2016
// ***********************************************************************
// <copyright file="ImpostoICMS00.cs" company="ACBr.Net">
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
	/// Classe ImpostoICMS00. Classe para os imposto com CST 00, 20 ou 90.
	/// </summary>
	[ImplementPropertyChanged]
	public sealed class ImpostoICMS00 : ICFeICMS
	{
		#region Propriedades

		/// <summary>
		/// Gets or sets the original.
		/// </summary>
		/// <value>The original.</value>
		[DFeElement(TipoCampo.Enum, "Orig", Id = "N06", Min = 1, Max = 1, Ocorrencias = 1)]
		public OrigemMercadoria Orig { get; set; }

		/// <summary>
		/// Gets or sets the CST.
		/// </summary>
		/// <value>The CST.</value>
		[DFeElement(TipoCampo.Str, "CST", Id = "N07", Min = 2, Max = 2, Ocorrencias = 1)]
		public string CST { get; set; }

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
// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-02-2016
// ***********************************************************************
// <copyright file="CFeTotalICMS.cs" company="ACBr.Net">
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
	/// Class CFeTotalICMS. This class cannot be inherited.
	/// </summary>
	[ImplementPropertyChanged]
	public sealed class CFeTotalIcms
	{
		/// <summary>
		/// Gets or sets the vicms.
		/// </summary>
		/// <value>The vicms.</value>
		[DFeElement(TipoCampo.De2, "vICMS", Id = "W03", Min = 3, Max = 15, Ocorrencias = 1)]
		public decimal VICMS { get; set; }

		/// <summary>
		/// Gets or sets the v product.
		/// </summary>
		/// <value>The v product.</value>
		[DFeElement(TipoCampo.De2, "vProd", Id = "W04", Min = 3, Max = 15, Ocorrencias = 1)]
		public decimal VProd { get; set; }

		/// <summary>
		/// Gets or sets the v desc.
		/// </summary>
		/// <value>The v desc.</value>
		[DFeElement(TipoCampo.De2, "vDesc", Id = "W05", Min = 3, Max = 15, Ocorrencias = 1)]
		public decimal VDesc { get; set; }

		/// <summary>
		/// Gets or sets the vpis.
		/// </summary>
		/// <value>The vpis.</value>
		[DFeElement(TipoCampo.De2, "vPIS", Id = "W06", Min = 3, Max = 15, Ocorrencias = 1)]
		public decimal VPIS { get; set; }

		/// <summary>
		/// Gets or sets the vcofins.
		/// </summary>
		/// <value>The vcofins.</value>
		[DFeElement(TipoCampo.De2, "vCOFINS", Id = "W07", Min = 3, Max = 15, Ocorrencias = 1)]
		public decimal VCOFINS { get; set; }

		/// <summary>
		/// Gets or sets the vpisst.
		/// </summary>
		/// <value>The vpisst.</value>
		[DFeElement(TipoCampo.De2, "vPISST", Id = "W08", Min = 3, Max = 15, Ocorrencias = 1)]
		public decimal VPISST { get; set; }

		/// <summary>
		/// Gets or sets the vcofinsst.
		/// </summary>
		/// <value>The vcofinsst.</value>
		[DFeElement(TipoCampo.De2, "vCOFINSST", Id = "W09", Min = 3, Max = 15, Ocorrencias = 1)]
		public decimal VCOFINSST { get; set; }

		/// <summary>
		/// Gets or sets the v outro.
		/// </summary>
		/// <value>The v outro.</value>
		[DFeElement(TipoCampo.De2, "vOutro", Id = "W10", Min = 3, Max = 15, Ocorrencias = 1)]
		public decimal VOutro { get; set; }
	}
}
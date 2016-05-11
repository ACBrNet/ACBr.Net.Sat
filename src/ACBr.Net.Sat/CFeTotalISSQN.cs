// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-02-2016
// ***********************************************************************
// <copyright file="CFeTotalISSQN.cs" company="ACBr.Net">
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
	/// Class CFeTotalISSQN. This class cannot be inherited.
	/// </summary>
	[ImplementPropertyChanged]
	public sealed class CFeTotalIssqn
	{

		/// <summary>
		/// Gets or sets the VBC.
		/// </summary>
		/// <value>The VBC.</value>
		[DFeElement(TipoCampo.De2, "vBC", Id = "W13", Min = 3, Max = 15, Ocorrencias = 1)]
		public decimal VBC { get; set; }

		/// <summary>
		/// Gets or sets the viss.
		/// </summary>
		/// <value>The viss.</value>
		[DFeElement(TipoCampo.De2, "vISS", Id = "W14", Min = 3, Max = 15, Ocorrencias = 1)]
		public decimal VISS { get; set; }

		/// <summary>
		/// Gets or sets the vpis.
		/// </summary>
		/// <value>The vpis.</value>
		[DFeElement(TipoCampo.De2, "vPIS", Id = "W15", Min = 3, Max = 15, Ocorrencias = 1)]
		public decimal VPIS { get; set; }

		/// <summary>
		/// Gets or sets the vcofins.
		/// </summary>
		/// <value>The vcofins.</value>
		[DFeElement(TipoCampo.De2, "vCOFINS", Id = "W16", Min = 3, Max = 15, Ocorrencias = 1)]
		public decimal VCOFINS { get; set; }

		/// <summary>
		/// Gets or sets the vpisst.
		/// </summary>
		/// <value>The vpisst.</value>
		[DFeElement(TipoCampo.De2, "vPISST", Id = "W17", Min = 3, Max = 15, Ocorrencias = 1)]
		public decimal VPISST { get; set; }

		/// <summary>
		/// Gets or sets the vcofinsst.
		/// </summary>
		/// <value>The vcofinsst.</value>
		[DFeElement(TipoCampo.De2, "vCOFINSST", Id = "W18", Min = 3, Max = 15, Ocorrencias = 1)]
		public decimal VCOFINSST { get; set; }
	}
}
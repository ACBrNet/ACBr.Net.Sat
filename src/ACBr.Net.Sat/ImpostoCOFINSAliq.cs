// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-02-2016
// ***********************************************************************
// <copyright file="ImpostoCOFINSAliq.cs" company="ACBr.Net">
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
	/// Class ImpostoCOFINSAliq. This class cannot be inherited.
	/// </summary>
	/// <seealso cref="ACBr.Net.Sat.Interfaces.ICFeCOFINS" />
	[ImplementPropertyChanged]
	public sealed class ImpostoCOFINSAliq : ICFeCOFINS
	{
		#region Propriedades

		/// <summary>
		/// Gets or sets the CST.
		/// </summary>
		/// <value>The CST.</value>
		[DFeElement(TipoCampo.Str, "CST", Id = "S07", Min = 2, Max = 2, Ocorrencias = 1)]
		public string CST { get; set; }

		/// <summary>
		/// Gets or sets the v bc.
		/// </summary>
		/// <value>The v bc.</value>
		[DFeElement(TipoCampo.De2, "vBC", Id = "S08", Min = 3, Max = 15, Ocorrencias = 1)]
		public decimal VBc { get; set; }

		/// <summary>
		/// Gets or sets the pcofins.
		/// </summary>
		/// <value>The pcofins.</value>
		[DFeElement(TipoCampo.De4, "pCOFINS", Id = "S09", Min = 5, Max = 5, Ocorrencias = 1)]
		public decimal PCOFINS { get; set; }

		/// <summary>
		/// Gets or sets the vcofins.
		/// </summary>
		/// <value>The vcofins.</value>
		[DFeElement(TipoCampo.De2, "vCOFINS", Id = "S10", Min = 1, Max = 15, Ocorrencias = 1)]
		public decimal VCOFINS { get; set; }

		#endregion Propriedades

		#region Methods

		/// <summary>
		/// Shoulds the serialize vcofins.
		/// </summary>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		private bool ShouldSerializeVCOFINS()
		{
			return VCOFINS > 0;
		}

		#endregion Methods
	}
}
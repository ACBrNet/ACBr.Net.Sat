// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-05-2016
// ***********************************************************************
// <copyright file="ImpostoCOFINSST.cs" company="ACBr.Net">
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
	/// Class ImpostoCOFINSST. This class cannot be inherited.
	/// </summary>
	[ImplementPropertyChanged]
	public sealed class ImpostoCOFINSST
	{

		#region Propriedades

		/// <summary>
		/// Gets or sets the v bc.
		/// </summary>
		/// <value>The v bc.</value>
		[DFeElement(TipoCampo.De2, "vBC", Id = "T02", Min = 3, Max = 15, Ocorrencias = 1)]
		public decimal VBc { get; set; }

		/// <summary>
		/// Gets or sets the p COFINS.
		/// </summary>
		/// <value>The p COFINS.</value>
		[DFeElement(TipoCampo.De4, "pCOFINS", Id = "T03", Min = 5, Max = 5, Ocorrencias = 1)]
		public decimal PCOFINS { get; set; }

		/// <summary>
		/// Gets or sets the q bc product.
		/// </summary>
		/// <value>The q bc product.</value>
		[DFeElement(TipoCampo.De4, "qBCProd", Id = "T04", Min = 1, Max = 16, Ocorrencias = 1)]
		public decimal QBcProd { get; set; }

		/// <summary>
		/// Gets or sets the v aliq product.
		/// </summary>
		/// <value>The v aliq product.</value>
		[DFeElement(TipoCampo.De4, "vAliqProd", Id = "T05", Min = 5, Max = 15, Ocorrencias = 1)]
		public decimal VAliqProd { get; set; }
		/// <summary>
		/// Gets or sets the v COFINS.
		/// </summary>
		/// <value>The v COFINS.</value>
		[DFeElement(TipoCampo.De2, "vCOFINS", Id = "T06", Min = 1, Max = 15, Ocorrencias = 1)]
		public decimal VCOFINS { get; set; }

		#endregion Propriedades

		#region Methods

		/// <summary>
		/// Shoulds the serialize q bc product.
		/// </summary>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		private bool ShouldSerializeQBcProd()
		{
			return VAliqProd > 0;
		}

		/// <summary>
		/// Shoulds the serialize v aliq product.
		/// </summary>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		private bool ShouldSerializeVAliqProd()
		{
			return VAliqProd > 0;
		}

		/// <summary>
		/// Shoulds the serialize v bc.
		/// </summary>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		private bool ShouldSerializeVBc()
		{
			return VAliqProd == 0;
		}

		/// <summary>
		/// Shoulds the serialize pCOFINS.
		/// </summary>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		private bool ShouldSerializePCOFINS()
		{
			return VAliqProd == 0;
		}

		/// <summary>
		/// Shoulds the serialize vCOFINS.
		/// </summary>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		private bool ShouldSerializeVCOFINS()
		{
			return VCOFINS > 0;
		}

		#endregion Methods
	}
}
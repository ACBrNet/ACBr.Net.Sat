// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-02-2016
// ***********************************************************************
// <copyright file="ImpostoPISOutr.cs" company="ACBr.Net">
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
	/// Class ImpostoPISOutr. This class cannot be inherited.
	/// </summary>
	[ImplementPropertyChanged]
	public sealed class ImpostoPisOutr : ICFePis
	{
		#region Propriedades

		/// <summary>
		/// Gets or sets the Cst.
		/// </summary>
		/// <value>The Cst.</value>
		[DFeElement(TipoCampo.Str, "Cst", Id = "Q07", Min = 2, Max = 2, Ocorrencias = 1)]
		public string CST { get; set; }

		/// <summary>
		/// Gets or sets the q bc product.
		/// </summary>
		/// <value>The q bc product.</value>
		[DFeElement(TipoCampo.De4, "qBCProd", Id = "Q11", Min = 1, Max = 16, Ocorrencias = 1)]
		public decimal QBcProd { get; set; }

		/// <summary>
		/// Gets or sets the v aliq product.
		/// </summary>
		/// <value>The v aliq product.</value>
		[DFeElement(TipoCampo.De4, "vAliqProd", Id = "Q12", Min = 5, Max = 15, Ocorrencias = 1)]
		public decimal VAliqProd { get; set; }

		/// <summary>
		/// Gets or sets the v bc.
		/// </summary>
		/// <value>The v bc.</value>
		[DFeElement(TipoCampo.De2, "vBC", Id = "Q08", Min = 3, Max = 15, Ocorrencias = 1)]
		public decimal VBc { get; set; }

		/// <summary>
		/// Gets or sets the p pis.
		/// </summary>
		/// <value>The p pis.</value>
		[DFeElement(TipoCampo.De4, "pPIS", Id = "Q09", Min = 5, Max = 5, Ocorrencias = 1)]
		public decimal PPIS { get; set; }

		/// <summary>
		/// Gets or sets the v pis.
		/// </summary>
		/// <value>The v pis.</value>
		[DFeElement(TipoCampo.De2, "vPIS", Id = "Q10", Min = 1, Max = 15, Ocorrencias = 1)]
		public decimal VPIS { get; set; }

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
		/// Shoulds the serialize ppis.
		/// </summary>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		private bool ShouldSerializePPIS()
		{
			return VAliqProd == 0;
		}

		/// <summary>
		/// Shoulds the serialize vpis.
		/// </summary>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		private bool ShouldSerializeVPIS()
		{
			return VPIS > 0;
		}

		#endregion Methods
	}
}
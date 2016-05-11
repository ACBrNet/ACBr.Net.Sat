// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-02-2016
// ***********************************************************************
// <copyright file="ImpostoCOFINSQtde.cs" company="ACBr.Net">
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
	/// Class ImpostoCOFINSQtde. This class cannot be inherited.
	/// </summary>
	/// <seealso cref="ACBr.Net.Sat.Interfaces.ICFeCofins" />
	[ImplementPropertyChanged]
	public sealed class ImpostoCofinsQtde : ICFeCofins
	{
		#region Propriedades

		/// <summary>
		/// Gets or sets the Cst.
		/// </summary>
		/// <value>The Cst.</value>
		[DFeElement(TipoCampo.Str, "Cst", Id = "S07", Min = 2, Max = 2, Ocorrencias = 1)]
		public string CST { get; set; }

		/// <summary>
		/// Gets or sets the q bc product.
		/// </summary>
		/// <value>The q bc product.</value>
		[DFeElement(TipoCampo.De4, "qBCProd", Id = "S11", Min = 1, Max = 16, Ocorrencias = 1)]
		public decimal QBcProd { get; set; }

		/// <summary>
		/// Gets or sets the v aliq product.
		/// </summary>
		/// <value>The v aliq product.</value>
		[DFeElement(TipoCampo.De4, "vAliqProd", Id = "S12", Min = 5, Max = 15, Ocorrencias = 1)]
		public decimal VAliqProd { get; set; }

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
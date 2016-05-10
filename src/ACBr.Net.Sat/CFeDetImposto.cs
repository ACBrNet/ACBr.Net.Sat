// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 04-29-2016
// ***********************************************************************
// <copyright file="CFeDetImposto.cs" company="ACBr.Net">
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
	/// Class CFeDetImposto. This class cannot be inherited.
	/// </summary>
	[ImplementPropertyChanged]
	public sealed class CFeDetImposto
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="CFeDetImposto"/> class.
		/// </summary>
		public CFeDetImposto()
		{
			COFINSST = new ImpostoCOFINSST();
			COFINS = new ImpostoCOFINS();
			PISST = new ImpostoPISST();
			PIS = new ImpostoPIS();
		}

		#endregion Constructors

		#region Propriedades

		/// <summary>
		/// Gets or sets the v item12741.
		/// </summary>
		/// <value>The v item12741.</value>
		[DFeElement(TipoCampo.De2, "vItem12741", Id = "M02", Min = 3, Max = 15, Ocorrencias = 0)]
		public decimal VItem12741 { get; set; }

		/// <summary>
		/// Gets or sets the item.
		/// </summary>
		/// <value>The item.</value>
		[DFeItem(typeof(ImpostoICMS), "ICMS")]
		[DFeItem(typeof(ImpostoISSQN), "ISSQN")]
		public ICFeImposto Imposto { get; set; }

		/// <summary>
		/// Gets or sets the pis.
		/// </summary>
		/// <value>The pis.</value>
		[DFeElement("PIS", Id = "Q01", Ocorrencias = 1)]
		public ImpostoPIS PIS { get; set; }

		/// <summary>
		/// Gets or sets the pisst.
		/// </summary>
		/// <value>The pisst.</value>
		[DFeElement("PISST", Id = "R01", Ocorrencias = 1)]
		public ImpostoPISST PISST { get; set; }

		/// <summary>
		/// Gets or sets the cofins.
		/// </summary>
		/// <value>The cofins.</value>
		[DFeElement("COFINS", Id = "S01", Ocorrencias = 1)]
		public ImpostoCOFINS COFINS { get; set; }

		/// <summary>
		/// Gets or sets the cofinsst.
		/// </summary>
		/// <value>The cofinsst.</value>
		[DFeElement("COFINSST", Id = "T01", Ocorrencias = 1)]
		public ImpostoCOFINSST COFINSST { get; set; }

		#endregion Propriedades

		#region Methods

		private bool ShouldSerializeVItem12741()
		{
			return VItem12741 > 0;
		}

		private bool ShouldSerializeImposto()
		{
			if (Imposto is ImpostoISSQN)
			{
				var issqn = (ImpostoISSQN)Imposto;
				return issqn.VDeducISSQN > 0 || issqn.VBc > 0 ||
				       issqn.VAliq > 0 || issqn.VISSQN > 0;
			}

			return true;
		}

		private bool ShouldSerializePISST()
		{
			return PISST.PPIS > 0 || PISST.VBc > 0 ||
					   PISST.QBcProd > 0 || PISST.VPIS > 0;
		}

		private bool ShouldSerializeCOFINSST()
		{
			return COFINSST.PCOFINS > 0 || COFINSST.VBc > 0 ||
					   COFINSST.QBcProd > 0 || COFINSST.VCOFINS > 0;
		}

		#endregion Methods
	}
}
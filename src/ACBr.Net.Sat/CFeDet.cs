// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-27-2016
//
// Last Modified By : RFTD
// Last Modified On : 04-28-2016
// ***********************************************************************
// <copyright file="CFeDet.cs" company="ACBr.Net">
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
	/// Class CFeDet.
	/// </summary>
	[ImplementPropertyChanged]
	public class CFeDet
	{
		private CFe parent;

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="CFeDet"/> class.
		/// </summary>
		public CFeDet()
		{
			Imposto = new CFeDetImposto();
			Prod = new CFeDetProd();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CFeDet"/> class.
		/// </summary>
		public CFeDet(CFe parent) : this()
		{
			Parent = parent;
			Prod = new CFeDetProd(Parent);
		}

		#endregion Constructors

		#region Propriedades

		/// <summary>
		/// Gets the parent.
		/// </summary>
		/// <value>The parent.</value>
		[DFeIgnore]
		public CFe Parent
		{
			get { return parent; }
			internal set
			{
				parent = value;
				Prod.Parent = value;
			}
		}

		/// <summary>
		/// Gets or sets the n item.
		/// </summary>
		/// <value>The n item.</value>
		[DFeAttribute(TipoCampo.Int, "nItem", Id = "H02", Min = 1, Max = 3, Ocorrencias = 1)]
		public int NItem { get; set; }

		/// <summary>
		/// Gets or sets the product.
		/// </summary>
		/// <value>The product.</value>
		[DFeElement("prod", Id = "I01", Ocorrencias = 1)]
		public CFeDetProd Prod { get; set; }

		/// <summary>
		/// Gets or sets the imposto.
		/// </summary>
		/// <value>The imposto.</value>
		[DFeElement("imposto", Id = "M01", Ocorrencias = 1)]
		public CFeDetImposto Imposto { get; set; }

		/// <summary>
		/// Gets or sets the inf ad product.
		/// </summary>
		/// <value>The inf ad product.</value>
		[DFeElement(TipoCampo.Str, "infAdProd", Id = "V01", Min = 1, Max = 500, Ocorrencias = 0)]
		public string InfAdProd { get; set; }

		#endregion Propriedades

	}
}
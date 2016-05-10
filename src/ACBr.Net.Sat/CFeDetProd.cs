// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-23-2016
//
// Last Modified By : RFTD
// Last Modified On : 04-29-2016
// ***********************************************************************
// <copyright file="CFeDetProd.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Globalization;
using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Collection;
using ACBr.Net.DFe.Core.Serializer;
using PropertyChanged;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Class CFeDetProd. This class cannot be inherited.
	/// </summary>
	[ImplementPropertyChanged]
	public sealed class CFeDetProd
    {
		#region Fields

		private bool ehConbustivel;

		#endregion Fields

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="CFeDetProd"/> class.
		/// </summary>
		public CFeDetProd()
		{
			ObsFiscoDet = new DFeCollection<ProdObsFisco>();
			EhCombustivel = false;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CFeDetProd"/> class.
		/// </summary>
		public CFeDetProd(CFe parent):this()
        {
			Parent = parent;
        }

		#endregion Constructors

		#region Propriedades

		/// <summary>
		/// Gets the parent.
		/// </summary>
		/// <value>The parent.</value>
		[DFeIgnore]
		public CFe Parent { get; internal set; }

		/// <summary>
		/// Gets or sets a value indicating whether [eh combustivel].
		/// </summary>
		/// <value><c>true</c> if [eh combustivel]; otherwise, <c>false</c>.</value>
		[DFeIgnore]
		public bool EhCombustivel {
			get { return ehConbustivel; }
			set
			{
				if (value == ehConbustivel)
					return;

				IndRegra = value ? IndRegra.Truncamento : IndRegra.Arredondamento;
				ehConbustivel = value;
			}
		}

		/// <summary>
		/// Gets or sets the c product.
		/// </summary>
		/// <value>The c product.</value>
		[DFeElement(TipoCampo.Str, "cProd", Id = "I02", Min = 1, Max = 60, Ocorrencias = 1)]
		public string CProd { get; set; }

		/// <summary>
		/// Gets or sets the c ean.
		/// </summary>
		/// <value>The c ean.</value>
		[DFeElement(TipoCampo.Str, "cEAN", Id = "I03", Min = 8, Max = 14, Ocorrencias = 0)]
		public string CEAN { get; set; }

		/// <summary>
		/// Gets or sets the x product.
		/// </summary>
		/// <value>The x product.</value>
		[DFeElement(TipoCampo.Str, "xProd", Id = "I04", Min = 1, Max = 120, Ocorrencias = 1)]
		public string XProd { get; set; }

		/// <summary>
		/// Gets or sets the NCM.
		/// </summary>
		/// <value>The NCM.</value>
		[DFeElement(TipoCampo.Str, "NCM", Id = "I05", Min = 2, Max = 8, Ocorrencias = 0)]
		public string NCM { get; set; }

		/// <summary>
		/// Gets or sets the cest.
		/// </summary>
		/// <value>The cest.</value>
		[DFeElement(TipoCampo.Str, "CEST", Id = "I05w", Min = 2, Max = 7, Ocorrencias = 0)]
		public string CEST { get; set; }

		/// <summary>
		/// Gets or sets the cfop.
		/// </summary>
		/// <value>The cfop.</value>
		[DFeElement(TipoCampo.StrNumberFill, "CFOP", Id = "I06", Min =41, Max = 4, Ocorrencias = 1)]
		public string CFOP { get; set; }

		/// <summary>
		/// Gets or sets the u COM.
		/// </summary>
		/// <value>The u COM.</value>
		[DFeElement(TipoCampo.Str, "uCom", Id = "I07", Min = 1, Max = 6, Ocorrencias = 1)]
		public string UCom { get; set; }

		/// <summary>
		/// Gets or sets the q COM.
		/// </summary>
		/// <value>The q COM.</value>
		[DFeElement(TipoCampo.De4, "qCom", Id = "I08", Min = 5, Max = 15, Ocorrencias = 1)]
		public decimal QCom { get; set; }

		/// <summary>
		/// Gets or sets the v un COM.
		/// </summary>
		/// <value>The v un COM.</value>
		[DFeElement(TipoCampo.Custom, "vUnCom", Id = "I09", Min = 3, Max = 15, Ocorrencias = 1)]
		public decimal VUnCom { get; set; }

		/// <summary>
		/// Gets or sets the v product.
		/// </summary>
		/// <value>The v product.</value>
		[DFeElement(TipoCampo.De2, "vProd", Id = "I10", Min = 3, Max = 15, Ocorrencias = 1)]
		public decimal VProd { get; set; }

		/// <summary>
		/// Gets or sets the ind regra.
		/// </summary>
		/// <value>The ind regra.</value>
		[DFeElement(TipoCampo.Enum, "indRegra", Id = "I11", Min = 1, Max = 1, Ocorrencias = 1)]
		public IndRegra IndRegra { get; set; }

		/// <summary>
		/// Gets or sets the v desc.
		/// </summary>
		/// <value>The v desc.</value>
		[DFeElement(TipoCampo.De2, "vDesc", Id = "I12", Min = 3, Max = 15, Ocorrencias = 0)]
		public decimal VDesc { get; set; }

		/// <summary>
		/// Gets or sets the v outro.
		/// </summary>
		/// <value>The v outro.</value>
		[DFeElement(TipoCampo.De2, "vOutro", Id = "I13", Min = 3, Max = 15, Ocorrencias = 0)]
		public decimal VOutro { get; set; }

		/// <summary>
		/// Gets or sets the v item.
		/// </summary>
		/// <value>The v item.</value>
		[DFeElement(TipoCampo.De2, "vItem", Id = "I14", Min = 3, Max = 15, Ocorrencias = 1)]
		public decimal VItem { get; set; }

		/// <summary>
		/// Gets or sets the v rat desc.
		/// </summary>
		/// <value>The v rat desc.</value>
		[DFeElement(TipoCampo.De2, "vRatDesc", Id = "I15", Min = 3, Max = 15, Ocorrencias = 0)]
		public decimal VRatDesc { get; set; }

		/// <summary>
		/// Gets or sets the v rat acr.
		/// </summary>
		/// <value>The v rat acr.</value>
		[DFeElement(TipoCampo.De2, "vRatAcr", Id = "I16", Min = 3, Max = 15, Ocorrencias = 0)]
		public decimal VRatAcr { get; set; }

		/// <summary>
		/// Gets or sets the obs fisco det.
		/// </summary>
		/// <value>The obs fisco det.</value>
		[DFeElement("obsFiscoDet", Id = "I18", Min = 0, Max = 500, Ocorrencias = 0)]
		public DFeCollection<ProdObsFisco> ObsFiscoDet { get; set; }

		#endregion Propriedades

		#region Methods

		private bool ShouldSerializeCEST()
		{
			return Parent != null && Parent.InfCFe.Ide.DEmi.Year > 2016;
		}

		private bool ShouldSerializeVProd()
		{
			return VProd > 0;
		}

		private bool ShouldSerializeVItem()
		{
			return VItem > 0;
		}

		private bool ShouldSerializeVRatDesc()
		{
			return VRatDesc > 0;
		}

		private bool ShouldSerializeVRatAcr()
		{
			return VRatAcr > 0;
		}

		private bool ShouldSerializeVDesc()
		{
			return VDesc > 0;
		}

		private bool ShouldSerializeVOutro()
		{
			return VOutro > 0;
		}

		private string SerializeVUnCom()
		{
			var numberFormat = CultureInfo.InvariantCulture.NumberFormat;
			var format = ehConbustivel ? "{0:0.000}" : "{0:0.00}";
			return string.Format(numberFormat, format, VUnCom);
		}

		private object DeserializeVUnCom(string value)
		{
			var decimais = value.Split('.')[1];
			EhCombustivel = decimais.Length > 2;
			var numberFormat = CultureInfo.InvariantCulture.NumberFormat;
			return decimal.Parse(value, numberFormat);
		}

		#endregion Methods
	}
}

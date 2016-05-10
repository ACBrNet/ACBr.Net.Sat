// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-23-2016
//
// Last Modified By : RFTD
// Last Modified On : 04-23-2016
// ***********************************************************************
// <copyright file="CFeIde.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using ACBr.Net.Core.Extensions;
using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Serializer;
using PropertyChanged;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Class CFeIde. This class cannot be inherited.
	/// </summary>
	[ImplementPropertyChanged]
	public sealed class CFeIde
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="CFeIde"/> class.
		/// </summary>
		public CFeIde()
		{
			DhEmissao = null;
		}

		#endregion Constructors

		#region Propriedades

		/// <summary>
		/// Gets or sets the c uf.
		/// </summary>
		/// <value>The c uf.</value>
		[DFeElement(TipoCampo.Int, "cUF", Id  = "B02", Min = 2, Max = 2, Ocorrencias = 0)]
		public int UF { get; set; }

		/// <summary>
		/// Gets or sets the c nf.
		/// </summary>
		/// <value>The c nf.</value>
		[DFeElement(TipoCampo.Int, "cNF", Id = "B03", Min = 6, Max = 6, Ocorrencias = 0)]
		public int CNf { get; set; }

		/// <summary>
		/// Gets or sets the modelo.
		/// </summary>
		/// <value>The modelo.</value>
		[DFeElement(TipoCampo.Int, "mod", Id = "B04", Min = 6, Max = 6, Ocorrencias = 0)]
		public int Modelo { get; set; }

		/// <summary>
		/// Gets or sets the nserie sat.
		/// </summary>
		/// <value>The nserie sat.</value>
		[DFeElement(TipoCampo.Int, "nserieSAT", Id = "B05", Min = 9, Max = 9, Ocorrencias = 0)]
		public int NSerieSAT { get; set; }

		/// <summary>
		/// Gets or sets the n c fe.
		/// </summary>
		/// <value>The n c fe.</value>
		[DFeElement(TipoCampo.Int, "nCFe", Id = "B06", Min = 6, Max = 6, Ocorrencias = 0)]
		public int NCFe { get; set; }

		/// <summary>
		/// A data e a hora da emissão na CFe
		/// </summary>
		/// <value>The dh emissao.</value>
		[DFeIgnore]
		public DateTime? DhEmissao { get; set; }

		/// <summary>
		/// Gets or sets the d emi.
		/// </summary>
		/// <value>The d emi.</value>
		[DFeElement(TipoCampo.DatCFe, "dEmi", Id = "B07", Min = 8, Max = 8, Ocorrencias = 0)]
		public DateTime DEmi
		{
			get { return DhEmissao ?? DateTime.MinValue; }
			set
			{
				DhEmissao = value.Date + (DhEmissao?.TimeOfDay ?? DateTime.MinValue.TimeOfDay);
			}
		}

		/// <summary>
		/// Gets or sets the h emi.
		/// </summary>
		/// <value>The h emi.</value>
		[DFeElement(TipoCampo.HorCFe, "hEmi", Id = "B08", Min = 6, Max = 6, Ocorrencias = 0)]
		public DateTime HEmi
		{
			get { return DhEmissao ?? DateTime.MinValue; }
			set
			{
				DhEmissao = (DhEmissao?.Date ?? DateTime.MinValue.Date) + value.TimeOfDay;
			}
		}

		/// <summary>
		/// Gets or sets the c dv.
		/// </summary>
		/// <value>The c dv.</value>
		[DFeElement(TipoCampo.Int, "cDV", Id = "B09", Min = 1, Max = 1, Ocorrencias = 0)]
		public int CDv { get; set; }

		/// <summary>
		/// Gets or sets the tp amb.
		/// </summary>
		/// <value>The tp amb.</value>
		[DFeElement(TipoCampo.Enum, "tpAmb", Id = "B10", Min = 1, Max = 1, Ocorrencias = 0)]
		public TipoAmbiente TpAmb { get; set; }

		/// <summary>
		/// Gets or sets the CNPJ.
		/// </summary>
		/// <value>The CNPJ.</value>
		[DFeElement(TipoCampo.StrNumberFill, "CNPJ", Id = "B11", Min = 14, Max = 14, Ocorrencias = 1)]
		public string CNPJ { get; set; }

		/// <summary>
		/// Gets or sets the sign ac.
		/// </summary>
		/// <value>The sign ac.</value>
		[DFeElement(TipoCampo.Str, "signAC", Id = "B12", Min = 1, Max = 344, Ocorrencias = 1)]
		public string SignAC { get; set; }

		/// <summary>
		/// Gets or sets the assinatura qrcode.
		/// </summary>
		/// <value>The assinatura qrcode.</value>
		[DFeElement(TipoCampo.Str, "assinaturaQRCODE", Id = "B13", Min = 344, Max = 344, Ocorrencias = 1)]
		public string AssinaturaQrcode { get; set; }

		/// <summary>
		/// Gets or sets the numero caixa.
		/// </summary>
		/// <value>The numero caixa.</value>
		[DFeElement(TipoCampo.Int, "numeroCaixa", Id = "B14", Min = 3, Max = 3, Ocorrencias = 1)]
		public int NumeroCaixa { get; set; }

		#endregion Propriedades

		#region Methods

		private bool ShouldSerializeUF()
		{
			return UF > 0;
		}

		private bool ShouldSerializeCNf()
		{
			return CNf > 0;
		}

		private bool ShouldSerializeModelo()
		{
			return Modelo > 0;
		}

		private bool ShouldSerializeNSerieSAT()
		{
			return NSerieSAT > 0;
		}

		private bool ShouldSerializeNCFe()
		{
			return NCFe > 0;
		}

		private bool ShouldSerializeDEmi()
		{
			return DhEmissao.HasValue;
		}

		private bool ShouldSerializeHEmi()
		{
			return DhEmissao.HasValue;
		}

		private bool ShouldSerializeCDv()
		{
			return CDv > 0;
		}

		private bool ShouldSerializeTpAmb()
		{
			return DhEmissao.HasValue;
		}

		private bool ShouldSerializeAssinaturaQrcode()
		{
			return !AssinaturaQrcode.IsEmpty();
		}

		#endregion Methods
	}
}
// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-02-2016
// ***********************************************************************
// <copyright file="CFePgto.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Collection;
using ACBr.Net.DFe.Core.Serializer;
using PropertyChanged;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Class CFePgto. This class cannot be inherited.
	/// </summary>
	[ImplementPropertyChanged]
	public sealed class CFePgto
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="CFePgto"/> class.
		/// </summary>
		public CFePgto()
		{
			Pagamentos = new DFeCollection<CFePgtoMp>();
		}

		#endregion Constructors

		#region Propriedades

		/// <summary>
		/// Gets or sets the pagamentos.
		/// </summary>
		/// <value>The pagamentos.</value>
		[DFeElement("MP", Id = "WA02", Min = 1, Max = 50, Ocorrencias = 1)]
		public DFeCollection<CFePgtoMp> Pagamentos { get; set; }

		/// <summary>
		/// Gets or sets the v troco.
		/// </summary>
		/// <value>The v troco.</value>
		[DFeElement(TipoCampo.De2, "vTroco", Id = "WA06", Min = 3, Max = 15, Ocorrencias = 1)]
		public decimal VTroco { get; set; }

		#endregion Propriedades

		#region Methods

		private bool ShouldSerializeVTroco()
		{
			return VTroco > 0;
		}

		#endregion Methods
	}
}
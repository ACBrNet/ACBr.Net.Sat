// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-02-2016
// ***********************************************************************
// <copyright file="CFeTotalDescAcr.cs" company="ACBr.Net">
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
	/// Class CFeTotalDescAcr. This class cannot be inherited.
	/// </summary>
	[ImplementPropertyChanged]
	public sealed class CFeTotalDescAcr
	{
		#region Propriedades

		/// <summary>
		/// Gets or sets the v desc subtot.
		/// </summary>
		/// <value>The v desc subtot.</value>
		[DFeElement(TipoCampo.De2, "vDescSubtot", Id = "W20", Min = 3, Max = 15, Ocorrencias = 0)]
		public decimal VDescSubtot { get; set; }

		/// <summary>
		/// Gets or sets the v acres subtot.
		/// </summary>
		/// <value>The v acres subtot.</value>
		[DFeElement(TipoCampo.De2, "vAcresSubtot", Id = "W21", Min = 3, Max = 15, Ocorrencias = 0)]
		public decimal VAcresSubtot { get; set; }

		#endregion Propriedades

		#region Methods

		private bool ShouldSerializeVDescSubtot()
		{
			return VDescSubtot > 0;
		}

		private bool ShouldSerializeVAcresSubtot()
		{
			return VAcresSubtot > 0;
		}

		#endregion Methods
	}
}
// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 04-29-2016
// ***********************************************************************
// <copyright file="CFeEntrega.cs" company="ACBr.Net">
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
	/// Class CFeEntrega. This class cannot be inherited.
	/// </summary>
	[ImplementPropertyChanged]
	public sealed class CFeEntrega
	{
		#region Propriedades

		/// <summary>
		/// Gets or sets the x LGR.
		/// </summary>
		/// <value>The x LGR.</value>
		[DFeElement(TipoCampo.Str, "xLgr", Id = "G02", Min = 2, Max = 60, Ocorrencias = 1)]
		public string XLgr { get; set; }

		/// <summary>
		/// Gets or sets the nro.
		/// </summary>
		/// <value>The nro.</value>
		[DFeElement(TipoCampo.Str, "nro", Id = "G03", Min = 1, Max = 60, Ocorrencias = 1)]
		public string Nro { get; set; }

		/// <summary>
		/// Gets or sets the x CPL.
		/// </summary>
		/// <value>The x CPL.</value>
		[DFeElement(TipoCampo.Str, "xCpl", Id = "G04", Min = 1, Max = 60, Ocorrencias = 0)]
		public string XCpl { get; set; }

		/// <summary>
		/// Gets or sets the x bairro.
		/// </summary>
		/// <value>The x bairro.</value>
		[DFeElement(TipoCampo.Str, "xBairro", Id = "G05", Min = 1, Max = 60, Ocorrencias = 1)]
		public string XBairro { get; set; }

		/// <summary>
		/// Gets or sets the x mun.
		/// </summary>
		/// <value>The x mun.</value>
		[DFeElement(TipoCampo.Str, "xMun", Id = "G06", Min = 2, Max = 60, Ocorrencias = 1)]
		public string XMun { get; set; }

		/// <summary>
		/// Gets or sets the uf.
		/// </summary>
		/// <value>The uf.</value>
		[DFeElement(TipoCampo.Str, "UF", Id = "G07", Min = 2, Max = 2, Ocorrencias = 1)]
		public string UF { get; set; }

		#endregion Propriedades

		#region Methods
		#endregion Methods
	}
}
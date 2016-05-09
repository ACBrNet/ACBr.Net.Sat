// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 04-30-2016
// ***********************************************************************
// <copyright file="ProdObsFisco.cs" company="ACBr.Net">
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
	/// Class ProdObsFisco. This class cannot be inherited.
	/// </summary>
	[ImplementPropertyChanged]
	public sealed class ProdObsFisco
	{
		/// <summary>
		/// Gets or sets the x campo det.
		/// </summary>
		/// <value>The x campo det.</value>
		[DFeAttribute("xCampoDet", Id = "I18A", Min = 1, Max = 60, Ocorrencias = 1)]
		public string XCampoDet { get; set; }

		/// <summary>
		/// Gets or sets the x texto det.
		/// </summary>
		/// <value>The x texto det.</value>
		[DFeElement(TipoCampo.Str, "xTextoDet", Id = "I19", Min = 1, Max = 60, Ocorrencias = 1)]
		public string XTextoDet { get; set; }
	}
}
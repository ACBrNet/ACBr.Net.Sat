// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-02-2016
// ***********************************************************************
// <copyright file="InfAdicObsFisco.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using ACBr.Net.DFe.Core.Attributes;
using PropertyChanged;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Class InfAdicObsFisco. This class cannot be inherited.
	/// </summary>
	[ImplementPropertyChanged]
	public sealed class InfAdicObsFisco
	{
		/// <summary>
		/// Gets or sets the x campo.
		/// </summary>
		/// <value>The x campo.</value>
		[DFeAttribute("xCampo", Id = "Z04", Min = 1, Max = 20, Ocorrencias = 1)]
		public string XCampo { get; set; }

		/// <summary>
		/// Gets or sets the x texto.
		/// </summary>
		/// <value>The x texto.</value>
		[DFeAttribute("xTexto", Id = "Z05", Min = 1, Max = 60, Ocorrencias = 1)]
		public string XTexto { get; set; }
	}
}
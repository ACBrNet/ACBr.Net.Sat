// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-02-2016
// ***********************************************************************
// <copyright file="ImpostoCOFINSNT.cs" company="ACBr.Net">
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
	/// Class ImpostoCOFINSNT. This class cannot be inherited.
	/// </summary>
	/// <seealso cref="ACBr.Net.Sat.Interfaces.ICFeCOFINS" />
	[ImplementPropertyChanged]
	public sealed class ImpostoCOFINSNT : ICFeCOFINS
	{
		/// <summary>
		/// Gets or sets the CST.
		/// </summary>
		/// <value>The CST.</value>
		[DFeElement(TipoCampo.Str, "CST", Id = "S07", Min = 2, Max = 2, Ocorrencias = 1)]
		public string CST { get; set; }
	}
}
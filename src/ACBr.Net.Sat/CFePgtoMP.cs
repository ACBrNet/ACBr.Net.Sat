// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-02-2016
// ***********************************************************************
// <copyright file="CFePgtoMP.cs" company="ACBr.Net">
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
	/// Class CFePgtoMp. This class cannot be inherited.
	/// </summary>
	[ImplementPropertyChanged]
	public sealed class CFePgtoMp
	{
		#region Properties

		/// <summary>
		/// Gets or sets the c mp.
		/// </summary>
		/// <value>The c mp.</value>
		[DFeElement(TipoCampo.Enum, "cMP", Id = "WA04", Min = 2, Max = 2, Ocorrencias = 0)]
		public CodigoMP CMp { get; set; }

		/// <summary>
		/// Gets or sets the v mp.
		/// </summary>
		/// <value>The v mp.</value>
		[DFeElement(TipoCampo.De2, "vMP", Id = "WA05", Min = 3, Max = 15, Ocorrencias = 1)]
		public decimal VMp { get; set; }

		/// <summary>
		/// Gets or sets the c adm c.
		/// </summary>
		/// <value>The c adm c.</value>
		[DFeElement(TipoCampo.Int, "cAdmC", Id = "WA06", Min = 3, Max = 3, Ocorrencias = 0)]
		public int? CAdmC { get; set; }

		#endregion Properties

		#region Methods

		private bool ShouldSerializeCAdmC()
		{
			return CAdmC != null;
		}

		#endregion Methods
	}
}
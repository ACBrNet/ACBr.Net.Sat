// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-02-2016
// ***********************************************************************
// <copyright file="CFeInfAdic.cs" company="ACBr.Net">
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
	/// Class CFeInfAdic. This class cannot be inherited.
	/// </summary>
	[ImplementPropertyChanged]
	public sealed class CFeInfAdic
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="CFeInfAdic"/> class.
		/// </summary>
		public CFeInfAdic()
		{
			ObsFisco = new DFeCollection<InfAdicObsFisco>();
		}

		#endregion Constructors

		#region Propriedades

		/// <summary>
		/// Gets or sets the inf CPL.
		/// </summary>
		/// <value>The inf CPL.</value>
		[DFeElement(TipoCampo.Str, "infCpl", Id = "Z02", Min = 1, Max = 5000, Ocorrencias = 0)]
		public string InfCpl { get; set; }

		/// <summary>
		/// Gets or sets the obs fisco.
		/// </summary>
		/// <value>The obs fisco.</value>
		[DFeElement("obsFisco", Id = "Z03", Min = 0, Max = 10, Ocorrencias = 0)]
		public DFeCollection<InfAdicObsFisco> ObsFisco { get; set; }

		#endregion Propriedades
	}
}
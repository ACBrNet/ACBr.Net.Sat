// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 04-29-2016
// ***********************************************************************
// <copyright file="CFeDest.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using ACBr.Net.Core.Extensions;
using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Serializer;
using PropertyChanged;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Class CFeDest.
	/// </summary>
	[ImplementPropertyChanged]
	public sealed class CFeDest
	{
		#region Propriedades

		/// <summary>
		/// Gets or sets the CPF.
		/// </summary>
		/// <value>The CPF.</value>
		[DFeElement(TipoCampo.StrNumberFill, "CPF", Id = "E02", Min = 11, Max = 11, Ocorrencias = 0)]
		public string CPF { get; set; }

		/// <summary>
		/// Gets or sets the CNPJ.
		/// </summary>
		/// <value>The CNPJ.</value>
		[DFeElement(TipoCampo.StrNumberFill, "CNPJ", Id = "E03", Min = 14, Max = 14, Ocorrencias = 0)]
		public string CNPJ { get; set; }

		/// <summary>
		/// Gets or sets the x nome.
		/// </summary>
		/// <value>The x nome.</value>
		[DFeElement(TipoCampo.Str, "xNome", Id = "E04", Min = 1, Max = 60, Ocorrencias = 0)]
		public string Nome { get; set; }

		#endregion Propriedades

		#region Methods

		private bool ShouldSerializeCPF()
		{
			return !CNPJ.IsEmpty();
		}

		private bool ShouldSerializeCNPJ()
		{
			return !CPF.IsEmpty();
		}

		#endregion Methods
	}
}
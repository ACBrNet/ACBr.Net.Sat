// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-23-2016
//
// Last Modified By : RFTD
// Last Modified On : 04-28-2016
// ***********************************************************************
// <copyright file="CFeEmit.cs" company="ACBr.Net">
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
	/// Class CFeEmit. This class cannot be inherited.
	/// </summary>
	[ImplementPropertyChanged]
	public sealed class CFeEmit
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="CFeEmit"/> class.
		/// </summary>
		public CFeEmit()
		{
			EnderEmit = new CFeEnderEmit();
		}

		#endregion Constructors

		#region Propriedades

		/// <summary>
		/// Gets or sets the CNPJ.
		/// </summary>
		/// <value>The CNPJ.</value>
		[DFeElement(TipoCampo.StrNumberFill, "CNPJ", Id = "C02", Min = 14, Max = 14, Ocorrencias = 1)]
		public string CNPJ { get; set; }

		/// <summary>
		/// Gets or sets the x nome.
		/// </summary>
		/// <value>The x nome.</value>
		[DFeElement(TipoCampo.Str, "xNome", Id = "C03", Min = 1, Max = 60, Ocorrencias = 0)]
		public string XNome { get; set; }

		/// <summary>
		/// Gets or sets the x fant.
		/// </summary>
		/// <value>The x fant.</value>
		[DFeElement(TipoCampo.Str, "xFant", Id = "C04", Min = 1, Max = 60, Ocorrencias = 0)]
		public string XFant { get; set; }

		/// <summary>
		/// Gets the ender emit.
		/// </summary>
		/// <value>The ender emit.</value>
		[DFeElement("enderEmit", Id = "C05", Ocorrencias = 0)]
		public CFeEnderEmit EnderEmit { get; set; }

		/// <summary>
		/// Gets or sets the ie.
		/// </summary>
		/// <value>The ie.</value>
		[DFeElement(TipoCampo.Str, "IE", Id = "C12", Min = 2, Max = 14, Ocorrencias = 0)]
		public string IE { get; set; }

		/// <summary>
		/// Gets or sets the im.
		/// </summary>
		/// <value>The im.</value>
		[DFeElement(TipoCampo.Str, "IM", Id = "C13", Min = 1, Max = 15, Ocorrencias = 0)]
		public string IM { get; set; }

		/// <summary>
		/// Gets or sets the c reg trib.
		/// </summary>
		/// <value>The c reg trib.</value>
		[DFeElement(TipoCampo.Enum, "cRegTrib", Id = "C14", Min = 1, Max = 1, Ocorrencias = 0)]
		public RegTrib? CRegTrib { get; set; }

		/// <summary>
		/// Gets or sets the c reg trib issqn.
		/// </summary>
		/// <value>The c reg trib issqn.</value>
		[DFeElement(TipoCampo.Enum, "cRegTribISSQN", Id = "C15", Min = 1, Max = 1, Ocorrencias = 1)]
		public RegTribIssqn CRegTribISSQN { get; set; }

		/// <summary>
		/// Gets or sets the ind rat issqn.
		/// </summary>
		/// <value>The ind rat issqn.</value>
		[DFeElement(TipoCampo.Enum, "indRatISSQN", Id = "C16", Min = 1, Max = 1, Ocorrencias = 1)]
		public RatIssqn IndRatISSQN { get; set; }

		#endregion Propriedades

		#region Methods

		private bool ShouldSerializeNome()
		{
			return !XNome.IsEmpty();
		}

		private bool ShouldSerializeFant()
		{
			return !XFant.IsEmpty();
		}

		private bool ShouldSerializeEnderEmit()
		{
			return !EnderEmit.CEP.IsEmpty() ||
				   !EnderEmit.Nro.IsEmpty() ||
				   !EnderEmit.XBairro.IsEmpty() ||
				   !EnderEmit.XCpl.IsEmpty() ||
				   !EnderEmit.XLgr.IsEmpty() ||
				   !EnderEmit.XMun.IsEmpty();
		}

		private bool ShouldSerializeCRegTrib()
		{
			return CRegTrib != null;
		}

		private bool ShouldSerializeIE()
		{
			return !IE.IsEmpty();
		}

		private bool ShouldSerializeIM()
		{
			return !IM.IsEmpty();
		}

		private bool ShouldSerializeCRegTribISSQN()
		{
			return !IM.IsEmpty() && CRegTribISSQN != RegTribIssqn.Nenhum;
		}

		#endregion Methods
	}
}
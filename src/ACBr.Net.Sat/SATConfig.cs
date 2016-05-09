// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 03-31-2016
//
// Last Modified By : RFTD
// Last Modified On : 03-31-2016
// ***********************************************************************
// <copyright file="SATConfig.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ACBr.Net.Sat
{
	/// <summary>
	/// Class SATConfig. This class cannot be inherited.
	/// </summary>
	public sealed class SATConfig
	{
		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="SATConfig"/> class.
		/// </summary>
		internal SATConfig()
		{
			InfCFeVersaoDadosEnt = 0.06M;
			IdeCNPJ = @"11111111111111";
			IdeNumeroCaixa = 1;
			IdeTpAmb = TipoAmbiente.Homologacao;
			EmitCNPJ = @"11111111111111";
			EmitIE = string.Empty;
			EmitIM = string.Empty;
			EmitCRegTrib = RegTrib.Normal;
			EmitCRegTribISSQN = RegTribISSQN.Nenhum;
			EmitIndRatISSQN = RatISSQN.Nao;
			IsUtf8 = false;
			PaginaDeCodigo = string.Empty;
		}

		#endregion Constructor

		#region Propriedades

		/// <summary>
		/// Gets or sets the inf c fe versao dados ent.
		/// </summary>
		/// <value>The inf c fe versao dados ent.</value>
		public decimal InfCFeVersaoDadosEnt { get; set; }

		/// <summary>
		/// Gets or sets the IDE CNPJ.
		/// </summary>
		/// <value>The IDE CNPJ.</value>
		public string IdeCNPJ { get; set; }

		/// <summary>
		/// Gets or sets the IDE numero caixa.
		/// </summary>
		/// <value>The IDE numero caixa.</value>
		public int IdeNumeroCaixa { get; set; }

		/// <summary>
		/// Gets or sets the ide_tp amb.
		/// </summary>
		/// <value>The ide_tp amb.</value>
		public TipoAmbiente IdeTpAmb { get; set; }

		/// <summary>
		/// Gets or sets the emit_ CNPJ.
		/// </summary>
		/// <value>The emit_ CNPJ.</value>
		public string EmitCNPJ { get; set; }

		/// <summary>
		/// Gets or sets the emit_ ie.
		/// </summary>
		/// <value>The emit_ ie.</value>
		public string EmitIE { get; set; }

		/// <summary>
		/// Gets or sets the emit_ im.
		/// </summary>
		/// <value>The emit_ im.</value>
		public string EmitIM { get; set; }

		/// <summary>
		/// Gets or sets the emit_c reg trib.
		/// </summary>
		/// <value>The emit_c reg trib.</value>
		public RegTrib EmitCRegTrib { get; set; }

		/// <summary>
		/// Gets or sets the emit_c reg trib issqn.
		/// </summary>
		/// <value>The emit_c reg trib issqn.</value>
		public RegTribISSQN EmitCRegTribISSQN { get; set; }

		/// <summary>
		/// Gets or sets the emit_ind rat issqn.
		/// </summary>
		/// <value>The emit_ind rat issqn.</value>
		public RatISSQN EmitIndRatISSQN { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance is ut f8.
		/// </summary>
		/// <value><c>true</c> if this instance is ut f8; otherwise, <c>false</c>.</value>
		public bool IsUtf8 { get; set; }

		/// <summary>
		/// Gets or sets the pagina de codigo.
		/// </summary>
		/// <value>The pagina de codigo.</value>
		public string PaginaDeCodigo { get; set; }

		#endregion Propriedades
	}
}
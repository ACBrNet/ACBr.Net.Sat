// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 03-31-2016
//
// Last Modified By : RFTD
// Last Modified On : 03-31-2016
// ***********************************************************************
// <copyright file="SATConfig.cs" company="ACBr.Net">
//		        		   The MIT License (MIT)
//	     		    Copyright (c) 2016 Grupo ACBr.Net
//
//	 Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//	 The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//	 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
// </copyright>
// <summary></summary>
// ***********************************************************************

using ACBr.Net.DFe.Core.Common;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Class SATConfig. This class cannot be inherited.
	/// </summary>
	public sealed class SatConfig
	{
		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="SatConfig"/> class.
		/// </summary>
		internal SatConfig()
		{
			InfCFeVersaoDadosEnt = 0.06M;
			IdeCNPJ = @"11111111111111";
			IdeNumeroCaixa = 1;
			IdeTpAmb = TipoAmbiente.Homologacao;
			EmitCNPJ = @"11111111111111";
			EmitIE = string.Empty;
			EmitIM = string.Empty;
			EmitCRegTrib = RegTrib.Normal;
			EmitCRegTribISSQN = RegTribIssqn.Nenhum;
			EmitIndRatISSQN = RatIssqn.Nao;
			IsUtf8 = false;
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
		public RegTribIssqn EmitCRegTribISSQN { get; set; }

		/// <summary>
		/// Gets or sets the emit_ind rat issqn.
		/// </summary>
		/// <value>The emit_ind rat issqn.</value>
		public RatIssqn EmitIndRatISSQN { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance is ut f8.
		/// </summary>
		/// <value><c>true</c> if this instance is ut f8; otherwise, <c>false</c>.</value>
		public bool IsUtf8 { get; set; }

		/// <summary>
		/// Gets or sets the pagina de codigo.
		/// </summary>
		/// <value>The pagina de codigo.</value>
		public bool RemoverAcentos { get; set; }

		#endregion Propriedades
	}
}
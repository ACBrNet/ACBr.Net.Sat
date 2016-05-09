// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 05-07-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-07-2016
// ***********************************************************************
// <copyright file="OrigemMercadoria.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using ACBr.Net.DFe.Core.Attributes;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Enum OrigemMercadoria
	/// </summary>
	public enum OrigemMercadoria
	{
		/// <summary>
		/// The nacional
		/// </summary>
		[DFeEnum("0")]
		Nacional,
		/// <summary>
		/// The estrangeira importacao direta
		/// </summary>
		[DFeEnum("1")]
		EstrangeiraImportacaoDireta,
		/// <summary>
		/// The estrangeira adquirida brasil
		/// </summary>
		[DFeEnum("2")]
		EstrangeiraAdquiridaBrasil,
		/// <summary>
		/// The nacional conteudo importacao superior40
		/// </summary>
		[DFeEnum("3")]
		NacionalConteudoImportacaoSuperior40,
		/// <summary>
		/// The nacional processos basicos
		/// </summary>
		[DFeEnum("4")]
		NacionalProcessosBasicos,
		/// <summary>
		/// The nacional conteudo importacao inferior igual40
		/// </summary>
		[DFeEnum("5")]
		NacionalConteudoImportacaoInferiorIgual40,
		/// <summary>
		/// The estrangeira importacao direta sem similar
		/// </summary>
		[DFeEnum("6")]
		EstrangeiraImportacaoDiretaSemSimilar,
		/// <summary>
		/// The estrangeira adquirida brasil sem similar
		/// </summary>
		[DFeEnum("7")]
		EstrangeiraAdquiridaBrasilSemSimilar,
		/// <summary>
		/// The nacional conteudo importacao superior70
		/// </summary>
		[DFeEnum("8")]
		NacionalConteudoImportacaoSuperior70
	}
}
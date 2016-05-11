// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 03-31-2016
//
// Last Modified By : RFTD
// Last Modified On : 03-31-2016
// ***********************************************************************
// <copyright file="ISatLibrary.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace ACBr.Net.Sat.Interfaces
{
	/// <summary>
	/// Interface ISatLibrary
	/// </summary>
	public interface ISatLibrary
	{
		#region Propriedades

		/// <summary>
		/// Gets the DLL path.
		/// </summary>
		/// <value>The DLL path.</value>
		string DllPath { get; }

		/// <summary>
		/// Gets the modelo string.
		/// </summary>
		/// <value>The modelo string.</value>
		string ModeloStr { get; }

		#endregion Propriedades

		#region Methods

		/// <summary>
		/// Associars the assinatura.
		/// </summary>
		/// <param name="cnpj">The CNPJ.</param>
		/// <param name="assinaturacnpj">The assinaturacnpj.</param>
		/// <returns>System.String.</returns>
		SatResposta AssociarAssinatura(string cnpj, string assinaturacnpj);

		/// <summary>
		/// Ativars the sat.
		/// </summary>
		/// <param name="subComando">The sub comando.</param>
		/// <param name="CNPJ">The CNPJ.</param>
		/// <param name="uf">The uf.</param>
		/// <returns>System.String.</returns>
		SatResposta AtivarSAT(int subComando, string CNPJ, int uf);

		/// <summary>
		/// Atualizars the software sat.
		/// </summary>
		/// <returns>System.String.</returns>
		SatResposta AtualizarSoftwareSAT();

		/// <summary>
		/// Bloquears the sat.
		/// </summary>
		/// <returns>System.String.</returns>
		SatResposta BloquearSAT();

		/// <summary>
		/// Cancelars the ultima venda.
		/// </summary>
		/// <param name="dadosvenda">The dadosvenda.</param>
		/// <returns>SatResposta.</returns>
		CancelamentoSatResposta CancelarUltimaVenda(CFe dadosvenda);

		/// <summary>
		/// Cancelars the ultima venda.
		/// </summary>
		/// <param name="chave">The chave.</param>
		/// <param name="dadosCancelamento">The dados cancelamento.</param>
		/// <returns>System.String.</returns>
		CancelamentoSatResposta CancelarUltimaVenda(string chave, CFeCanc dadosCancelamento);

		/// <summary>
		/// Comunicars the certificado icpbrasil.
		/// </summary>
		/// <param name="certificado">The certificado.</param>
		/// <returns>System.String.</returns>
		SatResposta ComunicarCertificadoICPBRASIL(string certificado);

		/// <summary>
		/// Configurars the interface de rede.
		/// </summary>
		/// <param name="dadosConfiguracao">The dados configuracao.</param>
		/// <returns>System.String.</returns>
		SatResposta ConfigurarInterfaceDeRede(string dadosConfiguracao);

		/// <summary>
		/// Consultars the numero sessao.
		/// </summary>
		/// <param name="numeroSessao">The numero sessao.</param>
		/// <returns>System.String.</returns>
		SatResposta ConsultarNumeroSessao(int numeroSessao);

		/// <summary>
		/// Consultars the sat.
		/// </summary>
		/// <returns>System.String.</returns>
		SatResposta ConsultarSAT();

		/// <summary>
		/// Consultars the status operacional.
		/// </summary>
		/// <returns>System.String.</returns>
		SatResposta ConsultarStatusOperacional();

		/// <summary>
		/// Desbloquears the sat.
		/// </summary>
		/// <returns>System.String.</returns>
		SatResposta DesbloquearSAT();

		/// <summary>
		/// Enviars the dados venda.
		/// </summary>
		/// <param name="cfe">The dados venda.</param>
		/// <returns>System.String.</returns>
		VendaSatResposta EnviarDadosVenda(CFe cfe);

		/// <summary>
		/// Extrairs the logs.
		/// </summary>
		/// <returns>System.String.</returns>
		SatResposta ExtrairLogs();

		/// <summary>
		/// Testes the fim a fim.
		/// </summary>
		/// <param name="dadosVenda">The dados venda.</param>
		/// <returns>System.String.</returns>
		SatResposta TesteFimAFim(CFe dadosVenda);

		/// <summary>
		/// Trocars the codigo de ativacao.
		/// </summary>
		/// <param name="codigoDeAtivacaoOuEmergencia">The codigo de ativacao ou emergencia.</param>
		/// <param name="opcao">The opcao.</param>
		/// <param name="novoCodigo">The novo codigo.</param>
		/// <returns>System.String.</returns>
		SatResposta TrocarCodigoDeAtivacao(string codigoDeAtivacaoOuEmergencia, int opcao,
			string novoCodigo);

		#endregion Methods
	}
}
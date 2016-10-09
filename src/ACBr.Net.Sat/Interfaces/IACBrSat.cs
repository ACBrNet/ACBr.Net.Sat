using ACBr.Net.Sat.Events;
using System;
using System.Text;

namespace ACBr.Net.Sat.Interfaces
{
	public interface IACBrSat
	{
		#region Events

		/// <summary>
		/// Ocorre quando é necessario pegar o valor do Codigo de Ativação.
		/// </summary>
		event EventHandler<ChaveEventArgs> OnGetCodigoDeAtivacao;

		/// <summary>
		/// Ocorre quando é necessario pegar o valor do SignAC.
		/// </summary>
		event EventHandler<ChaveEventArgs> OnGetSignAC;

		/// <summary>
		/// Ocorre que é necessario pegar o número da sessão.
		/// </summary>
		event EventHandler<NumeroSessaoEventArgs> OnGetNumeroSessao;

		/// <summary>
		/// Ocorre antes de enviar os dados da venda para o Sat.
		/// </summary>
		event EventHandler<EventoDadosEventArgs> OnEnviarDadosVenda;

		/// <summary>
		/// Ocorre antes de cancelar uma venda.
		/// </summary>
		event EventHandler<EventoDadosEventArgs> OnCancelarUltimaVenda;

		/// <summary>
		/// Ocorre quando é chamado o comando ConsultarSat para caso o usuario queria tratar esta função.
		/// </summary>
		event EventHandler<EventoEventArgs> OnConsultarSat;

		/// <summary>
		/// Ocorre quando é chamado o comando ConsultaStatusOperacional para caso o usuario queria tratar esta função.
		/// </summary>
		event EventHandler<EventoEventArgs> OnConsultaStatusOperacional;

		/// <summary>
		/// Ocorre quando é chamado o comando ExtrairLogs para caso o usuario queria tratar esta função.
		/// </summary>
		event EventHandler<EventoEventArgs> OnExtrairLogs;

		/// <summary>
		/// Ocorre quando é chamado o comando ConsultarNumeroSessao para caso o usuario queria tratar esta função.
		/// </summary>
		event EventHandler<EventoDadosEventArgs> OnConsultarNumeroSessao;

		/// <summary>
		/// Ocorre quando tem alguma mensagem da Sefaz no retorno do SAT.
		/// </summary>
		event EventHandler<SatMensagemEventArgs> OnMensagemSefaz;

		/// <summary>
		/// Ocorre quando é necessario calcular o Path para salvar os Xmls.
		/// </summary>
		event EventHandler<CalcPathEventEventArgs> OnCalcPath;

		#endregion Events

		#region Propriedades

		/// <summary>
		/// Configurações do ACBrSat
		/// </summary>
		/// <value>The configuracoes.</value>
		SatConfig Configuracoes { get; }

		/// <summary>
		/// Configurações de como ACBrSat vai se comportar com os arquivos gerado e recebido.
		/// </summary>
		/// <value>The arquivos.</value>
		CfgArquivos Arquivos { get; }

		/// <summary>
		/// Enconding usado para tratar as string que são enviadas/recebidas.
		/// </summary>
		/// <value>O Enconder</value>
		/// <exception cref="Exception">Não é possível definir a propriedade com o componente ativo</exception>
		Encoding Encoding { get; set; }

		/// <summary>
		/// Modelo a ser utilizado pelo ACBrSat.
		/// </summary>
		/// <value>The modelo.</value>
		ModeloSat Modelo { get; set; }

		/// <summary>
		/// Classe responsavel por imprimir o Extrato do Sat.
		/// </summary>
		/// <value>The extrato.</value>
		IExtratoSat Extrato { get; set; }

		/// <summary>
		/// Indica se o componente esta ativo ou não.
		/// </summary>
		/// <value><c>true</c> if ativo; otherwise, <c>false</c>.</value>
		bool Ativo { get; }

		/// <summary>
		/// Número da sessão atual.
		/// </summary>
		/// <value>The sessao.</value>
		int Sessao { get; }

		/// <summary>
		/// Código usado para ativar o Sat
		/// </summary>
		/// <value>Código ativacao.</value>
		string CodigoAtivacao { get; set; }

		/// <summary>
		/// Assinatura de (CNPJ Software House + CNPJ Emitente) que gerou o CF-e </summary>
		/// <value>SignAC.</value>
		string SignAC { get; set; }

		/// <summary>
		/// Caminho onde se encontra a biblioteca do Sat.
		/// </summary>
		/// <value>O caminho da dll.</value>
		string PathDll { get; set; }

		#endregion Propriedades

		/// <summary>
		/// Ativa o ACBrSat, obrigatorio antes de chamar qualquer metodo.
		/// </summary>
		/// <exception cref="NotImplementedException"></exception>
		void Ativar();

		/// <summary>
		/// Desativa o ACBrSat e libera a lib nativa
		/// </summary>
		void Desativar();

		/// <summary>
		/// Retorna uma nova instancia da classe CFe com os dados inciais preenchidos.
		/// </summary>
		/// <returns>CFe Iniciada.</returns>
		CFe NewCFe();

		/// <summary>
		/// Associa a sua assinatura ao Sat
		/// </summary>
		/// <param name="cnpj">The CNPJ.</param>
		/// <param name="assinaturaCnpj">The assinatura CNPJ.</param>
		/// <returns>SatResposta.</returns>
		SatResposta AssociarAssinatura(string cnpj, string assinaturaCnpj);

		/// <summary>
		/// Função para ativa o Sat.
		/// </summary>
		/// <param name="subComando">The sub comando.</param>
		/// <param name="cnpj">The CNPJ.</param>
		/// <param name="uf">The uf.</param>
		/// <returns>SatResposta.</returns>
		SatResposta AtivarSAT(int subComando, string cnpj, int uf);

		/// <summary>
		/// Envia um comando para o Sat se atualizar.
		/// </summary>
		/// <returns>SatResposta.</returns>
		SatResposta AtualizarSoftwareSAT();

		/// <summary>
		/// Bloquea o Sat.
		/// </summary>
		/// <returns>SatResposta.</returns>
		SatResposta BloquearSAT();

		/// <summary>
		/// Libera o Sat.
		/// </summary>
		/// <returns>SatResposta.</returns>
		SatResposta DesbloquearSAT();

		/// <summary>
		/// Cancelar o CFe Informado
		/// </summary>
		/// <param name="cfe">CFe para cancelar.</param>
		/// <returns>CancelamentoSatResposta.</returns>
		CancelamentoSatResposta CancelarUltimaVenda(CFe cfe);

		/// <summary>
		/// Cancela a venda relacionada a classe de cancelamento informada.
		/// </summary>
		/// <param name="cfeCanc">The cfe canc.</param>
		/// <returns>CancelamentoSatResposta.</returns>
		CancelamentoSatResposta CancelarUltimaVenda(CFeCanc cfeCanc);

		/// <summary>
		/// Cancela a venda
		/// </summary>
		/// <param name="chave">A chave da CFe pra cancelar.</param>
		/// <param name="dadosCancelamento">XML de cancelamento.</param>
		/// <returns>CancelamentoSatResposta.</returns>
		CancelamentoSatResposta CancelarUltimaVenda(string chave, string dadosCancelamento);

		/// <summary>
		/// Seta o certificado para o Sat usa.
		/// So use caso você utiliza certificado Icp Brasil (NFe).
		/// </summary>
		/// <param name="certificado">The certificado.</param>
		/// <returns>SatResposta.</returns>
		SatResposta ComunicarCertificadoIcpBrasil(string certificado);

		/// <summary>
		/// Configura a interface de rede do Sat.
		/// </summary>
		/// <param name="config">The configuration.</param>
		/// <returns>SatResposta.</returns>
		SatResposta ConfigurarInterfaceDeRede(SatRede config);

		/// <summary>
		/// Consulta os dados da sessão informada.
		/// </summary>
		/// <param name="numeroSessao">The numero sessao.</param>
		/// <returns>SatResposta.</returns>
		ConsultaSessaoResposta ConsultarNumeroSessao(int numeroSessao);

		/// <summary>
		/// Consulta a situação do Sat.
		/// </summary>
		/// <returns>SatResposta.</returns>
		SatResposta ConsultarSAT();

		/// <summary>
		/// Consulta a situação operacional do Sat.
		/// </summary>
		/// <returns>SatResposta.</returns>
		StatusOperacionalResposta ConsultarStatusOperacional();

		/// <summary>
		/// Envia os dados da venda para o Sat.
		/// </summary>
		/// <param name="cfe">The cfe.</param>
		/// <returns>VendaSatResposta.</returns>
		VendaSatResposta EnviarDadosVenda(CFe cfe);

		/// <summary>
		/// Extrai os logs do Sat.
		/// </summary>
		/// <returns>SatResposta.</returns>
		LogResposta ExtrairLogs();

		/// <summary>
		/// Realiza um teste de fim a fim no Sat.
		/// </summary>
		/// <param name="cfe">The cfe.</param>
		/// <returns>SatResposta.</returns>
		TesteResposta TesteFimAFim(CFe cfe);

		/// <summary>
		/// Troca o codigo de ativação do Sat.
		/// </summary>
		/// <param name="codigo">The novo codigo.</param>
		/// <param name="opcao">The opcao.</param>
		/// <param name="novoCodigo">The conf novo codigo.</param>
		/// <returns>SatResposta.</returns>
		SatResposta TrocarCodigoDeAtivacao(string codigo, int opcao, string novoCodigo);

		/// <summary>
		/// Imprime o extrato do Cfe.
		/// </summary>
		/// <param name="cfe">The cfe.</param>
		void ImprimirExtrato(CFe cfe);

		/// <summary>
		/// Imprime o extrato resumido do CFe.
		/// </summary>
		/// <param name="cfe">The cfe.</param>
		void ImprimirExtratoResumido(CFe cfe);

		/// <summary>
		/// Imprimir o extrato de cancelamento do CFe.
		/// </summary>
		/// <param name="cfe">The cfe.</param>
		/// <param name="cFeCanc">The c fe canc.</param>
		void ImprimirExtratoCancelamento(CFe cfe, CFeCanc cFeCanc);

		/// <summary>
		/// Retorna a XML do CFe.
		/// </summary>
		/// <param name="cfe">Instancia CFe.</param>
		/// <returns>XML da CFe</returns>
		string GetXml(CFe cfe);

		/// <summary>
		/// Retorna a XML do CFe de cancelamento.
		/// </summary>
		/// <param name="cfeCanc">Instancia CFeCanc.</param>
		/// <returns>XML de Cancelamento.</returns>
		string GetXml(CFeCanc cfeCanc);

		/// <summary>
		/// Retorna a XML de configuração da rede do Sat.
		/// </summary>
		/// <param name="rede">Instancia da classe SatRede.</param>
		/// <returns>XML da configuração da rede do Sat</returns>
		string GetXml(SatRede rede);

		void Dispose();

		event EventHandler Disposed;
	}
}
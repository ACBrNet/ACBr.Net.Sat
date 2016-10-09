using System;
using System.Drawing;

namespace ACBr.Net.Sat.Interfaces
{
	public interface IExtratoSat
	{
		#region Propriedades

		ACBrSat Parent { get; set; }

		Image Logo { get; set; }

		ExtratoLayOut LayOut { get; set; }

		ExtratoFiltro Filtro { get; set; }

		bool MostrarPreview { get; set; }

		bool MostrarSetup { get; set; }

		string PrinterName { get; set; }

		int NumeroCopias { get; set; }

		string NomeArquivo { get; set; }

		string SoftwareHouse { get; set; }

		string Site { get; set; }

		#endregion Propriedades

		#region Methods

		/// <summary>
		/// Gera o conteudo do QrCode.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="dhEmissao"></param>
		/// <param name="valor"></param>
		/// <param name="cpfcnpj"></param>
		/// <param name="assinaturaQrcode"></param>
		/// <returns></returns>
		string CalcularConteudoQRCode(string id, DateTime dhEmissao, decimal valor, string cpfcnpj, string assinaturaQrcode);

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

		#endregion Methods
	}
}
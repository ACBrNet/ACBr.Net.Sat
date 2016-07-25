using System;
using System.Drawing;
using System.Globalization;
using ACBr.Net.Core.Extensions;
using ACBr.Net.Sat.Interfaces;

namespace ACBr.Net.Sat.Extrato
{
	public abstract class ExtratoSat : IExtratoSat
	{
		#region Fields

		private ACBrSat parent;

		#endregion Fields

		#region Propriedades

		public ACBrSat Parent
		{
			get { return parent; }
			set
			{
				parent = value;
				if (parent.Extrato != this)
					parent.Extrato = this;
			}
		}

		public Image Logo { get; set; }

		public ExtratoLayOut LayOut { get; set; }

		public ExtratoFiltro Filtro { get; set; }

		public bool ImprimeQrcode { get; set; }

		public bool MostrarPreview { get; set; }

		public bool MostrarSetup { get; set; }

		public string PrinterName { get; set; }

		public int NumeroCopias { get; set; }

		public string NomeArquivo { get; set; }

		public string SoftwareHouse { get; set; }

		public string Site { get; set; }

		#endregion Propriedades

		#region Methods

		public string CalcularConteudoQRCode(string id, DateTime dhEmissao, decimal valor, string cpfcnpj,
			string assinaturaQrcode)
		{
			return $"{id}|{dhEmissao:yyyyMMddHHmmss}|{valor.ToString(CultureInfo.InvariantCulture)}" +
			       $"|{cpfcnpj.OnlyNumbers()}|{assinaturaQrcode}";
		}

		public abstract void ImprimirExtrato(CFe cfe);

		public abstract void ImprimirExtratoResumido(CFe cfe);

		public abstract void ImprimirExtratoCancelamento(CFe cfe, CFeCanc cFeCanc);

		#endregion Methods
	}
}
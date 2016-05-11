// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 05-10-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-10-2016
// ***********************************************************************
// <copyright file="CancelamentoSatResposta.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.IO;
using ACBr.Net.Core.Extensions;
using ACBr.Net.Sat.Events;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Class CancelamentoSatResposta.
	/// </summary>
	/// <seealso cref="ACBr.Net.Sat.SatResposta" />
	public class CancelamentoSatResposta : SatResposta
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="VendaSatResposta" /> class.
		/// </summary>
		/// <param name="retorno">The retorno.</param>
		public CancelamentoSatResposta(string retorno) : base(retorno)
		{
			if (CodigoDeRetorno != 7000)
				return;

			var xmlRecebido = RetornoLst[5].Base64Decode();
			Cancelamento = CFeCanc.LoadCFe(xmlRecebido);
			if (!ACBrSat.Arquivos.SalvarCFe)
				return;

			var path = $@"{ACBrSat.Arquivos.PastaCFeVenda}\{Cancelamento.Emit.CNPJ}\{Cancelamento.Ide.DEmi:yyyyMM}";
			var e = new CalcPathEventEventArgs
			{
				CNPJ = Cancelamento.Emit.CNPJ,
				Data = Cancelamento.Ide.DEmi,
				Path = path
			};

			ACBrSat.OnCalcPath.Raise(e);

			if (!Directory.Exists(e.Path))
				Directory.CreateDirectory(e.Path);

			var nomeArquivo = $"{ACBrSat.Arquivos.PrefixoArqCFe}{Cancelamento.InfCFe.Id}";
			Venda.SalvarCFe($@"{e.Path}\{nomeArquivo}");
		}

		#endregion Constructors

		#region Propriedades

		/// <summary>
		/// Gets or sets the venda.
		/// </summary>
		/// <value>The venda.</value>
		public CFe Venda { get; set; }

		/// <summary>
		/// Gets or sets the cancelamento.
		/// </summary>
		/// <value>The cancelamento.</value>
		public CFeCanc Cancelamento { get; set; }

		#endregion Propriedades

		#region Methods
		#endregion Methods
	}
}
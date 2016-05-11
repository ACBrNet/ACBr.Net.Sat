// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 05-10-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-10-2016
// ***********************************************************************
// <copyright file="VendaSatResposta.cs" company="ACBr.Net">
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
	/// Class VendaSatResposta.
	/// </summary>
	/// <seealso cref="SatResposta" />
	public class VendaSatResposta : SatResposta
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="VendaSatResposta" /> class.
		/// </summary>
		/// <param name="retorno">The retorno.</param>
		public VendaSatResposta(string retorno):base(retorno)
		{
			if (CodigoDeRetorno != 6000)
				return;

			var xmlRecebido = RetornoLst[5].Base64Decode();
			Venda = CFe.LoadCFe(xmlRecebido);
			if (!ACBrSat.Arquivos.SalvarCFe)
				return;

			var path = $@"{ACBrSat.Arquivos.PastaCFeVenda}\{Venda.InfCFe.Emit.CNPJ}\{Venda.InfCFe.Ide.DEmi:yyyyMM}";
			var e = new CalcPathEventEventArgs
			{
				CNPJ = Venda.InfCFe.Emit.CNPJ,
				Data = Venda.InfCFe.Ide.DEmi,
				Path = path
			};

			ACBrSat.OnCalcPath.Raise(e);

			if (!Directory.Exists(e.Path))
				Directory.CreateDirectory(e.Path);

			var nomeArquivo = $"{ACBrSat.Arquivos.PrefixoArqCFe}{Venda.InfCFe.Id}";
			Venda.SalvarCFe($@"{e.Path}\{nomeArquivo}");
		}

		#endregion Constructors

		#region Propriedades

		/// <summary>
		/// Gets or sets the venda.
		/// </summary>
		/// <value>The venda.</value>
		public CFe Venda { get; set; }

		#endregion Propriedades

		#region Methods
		#endregion Methods
	}
}
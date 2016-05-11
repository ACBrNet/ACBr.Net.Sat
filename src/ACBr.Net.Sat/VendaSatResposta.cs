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
using ACBr.Net.Core.Extensions;
using ACBr.Net.Sat.Events;
using System;
using System.IO;

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
		public VendaSatResposta(string retorno) : base(retorno)
		{
			if (CodigoDeRetorno != 6000)
				return;

			if (RetornoLst.Count >= 7)
			{
				using (var stream = new MemoryStream(Convert.FromBase64String(RetornoLst[6])))
				{
					Venda = CFe.LoadCFe(stream);
				}
			}

			if (RetornoLst.Count >= 9)
			{
				ChaveConsulta = RetornoLst[8];
			}

			if (RetornoLst.Count >= 12)
			{
				//O QRCode é montado a partir dos últimos campos do retorno

				var indexOf = -1;
				for (int i = 0; i < 8; i++)
				{
					indexOf = RetornoStr.IndexOf('|', indexOf + 1);
					if (indexOf == -1) break;
				}

				QRCode = RetornoStr.Substring(indexOf + 1);
			}

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
		public CFe Venda { get; private set; }

		public string ChaveConsulta { get; private set; }

		public string QRCode { get; private set; }

		#endregion Propriedades
	}
}
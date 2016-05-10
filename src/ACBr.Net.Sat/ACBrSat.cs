// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 03-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-05-2016
// ***********************************************************************
// <copyright file="ACBrSat.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using System.Text;
using ACBr.Net.Core;
using ACBr.Net.Core.Extensions;
using ACBr.Net.Core.Logging;
using ACBr.Net.Sat.Events;
using ACBr.Net.Sat.Interfaces;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Class ACBrSat. This class cannot be inherited.
	/// </summary>
	public static class ACBrSat
	{
		#region Fields

		/// <summary>
		/// The logger
		/// </summary>
		internal static IInternalLogger Logger = LoggerProvider.LoggerFor(typeof (ACBrSat));
		/// <summary>
		/// The sign ac
		/// </summary>
		private static string signAC;

		#endregion Fields

		#region Events

		/// <summary>
		/// The on getcodigo de ativacao
		/// </summary>
		public static EventHandler<ChaveEventArgs> OnGetcodigoDeAtivacao;

		/// <summary>
		/// The on getsign ac
		/// </summary>
		public static EventHandler<ChaveEventArgs> OnGetsignAC;

		/// <summary>
		/// The on on get numero sessao
		/// </summary>
		public static EventHandler<NumeroSessaoEventArgs> OnOnGetNumeroSessao;

		/// <summary>
		/// The on enviar dados venda
		/// </summary>
		public static EventHandler<EventoDadosEventArgs> OnEnviarDadosVenda;

		/// <summary>
		/// The on cancelar ultima venda
		/// </summary>
		public static EventHandler<EventoDadosEventArgs> OnCancelarUltimaVenda;

		/// <summary>
		/// The on consulta status operacional
		/// </summary>
		public static EventHandler<EventoEventArgs> OnConsultaStatusOperacional;

		/// <summary>
		/// The on extrair logs
		/// </summary>
		public static EventHandler<EventoEventArgs> OnExtrairLogs;

		/// <summary>
		/// The on consultar numero sessao
		/// </summary>
		public static EventHandler<EventoDadosEventArgs> OnConsultarNumeroSessao;

		/// <summary>
		/// The on mensagem sefaz
		/// </summary>
		public static EventHandler<SATMensagemEventArgs> OnMensagemSEFAZ;

		/// <summary>
		/// The on calculate path
		/// </summary>
		public static EventHandler<CalcPathEventEventArgs> OnCalcPath;

		#endregion Events

		#region Constructor

		/// <summary>
		/// Initializes static members of the <see cref="ACBrSat"/> class.
		/// </summary>
		static ACBrSat()
		{
			Configuracoes = new SATConfig();
			Arquivos = new CfgArquivos();
			Enconder = Encoding.ASCII;

			PathDll = @"C:\SAT\SAT.dll";
			CodigoAtivacao = "123456";
		}

		#endregion Constructor

		#region Propriedades

		/// <summary>
		/// Gets or sets the sessao.
		/// </summary>
		/// <value>The sessao.</value>
		public static int Sessao { get; set; }

		/// <summary>
		/// Gets or sets the codigo ativacao.
		/// </summary>
		/// <value>The codigo ativacao.</value>
		public static string CodigoAtivacao { get; set; }

		/// <summary>
		/// Gets or sets the sign ac.
		/// </summary>
		/// <value>The sign ac.</value>
		public static string SignAC
		{
			get
			{
				var e = new ChaveEventArgs {Chave = signAC};
				OnGetsignAC.Raise(e);
				signAC = e.Chave;
				return signAC; 
				
			}
			set { signAC = value; }
		}

		/// <summary>
		/// Gets or sets the path DLL.
		/// </summary>
		/// <value>The path DLL.</value>
		public static string PathDll { get; set; }

		/// <summary>
		/// Gets the configuracoes.
		/// </summary>
		/// <value>The configuracoes.</value>
		public static SATConfig Configuracoes { get; set; }

		/// <summary>
		/// Gets the arquivos.
		/// </summary>
		/// <value>The arquivos.</value>
		public static CfgArquivos Arquivos { get; set; }

		/// <summary>
		/// Gets or sets the enconder.
		/// </summary>
		/// <value>The enconder.</value>
		public static Encoding Enconder { get; set; }

		#endregion Propriedades

		#region Methods

		/// <summary>
		/// Creates the library.
		/// </summary>
		/// <param name="modelo">The modelo.</param>
		/// <returns>ISATLibrary.</returns>
		public static ISATLibrary CreateLibrary(ModeloSat modelo)
		{
			// ReSharper disable once SwitchStatementMissingSomeCases
			switch (modelo)
			{
				case ModeloSat.StdCall:
					return new SatStdCall(PathDll);

				default:
					return new SatCdecl(PathDll);
			}
		}

		/// <summary>
		/// Creates the library.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns>ISATLibrary.</returns>
		public static ISATLibrary CreateLibrary<T>() where  T : ISATLibrary
		{
			var ret = (T)Activator.CreateInstance(typeof(T), PathDll);
			return ret;
		}

		/// <summary>
		/// News the c fe.
		/// </summary>
		/// <returns>CFe.</returns>
		public static CFe NewCFe()
		{
			var ret = new CFe();
			ret.InfCFe.Ide.CNPJ = Configuracoes.IdeCNPJ;
			ret.InfCFe.Ide.TpAmb = Configuracoes.IdeTpAmb;
			ret.InfCFe.Ide.NumeroCaixa = Configuracoes.IdeNumeroCaixa;
			ret.InfCFe.Ide.SignAC = SignAC;
			ret.InfCFe.Emit.CNPJ = Configuracoes.EmitCNPJ;
			ret.InfCFe.Emit.IM = Configuracoes.EmitIM;
			ret.InfCFe.Emit.IE = Configuracoes.EmitIE;
			ret.InfCFe.Emit.CRegTrib = Configuracoes.EmitCRegTrib;
			ret.InfCFe.Emit.CRegTribISSQN = Configuracoes.EmitCRegTribISSQN;
			ret.InfCFe.Emit.IndRatISSQN = Configuracoes.EmitIndRatISSQN;
			ret.InfCFe.VersaoDadosEnt = Configuracoes.InfCFeVersaoDadosEnt;
			return ret;
		}

		/// <summary>
		/// Gera um novo numero de sessão
		/// </summary>
		/// <returns>System.Int32.</returns>
		public static int GerarnumeroSessao()
		{
			Sessao = StaticRandom.Next();

			if (OnOnGetNumeroSessao == null)
				return Sessao;

			var args = new NumeroSessaoEventArgs(Sessao);
			OnOnGetNumeroSessao.Raise(null, args);
			Sessao = args.Sessao;
			return Sessao;
		}

		internal static CFe LoadRetVenda(SATResposta retSat)
		{
			if (retSat.CodigoDeRetorno != 6000)
				return null;

			var xmlRecebido = retSat.RetornoLst[5].Base64Decode();
			var ret = CFe.LoadCFe(xmlRecebido);
			if (!Arquivos.SalvarCFe)
				return ret;

			var path = $@"{Arquivos.PastaCFeVenda}\{ret.InfCFe.Emit.CNPJ}\{ret.InfCFe.Ide.DEmi:yyyyMM}";
			var e = new CalcPathEventEventArgs
			{
				CNPJ = ret.InfCFe.Emit.CNPJ,
				Data = ret.InfCFe.Ide.DEmi,
				Path = path
			};
			OnCalcPath.Raise(e);

			if (!Directory.Exists(e.Path))
				Directory.CreateDirectory(e.Path);

			var nomeArquivo = $"{Arquivos.PrefixoArqCFe}{ret.InfCFe.Id}";
			ret.SalvarCFe($@"{e.Path}\{nomeArquivo}");
			return ret;
		}

		internal static CFeCanc LoadRetCanc(SATResposta retSat)
		{
			if (retSat.CodigoDeRetorno != 7000)
				return null;

			var xmlRecebido = retSat.RetornoLst[5].Base64Decode();
			var ret = CFeCanc.LoadCFe(xmlRecebido);
			if (!Arquivos.SalvarCFe)
				return ret;

			var path = $@"{Arquivos.PastaCFeVenda}\{ret.Emit.CNPJ}\{ret.Ide.DEmi:yyyyMM}";
			var e = new CalcPathEventEventArgs
			{
				CNPJ = ret.Emit.CNPJ,
				Data = ret.Ide.DEmi,
				Path = path
			};
			OnCalcPath.Raise(e);

			if (!Directory.Exists(e.Path))
				Directory.CreateDirectory(e.Path);

			var nomeArquivo = $"{Arquivos.PrefixoArqCFe}{ret.InfCFe.Id}";
			ret.SalvarCFe($@"{e.Path}\{nomeArquivo}");
			return ret;
		}

		internal static void IniciaComando(string comandoLog)
		{
			GerarnumeroSessao();
			Logger.Info($"{DateTime.Now:dd/MM/yyyy HH:mm:ss} - NumeroSessao: {Sessao} - Comando: {comandoLog}");
		}

		internal static SATResposta FinalizaComando(string resposta)
		{
			Logger.Info($"{DateTime.Now:dd/MM/yyyy HH:mm:ss} - NumeroSessao: {Sessao} - Resposta: {resposta}");
			var resp = new SATResposta(resposta);
			if (OnMensagemSEFAZ == null)
				return resp;

			if (resp.CodigoSEFAZ <= 0 || resp.MensagemSEFAZ.IsEmpty())
				return resp;

			var args = new SATMensagemEventArgs(resp.CodigoSEFAZ, resp.MensagemSEFAZ);
			OnMensagemSEFAZ.Raise(null, args);
			return resp;
		}

		#endregion Methods
	}
}

// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 03-31-2016
//
// Last Modified By : RFTD
// Last Modified On : 03-31-2016
// ***********************************************************************
// <copyright file="SatStdCall.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.InteropServices;
using ACBr.Net.Sat.Interfaces;
using ACBr.Net.Sat.Utils;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Class SatStdCall.
	/// </summary>
	/// <seealso cref="ISATLibrary" />
	public class SatStdCall : ISATLibrary
	{
		#region Delegates

		/// <summary>
		/// Delegate AssociarAssinatura
		/// </summary>
		/// <param name="numeroSessao">The numero sessao.</param>
		/// <param name="codigoDeAtivacao">The codigo de ativacao.</param>
		/// <param name="cnpJvalue">The CNP jvalue.</param>
		/// <param name="assinaturaCnpJs">The assinatura CNP js.</param>
		/// <returns>System.String.</returns>
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate IntPtr DelAssociarAssinatura(int numeroSessao,
			[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
			[MarshalAs(UnmanagedType.LPStr)]string cnpJvalue,
			[MarshalAs(UnmanagedType.LPStr)]string assinaturaCnpJs);

		/// <summary>
		/// Delegate AtivarSAT
		/// </summary>
		/// <param name="numeroSessao">The numero sessao.</param>
		/// <param name="subComando">The sub comando.</param>
		/// <param name="codigoDeAtivacao">The codigo de ativacao.</param>
		/// <param name="cnpj">The CNPJ.</param>
		/// <param name="cUF">The c uf.</param>
		/// <returns>System.String.</returns>
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate IntPtr DelAtivarSAT(int numeroSessao, int subComando,
			[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
			[MarshalAs(UnmanagedType.LPStr)]string cnpj,
			int cUF);

		/// <summary>
		/// Delegate AtualizarSoftwareSAT
		/// </summary>
		/// <param name="numeroSessao">The numero sessao.</param>
		/// <param name="codigoDeAtivacao">The codigo de ativacao.</param>
		/// <returns>System.String.</returns>
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate IntPtr DelAtualizarSoftwareSAT(int numeroSessao,
			[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao);

		/// <summary>
		/// Delegate BloquearSAT
		/// </summary>
		/// <param name="numeroSessao">The numero sessao.</param>
		/// <param name="codigoDeAtivacao">The codigo de ativacao.</param>
		/// <returns>System.String.</returns>
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate IntPtr DelBloquearSAT(int numeroSessao,
			[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao);

		/// <summary>
		/// Delegate CancelarUltimaVenda
		/// </summary>
		/// <param name="numeroSessao">The numero sessao.</param>
		/// <param name="codigoDeAtivacao">The codigo de ativacao.</param>
		/// <param name="chave">The chave.</param>
		/// <param name="dadosCancelamento">The dados cancelamento.</param>
		/// <returns>System.String.</returns>
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate IntPtr DelCancelarUltimaVenda(int numeroSessao,
			[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
			[MarshalAs(UnmanagedType.LPStr)]string chave,
			[MarshalAs(UnmanagedType.LPStr)]string dadosCancelamento);

		/// <summary>
		/// Delegate ComunicarCertificadoICPBRASIL
		/// </summary>
		/// <param name="numeroSessao">The numero sessao.</param>
		/// <param name="codigoDeAtivacao">The codigo de ativacao.</param>
		/// <param name="certificado">The certificado.</param>
		/// <returns>System.String.</returns>
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate IntPtr DelComunicarCertificadoICPBRASIL(int numeroSessao,
			[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
			[MarshalAs(UnmanagedType.LPStr)]string certificado);

		/// <summary>
		/// Delegate ConfigurarInterfaceDeRede
		/// </summary>
		/// <param name="numeroSessao">The numero sessao.</param>
		/// <param name="codigoDeAtivacao">The codigo de ativacao.</param>
		/// <param name="dadosConfiguracao">The dados configuracao.</param>
		/// <returns>System.String.</returns>
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate IntPtr DelConfigurarInterfaceDeRede(int numeroSessao,
			[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
			[MarshalAs(UnmanagedType.LPStr)]string dadosConfiguracao);

		/// <summary>
		/// Delegate ConsultarNumeroSessao
		/// </summary>
		/// <param name="numeroSessao">The numero sessao.</param>
		/// <param name="codigoDeAtivacao">The codigo de ativacao.</param>
		/// <param name="cNumeroDeSessao">The c numero de sessao.</param>
		/// <returns>System.String.</returns>
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate IntPtr DelConsultarNumeroSessao(int numeroSessao,
			[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
			int cNumeroDeSessao);

		/// <summary>
		/// Delegate ConsultarSAT
		/// </summary>
		/// <param name="numeroSessao">The numero sessao.</param>
		/// <returns>System.String.</returns>
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate IntPtr DelConsultarSAT(int numeroSessao);

		/// <summary>
		/// Delegate ConsultarStatusOperacional
		/// </summary>
		/// <param name="numeroSessao">The numero sessao.</param>
		/// <param name="codigoDeAtivacao">The codigo de ativacao.</param>
		/// <returns>System.String.</returns>
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate IntPtr DelConsultarStatusOperacional(int numeroSessao,
			[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao);

		/// <summary>
		/// Delegate DesbloquearSAT
		/// </summary>
		/// <param name="numeroSessao">The numero sessao.</param>
		/// <param name="codigoDeAtivacao">The codigo de ativacao.</param>
		/// <returns>System.String.</returns>
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate IntPtr DelDesbloquearSAT(int numeroSessao,
			[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao);

		/// <summary>
		/// Delegate EnviarDadosVenda
		/// </summary>
		/// <param name="numeroSessao">The numero sessao.</param>
		/// <param name="codigoDeAtivacao">The codigo de ativacao.</param>
		/// <param name="dadosVenda">The dados venda.</param>
		/// <returns>System.String.</returns>
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate IntPtr DelEnviarDadosVenda(int numeroSessao,
			[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
			[MarshalAs(UnmanagedType.LPStr)]string dadosVenda);

		/// <summary>
		/// Delegate ExtrairLogs
		/// </summary>
		/// <param name="numeroSessao">The numero sessao.</param>
		/// <param name="codigoDeAtivacao">The codigo de ativacao.</param>
		/// <returns>System.String.</returns>
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate IntPtr DelExtrairLogs(int numeroSessao,
			[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao);

		/// <summary>
		/// Delegate TesteFimAFim
		/// </summary>
		/// <param name="numeroSessao">The numero sessao.</param>
		/// <param name="codigoDeAtivacao">The codigo de ativacao.</param>
		/// <param name="dadosVenda">The dados venda.</param>
		/// <returns>System.String.</returns>
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate IntPtr DelTesteFimAFim(int numeroSessao,
			[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
			[MarshalAs(UnmanagedType.LPStr)]string dadosVenda);

		/// <summary>
		/// Delegate TrocarCodigoDeAtivacao
		/// </summary>
		/// <param name="numeroSessao">The numero sessao.</param>
		/// <param name="codigoDeAtivacao">The codigo de ativacao.</param>
		/// <param name="opcao">The opcao.</param>
		/// <param name="novoCodigo">The novo codigo.</param>
		/// <param name="confNovoCodigo">The conf novo codigo.</param>
		/// <returns>System.String.</returns>
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate IntPtr DelTrocarCodigoDeAtivacao(int numeroSessao,
			[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
			int opcao,
			[MarshalAs(UnmanagedType.LPStr)]string novoCodigo,
			[MarshalAs(UnmanagedType.LPStr)]string confNovoCodigo);

		#endregion Delegates

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="SatStdCall" /> class.
		/// </summary>
		/// <param name="dllPath">The DLL path.</param>
		internal SatStdCall(string dllPath)
		{
			DllPath = dllPath;
		}

		#endregion Constructors

		#region Propriedades

		/// <summary>
		/// Gets the DLL path.
		/// </summary>
		/// <value>The DLL path.</value>
		public string DllPath { get; set; }

		/// <summary>
		/// Gets the modelo string.
		/// </summary>
		/// <value>The modelo string.</value>
		public string ModeloStr => "StdCallSatLibrary";

		#endregion Propriedades
		
		#region Method

		/// <summary>
		/// Associar cnpj ao SAT
		/// </summary>
		/// <param name="cnpj">The CNPJ.</param>
		/// <param name="assinaturacnpj">The assinaturacnpj.</param>
		/// <returns>System.String.</returns>
		public SATResposta AssociarAssinatura(string cnpj, string assinaturacnpj)
		{
			ACBrSat.IniciaComando($"AssociarAssinatura({cnpj}, {assinaturacnpj})");
			var ptr = NativeMethods.LoadLibrary(DllPath);
			try
			{
				var funcaoSat = ptr.GetMethod<DelAssociarAssinatura>("AssociarAssinatura");
				var retPtr = funcaoSat(ACBrSat.Sessao, ACBrSat.CodigoAtivacao, cnpj, assinaturacnpj);
				var ret = Marshal.PtrToStringAnsi(retPtr);
				return ACBrSat.FinalizaComando(ret);
			}
			finally
			{
				ptr.FreeLibrary();
			}
		}

		/// <summary>
		/// Ativar o SAT
		/// </summary>
		/// <param name="subComando">The sub comando.</param>
		/// <param name="cnpj">The CNPJ.</param>
		/// <param name="uf">The uf.</param>
		/// <returns>System.String.</returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public SATResposta AtivarSAT(int subComando, string cnpj, int uf)
		{
			ACBrSat.IniciaComando($"AtivarSAT({subComando}, {cnpj}, {uf})");
			var ptr = NativeMethods.LoadLibrary(DllPath);
			try
			{
				var funcaoSat = ptr.GetMethod<DelAtivarSAT>("AtivarSAT");
				var retPtr = funcaoSat(ACBrSat.Sessao, subComando, ACBrSat.CodigoAtivacao, cnpj, uf);
				var ret = Marshal.PtrToStringAnsi(retPtr);
				return ACBrSat.FinalizaComando(ret);
			}
			finally
			{
				ptr.FreeLibrary();
			}
		}

		/// <summary>
		/// Atualizars the software sat.
		/// </summary>
		/// <returns>System.String.</returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public SATResposta AtualizarSoftwareSAT()
		{
			ACBrSat.IniciaComando("AtualizarSoftwareSAT()");
			var ptr = NativeMethods.LoadLibrary(DllPath);
			try
			{
				var funcaoSat = ptr.GetMethod<DelAtualizarSoftwareSAT>("AtualizarSoftwareSAT");
				var retPtr = funcaoSat(ACBrSat.Sessao, ACBrSat.CodigoAtivacao);
				var ret = Marshal.PtrToStringAnsi(retPtr);
				return ACBrSat.FinalizaComando(ret);
			}
			finally
			{
				ptr.FreeLibrary();
			}
		}

		/// <summary>
		/// Bloquears the sat.
		/// </summary>
		/// <returns>System.String.</returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public SATResposta BloquearSAT()
		{
			ACBrSat.IniciaComando("BloquearSAT()");
			var ptr = NativeMethods.LoadLibrary(DllPath);
			try
			{
				var funcaoSat = ptr.GetMethod<DelBloquearSAT>("BloquearSAT");
				var retPtr = funcaoSat(ACBrSat.Sessao, ACBrSat.CodigoAtivacao);
				var ret = Marshal.PtrToStringAnsi(retPtr);
				return ACBrSat.FinalizaComando(ret);
			}
			finally
			{
				ptr.FreeLibrary();
			}
		}

		/// <summary>
		/// Cancelars the ultima venda.
		/// </summary>
		/// <param name="chave">The chave.</param>
		/// <param name="dadosCancelamento">The dados cancelamento.</param>
		/// <returns>System.String.</returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public SATResposta CancelarUltimaVenda(string chave, CFeCanc dadosCancelamento)
		{
			ACBrSat.IniciaComando($"CancelarUltimaVenda({chave}, \"\")");
            var ptr = NativeMethods.LoadLibrary(DllPath);
			try
			{
				var funcaoSat = ptr.GetMethod<DelCancelarUltimaVenda>("CancelarUltimaVenda");
				var retPtr = funcaoSat(ACBrSat.Sessao, ACBrSat.CodigoAtivacao, chave, "");
				var ret = Marshal.PtrToStringAnsi(retPtr);
				return ACBrSat.FinalizaComando(ret);
			}
			finally
			{
				ptr.FreeLibrary();
			}
		}

		/// <summary>
		/// Cancelars the ultima venda.
		/// </summary>
		/// <param name="dadosvenda">The dadosvenda.</param>
		/// <returns>SATResposta.</returns>
		public SATResposta CancelarUltimaVenda(CFe dadosvenda)
		{
			ACBrSat.IniciaComando($"CancelarUltimaVenda({dadosvenda}");
			var ptr = NativeMethods.LoadLibrary(DllPath);
			try
			{
				var funcaoSat = ptr.GetMethod<DelCancelarUltimaVenda>("CancelarUltimaVenda");
				var retPtr = funcaoSat(ACBrSat.Sessao, ACBrSat.CodigoAtivacao, "", "");
				var ret = Marshal.PtrToStringAnsi(retPtr);
				return ACBrSat.FinalizaComando(ret);
			}
			finally
			{
				ptr.FreeLibrary();
			}
		}

		/// <summary>
		/// Comunicars the certificado icpbrasil.
		/// </summary>
		/// <param name="certificado">The certificado.</param>
		/// <returns>System.String.</returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public SATResposta ComunicarCertificadoICPBRASIL(string certificado)
		{
			ACBrSat.IniciaComando($"ComunicarCertificadoICPBRASIL({certificado})");
			var ptr = NativeMethods.LoadLibrary(DllPath);
			try
			{
				var funcaoSat = ptr.GetMethod<DelComunicarCertificadoICPBRASIL>("ComunicarCertificadoICPBRASIL");
				var retPtr = funcaoSat(ACBrSat.Sessao, ACBrSat.CodigoAtivacao, certificado);
				var ret = Marshal.PtrToStringAnsi(retPtr);
				return ACBrSat.FinalizaComando(ret);
			}
			finally
			{
				ptr.FreeLibrary();
			}
		}

		/// <summary>
		/// Configurars the interface de rede.
		/// </summary>
		/// <param name="dadosConfiguracao">The dados configuracao.</param>
		/// <returns>System.String.</returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public SATResposta ConfigurarInterfaceDeRede(string dadosConfiguracao)
		{
			ACBrSat.IniciaComando($"ConfigurarInterfaceDeRede({dadosConfiguracao})");
			var ptr = NativeMethods.LoadLibrary(DllPath);
			try
			{
				var funcaoSat = ptr.GetMethod<DelConfigurarInterfaceDeRede>("ConfigurarInterfaceDeRede");
				var retPtr = funcaoSat(ACBrSat.Sessao, ACBrSat.CodigoAtivacao, dadosConfiguracao);
				var ret = Marshal.PtrToStringAnsi(retPtr);
				return ACBrSat.FinalizaComando(ret);
			}
			finally
			{
				ptr.FreeLibrary();
			}
		}

		/// <summary>
		/// Consultars the numero sessao.
		/// </summary>
		/// <param name="numeroSessao">The numero sessao.</param>
		/// <returns>System.String.</returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public SATResposta ConsultarNumeroSessao(int numeroSessao)
		{
			ACBrSat.IniciaComando($"ConsultarNumeroSessao({numeroSessao})");
			var ptr = NativeMethods.LoadLibrary(DllPath);
			try
			{
				var funcaoSat = ptr.GetMethod<DelConsultarNumeroSessao>("ConsultarNumeroSessao");
				var retPtr = funcaoSat(ACBrSat.Sessao, ACBrSat.CodigoAtivacao, numeroSessao);
				var ret = Marshal.PtrToStringAnsi(retPtr);
				return ACBrSat.FinalizaComando(ret);
			}
			finally
			{
				ptr.FreeLibrary();
			}
		}

		/// <summary>
		/// Consultars the sat.
		/// </summary>
		/// <returns>System.String.</returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public SATResposta ConsultarSAT()
		{
			ACBrSat.IniciaComando($"ConsultarSAT()");
			var ptr = NativeMethods.LoadLibrary(DllPath);
			try
			{
				var funcaoSat = ptr.GetMethod<DelConsultarSAT>("ConsultarSAT");
				var retPtr = funcaoSat(ACBrSat.Sessao);
				var ret = Marshal.PtrToStringAnsi(retPtr);
				return ACBrSat.FinalizaComando(ret);
			}
			finally
			{
				ptr.FreeLibrary();
			}
		}

		/// <summary>
		/// Consultars the status operacional.
		/// </summary>
		/// <returns>System.String.</returns>
		public SATResposta ConsultarStatusOperacional()
		{
			ACBrSat.IniciaComando($"ConsultarStatusOperacional()");
			var ptr = NativeMethods.LoadLibrary(DllPath);
			try
			{
				var funcaoSat = ptr.GetMethod<DelConsultarStatusOperacional>("ConsultarStatusOperacional");
				var retPtr = funcaoSat(ACBrSat.Sessao, ACBrSat.CodigoAtivacao);
				var ret = Marshal.PtrToStringAnsi(retPtr);
				return ACBrSat.FinalizaComando(ret);
			}
			finally
			{
				ptr.FreeLibrary();
			}
		}

		/// <summary>
		/// Desbloquears the sat.
		/// </summary>
		/// <returns>System.String.</returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public SATResposta DesbloquearSAT()
		{
			ACBrSat.IniciaComando($"DesbloquearSAT()");
			var ptr = NativeMethods.LoadLibrary(DllPath);
			try
			{
				var funcaoSat = ptr.GetMethod<DelDesbloquearSAT>("DesbloquearSAT");
				var retPtr = funcaoSat(ACBrSat.Sessao, ACBrSat.CodigoAtivacao);
				var ret = Marshal.PtrToStringAnsi(retPtr);
				return ACBrSat.FinalizaComando(ret);
			}
			finally
			{
				ptr.FreeLibrary();
			}
		}

		/// <summary>
		/// Enviars the dados venda.
		/// </summary>
		/// <param name="cfe">The dados venda.</param>
		/// <returns>System.String.</returns>
		/// <exception cref="NotImplementedException"></exception>
		/// <exception cref="System.NotImplementedException"></exception>
		public SATResposta EnviarDadosVenda(CFe cfe)
		{
			ACBrSat.IniciaComando($"EnviarDadosVenda({cfe})");
			var ptr = NativeMethods.LoadLibrary(DllPath);
			try
			{
				var funcaoSat = ptr.GetMethod<DelEnviarDadosVenda>("DesbloquearSAT");
				var retPtr = funcaoSat(ACBrSat.Sessao, ACBrSat.CodigoAtivacao, "");
				var ret = Marshal.PtrToStringAnsi(retPtr);
				return ACBrSat.FinalizaComando(ret);
			}
			finally
			{
				ptr.FreeLibrary();
			}
		}

		/// <summary>
		/// Extrairs the logs.
		/// </summary>
		/// <returns>System.String.</returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public SATResposta ExtrairLogs()
		{
			ACBrSat.IniciaComando($"ExtrairLogs()");
			var ptr = NativeMethods.LoadLibrary(DllPath);
			try
			{
				var funcaoSat = ptr.GetMethod<DelExtrairLogs>("ExtrairLogs");
				var retPtr = funcaoSat(ACBrSat.Sessao, ACBrSat.CodigoAtivacao);
				var ret = Marshal.PtrToStringAnsi(retPtr);
				return ACBrSat.FinalizaComando(ret);
			}
			finally
			{
				ptr.FreeLibrary();
			}
		}

		/// <summary>
		/// Testes the fim a fim.
		/// </summary>
		/// <param name="dadosVenda">The dados venda.</param>
		/// <returns>System.String.</returns>
		/// <exception cref="NotImplementedException"></exception>
		/// <exception cref="System.NotImplementedException"></exception>
		public SATResposta TesteFimAFim(CFe dadosVenda)
		{
			ACBrSat.IniciaComando($"TesteFimAFim({dadosVenda})");
			var ptr = NativeMethods.LoadLibrary(DllPath);
			try
			{
				var funcaoSat = ptr.GetMethod<DelTesteFimAFim>("ExtrairLogs");
				var retPtr = funcaoSat(ACBrSat.Sessao, ACBrSat.CodigoAtivacao, "");
				var ret = Marshal.PtrToStringAnsi(retPtr);
				return ACBrSat.FinalizaComando(ret);
			}
			finally
			{
				ptr.FreeLibrary();
			}
		}

		/// <summary>
		/// Trocars the codigo de ativacao.
		/// </summary>
		/// <param name="codigoDeAtivacaoOuEmergencia">The codigo de ativacao ou emergencia.</param>
		/// <param name="opcao">The opcao.</param>
		/// <param name="novoCodigo">The novo codigo.</param>
		/// <returns>System.String.</returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public SATResposta TrocarCodigoDeAtivacao(string codigoDeAtivacaoOuEmergencia, int opcao, string novoCodigo)
		{
			ACBrSat.IniciaComando($"TrocarCodigoDeAtivacao({codigoDeAtivacaoOuEmergencia}, {opcao}, {novoCodigo})");
            var ptr = NativeMethods.LoadLibrary(DllPath);
			try
			{
				var funcaoSat = ptr.GetMethod<DelTrocarCodigoDeAtivacao>("TrocarCodigoDeAtivacao");
				var retPtr = funcaoSat(ACBrSat.Sessao, ACBrSat.CodigoAtivacao, opcao, novoCodigo, codigoDeAtivacaoOuEmergencia);
				var ret = Marshal.PtrToStringAnsi(retPtr);
				return ACBrSat.FinalizaComando(ret);
			}
			finally
			{
				ptr.FreeLibrary();
			}
		}

		#endregion Methods
	}
}
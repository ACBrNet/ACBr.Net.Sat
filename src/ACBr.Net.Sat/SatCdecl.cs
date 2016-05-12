// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 03-30-2016
//
// Last Modified By : RFTD
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="SatCdecl.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using ACBr.Net.Sat.Interfaces;
using ACBr.Net.Sat.Internal;
using ACBr.Net.Sat.Utils;
using System;
using System.Runtime.InteropServices;

namespace ACBr.Net.Sat
{
	internal class SatCdecl : ISatLibrary, IDisposable
	{
		#region InnerTypes

		private class Delegates
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public delegate IntPtr AssociarAssinatura(int numeroSessao,
				[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
				[MarshalAs(UnmanagedType.LPStr)]string cnpjValue,
				[MarshalAs(UnmanagedType.LPStr)]string assinaturaCnpj);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public delegate IntPtr AtivarSAT(int numeroSessao, int subComando,
				[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
				[MarshalAs(UnmanagedType.LPStr)]string cnpj,
				int cUF);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public delegate IntPtr AtualizarSoftwareSAT(int numeroSessao,
				[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public delegate IntPtr BloquearSAT(int numeroSessao,
				[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public delegate IntPtr CancelarUltimaVenda(int numeroSessao,
				[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
				[MarshalAs(UnmanagedType.LPStr)]string chave,
				[MarshalAs(UnmanagedType.LPStr)]string dadosCancelamento);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public delegate IntPtr ComunicarCertificadoICPBRASIL(int numeroSessao,
				[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
				[MarshalAs(UnmanagedType.LPStr)]string certificado);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public delegate IntPtr ConfigurarInterfaceDeRede(int numeroSessao,
				[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
				[MarshalAs(UnmanagedType.LPStr)]string dadosConfiguracao);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public delegate IntPtr ConsultarNumeroSessao(int numeroSessao,
				[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
				int cNumeroDeSessao);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public delegate IntPtr ConsultarSAT(int numeroSessao);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public delegate IntPtr ConsultarStatusOperacional(int numeroSessao,
				[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public delegate IntPtr DesbloquearSAT(int numeroSessao,
				[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public delegate IntPtr EnviarDadosVenda(int numeroSessao,
				[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
				[MarshalAs(UnmanagedType.LPStr)]string dadosVenda);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public delegate IntPtr ExtrairLogs(int numeroSessao,
				[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public delegate IntPtr TesteFimAFim(int numeroSessao,
				[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
				[MarshalAs(UnmanagedType.LPStr)]string dadosVenda);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public delegate IntPtr TrocarCodigoDeAtivacao(int numeroSessao,
				[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
				int opcao,
				[MarshalAs(UnmanagedType.LPStr)]string novoCodigo,
				[MarshalAs(UnmanagedType.LPStr)]string confNovoCodigo);
		}

		#endregion InnerTypes

		#region Fields

		private IntPtr handle;

		#endregion Fields

		#region Constructors

		public SatCdecl(string pathDll)
		{
			PathDll = pathDll;

			handle = NativeMethods.LoadLibrary(pathDll);
			if (handle == IntPtr.Zero) throw new Exception("");
		}

		~SatCdecl()
		{
			Dispose(false);
		}

		#endregion Constructors

		#region Propriedades

		public string PathDll { get; private set; }

		public string ModeloStr => "CdeclSatLibrary";

		#endregion Propriedades

		#region Method

		public string AssociarAssinatura(int numeroSessao, string codigoAtivacao, string cnpjValue, string assinaturacnpj)
		{
			var funcaoSat = handle.GetMethod<Delegates.AssociarAssinatura>("AssociarAssinatura");

			var retPtr = funcaoSat(numeroSessao, codigoAtivacao.ToSatStr(), cnpjValue.ToSatStr(), assinaturacnpj.ToSatStr());
			var ret = Marshal.PtrToStringAnsi(retPtr);

			return ret.FromSatStr();
		}

		public string AtivarSAT(int numeroSessao, int subComando, string codigoDeAtivacao, string cnpj, int cUF)
		{
			var funcaoSat = handle.GetMethod<Delegates.AtivarSAT>("AtivarSAT");

			var retPtr = funcaoSat(numeroSessao, subComando, codigoDeAtivacao.ToSatStr(), cnpj.ToSatStr(), cUF);
			var ret = Marshal.PtrToStringAnsi(retPtr);
			return ret.FromSatStr();
		}

		public string AtualizarSoftwareSAT(int numeroSessao, string codigoDeAtivacao)
		{
			var funcaoSat = handle.GetMethod<Delegates.AtualizarSoftwareSAT>("AtualizarSoftwareSAT");
			var retPtr = funcaoSat(numeroSessao, codigoDeAtivacao.ToSatStr());

			var ret = Marshal.PtrToStringAnsi(retPtr);
			return ret.FromSatStr();
		}

		public string BloquearSAT(int numeroSessao, string codigoDeAtivacao)
		{
			var funcaoSat = handle.GetMethod<Delegates.BloquearSAT>("BloquearSAT");
			var retPtr = funcaoSat(numeroSessao, codigoDeAtivacao.ToSatStr());

			var ret = Marshal.PtrToStringAnsi(retPtr);
			return ret.FromSatStr();
		}

		public string CancelarUltimaVenda(int numeroSessao, string codigoDeAtivacao, string chave, string dadosCancelamento)
		{
			var funcaoSat = handle.GetMethod<Delegates.CancelarUltimaVenda>("CancelarUltimaVenda");
			var retPtr = funcaoSat(numeroSessao, codigoDeAtivacao.ToSatStr(), chave.ToSatStr(), dadosCancelamento.ToSatStr());

			var ret = Marshal.PtrToStringAnsi(retPtr);
			return ret.FromSatStr();
		}

		public string ComunicarCertificadoIcpBrasil(int numeroSessao, string codigoDeAtivacao, string certificado)
		{
			var funcaoSat = handle.GetMethod<Delegates.ComunicarCertificadoICPBRASIL>("ComunicarCertificadoICPBRASIL");
			var retPtr = funcaoSat(numeroSessao, codigoDeAtivacao.ToSatStr(), certificado.ToSatStr());

			var ret = Marshal.PtrToStringAnsi(retPtr);
			return ret.FromSatStr();
		}

		public string ConfigurarInterfaceDeRede(int numeroSessao, string codigoDeAtivacao, string dadosConfiguracao)
		{
			var funcaoSat = handle.GetMethod<Delegates.ConfigurarInterfaceDeRede>("ConfigurarInterfaceDeRede");
			var retPtr = funcaoSat(numeroSessao, codigoDeAtivacao.ToSatStr(), dadosConfiguracao.ToSatStr());

			var ret = Marshal.PtrToStringAnsi(retPtr);
			return ret.FromSatStr();
		}

		public string ConsultarNumeroSessao(int numeroSessao, string codigoDeAtivacao, int cNumeroDeSessao)
		{
			var funcaoSat = handle.GetMethod<Delegates.ConsultarNumeroSessao>("ConsultarNumeroSessao");
			var retPtr = funcaoSat(numeroSessao, codigoDeAtivacao.ToSatStr(), cNumeroDeSessao);

			var ret = Marshal.PtrToStringAnsi(retPtr);
			return ret.FromSatStr();
		}

		public string ConsultarSAT(int numeroSessao)
		{
			var funcaoSat = handle.GetMethod<Delegates.ConsultarSAT>("ConsultarSAT");
			var retPtr = funcaoSat(numeroSessao);

			var ret = Marshal.PtrToStringAnsi(retPtr);
			return ret.FromSatStr();
		}

		public string ConsultarStatusOperacional(int numeroSessao, string codigoDeAtivacao)
		{
			var funcaoSat = handle.GetMethod<Delegates.ConsultarStatusOperacional>("ConsultarStatusOperacional");
			var retPtr = funcaoSat(numeroSessao, codigoDeAtivacao.ToSatStr());

			var ret = Marshal.PtrToStringAnsi(retPtr);
			return ret.FromSatStr();
		}

		public string DesbloquearSAT(int numeroSessao, string codigoDeAtivacao)
		{
			var funcaoSat = handle.GetMethod<Delegates.DesbloquearSAT>("DesbloquearSAT");
			var retPtr = funcaoSat(numeroSessao, codigoDeAtivacao.ToSatStr());

			var ret = Marshal.PtrToStringAnsi(retPtr);
			return ret.FromSatStr();
		}

		public string EnviarDadosVenda(int numeroSessao, string codigoDeAtivacao, string dadosVenda)
		{
			var funcaoSat = handle.GetMethod<Delegates.EnviarDadosVenda>("EnviarDadosVenda");
			var retPtr = funcaoSat(numeroSessao, codigoDeAtivacao.ToSatStr(), dadosVenda.ToSatStr());

			var ret = Marshal.PtrToStringAnsi(retPtr);
			return ret.FromSatStr();
		}

		public string ExtrairLogs(int numeroSessao, string codigoDeAtivacao)
		{
			var funcaoSat = handle.GetMethod<Delegates.ExtrairLogs>("ExtrairLogs");
			var retPtr = funcaoSat(numeroSessao, codigoDeAtivacao.ToSatStr());

			var ret = Marshal.PtrToStringAnsi(retPtr);
			return ret.FromSatStr();
		}

		public string TesteFimAFim(int numeroSessao, string codigoDeAtivacao, string dadosVenda)
		{
			var funcaoSat = handle.GetMethod<Delegates.TesteFimAFim>("ExtrairLogs");
			var retPtr = funcaoSat(numeroSessao, codigoDeAtivacao, dadosVenda.ToSatStr());

			var ret = Marshal.PtrToStringAnsi(retPtr);
			return ret.FromSatStr();
		}

		public string TrocarCodigoDeAtivacao(int numeroSessao, string codigoDeAtivacao, int opcao, string novoCodigo, string confNovoCodigo)
		{
			var funcaoSat = handle.GetMethod<Delegates.TrocarCodigoDeAtivacao>("TrocarCodigoDeAtivacao");
			var retPtr = funcaoSat(numeroSessao, codigoDeAtivacao.ToSatStr(), opcao, novoCodigo.ToSatStr(), confNovoCodigo.ToSatStr());

			var ret = Marshal.PtrToStringAnsi(retPtr);
			return ret.FromSatStr();
		}

		#endregion Method

		#region IDisposable

		public void Dispose()
		{
			Dispose(true);
		}

		private void Dispose(bool disposing)
		{
			if (disposing) GC.SuppressFinalize(this);
			if (handle != IntPtr.Zero)
			{
				handle.FreeLibrary();
				handle = IntPtr.Zero;
			}
		}

		#endregion IDisposable
	}
}
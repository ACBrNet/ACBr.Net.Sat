// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 03-30-2016
//
// Last Modified By : RFTD
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="SatCdecl.cs" company="ACBr.Net">
//		        		   The MIT License (MIT)
//	     		    Copyright (c) 2016 Grupo ACBr.Net
//
//	 Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//	 The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//	 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
// </copyright>
// <summary></summary>
// ***********************************************************************
using ACBr.Net.Core;
using ACBr.Net.Core.Exceptions;
using ACBr.Net.Sat.Interfaces;
using ACBr.Net.Sat.Utils;
using System;
using System.Runtime.InteropServices;
using System.Text;

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

		public SatCdecl(string pathDll, Encoding encoding)
		{
			PathDll = pathDll;
			Encoding = encoding;

			handle = NativeMethods.LoadLibrary(pathDll);
			Guard.Against<ACBrException>(handle == IntPtr.Zero, "Não foi possivel carregar a biblioteca Sat");
		}

		~SatCdecl()
		{
			Dispose(false);
		}

		#endregion Constructors

		#region Propriedades

		public Encoding Encoding { get; private set; }

		public string PathDll { get; private set; }

		public string ModeloStr => "CdeclSatLibrary";

		#endregion Propriedades

		#region Method

		public string AssociarAssinatura(int numeroSessao, string codigoAtivacao, string cnpjValue, string assinaturacnpj)
		{
			var funcaoSat = handle.GetMethod<Delegates.AssociarAssinatura>("AssociarAssinatura");

			var retPtr = funcaoSat(numeroSessao, ToEncoding(codigoAtivacao), ToEncoding(cnpjValue), ToEncoding(assinaturacnpj));
			var ret = Marshal.PtrToStringAnsi(retPtr);

			return FromEncoding(ret);
		}

		public string AtivarSAT(int numeroSessao, int subComando, string codigoDeAtivacao, string cnpj, int cUF)
		{
			var funcaoSat = handle.GetMethod<Delegates.AtivarSAT>("AtivarSAT");

			var retPtr = funcaoSat(numeroSessao, subComando, ToEncoding(codigoDeAtivacao), ToEncoding(cnpj), cUF);
			var ret = Marshal.PtrToStringAnsi(retPtr);

			return FromEncoding(ret);
		}

		public string AtualizarSoftwareSAT(int numeroSessao, string codigoDeAtivacao)
		{
			var funcaoSat = handle.GetMethod<Delegates.AtualizarSoftwareSAT>("AtualizarSoftwareSAT");

			var retPtr = funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao));
			var ret = Marshal.PtrToStringAnsi(retPtr);

			return FromEncoding(ret);
		}

		public string BloquearSAT(int numeroSessao, string codigoDeAtivacao)
		{
			var funcaoSat = handle.GetMethod<Delegates.BloquearSAT>("BloquearSAT");
			var retPtr = funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao));

			var ret = Marshal.PtrToStringAnsi(retPtr);
			return FromEncoding(ret);
		}

		public string CancelarUltimaVenda(int numeroSessao, string codigoDeAtivacao, string chave, string dadosCancelamento)
		{
			var funcaoSat = handle.GetMethod<Delegates.CancelarUltimaVenda>("CancelarUltimaVenda");
			var retPtr = funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao), ToEncoding(chave), ToEncoding(dadosCancelamento));

			var ret = Marshal.PtrToStringAnsi(retPtr);
			return FromEncoding(ret);
		}

		public string ComunicarCertificadoIcpBrasil(int numeroSessao, string codigoDeAtivacao, string certificado)
		{
			var funcaoSat = handle.GetMethod<Delegates.ComunicarCertificadoICPBRASIL>("ComunicarCertificadoICPBRASIL");
			var retPtr = funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao), ToEncoding(certificado));

			var ret = Marshal.PtrToStringAnsi(retPtr);
			return FromEncoding(ret);
		}

		public string ConfigurarInterfaceDeRede(int numeroSessao, string codigoDeAtivacao, string dadosConfiguracao)
		{
			var funcaoSat = handle.GetMethod<Delegates.ConfigurarInterfaceDeRede>("ConfigurarInterfaceDeRede");
			var retPtr = funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao), ToEncoding(dadosConfiguracao));

			var ret = Marshal.PtrToStringAnsi(retPtr);
			return FromEncoding(ret);
		}

		public string ConsultarNumeroSessao(int numeroSessao, string codigoDeAtivacao, int cNumeroDeSessao)
		{
			var funcaoSat = handle.GetMethod<Delegates.ConsultarNumeroSessao>("ConsultarNumeroSessao");
			var retPtr = funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao), cNumeroDeSessao);

			var ret = Marshal.PtrToStringAnsi(retPtr);
			return FromEncoding(ret);
		}

		public string ConsultarSAT(int numeroSessao)
		{
			var funcaoSat = handle.GetMethod<Delegates.ConsultarSAT>("ConsultarSAT");
			var retPtr = funcaoSat(numeroSessao);

			var ret = Marshal.PtrToStringAnsi(retPtr);
			return FromEncoding(ret);
		}

		public string ConsultarStatusOperacional(int numeroSessao, string codigoDeAtivacao)
		{
			var funcaoSat = handle.GetMethod<Delegates.ConsultarStatusOperacional>("ConsultarStatusOperacional");
			var retPtr = funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao));

			var ret = Marshal.PtrToStringAnsi(retPtr);
			return FromEncoding(ret);
		}

		public string DesbloquearSAT(int numeroSessao, string codigoDeAtivacao)
		{
			var funcaoSat = handle.GetMethod<Delegates.DesbloquearSAT>("DesbloquearSAT");
			var retPtr = funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao));

			var ret = Marshal.PtrToStringAnsi(retPtr);
			return FromEncoding(ret);
		}

		public string EnviarDadosVenda(int numeroSessao, string codigoDeAtivacao, string dadosVenda)
		{
			var funcaoSat = handle.GetMethod<Delegates.EnviarDadosVenda>("EnviarDadosVenda");
			var retPtr = funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao), ToEncoding(dadosVenda));

			var ret = Marshal.PtrToStringAnsi(retPtr);
			return FromEncoding(ret);
		}

		public string ExtrairLogs(int numeroSessao, string codigoDeAtivacao)
		{
			var funcaoSat = handle.GetMethod<Delegates.ExtrairLogs>("ExtrairLogs");
			var retPtr = funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao));

			var ret = Marshal.PtrToStringAnsi(retPtr);
			return FromEncoding(ret);
		}

		public string TesteFimAFim(int numeroSessao, string codigoDeAtivacao, string dadosVenda)
		{
			var funcaoSat = handle.GetMethod<Delegates.TesteFimAFim>("ExtrairLogs");
			var retPtr = funcaoSat(numeroSessao, codigoDeAtivacao, ToEncoding(dadosVenda));

			var ret = Marshal.PtrToStringAnsi(retPtr);
			return FromEncoding(ret);
		}

		public string TrocarCodigoDeAtivacao(int numeroSessao, string codigoDeAtivacao, int opcao, string novoCodigo, string confNovoCodigo)
		{
			var funcaoSat = handle.GetMethod<Delegates.TrocarCodigoDeAtivacao>("TrocarCodigoDeAtivacao");
			var retPtr = funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao), opcao, ToEncoding(novoCodigo), ToEncoding(confNovoCodigo));

			var ret = Marshal.PtrToStringAnsi(retPtr);
			return FromEncoding(ret);
		}

		private string FromEncoding(string str)
		{
			return Encoding.GetString(Encoding.Default.GetBytes(str));
		}

		private string ToEncoding(string str)
		{
			return Encoding.Default.GetString(Encoding.GetBytes(str));
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
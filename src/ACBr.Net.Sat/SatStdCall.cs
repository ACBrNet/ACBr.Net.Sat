// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 03-30-2016
//
// Last Modified By : RFTD
// Last Modified On : 02-16-2017
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
using ACBr.Net.Sat.Utils;
using System;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBr.Net.Sat
{
	internal sealed class SatStdCall : SatLibrary
	{
		#region InnerTypes

		private class Delegates
		{
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			public delegate IntPtr AssociarAssinatura(int numeroSessao,
				[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
				[MarshalAs(UnmanagedType.LPStr)]string cnpjValue,
				[MarshalAs(UnmanagedType.LPStr)]string assinaturaCnpj);

			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			public delegate IntPtr AtivarSAT(int numeroSessao, int subComando,
				[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
				[MarshalAs(UnmanagedType.LPStr)]string cnpj,
				int cUF);

			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			public delegate IntPtr AtualizarSoftwareSAT(int numeroSessao,
				[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao);

			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			public delegate IntPtr BloquearSAT(int numeroSessao,
				[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao);

			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			public delegate IntPtr CancelarUltimaVenda(int numeroSessao,
				[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
				[MarshalAs(UnmanagedType.LPStr)]string chave,
				[MarshalAs(UnmanagedType.LPStr)]string dadosCancelamento);

			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			public delegate IntPtr ComunicarCertificadoICPBRASIL(int numeroSessao,
				[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
				[MarshalAs(UnmanagedType.LPStr)]string certificado);

			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			public delegate IntPtr ConfigurarInterfaceDeRede(int numeroSessao,
				[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
				[MarshalAs(UnmanagedType.LPStr)]string dadosConfiguracao);

			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			public delegate IntPtr ConsultarNumeroSessao(int numeroSessao,
				[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
				int cNumeroDeSessao);

			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			public delegate IntPtr ConsultarSAT(int numeroSessao);

			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			public delegate IntPtr ConsultarStatusOperacional(int numeroSessao,
				[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao);

			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			public delegate IntPtr DesbloquearSAT(int numeroSessao,
				[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao);

			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			public delegate IntPtr EnviarDadosVenda(int numeroSessao,
				[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
				[MarshalAs(UnmanagedType.LPStr)]string dadosVenda);

			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			public delegate IntPtr ExtrairLogs(int numeroSessao,
				[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao);

			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			public delegate IntPtr TesteFimAFim(int numeroSessao,
				[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
				[MarshalAs(UnmanagedType.LPStr)]string dadosVenda);

			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			public delegate IntPtr TrocarCodigoDeAtivacao(int numeroSessao,
				[MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
				int opcao,
				[MarshalAs(UnmanagedType.LPStr)]string novoCodigo,
				[MarshalAs(UnmanagedType.LPStr)]string confNovoCodigo);
		}

		#endregion InnerTypes

		#region Constructors

		public SatStdCall(SatConfig config, string pathDll, Encoding encoding) : base(config, pathDll, encoding)
		{
			ModeloStr = "StdCallSatLibrary";
			handle = NativeMethods.LoadLibrary(PathDll);
			Guard.Against<ACBrException>(handle == IntPtr.Zero, "Não foi possivel carregar a biblioteca Sat");
		}

		#endregion Constructors

		#region Methods

		[HandleProcessCorruptedStateExceptions]
		public override string AssociarAssinatura(int numeroSessao, string codigoAtivacao, string cnpjValue, string assinaturacnpj)
		{
			try
			{
				var funcaoSat = handle.GetMethod<Delegates.AssociarAssinatura>("AssociarAssinatura");

				var retPtr = funcaoSat(numeroSessao, ToEncoding(codigoAtivacao), ToEncoding(cnpjValue), ToEncoding(assinaturacnpj));
				var ret = Marshal.PtrToStringAnsi(retPtr);

				return FromEncoding(ret);
			}
			catch (Exception exception)
			{
				throw new ACBrException(exception, exception.Message);
			}
		}

		[HandleProcessCorruptedStateExceptions]
		public override string AtivarSAT(int numeroSessao, int subComando, string codigoDeAtivacao, string cnpj, int cUF)
		{
			try
			{
				var funcaoSat = handle.GetMethod<Delegates.AtivarSAT>("AtivarSAT");

				var retPtr = funcaoSat(numeroSessao, subComando, ToEncoding(codigoDeAtivacao), ToEncoding(cnpj), cUF);
				var ret = Marshal.PtrToStringAnsi(retPtr);
				return FromEncoding(ret);
			}
			catch (Exception exception)
			{
				throw new ACBrException(exception, exception.Message);
			}
		}

		[HandleProcessCorruptedStateExceptions]
		public override string AtualizarSoftwareSAT(int numeroSessao, string codigoDeAtivacao)
		{
			try
			{
				var funcaoSat = handle.GetMethod<Delegates.AtualizarSoftwareSAT>("AtualizarSoftwareSAT");
				var retPtr = funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao));

				var ret = Marshal.PtrToStringAnsi(retPtr);
				return FromEncoding(ret);
			}
			catch (Exception exception)
			{
				throw new ACBrException(exception, exception.Message);
			}
		}

		[HandleProcessCorruptedStateExceptions]
		public override string BloquearSAT(int numeroSessao, string codigoDeAtivacao)
		{
			try
			{
				var funcaoSat = handle.GetMethod<Delegates.BloquearSAT>("BloquearSAT");
				var retPtr = funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao));

				var ret = Marshal.PtrToStringAnsi(retPtr);
				return FromEncoding(ret);
			}
			catch (Exception exception)
			{
				throw new ACBrException(exception, exception.Message);
			}
		}

		[HandleProcessCorruptedStateExceptions]
		public override string CancelarUltimaVenda(int numeroSessao, string codigoDeAtivacao, string chave, string dadosCancelamento)
		{
			try
			{
				var funcaoSat = handle.GetMethod<Delegates.CancelarUltimaVenda>("CancelarUltimaVenda");
				var retPtr = funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao), ToEncoding(chave), ToEncoding(dadosCancelamento));

				var ret = Marshal.PtrToStringAnsi(retPtr);
				return FromEncoding(ret);
			}
			catch (Exception exception)
			{
				throw new ACBrException(exception, exception.Message);
			}
		}

		[HandleProcessCorruptedStateExceptions]
		public override string ComunicarCertificadoIcpBrasil(int numeroSessao, string codigoDeAtivacao, string certificado)
		{
			try
			{
				var funcaoSat = handle.GetMethod<Delegates.ComunicarCertificadoICPBRASIL>("ComunicarCertificadoICPBRASIL");
				var retPtr = funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao), ToEncoding(certificado));

				var ret = Marshal.PtrToStringAnsi(retPtr);
				return FromEncoding(ret);
			}
			catch (Exception exception)
			{
				throw new ACBrException(exception, exception.Message);
			}
		}

		[HandleProcessCorruptedStateExceptions]
		public override string ConfigurarInterfaceDeRede(int numeroSessao, string codigoDeAtivacao, string dadosConfiguracao)
		{
			try
			{
				var funcaoSat = handle.GetMethod<Delegates.ConfigurarInterfaceDeRede>("ConfigurarInterfaceDeRede");
				var retPtr = funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao), ToEncoding(dadosConfiguracao));

				var ret = Marshal.PtrToStringAnsi(retPtr);
				return FromEncoding(ret);
			}
			catch (Exception exception)
			{
				throw new ACBrException(exception, exception.Message);
			}
		}

		[HandleProcessCorruptedStateExceptions]
		public override string ConsultarNumeroSessao(int numeroSessao, string codigoDeAtivacao, int cNumeroDeSessao)
		{
			try
			{
				var funcaoSat = handle.GetMethod<Delegates.ConsultarNumeroSessao>("ConsultarNumeroSessao");
				var retPtr = funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao), cNumeroDeSessao);

				var ret = Marshal.PtrToStringAnsi(retPtr);
				return FromEncoding(ret);
			}
			catch (Exception exception)
			{
				throw new ACBrException(exception, exception.Message);
			}
		}

		[HandleProcessCorruptedStateExceptions]
		public override string ConsultarSAT(int numeroSessao)
		{
			try
			{
				var funcaoSat = handle.GetMethod<Delegates.ConsultarSAT>("ConsultarSAT");
				var retPtr = funcaoSat(numeroSessao);

				var ret = Marshal.PtrToStringAnsi(retPtr);
				return FromEncoding(ret);
			}
			catch (Exception exception)
			{
				throw new ACBrException(exception, exception.Message);
			}
		}

		[HandleProcessCorruptedStateExceptions]
		public override string ConsultarStatusOperacional(int numeroSessao, string codigoDeAtivacao)
		{
			try
			{
				var funcaoSat = handle.GetMethod<Delegates.ConsultarStatusOperacional>("ConsultarStatusOperacional");
				var retPtr = funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao));

				var ret = Marshal.PtrToStringAnsi(retPtr);
				return FromEncoding(ret);
			}
			catch (Exception exception)
			{
				throw new ACBrException(exception, exception.Message);
			}
		}

		[HandleProcessCorruptedStateExceptions]
		public override string DesbloquearSAT(int numeroSessao, string codigoDeAtivacao)
		{
			try
			{
				var funcaoSat = handle.GetMethod<Delegates.DesbloquearSAT>("DesbloquearSAT");
				var retPtr = funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao));

				var ret = Marshal.PtrToStringAnsi(retPtr);
				return FromEncoding(ret);
			}
			catch (Exception exception)
			{
				throw new ACBrException(exception, exception.Message);
			}
		}

		[HandleProcessCorruptedStateExceptions]
		public override string EnviarDadosVenda(int numeroSessao, string codigoDeAtivacao, string dadosVenda)
		{
			try
			{
				var funcaoSat = handle.GetMethod<Delegates.EnviarDadosVenda>("EnviarDadosVenda");
				var retPtr = funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao), ToEncoding(dadosVenda));

				var ret = Marshal.PtrToStringAnsi(retPtr);
				return FromEncoding(ret);
			}
			catch (Exception exception)
			{
				throw new ACBrException(exception, exception.Message);
			}
		}

		[HandleProcessCorruptedStateExceptions]
		public override string ExtrairLogs(int numeroSessao, string codigoDeAtivacao)
		{
			try
			{
				var funcaoSat = handle.GetMethod<Delegates.ExtrairLogs>("ExtrairLogs");
				var retPtr = funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao));

				var ret = Marshal.PtrToStringAnsi(retPtr);
				return FromEncoding(ret);
			}
			catch (Exception exception)
			{
				throw new ACBrException(exception, exception.Message);
			}
		}

		[HandleProcessCorruptedStateExceptions]
		public override string TesteFimAFim(int numeroSessao, string codigoDeAtivacao, string dadosVenda)
		{
			try
			{
				var funcaoSat = handle.GetMethod<Delegates.TesteFimAFim>("TesteFimAFim");
				var retPtr = funcaoSat(numeroSessao, codigoDeAtivacao, FromEncoding(dadosVenda));

				var ret = Marshal.PtrToStringAnsi(retPtr);
				return FromEncoding(ret);
			}
			catch (Exception exception)
			{
				throw new ACBrException(exception, exception.Message);
			}
		}

		[HandleProcessCorruptedStateExceptions]
		public override string TrocarCodigoDeAtivacao(int numeroSessao, string codigoDeAtivacao, int opcao, string novoCodigo, string confNovoCodigo)
		{
			try
			{
				var funcaoSat = handle.GetMethod<Delegates.TrocarCodigoDeAtivacao>("TrocarCodigoDeAtivacao");
				var retPtr = funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao), opcao, ToEncoding(novoCodigo), ToEncoding(confNovoCodigo));

				var ret = Marshal.PtrToStringAnsi(retPtr);
				return FromEncoding(ret);
			}
			catch (Exception exception)
			{
				throw new ACBrException(exception, exception.Message);
			}
		}

		#endregion Methods
	}
}
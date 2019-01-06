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

using System.Runtime.InteropServices;
using System.Text;
using ACBr.Net.Core.InteropServices;

namespace ACBr.Net.Sat
{
    internal sealed class SatCdecl : SatLibrary
    {
        #region InnerTypes

        private class Delegates
        {
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ACBrLPStr))]
            public delegate string AssociarAssinatura(int numeroSessao,
                [MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
                [MarshalAs(UnmanagedType.LPStr)]string cnpjValue,
                [MarshalAs(UnmanagedType.LPStr)]string assinaturaCnpj);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ACBrLPStr))]
            public delegate string AtivarSAT(int numeroSessao, int subComando,
                [MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
                [MarshalAs(UnmanagedType.LPStr)]string cnpj,
                int cUF);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ACBrLPStr))]
            public delegate string AtualizarSoftwareSAT(int numeroSessao,
                [MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ACBrLPStr))]
            public delegate string BloquearSAT(int numeroSessao,
                [MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ACBrLPStr))]
            public delegate string CancelarUltimaVenda(int numeroSessao,
                [MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
                [MarshalAs(UnmanagedType.LPStr)]string chave,
                [MarshalAs(UnmanagedType.LPStr)]string dadosCancelamento);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ACBrLPStr))]
            public delegate string ComunicarCertificadoICPBRASIL(int numeroSessao,
                [MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
                [MarshalAs(UnmanagedType.LPStr)]string certificado);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ACBrLPStr))]
            public delegate string ConfigurarInterfaceDeRede(int numeroSessao,
                [MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
                [MarshalAs(UnmanagedType.LPStr)]string dadosConfiguracao);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ACBrLPStr))]
            public delegate string ConsultarNumeroSessao(int numeroSessao,
                [MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
                int cNumeroDeSessao);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ACBrLPStr))]
            public delegate string ConsultarSAT(int numeroSessao);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ACBrLPStr))]
            public delegate string ConsultarStatusOperacional(int numeroSessao,
                [MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ACBrLPStr))]
            public delegate string DesbloquearSAT(int numeroSessao,
                [MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ACBrLPStr))]
            public delegate string EnviarDadosVenda(int numeroSessao,
                [MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
                [MarshalAs(UnmanagedType.LPStr)]string dadosVenda);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ACBrLPStr))]
            public delegate string ExtrairLogs(int numeroSessao,
                [MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ACBrLPStr))]
            public delegate string TesteFimAFim(int numeroSessao,
                [MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
                [MarshalAs(UnmanagedType.LPStr)]string dadosVenda);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ACBrLPStr))]
            public delegate string TrocarCodigoDeAtivacao(int numeroSessao,
                [MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao,
                int opcao,
                [MarshalAs(UnmanagedType.LPStr)]string novoCodigo,
                [MarshalAs(UnmanagedType.LPStr)]string confNovoCodigo);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ACBrLPStr))]
            public delegate string ConsultarUltimaSessaoFiscal(int numeroSessao,
                [MarshalAs(UnmanagedType.LPStr)]string codigoDeAtivacao);
        }

        #endregion InnerTypes

        #region Constructors

        public SatCdecl(SatConfig config, string pathDll, Encoding encoding) : base(config, pathDll, encoding)
        {
            ModeloStr = "Cdecl";

            AddMethod<Delegates.AssociarAssinatura>("AssociarAssinatura");
            AddMethod<Delegates.AtivarSAT>("AtivarSAT");
            AddMethod<Delegates.AtualizarSoftwareSAT>("AtualizarSoftwareSAT");
            AddMethod<Delegates.BloquearSAT>("BloquearSAT");
            AddMethod<Delegates.CancelarUltimaVenda>("CancelarUltimaVenda");
            AddMethod<Delegates.ComunicarCertificadoICPBRASIL>("ComunicarCertificadoICPBRASIL");
            AddMethod<Delegates.ConfigurarInterfaceDeRede>("ConfigurarInterfaceDeRede");
            AddMethod<Delegates.ConsultarNumeroSessao>("ConsultarNumeroSessao");
            AddMethod<Delegates.ConsultarSAT>("ConsultarSAT");
            AddMethod<Delegates.ConsultarStatusOperacional>("ConsultarStatusOperacional");
            AddMethod<Delegates.DesbloquearSAT>("DesbloquearSAT");
            AddMethod<Delegates.EnviarDadosVenda>("EnviarDadosVenda");
            AddMethod<Delegates.ExtrairLogs>("ExtrairLogs");
            AddMethod<Delegates.TesteFimAFim>("TesteFimAFim");
            AddMethod<Delegates.TrocarCodigoDeAtivacao>("TrocarCodigoDeAtivacao");
            AddMethod<Delegates.ConsultarUltimaSessaoFiscal>("ConsultarUltimaSessaoFiscal");
        }

        #endregion Constructors

        #region Method

        public override string AssociarAssinatura(int numeroSessao, string codigoAtivacao, string cnpjValue, string assinaturacnpj)
        {
            var funcaoSat = GetMethod<Delegates.AssociarAssinatura>();
            return ExecuteMethod(() => funcaoSat(numeroSessao, ToEncoding(codigoAtivacao), ToEncoding(cnpjValue), ToEncoding(assinaturacnpj)));
        }

        public override string AtivarSAT(int numeroSessao, int subComando, string codigoDeAtivacao, string cnpj, int cUF)
        {
            var funcaoSat = GetMethod<Delegates.AtivarSAT>();
            return ExecuteMethod(() => funcaoSat(numeroSessao, subComando, ToEncoding(codigoDeAtivacao), ToEncoding(cnpj), cUF));
        }

        public override string AtualizarSoftwareSAT(int numeroSessao, string codigoDeAtivacao)
        {
            var funcaoSat = GetMethod<Delegates.AtualizarSoftwareSAT>();
            return ExecuteMethod(() => funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao)));
        }

        public override string BloquearSAT(int numeroSessao, string codigoDeAtivacao)
        {
            var funcaoSat = GetMethod<Delegates.BloquearSAT>();
            return ExecuteMethod(() => funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao)));
        }

        public override string CancelarUltimaVenda(int numeroSessao, string codigoDeAtivacao, string chave, string dadosCancelamento)
        {
            var funcaoSat = GetMethod<Delegates.CancelarUltimaVenda>();
            return ExecuteMethod(() => funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao), ToEncoding(chave),
                ToEncoding(dadosCancelamento)));
        }

        public override string ComunicarCertificadoIcpBrasil(int numeroSessao, string codigoDeAtivacao, string certificado)
        {
            var funcaoSat = GetMethod<Delegates.ComunicarCertificadoICPBRASIL>();
            return ExecuteMethod(() => funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao), ToEncoding(certificado)));
        }

        public override string ConfigurarInterfaceDeRede(int numeroSessao, string codigoDeAtivacao, string dadosConfiguracao)
        {
            var funcaoSat = GetMethod<Delegates.ConfigurarInterfaceDeRede>();
            return ExecuteMethod(() => funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao), ToEncoding(dadosConfiguracao)));
        }

        public override string ConsultarNumeroSessao(int numeroSessao, string codigoDeAtivacao, int cNumeroDeSessao)
        {
            var funcaoSat = GetMethod<Delegates.ConsultarNumeroSessao>();
            return ExecuteMethod(() => funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao), cNumeroDeSessao));
        }

        public override string ConsultarUltimaSessaoFiscal(int numeroSessao, string codigoDeAtivacao)
        {
            var funcaoSat = GetMethod<Delegates.ConsultarUltimaSessaoFiscal>();
            return ExecuteMethod(() => funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao)));
        }

        public override string ConsultarSAT(int numeroSessao)
        {
            var funcaoSat = GetMethod<Delegates.ConsultarSAT>();
            return ExecuteMethod(() => funcaoSat(numeroSessao));
        }

        public override string ConsultarStatusOperacional(int numeroSessao, string codigoDeAtivacao)
        {
            var funcaoSat = GetMethod<Delegates.ConsultarStatusOperacional>();
            return ExecuteMethod(() => funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao)));
        }

        public override string DesbloquearSAT(int numeroSessao, string codigoDeAtivacao)
        {
            var funcaoSat = GetMethod<Delegates.DesbloquearSAT>();
            return ExecuteMethod(() => funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao)));
        }

        public override string EnviarDadosVenda(int numeroSessao, string codigoDeAtivacao, string dadosVenda)
        {
            var funcaoSat = GetMethod<Delegates.EnviarDadosVenda>();
            return ExecuteMethod(() => funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao), ToEncoding(dadosVenda)));
        }

        public override string ExtrairLogs(int numeroSessao, string codigoDeAtivacao)
        {
            var funcaoSat = GetMethod<Delegates.ExtrairLogs>();
            return ExecuteMethod(() => funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao)));
        }

        public override string TesteFimAFim(int numeroSessao, string codigoDeAtivacao, string dadosVenda)
        {
            var funcaoSat = GetMethod<Delegates.TesteFimAFim>();
            return ExecuteMethod(() => funcaoSat(numeroSessao, codigoDeAtivacao, ToEncoding(dadosVenda)));
        }

        public override string TrocarCodigoDeAtivacao(int numeroSessao, string codigoDeAtivacao, int opcao, string novoCodigo, string confNovoCodigo)
        {
            var funcaoSat = GetMethod<Delegates.TrocarCodigoDeAtivacao>();
            return ExecuteMethod(() => funcaoSat(numeroSessao, ToEncoding(codigoDeAtivacao), opcao, ToEncoding(novoCodigo),
                ToEncoding(confNovoCodigo)));
        }

        #endregion Method
    }
}
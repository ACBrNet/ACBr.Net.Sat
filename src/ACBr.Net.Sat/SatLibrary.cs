// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 11-24-2016
//
// Last Modified By : RFTD
// Last Modified On : 11-24-2016
// ***********************************************************************
// <copyright file="SatLibrary.cs" company="ACBr.Net">
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
using System.Text;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Class SatLibrary.
	/// </summary>
	/// <seealso cref="System.IDisposable" />
	public abstract class SatLibrary : IDisposable
	{
		#region Fields

		protected IntPtr handle;

		#endregion Fields

		#region Constructors

		protected SatLibrary(string pathDll, Encoding encoding)
		{
			PathDll = pathDll;
			Encoding = encoding;

			handle = NativeMethods.LoadLibrary(pathDll);
			Guard.Against<ACBrException>(handle == IntPtr.Zero, "Não foi possivel carregar a biblioteca Sat");
		}

		~SatLibrary()
		{
			Dispose(false);
		}

		#endregion Constructors

		#region Propriedades

		public Encoding Encoding { get; protected set; }

		public string PathDll { get; protected set; }

		public string ModeloStr { get; protected set; }

		#endregion Propriedades

		#region Method

		public abstract string AssociarAssinatura(int numeroSessao, string codigoAtivacao, string cnpjValue,
			string assinaturacnpj);

		public abstract string AtivarSAT(int numeroSessao, int subComando, string codigoDeAtivacao, string cnpj, int cUF);

		public abstract string AtualizarSoftwareSAT(int numeroSessao, string codigoDeAtivacao);

		public abstract string BloquearSAT(int numeroSessao, string codigoDeAtivacao);

		public abstract string CancelarUltimaVenda(int numeroSessao, string codigoDeAtivacao, string chave,
			string dadosCancelamento);

		public abstract string ComunicarCertificadoIcpBrasil(int numeroSessao, string codigoDeAtivacao, string certificado);

		public abstract string ConfigurarInterfaceDeRede(int numeroSessao, string codigoDeAtivacao, string dadosConfiguracao);

		public abstract string ConsultarNumeroSessao(int numeroSessao, string codigoDeAtivacao, int cNumeroDeSessao);

		public abstract string ConsultarSAT(int numeroSessao);

		public abstract string ConsultarStatusOperacional(int numeroSessao, string codigoDeAtivacao);

		public abstract string DesbloquearSAT(int numeroSessao, string codigoDeAtivacao);

		public abstract string EnviarDadosVenda(int numeroSessao, string codigoDeAtivacao, string dadosVenda);

		public abstract string ExtrairLogs(int numeroSessao, string codigoDeAtivacao);

		public abstract string TesteFimAFim(int numeroSessao, string codigoDeAtivacao, string dadosVenda);

		public abstract string TrocarCodigoDeAtivacao(int numeroSessao, string codigoDeAtivacao, int opcao, string novoCodigo,
			string confNovoCodigo);

		protected string FromEncoding(string str)
		{
			return Encoding.GetString(Encoding.Default.GetBytes(str));
		}

		protected string ToEncoding(string str)
		{
			return Encoding.Default.GetString(Encoding.GetBytes(str));
		}

		#endregion Method

		#region IDisposable

		public void Dispose()
		{
			Dispose(true);
		}

		protected void Dispose(bool disposing)
		{
			if (disposing) GC.SuppressFinalize(this);
			if (handle == IntPtr.Zero) return;

			handle.FreeLibrary();
			handle = IntPtr.Zero;
		}

		#endregion IDisposable
	}
}
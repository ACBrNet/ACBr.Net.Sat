// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 03-31-2016
//
// Last Modified By : RFTD
// Last Modified On : 02-16-2017
// ***********************************************************************
// <copyright file="CfgArquivos.cs" company="ACBr.Net">
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

using System.ComponentModel;
using System.Reflection;
using ACBr.Net.Core;
using ACBr.Net.Core.Extensions;

namespace ACBr.Net.Sat
{
    /// <summary>
    /// Classe de configuração de salvamento dos arquivos da NFe
    /// </summary>
    [TypeConverter(typeof(ACBrExpandableObjectConverter))]
    public sealed class CfgArquivos
    {
        #region Constructor

        /// <summary>
        /// Inicializa uma nova instancia da classe <see cref="CfgArquivos" />.
        /// </summary>
        internal CfgArquivos()
        {
            PrefixoArqCFe = @"AD";
            PrefixoArqCFeCanc = @"ADC";
            var path = Assembly.GetExecutingAssembly().GetPath();
            PastaCFeVenda = $@"{path}\Vendas";
            PastaCFeCancelamento = $@"{path}\Cancelamentos";
            PastaEnvio = $@"{path}\Enviado";
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether [salvar c fe].
        /// </summary>
        /// <value><c>true</c> if [salvar c fe]; otherwise, <c>false</c>.</value>
        public bool SalvarCFe { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [salvar c fe canc].
        /// </summary>
        /// <value><c>true</c> if [salvar c fe canc]; otherwise, <c>false</c>.</value>
        public bool SalvarCFeCanc { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [salvar envio].
        /// </summary>
        /// <value><c>true</c> if [salvar envio]; otherwise, <c>false</c>.</value>
        public bool SalvarEnvio { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [separar por CNPJ].
        /// </summary>
        /// <value><c>true</c> if [separar por CNPJ]; otherwise, <c>false</c>.</value>
        public bool SepararPorCNPJ { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [separar por mes].
        /// </summary>
        /// <value><c>true</c> if [separar por mes]; otherwise, <c>false</c>.</value>
        public bool SepararPorMes { get; set; }

        /// <summary>
        /// Gets or sets the pasta c fe venda.
        /// </summary>
        /// <value>The pasta c fe venda.</value>
        public string PastaCFeVenda { get; set; }

        /// <summary>
        /// Gets or sets the pasta c fe cancelamento.
        /// </summary>
        /// <value>The pasta c fe cancelamento.</value>
        public string PastaCFeCancelamento { get; set; }

        /// <summary>
        /// Gets or sets the pasta envio.
        /// </summary>
        /// <value>The pasta envio.</value>
        public string PastaEnvio { get; set; }

        /// <summary>
        /// Gets or sets the prefixo arq c fe.
        /// </summary>
        /// <value>The prefixo arq c fe.</value>
        public string PrefixoArqCFe { get; set; }

        /// <summary>
        /// Gets or sets the prefixo arq c fe canc.
        /// </summary>
        /// <value>The prefixo arq c fe canc.</value>
        public string PrefixoArqCFeCanc { get; set; }

        #endregion Properties
    }
}
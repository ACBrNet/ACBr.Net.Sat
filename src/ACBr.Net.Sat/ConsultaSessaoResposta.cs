// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 05-10-2016
//
// Last Modified By : RFTD
// Last Modified On : 02-16-2017
// ***********************************************************************
// <copyright file="ConsultaSessaoResposta.cs" company="ACBr.Net">
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

using System;
using System.IO;
using System.Text;
using ACBr.Net.Core.Extensions;

namespace ACBr.Net.Sat
{
    public sealed class ConsultaSessaoResposta : SatResposta
    {
        #region Constructors

        /// <inheritdoc />
        public ConsultaSessaoResposta(string retorno, Encoding encoding) : base(retorno, encoding)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (CodigoDeRetorno)
            {
                case 6000:
                    if (RetornoLst.Count < 6) return;

                    using (var stream = new MemoryStream(Convert.FromBase64String(RetornoLst[6])))
                        Venda = CFe.Load(stream, encoding);

                    QRCode = $"{RetornoLst[8].OnlyNumbers()}|{RetornoLst[7]}|{RetornoLst[9]}|{RetornoLst[10]}|{RetornoLst[11]}";
                    break;

                case 7000:
                    if (RetornoLst.Count < 6) return;

                    using (var stream = new MemoryStream(Convert.FromBase64String(RetornoLst[6])))
                        Cancelamento = CFeCanc.Load(stream, encoding);

                    QRCode = $"{RetornoLst[8].OnlyNumbers()}|{RetornoLst[7]}|{RetornoLst[9]}|{RetornoLst[10]}|{RetornoLst[11]}";
                    break;
            }
        }

        #endregion Constructors

        #region Properties

        public CFe Venda { get; private set; }

        public CFeCanc Cancelamento { get; set; }

        /// <summary>
        /// Retorna o QRCode caso tenha sido realizado com sucesso.
        /// </summary>
        /// <value>The qr code.</value>
        public string QRCode { get; private set; }

        #endregion Properties
    }
}
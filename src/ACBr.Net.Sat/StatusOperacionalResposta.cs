﻿// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 05-10-2016
//
// Last Modified By : RFTD
// Last Modified On : 02-16-2017
// ***********************************************************************
// <copyright file="StatusOperacionalResposta.cs" company="ACBr.Net">
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
using System.Globalization;
using System.Text;
using ACBr.Net.Core.Extensions;

namespace ACBr.Net.Sat
{
    public sealed class StatusOperacionalResposta : SatResposta
    {
        #region Constructors

        public StatusOperacionalResposta(string retorno, Encoding encoding) : base(retorno, encoding)
        {
            ConfigRede = new SatRede();
            Status = new SatStatus();

            if (CodigoDeRetorno != 10000) return;

            switch (RetornoLst[6])
            {
                case "PPPoE":
                    ConfigRede.TipoLan = TipoLan.PPPoE;
                    break;

                case "IPFIX":
                    ConfigRede.TipoLan = TipoLan.IPFIX;
                    break;

                default:
                    ConfigRede.TipoLan = TipoLan.DHCP;
                    break;
            }

            ConfigRede.LanIp = RetornoLst[7];
            ConfigRede.LanMask = RetornoLst[9];
            ConfigRede.LanGateway = RetornoLst[10];
            ConfigRede.LanDNS1 = RetornoLst[11];
            ConfigRede.LanDNS2 = RetornoLst[12];

            Status.NSerie = RetornoLst[5];
            Status.LanMac = RetornoLst[8];
            switch (RetornoLst[13])
            {
                case "NAO_CONECTADO":
                    Status.StatusLan = StatusLan.NaoConectado;
                    break;

                default:
                    Status.StatusLan = StatusLan.Conectado;
                    break;
            }
            switch (RetornoLst[14])
            {
                case "ALTO":
                    Status.NivelBateria = NivelBateria.Alto;
                    break;

                case "MEDIO":
                    Status.NivelBateria = NivelBateria.Medio;
                    break;

                default:
                    Status.NivelBateria = NivelBateria.Baixo;
                    break;
            }
            Status.MTTotal = RetornoLst[15];
            Status.MTUsada = RetornoLst[16];
            Status.DhAtual = DateTime.ParseExact(RetornoLst[17], "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
            Status.VerSb = RetornoLst[18];
            Status.VerLayout = RetornoLst[19];
            Status.UltimoCFe = RetornoLst[20];
            Status.ListaInicial = RetornoLst[21];

            var i = 22;
            //Workaround para leitura de Status do Emulador do Fisco, que não retorna o campo: LISTA_FINAL
            if (RetornoLst.Count > 27)
            {
                Status.ListaFinal = RetornoLst[i];
                i++;
            }
            Status.DhCFe = DateTime.ParseExact(RetornoLst[i], "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
            i++;
            Status.DhUltima = DateTime.ParseExact(RetornoLst[i], "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
            i++;
            Status.CertEmissao = DateTime.ParseExact(RetornoLst[i], "yyyyMMdd", CultureInfo.InvariantCulture);
            i++;
            Status.CertVencimento = DateTime.ParseExact(RetornoLst[i], "yyyyMMdd", CultureInfo.InvariantCulture);
            i++;
            var retStr = RetornoLst[i];
            if (retStr.IsNumeric())
                Status.EstadoOperacao = (EstadoOperacao)retStr.ToInt32();
            else
                switch (retStr)
                {
                    case "BLOQUEIO_SEFAZ":
                        Status.EstadoOperacao = EstadoOperacao.BloqueioSEFAZ;
                        break;

                    case "BLOQUEIO_CONTRIBUINTE":
                        Status.EstadoOperacao = EstadoOperacao.BloqueioComtribuinte;
                        break;

                    case "BLOQUEIO_AUTONOMO":
                        Status.EstadoOperacao = EstadoOperacao.BloqueioAutonomo;
                        break;

                    case "BLOQUEIO_DESATIVACAO":
                        Status.EstadoOperacao = EstadoOperacao.BloqueioDesativacao;
                        break;

                    default:
                        Status.EstadoOperacao = EstadoOperacao.Desbloqueado;
                        break;
                }
        }

        #endregion Constructors

        #region Propriedades

        public SatRede ConfigRede { get; set; }

        public SatStatus Status { get; set; }

        #endregion Propriedades
    }
}
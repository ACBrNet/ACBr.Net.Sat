// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-23-2016
//
// Last Modified By : RFTD
// Last Modified On : 04-28-2016
// ***********************************************************************
// <copyright file="CFe.cs" company="ACBr.Net">
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
using System.Globalization;
using ACBr.Net.Core.Extensions;
using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Document;

namespace ACBr.Net.Sat
{
    [DFeRoot("CFe")]
    public sealed class CFe : DFeDocument<CFe>, INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Fields

        private InfCFe infCFe;

        #endregion Fields

        #region Constructors

        /// <summary>
        ///
        /// </summary>
        public CFe()
        {
            infCFe = new InfCFe(this);
            Signature = new DFeSignature();
        }

        #endregion Constructors

        #region Properties

        [DFeElement("infCFe", Ocorrencia = Ocorrencia.Obrigatoria)]
        public InfCFe InfCFe
        {
            get => infCFe;
            set
            {
                if (infCFe == value) return;

                infCFe = value;
                if (value != null && value.Parent != this)
                    value.Parent = this;
            }
        }

        public DFeSignature Signature { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Retorna o valor do QrCode
        /// </summary>
        /// <returns>Código QrCode</returns>
        public string GetQRCode()
        {
            var documento = InfCFe.Dest.CNPJ.IsEmpty() ? InfCFe.Dest.CPF.OnlyNumbers() : InfCFe.Dest.CNPJ.OnlyNumbers();
            return $"{InfCFe.Id.OnlyNumbers()}|{InfCFe.Ide.DhEmissao:yyyyMMddHHmmss}|{InfCFe.Total.VCFe.ToString("0.00", CultureInfo.InvariantCulture)}|{documento}|{InfCFe.Ide.AssinaturaQrcode}";
        }

        /// <summary>
        /// Função para preencher o número do item da lista de itens da CFe.
        /// </summary>
        public void PreencherNItem()
        {
            for (var i = 0; i < InfCFe.Det.Count; i++)
            {
                var det = InfCFe.Det[i];
                det.NItem = i++;
            }
        }

        private bool ShouldSerializeSignature()
        {
            return !Signature.SignatureValue.IsEmpty() &&
                   !Signature.SignedInfo.Reference.DigestValue.IsEmpty() &&
                   !Signature.KeyInfo.X509Data.X509Certificate.IsEmpty();
        }

        #endregion Methods
    }
}
// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-28-2016
//
// Last Modified By : RFTD
// Last Modified On : 04-28-2016
// ***********************************************************************
// <copyright file="infCFe.cs" company="ACBr.Net">
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
using ACBr.Net.Core.Extensions;
using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Serializer;
using System.Linq;
using ACBr.Net.DFe.Core.Collection;

namespace ACBr.Net.Sat
{
    /// <summary>
    /// Class infCFe.
    /// </summary>
    public sealed class InfCFe : DFeParentItem<InfCFe, CFe>, INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Fields

        private CFeDetCollection det;
        private CFeInfAdic infAdic;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="InfCFe"/> class.
        /// </summary>
        public InfCFe()
        {
            Ide = new CFeIde();
            Emit = new CFeEmit();
            Dest = new CFeDest();
            Entrega = new CFeEntrega();
            Det = new CFeDetCollection();
            Total = new CFeTotal();
            Pagto = new CFePgto();
            InfAdic = new CFeInfAdic();
            ObsFisco = new DFeCollection<CFeObsFisco>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CFe" /> class.
        /// </summary>
        /// <returns>CFe.</returns>
        public InfCFe(CFe parent) : this()
        {
            Parent = parent;
            Det = new CFeDetCollection(Parent);
            InfAdic = new CFeInfAdic(Parent);
        }

        #endregion Constructor

        #region Propriedades

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [DFeAttribute(TipoCampo.Str, "Id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets the versao.
        /// </summary>
        /// <value>The versao.</value>
        [DFeAttribute(TipoCampo.De2, "versao", Min = 4, Max = 9, Ocorrencia = Ocorrencia.MaiorQueZero)]
        public decimal Versao { get; set; }

        /// <summary>
        /// Gets the versao dados ent.
        /// </summary>
        /// <value>The versao dados ent.</value>
        [DFeAttribute(TipoCampo.De2, "versaoDadosEnt", Min = 4, Max = 9, Ocorrencia = Ocorrencia.MaiorQueZero)]
        public decimal VersaoDadosEnt { get; set; }

        /// <summary>
        /// Gets the versao sb.
        /// </summary>
        /// <value>The versao sb.</value>
        [DFeAttribute(TipoCampo.De2, "versaoSB", Ocorrencia = Ocorrencia.MaiorQueZero)]
        public decimal VersaoSb { get; set; }

        /// <summary>
        /// Gets the IDE.
        /// </summary>
        /// <value>The IDE.</value>
        [DFeElement("ide", Id = "B01", Ocorrencia = Ocorrencia.Obrigatoria)]
        public CFeIde Ide { get; set; }

        /// <summary>
        /// Gets the emit.
        /// </summary>
        /// <value>The emit.</value>
        [DFeElement("emit", Id = "C01", Ocorrencia = Ocorrencia.Obrigatoria)]
        public CFeEmit Emit { get; set; }

        /// <summary>
        /// Gets the dest.
        /// </summary>
        /// <value>The dest.</value>
        [DFeElement("dest", Id = "E01", Ocorrencia = Ocorrencia.Obrigatoria)]
        public CFeDest Dest { get; set; }

        /// <summary>
        /// Gets the entrega.
        /// </summary>
        /// <value>The entrega.</value>
        [DFeElement("entrega", Id = "G01", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public CFeEntrega Entrega { get; set; }

        /// <summary>
        /// Gets the det.
        /// </summary>
        /// <value>The det.</value>
        [DFeCollection("det", Id = "H01", MinSize = 1, MaxSize = 500)]
        public CFeDetCollection Det
        {
            get => det;
            set
            {
                det = value;
                if (det != null && det.Parent != Parent)
                    det.Parent = Parent;
            }
        }

        /// <summary>
        /// Gets the total.
        /// </summary>
        /// <value>The total.</value>
        [DFeElement("total", Id = "W01", Ocorrencia = Ocorrencia.Obrigatoria)]
        public CFeTotal Total { get; set; }

        /// <summary>
        /// Gets the pgto.
        /// </summary>
        /// <value>The pgto.</value>
        [DFeElement("pgto", Id = "WA01", Ocorrencia = Ocorrencia.Obrigatoria)]
        public CFePgto Pagto { get; set; }

        /// <summary>
        /// Gets the inf adic.
        /// </summary>
        /// <value>The inf adic.</value>
        [DFeElement("infAdic", Id = "Z01", Ocorrencia = Ocorrencia.Obrigatoria)]
        public CFeInfAdic InfAdic
        {
            get => infAdic;
            set
            {
                if (infAdic == value) return;

                infAdic = value;
                if (value != null && value.Parent != Parent)
                    value.Parent = Parent;
            }
        }

        /// <summary>
        /// Gets or sets the obs fisco.
        /// </summary>
        /// <value>The obs fisco.</value>
        [DFeCollection("obsFisco", Id = "Z03", MinSize = 0, MaxSize = 10, Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public DFeCollection<CFeObsFisco> ObsFisco { get; set; }

        #endregion Propriedades

        #region Methods

        private bool ShouldSerializeId()
        {
            return !Id.IsEmpty();
        }

        private bool ShouldSerializeEntrega()
        {
            return !Entrega.XLgr.IsEmpty() ||
                   !Entrega.Nro.IsEmpty() ||
                   !Entrega.XCpl.IsEmpty() ||
                   !Entrega.XBairro.IsEmpty() ||
                   !Entrega.XMun.IsEmpty() ||
                   !Entrega.UF.IsEmpty();
        }

        private bool ShouldSerializeInfAdic()
        {
            return !InfAdic.InfCpl.IsEmpty() || InfAdic.ObsFisco.Any() && Versao < 0.08M;
        }

        private bool ShouldSerializeObsFisco()
        {
            return Versao > 0.07M && ObsFisco.Any();
        }

        /// <inheritdoc />
        protected override void OnParentChanged()
        {
            Det.Parent = Parent;
            InfAdic.Parent = Parent;
        }

        #endregion Methods
    }
}
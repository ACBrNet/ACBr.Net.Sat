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

using System.Linq;
using ACBr.Net.Core.Extensions;
using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Serializer;
using PropertyChanged;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Class infCFe.
	/// </summary>
	[ImplementPropertyChanged]
	public sealed class InfCFe
	{
		#region Fields

		private CFe parent;
		private CFeDetCollection det;
		private string id;

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
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CFe" /> class.
		/// </summary>
		/// <returns>CFe.</returns>
		public InfCFe(CFe parent):this()
		{
			Parent = parent;
			Det = new CFeDetCollection(Parent);
		}

		#endregion Constructor

		#region Propriedades

		/// <summary>
		/// Gets the parent.
		/// </summary>
		/// <value>The parent.</value>
		[DFeIgnore]
		public CFe Parent
		{
			get { return parent; }
			internal set
			{
				parent = value;
				Det.Parent = value;
			}
		}

		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>The identifier.</value>
		[DFeAttribute(TipoCampo.Str, "Id")]
		public string Id
		{
			get { return id; }
			set
			{
				id = value.SafeReplace("CFe", string.Empty);
			}
		}

		/// <summary>
		/// Gets the versao.
		/// </summary>
		/// <value>The versao.</value>
		[DFeAttribute(TipoCampo.De2, "versao", Min = 4, Max = 9)]
		public decimal Versao { get; set; }

		/// <summary>
		/// Gets the versao dados ent.
		/// </summary>
		/// <value>The versao dados ent.</value>
		[DFeAttribute(TipoCampo.De2, "versaoDadosEnt", Min = 4, Max = 9, Ocorrencias = 1)]
		public decimal VersaoDadosEnt { get; set; }

		/// <summary>
		/// Gets the versao sb.
		/// </summary>
		/// <value>The versao sb.</value>
		[DFeAttribute(TipoCampo.De2, "versaoSB")]
		public decimal VersaoSb { get; set; }

		/// <summary>
		/// Gets the IDE.
		/// </summary>
		/// <value>The IDE.</value>
		[DFeElement("ide", Id = "B01", Ocorrencias = 1)]
		public CFeIde Ide { get; set; }

		/// <summary>
		/// Gets the emit.
		/// </summary>
		/// <value>The emit.</value>
		[DFeElement("emit", Id = "C01", Ocorrencias = 1)]
		public CFeEmit Emit { get; set; }

		/// <summary>
		/// Gets the dest.
		/// </summary>
		/// <value>The dest.</value>
		[DFeElement("dest", Id = "E01", Ocorrencias = 1)]
		public CFeDest Dest { get; set; }

		/// <summary>
		/// Gets the entrega.
		/// </summary>
		/// <value>The entrega.</value>
		[DFeElement("entrega", Id = "G01", Ocorrencias = 0)]
		public CFeEntrega Entrega { get; set; }

		/// <summary>
		/// Gets the det.
		/// </summary>
		/// <value>The det.</value>
		[DFeElement("det", Id = "H01", Min = 1, Max = 500)]
		public CFeDetCollection Det
		{
			get { return det; }
			set
			{
				det = value;
				det.Parent = parent;
			}
		}

		/// <summary>
		/// Gets the total.
		/// </summary>
		/// <value>The total.</value>
		[DFeElement("total", Id = "W01", Ocorrencias = 1)]
		public CFeTotal Total { get; set; }

		/// <summary>
		/// Gets the pgto.
		/// </summary>
		/// <value>The pgto.</value>
		[DFeElement("pgto", Id = "WA01", Ocorrencias = 1)]
		public CFePgto Pagto { get; set; }

		/// <summary>
		/// Gets the inf adic.
		/// </summary>
		/// <value>The inf adic.</value>
		[DFeElement("infAdic", Id = "Z01", Ocorrencias = 1)]
		public CFeInfAdic InfAdic { get; set; }


		#endregion Propriedades

		#region Methods

		private bool ShouldSerializeId()
		{
			return !Id.IsEmpty();
		}

		private bool ShouldSerializeVersao()
		{
			return Versao > 0;
		}

		private bool ShouldSerializeVersaoSb()
		{
			return VersaoSb > 0;
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
			return !InfAdic.InfCpl.IsEmpty() || InfAdic.ObsFisco.Any();
		}

		#endregion Methods
	}
}
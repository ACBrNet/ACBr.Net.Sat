// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 04-29-2016
// ***********************************************************************
// <copyright file="CFeDetImposto.cs" company="ACBr.Net">
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

using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Serializer;
using ACBr.Net.Sat.Interfaces;
using PropertyChanged;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Class CFeDetImposto. This class cannot be inherited.
	/// </summary>
	[ImplementPropertyChanged]
	public sealed class CFeDetImposto
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="CFeDetImposto"/> class.
		/// </summary>
		public CFeDetImposto()
		{
			CofinsSt = new ImpostoCofinsSt();
			Cofins = new ImpostoCofins();
			PisSt = new ImpostoPisSt();
			Pis = new ImpostoPIS();
		}

		#endregion Constructors

		#region Propriedades

		/// <summary>
		/// Gets or sets the v item12741.
		/// </summary>
		/// <value>The v item12741.</value>
		[DFeElement(TipoCampo.De2, "vItem12741", Id = "M02", Min = 3, Max = 15, Ocorrencias = 0)]
		public decimal VItem12741 { get; set; }

		/// <summary>
		/// Gets or sets the item.
		/// </summary>
		/// <value>The item.</value>
		[DFeItem(typeof(ImpostoIcms), "ICMS")]
		[DFeItem(typeof(ImpostoIssqn), "ISSQN")]
		public ICFeImposto Imposto { get; set; }

		/// <summary>
		/// Gets or sets the pis.
		/// </summary>
		/// <value>The pis.</value>
		[DFeElement("PIS", Id = "Q01", Ocorrencias = 1)]
		public ImpostoPIS Pis { get; set; }

		/// <summary>
		/// Gets or sets the pisst.
		/// </summary>
		/// <value>The pisst.</value>
		[DFeElement("PISST", Id = "R01", Ocorrencias = 1)]
		public ImpostoPisSt PisSt { get; set; }

		/// <summary>
		/// Gets or sets the cofins.
		/// </summary>
		/// <value>The cofins.</value>
		[DFeElement("COFINS", Id = "S01", Ocorrencias = 1)]
		public ImpostoCofins Cofins { get; set; }

		/// <summary>
		/// Gets or sets the cofinsst.
		/// </summary>
		/// <value>The cofinsst.</value>
		[DFeElement("COFINSST", Id = "T01", Ocorrencias = 1)]
		public ImpostoCofinsSt CofinsSt { get; set; }

		#endregion Propriedades

		#region Methods

		private bool ShouldSerializeVItem12741()
		{
			return VItem12741 > 0;
		}

		private bool ShouldSerializeImposto()
		{
			if (Imposto is ImpostoIssqn)
			{
				var issqn = (ImpostoIssqn)Imposto;
				return issqn.VDeducIssqn > 0 || issqn.VBc > 0 ||
				       issqn.VAliq > 0 || issqn.VIssqn > 0;
			}

			return true;
		}

		private bool ShouldSerializePisSt()
		{
			return PisSt.PPis > 0 || PisSt.VBc > 0 ||
					   PisSt.QBcProd > 0 || PisSt.VPis > 0;
		}

		private bool ShouldSerializeCofinsSt()
		{
			return CofinsSt.PCofins > 0 || CofinsSt.VBc > 0 ||
					   CofinsSt.QBcProd > 0 || CofinsSt.VCofins > 0;
		}

		#endregion Methods
	}
}
// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 04-29-2016
// ***********************************************************************
// <copyright file="CFeTotal.cs" company="ACBr.Net">
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
using PropertyChanged;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Class CFeTotal. This class cannot be inherited.
	/// </summary>
	[ImplementPropertyChanged]
	public sealed class CFeTotal
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="CFeTotal"/> class.
		/// </summary>
		public CFeTotal()
		{
			ICMSTot = new CFeTotalIcms();
			ISSQNTot = new CFeTotalIssqn();
			DescAcrEntr = new CFeTotalDescAcr();
		}

		#endregion Constructors

		#region Propriedades

		/// <summary>
		/// Gets or sets the icms tot.
		/// </summary>
		/// <value>The icms tot.</value>
		[DFeElement("ICMSTot", Id = "W02", Ocorrencias = 0)]
		public CFeTotalIcms ICMSTot { get; set; }

		/// <summary>
		/// Gets or sets the v c fe.
		/// </summary>
		/// <value>The v c fe.</value>
		[DFeElement(TipoCampo.De2, "vCFe", Id = "W11", Min = 3, Max = 15, Ocorrencias = 1)]
		public decimal VCFe { get; set; }

		/// <summary>
		/// Gets or sets the issq ntot.
		/// </summary>
		/// <value>The issq ntot.</value>
		[DFeElement("ISSQNtot", Id = "W12", Ocorrencias = 0)]
		public CFeTotalIssqn ISSQNTot { get; set; }

		/// <summary>
		/// Gets or sets the desc acr entr.
		/// </summary>
		/// <value>The desc acr entr.</value>
		[DFeElement("DescAcrEntr", Id = "W19", Ocorrencias = 0)]
		public CFeTotalDescAcr DescAcrEntr { get; set; }

		/// <summary>
		/// Gets or sets the v c fe lei12741.
		/// </summary>
		/// <value>The v c fe lei12741.</value>
		[DFeElement(TipoCampo.De2, "vCFeLei12741", Id = "W22", Min = 3, Max = 15, Ocorrencias = 1)]
		public decimal VCFeLei12741 { get; set; }

		#endregion Propriedades

		#region Methods

		private bool ShouldSerializeVCFe()
		{
			return VCFe > 0;
		}

		private bool ShouldSerializeICMSTot()
		{
			return ICMSTot.VICMS > 0 || ICMSTot.VProd > 0 ||
					   ICMSTot.VDesc > 0 || ICMSTot.VPIS > 0 ||
					   ICMSTot.VCOFINS > 0 || ICMSTot.VPISST > 0 ||
					   ICMSTot.VCOFINSST > 0 || ICMSTot.VOutro > 0;
		}

		private bool ShouldSerializeISSQNTot()
		{
			return ISSQNTot.VBC > 0 || ISSQNTot.VISS > 0 ||
					   ISSQNTot.VPIS > 0 || ISSQNTot.VCOFINS > 0 ||
					   ISSQNTot.VPISST > 0 || ISSQNTot.VCOFINSST > 0;
		}

		private bool ShouldSerializeDescAcrEntr()
		{
			return DescAcrEntr.VDescSubtot > 0 || DescAcrEntr.VAcresSubtot > 0;
		}

		private bool ShouldSerializeVCFeLei12741()
		{
			return VCFeLei12741 > 0;
		}

		#endregion Methods
	}
}
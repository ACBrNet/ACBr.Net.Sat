// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 04-30-2016
// ***********************************************************************
// <copyright file="ImpostoISSQN.cs" company="ACBr.Net">
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
	/// Class ImpostoISSQN. This class cannot be inherited.
	/// </summary>
	[ImplementPropertyChanged]
	public sealed class ImpostoIssqn : ICFeImposto
	{
		#region Propriedades

		/// <summary>
		/// Gets or sets the v deduc issqn.
		/// </summary>
		/// <value>The v deduc issqn.</value>
		[DFeElement(TipoCampo.De2, "vDeducISSQN", Id = "U02", Min = 3, Max = 15, Ocorrencias = 1)]
		public decimal VDeducISSQN { get; set; }

		/// <summary>
		/// Gets or sets the v bc.
		/// </summary>
		/// <value>The v bc.</value>
		[DFeElement(TipoCampo.De2, "vBC", Id = "U03", Min = 3, Max = 15, Ocorrencias = 1)]
		public decimal VBc { get; set; }

		/// <summary>
		/// Gets or sets the v aliq.
		/// </summary>
		/// <value>The v aliq.</value>
		[DFeElement(TipoCampo.De2, "vAliq", Id = "U04", Min = 5, Max = 5, Ocorrencias = 1)]
		public decimal VAliq { get; set; }

		/// <summary>
		/// Gets or sets the vissqn.
		/// </summary>
		/// <value>The vissqn.</value>
		[DFeElement(TipoCampo.De2, "vISSQN", Id = "U05", Min = 3, Max = 15, Ocorrencias = 1)]
		public decimal VISSQN { get; set; }

		/// <summary>
		/// Gets or sets the c mun fg.
		/// </summary>
		/// <value>The c mun fg.</value>
		[DFeElement(TipoCampo.Int, "cMunFG", Id = "U06", Min = 7, Max = 7, Ocorrencias = 0)]
		public int CMunFg { get; set; }

		/// <summary>
		/// Gets or sets the c list serv.
		/// </summary>
		/// <value>The c list serv.</value>
		[DFeElement(TipoCampo.Int, "cListServ", Id = "U07", Min = 5, Max = 5, Ocorrencias = 0)]
		public string CListServ { get; set; }

		/// <summary>
		/// Gets or sets the c serv trib mun.
		/// </summary>
		/// <value>The c serv trib mun.</value>
		[DFeElement(TipoCampo.Str, "cServTribMun", Id = "U08", Min = 20, Max = 20, Ocorrencias = 0)]
		public string CServTribMun { get; set; }

		/// <summary>
		/// Gets or sets the c nat op.
		/// </summary>
		/// <value>The c nat op.</value>
		[DFeElement(TipoCampo.Int, "cNatOp", Id = "U09", Min = 2, Max = 2, Ocorrencias = 1)]
		public int CNatOp { get; set; }

		/// <summary>
		/// Gets or sets the ind inc fisc.
		/// </summary>
		/// <value>The ind inc fisc.</value>
		[DFeElement(TipoCampo.Str, "indIncFisc", Id = "U10", Min = 1, Max = 1, Ocorrencias = 1)]
		public string IndIncFisc { get; set; }

		#endregion Propriedades

		#region Methods

		private bool ShouldSerializeVBc()
		{
			return VBc > 0;
		}

		private bool ShouldSerializeVISSQN()
		{
			return VISSQN > 0;
		}

		#endregion Methods
	}
}
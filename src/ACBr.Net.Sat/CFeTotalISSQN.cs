// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-02-2016
// ***********************************************************************
// <copyright file="CFeTotalISSQN.cs" company="ACBr.Net">
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
	/// Class CFeTotalISSQN. This class cannot be inherited.
	/// </summary>
	[ImplementPropertyChanged]
	public sealed class CFeTotalIssqn
	{

		/// <summary>
		/// Gets or sets the VBC.
		/// </summary>
		/// <value>The VBC.</value>
		[DFeElement(TipoCampo.De2, "vBC", Id = "W13", Min = 3, Max = 15, Ocorrencia = Ocorrencia.Obrigatoria)]
		public decimal VBC { get; set; }

		/// <summary>
		/// Gets or sets the viss.
		/// </summary>
		/// <value>The viss.</value>
		[DFeElement(TipoCampo.De2, "vISS", Id = "W14", Min = 3, Max = 15, Ocorrencia = Ocorrencia.Obrigatoria)]
		public decimal VISS { get; set; }

		/// <summary>
		/// Gets or sets the vpis.
		/// </summary>
		/// <value>The vpis.</value>
		[DFeElement(TipoCampo.De2, "vPIS", Id = "W15", Min = 3, Max = 15, Ocorrencia = Ocorrencia.Obrigatoria)]
		public decimal VPIS { get; set; }

		/// <summary>
		/// Gets or sets the vcofins.
		/// </summary>
		/// <value>The vcofins.</value>
		[DFeElement(TipoCampo.De2, "vCOFINS", Id = "W16", Min = 3, Max = 15, Ocorrencia = Ocorrencia.Obrigatoria)]
		public decimal VCOFINS { get; set; }

		/// <summary>
		/// Gets or sets the vpisst.
		/// </summary>
		/// <value>The vpisst.</value>
		[DFeElement(TipoCampo.De2, "vPISST", Id = "W17", Min = 3, Max = 15, Ocorrencia = Ocorrencia.Obrigatoria)]
		public decimal VPISST { get; set; }

		/// <summary>
		/// Gets or sets the vcofinsst.
		/// </summary>
		/// <value>The vcofinsst.</value>
		[DFeElement(TipoCampo.De2, "vCOFINSST", Id = "W18", Min = 3, Max = 15, Ocorrencia = Ocorrencia.Obrigatoria)]
		public decimal VCOFINSST { get; set; }
	}
}
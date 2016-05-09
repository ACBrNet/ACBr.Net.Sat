// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-30-2016
//
// Last Modified By : RFTD
// Last Modified On : 04-30-2016
// ***********************************************************************
// <copyright file="CFeDetCollection.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Collection;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Class CFeDetCollection. This class cannot be inherited.
	/// </summary>
	/// <seealso>
	///     <cref>ACBr.Net.DFe.Core.Collection.DFeCollection{ACBr.Net.Sat.CFeDet}</cref>
	/// </seealso>
	public sealed class CFeDetCollection : DFeCollection<CFeDet>
	{
		#region Fields

		private CFe parent;

		#endregion Fields

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="CFeDetCollection"/> class.
		/// </summary>
		public CFeDetCollection()
		{
			
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CFeDetCollection"/> class.
		/// </summary>
		/// <param name="parent">The parent.</param>
		public CFeDetCollection(CFe parent)
		{
			Parent = parent;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CFeDetCollection"/> class.
		/// </summary>
		/// <param name="source">The source.</param>
		public CFeDetCollection(IList<CFeDet> source)
		{
			AddRange(source);
		}

		#endregion Constructors

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
				foreach (var cFeDet in List)
					cFeDet.Parent = value;
			}
		}

		#endregion Propriedades

		#region Methods

		/// <summary>
		/// Adiciona novo item na coleção e retorna  item criado
		/// </summary>
		/// <returns>T.</returns>
		public override CFeDet AddNew()
		{
			var ret = new CFeDet(Parent);
			List.Add(ret);
			return ret;
		}

		/// <summary>
		/// Adds the range.
		/// </summary>
		/// <param name="item">The item.</param>
		public override void Add(CFeDet item)
		{
			item.Parent = Parent;
			base.Add(item);
		}

		#endregion Methods
	}
}
using System;
using System.IO;
using System.Text;
using ACBr.Net.Core.Extensions;

namespace ACBr.Net.Sat
{
	public sealed class TesteResposta : SatResposta
	{
		#region Constructors

		public TesteResposta(string retorno, Encoding encoding) : base(retorno, encoding)
		{
			VendaTeste = new CFe();
			if (CodigoDeRetorno != 9000)
				return;

			if (RetornoLst.Count < 5)
				return;

			using (var stream = new MemoryStream(Convert.FromBase64String(RetornoLst[5])))
			{
				VendaTeste = CFe.Load(stream, encoding);
			}
		}

		#endregion Constructors

		#region Propriedades

		public CFe VendaTeste { get; private set; }

		#endregion Propriedades
	}
}
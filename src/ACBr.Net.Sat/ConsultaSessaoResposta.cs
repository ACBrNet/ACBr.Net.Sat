using System;
using System.IO;
using System.Text;

namespace ACBr.Net.Sat
{
	public class ConsultaSessaoResposta : SatResposta
	{
		#region Constructors

		public ConsultaSessaoResposta(string retorno, Encoding encoding) : base(retorno, encoding)
		{

			if (CodigoDeRetorno == 6000)
			{
				if (RetornoLst.Count >= 6)
				{
					using (var stream = new MemoryStream(Convert.FromBase64String(RetornoLst[6])))
						Venda = CFe.Load(stream, encoding);
				}
			}

			if (CodigoDeRetorno != 7000) return;

			if (RetornoLst.Count < 6) return;

			using (var stream = new MemoryStream(Convert.FromBase64String(RetornoLst[6])))
					Cancelamento = CFeCanc.Load(stream, encoding);
		}

		#endregion Constructors

		#region Properties

		public CFe Venda { get; private set; }

		public CFeCanc Cancelamento { get; set; }

		#endregion Properties
	}
}
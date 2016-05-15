using System.Text;

namespace ACBr.Net.Sat
{
	public sealed class StatusOperacionalResposta : SatResposta
	{
		#region Constructors

		public StatusOperacionalResposta(string retorno, Encoding encoding) : base(retorno, encoding)
		{
			if (CodigoDeRetorno != 10000)
				return;

			ConfigRede = new CFeRede();
		}

		#endregion Constructors

		#region Propriedades

		public CFeRede ConfigRede { get; set; }

		#endregion Propriedades
	}
}
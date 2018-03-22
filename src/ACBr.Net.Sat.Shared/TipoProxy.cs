using ACBr.Net.DFe.Core.Attributes;

namespace ACBr.Net.Sat
{
	public enum TipoProxy
	{
		[DFeEnum("0")]
		None,
		[DFeEnum("1")]
		ProxyConfiguracao,
		[DFeEnum("2")]
		ProxyTransparente
	}
}
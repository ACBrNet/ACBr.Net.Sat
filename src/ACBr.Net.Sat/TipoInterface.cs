using ACBr.Net.DFe.Core.Attributes;

namespace ACBr.Net.Sat
{
	public enum TipoInterface
	{
		[DFeEnum("ETHE")]
		Lan,
		[DFeEnum("WIFI")]
		Wifi
	}
}
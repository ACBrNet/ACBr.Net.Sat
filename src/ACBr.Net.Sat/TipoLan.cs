using ACBr.Net.DFe.Core.Attributes;

namespace ACBr.Net.Sat
{
	public enum TipoLan
	{
		[DFeEnum("DHCP")]
		DHCP,
		[DFeEnum("PPPoE")]
		PPPoE,
		[DFeEnum("IPFIX")]
		IPFIX
	}
}
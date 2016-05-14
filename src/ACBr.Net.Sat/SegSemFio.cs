using ACBr.Net.DFe.Core.Attributes;

namespace ACBr.Net.Sat
{
	public enum SegSemFio
	{
		[DFeEnum("")]
		None,
		[DFeEnum("WEP")]
		Wep,
		[DFeEnum("WPA-PERSONAL")]
		WpaPersonal,
		[DFeEnum("WPA-ENTERPRISE")]
		WpaEnterprise
	}
}
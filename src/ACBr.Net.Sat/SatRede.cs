using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Common;
using ACBr.Net.DFe.Core.Serializer;

namespace ACBr.Net.Sat
{
	[DFeRoot("config")]
	public sealed class SatRede : DFeDocument<SatRede>
	{
		#region Propriedades

		[DFeElement(TipoCampo.Enum, "tipoInter", Id = "C01", Min = 1, Max = 4, Ocorrencia = Ocorrencia.Obrigatoria)]
		public TipoInterface TipoInterface { get; set; }

		[DFeElement(TipoCampo.Str, "SSID", Id = "C02", Min = 1, Max = 32, Ocorrencia = Ocorrencia.Obrigatoria)]
		public string SSID { get; set; }

		[DFeElement(TipoCampo.Enum, "seg", Id = "C03", Min = 1, Max = 25, Ocorrencia = Ocorrencia.Obrigatoria)]
		public SegSemFio Seguranca { get; set; }

		[DFeElement(TipoCampo.Str, "codigo", Id = "C04", Min = 1, Max = 64, Ocorrencia = Ocorrencia.Obrigatoria)]
		public string Codigo { get; set; }

		[DFeElement(TipoCampo.Enum, "tipoLan", Id = "C05", Min = 1, Max = 8, Ocorrencia = Ocorrencia.Obrigatoria)]
		public TipoLan TipoLan { get; set; }

		[DFeElement(TipoCampo.Str, "lanIP", Id = "C06", Min = 1, Max = 15, Ocorrencia = Ocorrencia.Obrigatoria)]
		public string LanIp { get; set; }

		[DFeElement(TipoCampo.Str, "lanMask", Id = "C07", Min = 1, Max = 15, Ocorrencia = Ocorrencia.Obrigatoria)]
		public string LanMask { get; set; }

		[DFeElement(TipoCampo.Str, "lanGW", Id = "C08", Min = 1, Max = 15, Ocorrencia = Ocorrencia.Obrigatoria)]
		public string LanGateway { get; set; }

		[DFeElement(TipoCampo.Str, "lanDNS1", Id = "C09", Min = 1, Max = 15, Ocorrencia = Ocorrencia.Obrigatoria)]
		public string LanDNS1 { get; set; }

		[DFeElement(TipoCampo.Str, "lanDNS2", Id = "C10", Min = 1, Max = 15, Ocorrencia = Ocorrencia.Obrigatoria)]
		public string LanDNS2 { get; set; }

		[DFeElement(TipoCampo.Str, "usuario", Id = "C11", Min = 1, Max = 64, Ocorrencia = Ocorrencia.Obrigatoria)]
		public string Usuario { get; set; }

		[DFeElement(TipoCampo.Str, "senha", Id = "C12", Min = 1, Max = 64, Ocorrencia = Ocorrencia.Obrigatoria)]
		public string Senha { get; set; }

		[DFeElement(TipoCampo.Str, "proxy", Id = "C13", Min = 1, Max = 1, Ocorrencia = Ocorrencia.Obrigatoria)]
		public TipoProxy Proxy { get; set; }

		[DFeElement(TipoCampo.Str, "proxy_ip", Id = "C14", Min = 1, Max = 15, Ocorrencia = Ocorrencia.Obrigatoria)]
		public string ProxyIp { get; set; }

		[DFeElement(TipoCampo.Int, "proxy_porta", Id = "C15", Min = 1, Max = 5, Ocorrencia = Ocorrencia.Obrigatoria)]
		public int ProxyPorta { get; set; }

		[DFeElement(TipoCampo.Str, "proxy_user", Id = "C16", Min = 1, Max = 64, Ocorrencia = Ocorrencia.Obrigatoria)]
		public string ProxyUser { get; set; }

		[DFeElement(TipoCampo.Str, "proxy_senha", Id = "C17", Min = 1, Max = 64, Ocorrencia = Ocorrencia.Obrigatoria)]
		public string ProxyPass { get; set; }

		#endregion Propriedades

		#region Methods

		private bool ShouldSerializeSSID()
		{
			return TipoInterface == TipoInterface.Wifi;
		}

		private bool ShouldSerializeSeguranca()
		{
			return TipoInterface == TipoInterface.Wifi;
		}

		private bool ShouldSerializeCodigo()
		{
			return TipoInterface == TipoInterface.Wifi;
		}

		private bool ShouldSerializeLanIp()
		{
			return TipoLan == TipoLan.IPFIX;
		}

		private bool ShouldSerializeLanMask()
		{
			return TipoLan == TipoLan.IPFIX;
		}

		private bool ShouldSerializeLanGateway()
		{
			return TipoLan == TipoLan.IPFIX;
		}

		private bool ShouldSerializeLanDNS1()
		{
			return TipoLan == TipoLan.IPFIX;
		}

		private bool ShouldSerializeLanDNS2()
		{
			return TipoLan == TipoLan.IPFIX;
		}

		private bool ShouldSerializeUsuario()
		{
			return TipoLan == TipoLan.PPPoE;
		}

		private bool ShouldSerializeSenha()
		{
			return TipoLan == TipoLan.PPPoE;
		}

		private bool ShouldSerializeProxyIp()
		{
			return Proxy != TipoProxy.None;
		}

		private bool ShouldSerializeProxyPorta()
		{
			return Proxy != TipoProxy.None;
		}

		private bool ShouldSerializeProxyUser()
		{
			return Proxy != TipoProxy.None;
		}

		private bool ShouldSerializeProxyPass()
		{
			return Proxy != TipoProxy.None;
		}

		#endregion Methods
	}
}
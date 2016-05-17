using System.IO;
using System.Text;
using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Serializer;

namespace ACBr.Net.Sat
{
	[DFeRoot("config")]
	public sealed class SatRede
	{
		#region Propriedades

		[DFeElement(TipoCampo.Enum, "tipoInter", Id = "C01", Min = 1, Max = 4, Ocorrencias = 1)]
		public TipoInterface TipoInterface { get; set; }

		[DFeElement(TipoCampo.Str, "SSID", Id = "C02", Min = 1, Max = 32, Ocorrencias = 1)]
		public string SSID { get; set; }

		[DFeElement(TipoCampo.Enum, "seg", Id = "C03", Min = 1, Max = 25, Ocorrencias = 1)]
		public SegSemFio Seguranca { get; set; }

		[DFeElement(TipoCampo.Str, "codigo", Id = "C04", Min = 1, Max = 64, Ocorrencias = 1)]
		public string Codigo { get; set; }

		[DFeElement(TipoCampo.Enum, "tipoLan", Id = "C05", Min = 1, Max = 8, Ocorrencias = 1)]
		public TipoLan TipoLan { get; set; }

		[DFeElement(TipoCampo.Str, "lanIP", Id = "C06", Min = 1, Max = 15, Ocorrencias = 1)]
		public string LanIp { get; set; }

		[DFeElement(TipoCampo.Str, "lanMask", Id = "C07", Min = 1, Max = 15, Ocorrencias = 1)]
		public string LanMask { get; set; }

		[DFeElement(TipoCampo.Str, "lanGW", Id = "C08", Min = 1, Max = 15, Ocorrencias = 1)]
		public string LanGateway { get; set; }

		[DFeElement(TipoCampo.Str, "lanDNS1", Id = "C09", Min = 1, Max = 15, Ocorrencias = 1)]
		public string LanDNS1 { get; set; }

		[DFeElement(TipoCampo.Str, "lanDNS2", Id = "C10", Min = 1, Max = 15, Ocorrencias = 1)]
		public string LanDNS2 { get; set; }

		[DFeElement(TipoCampo.Str, "usuario", Id = "C11", Min = 1, Max = 64, Ocorrencias = 1)]
		public string Usuario { get; set; }

		[DFeElement(TipoCampo.Str, "senha", Id = "C12", Min = 1, Max = 64, Ocorrencias = 1)]
		public string Senha { get; set; }

		[DFeElement(TipoCampo.Str, "proxy", Id = "C13", Min = 1, Max = 1, Ocorrencias = 1)]
		public TipoProxy Proxy { get; set; }

		[DFeElement(TipoCampo.Str, "proxy_ip", Id = "C14", Min = 1, Max = 15, Ocorrencias = 1)]
		public string ProxyIp { get; set; }

		[DFeElement(TipoCampo.Int, "proxy_porta", Id = "C15", Min = 1, Max = 5, Ocorrencias = 1)]
		public int ProxyPorta { get; set; }

		[DFeElement(TipoCampo.Str, "proxy_user", Id = "C16", Min = 1, Max = 64, Ocorrencias = 1)]
		public string ProxyUser { get; set; }

		[DFeElement(TipoCampo.Str, "proxy_senha", Id = "C17", Min = 1, Max = 64, Ocorrencias = 1)]
		public string ProxyPass { get; set; }

		#endregion Propriedades

		#region Methods

		public static SatRede Load(string path, Encoding encoding = null)
		{
			var serializer = DFeSerializer.CreateSerializer<SatRede>();
			if (encoding != null)
				serializer.Options.Encoder = encoding;
			return serializer.Deserialize(path);
		}

		public static SatRede Load(Stream stream, Encoding encoding = null)
		{
			var serializer = DFeSerializer.CreateSerializer<SatRede>();
			if (encoding != null)
				serializer.Options.Encoder = encoding;
			return serializer.Deserialize(stream);
		}

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
using System;
using System.Text;

namespace ACBr.Net.Sat
{
	public static class SatManager
	{
		public static SatLibrary GetLibrary(ModeloSat modelo, SatConfig config, string pathDll, Encoding encoding)
		{
			switch (modelo)
			{
				case ModeloSat.Cdecl: return new SatCdecl(config, pathDll, encoding);
				case ModeloSat.StdCall: return new SatStdCall(config, pathDll, encoding);
				case ModeloSat.MFeIntegrador: return new SatIntegradorMFe(config, pathDll, encoding);
				default: throw new NotImplementedException("Modelo não impementado !");
			}
		}
	}
}
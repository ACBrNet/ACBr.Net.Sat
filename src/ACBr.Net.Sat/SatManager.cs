using ACBr.Net.Sat.Interfaces;
using System;
using System.Text;

namespace ACBr.Net.Sat
{
	public static class SatManager
	{
		public static ISatLibrary GetLibrary(ModeloSat modelo, string pathDll, Encoding encoding)
		{
			switch (modelo)
			{
				case ModeloSat.Cdecl: return new SatCdecl(pathDll, encoding);
				case ModeloSat.StdCall: return new SatStdCall(pathDll, encoding);
				default: throw new NotImplementedException("Modelo não impementado !");
			}
		}
	}
}
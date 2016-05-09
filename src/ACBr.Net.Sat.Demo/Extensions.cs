using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace ACBr.Net.Sat.Demo
{
	public static class Extensions
	{
		public static void LoadXml(this WebBrowser browser, string xml)
		{
			if(xml == null)
				return;

			var path = Path.GetTempPath();
			var fileName = Guid.NewGuid() + ".xml";
			var fullFileName = Path.Combine(path, fileName);
			var xmlDoc = new XmlDocument();
			if(File.Exists(xml))
				xmlDoc.Load(xml);
			else
				xmlDoc.LoadXml(xml);
			xmlDoc.Save(fullFileName);
			browser.Navigate(fullFileName);
		}
	}
}
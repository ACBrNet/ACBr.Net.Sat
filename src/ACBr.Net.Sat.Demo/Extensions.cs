using ACBr.Net.Core.Exceptions;
using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace ACBr.Net.Sat.Demo
{
	public static class Extensions
	{
		public static void LoadXml(this WebBrowser browser, string xml)
		{
			if (xml == null)
				return;

			var path = Path.GetTempPath();
			var fileName = Guid.NewGuid() + ".xml";
			var fullFileName = Path.Combine(path, fileName);
			var xmlDoc = new XmlDocument();
			if (File.Exists(xml))
				xmlDoc.Load(xml);
			else
				xmlDoc.LoadXml(xml);
			xmlDoc.Save(fullFileName);
			browser.Navigate(fullFileName);
		}

		public static void EnumDataSource<T>(this ComboBox cmb, T? valorPadrao = null) where T : struct
		{
			Guard.Against<ArgumentException>(!typeof(T).IsEnum, "O tipo precisar ser um Enum.");

			cmb.DataSource = Enum.GetValues(typeof(T));
			if (valorPadrao.HasValue)
				cmb.SelectedItem = valorPadrao.Value;
		}

		public static void SetAppSetting(this Configuration config, string setting, object value)
		{
			Guard.Against<ArgumentNullException>(config == null, nameof(config));
			Guard.Against<ArgumentNullException>(config.AppSettings == null, nameof(config.AppSettings));

			var valor = string.Format(CultureInfo.InvariantCulture, "{0}", value);

			if (config.AppSettings.Settings[setting]?.Value != null)
				config.AppSettings.Settings[setting].Value = valor;
			else
				config.AppSettings.Settings.Add(setting, valor);
		}

		public static T GetAppSetting<T>(this Configuration config, string setting, T defaultValue)
		{
			Guard.Against<ArgumentNullException>(config == null, nameof(config));
			Guard.Against<ArgumentNullException>(config.AppSettings == null, nameof(config.AppSettings));

			var value = config.AppSettings.Settings[setting]?.Value;
			if (value == null) return defaultValue;

			try
			{
				if (typeof(T).IsEnum || (typeof(T).IsGenericType && typeof(T).GetGenericArguments()[0].IsEnum))
				{
					return (T)Enum.Parse(typeof(T), value);
				}

				return (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
			}
			catch (Exception)
			{
				return defaultValue;
			}
		}
	}
}
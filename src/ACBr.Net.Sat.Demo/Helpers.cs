using System.Windows.Forms;

namespace ACBr.Net.Sat.Demo
{
	public static class Helpers
	{
		public static string OpenFiles(string filters)
		{
			using (var ofd = new OpenFileDialog())
			{
				ofd.CheckPathExists = true;
				ofd.CheckFileExists = true;
				ofd.Multiselect = false;
				ofd.Filter = filters;

				if (ofd.ShowDialog().Equals(DialogResult.Cancel))
					return null;

				return ofd.FileName;
			}
		}
	}
}
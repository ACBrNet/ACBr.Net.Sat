using System.Text;

namespace ACBr.Net.Sat.Internal
{
	internal static class StringExtensions
	{
		public static string ToSatStr(this string str)
		{
			return ACBrSat.Enconder.GetString(Encoding.UTF8.GetBytes(str));
		}
	}
}

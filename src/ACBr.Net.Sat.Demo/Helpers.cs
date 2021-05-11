using System.Windows.Forms;

namespace ACBr.Net.Sat.Demo
{
    public static class Helpers
    {
        public static string OpenFile(string filters)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.CheckPathExists = true;
                ofd.CheckFileExists = true;
                ofd.Multiselect = false;
                ofd.Filter = filters;

                return ofd.ShowDialog().Equals(DialogResult.Cancel) ? null : ofd.FileName;
            }
        }

        public static string SaveFile(string filename, string filter)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.CheckPathExists = true;
                sfd.CheckFileExists = true;
                sfd.Filter = filter;
                sfd.FileName = filename;

                return sfd.ShowDialog().Equals(DialogResult.Cancel) ? null : sfd.FileName;
            }
        }
    }
}
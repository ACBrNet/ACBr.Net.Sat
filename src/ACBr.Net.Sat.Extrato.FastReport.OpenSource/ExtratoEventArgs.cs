using System;

namespace ACBr.Net.Sat.Extrato.FastReport.OpenSource
{
    public class ExtratoEventArgs : EventArgs
    {
        #region Constructors

        public ExtratoEventArgs(ExtratoLayOut tipo)
        {
            Tipo = tipo;
            FilePath = string.Empty;
        }

        #endregion Constructors

        #region Propriedades

        /// <summary>
        /// Retorna o tipo de arquivo necessario.
        /// </summary>
        /// <value>The tipo.</value>
        public ExtratoLayOut Tipo { get; internal set; }

        /// <summary>
        /// Define ou retorna o caminho para o arquivo do FastReport.
        /// </summary>
        /// <value>The file path.</value>
        public string FilePath { get; set; }

        #endregion Propriedades
    }
}
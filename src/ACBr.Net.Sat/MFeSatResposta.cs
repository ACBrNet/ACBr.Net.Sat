using System.IO;
using System.Text;
using ACBr.Net.DFe.Core.Attributes;

namespace ACBr.Net.Sat
{
    public class MFeSatResposta : SatResposta
    {
        #region Constructors

        public MFeSatResposta(string resposta, Encoding encoding) : base(resposta, encoding)
        {
            RespostaMFe = MFeIntegradorResp.Load(resposta);
        }

        #endregion Constructors

        #region Properties

        public MFeIntegradorResp RespostaMFe { get; }

        [DFeIgnore]
        public string XmlEnvio { get; set; }

        #endregion Properties
    }
}
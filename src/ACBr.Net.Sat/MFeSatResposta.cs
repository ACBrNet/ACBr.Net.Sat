using System.IO;
using System.Text;

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

        #endregion Properties
    }
}
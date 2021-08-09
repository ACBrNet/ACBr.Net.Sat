using ACBr.Net.Core.Extensions;

namespace ACBr.Net.Sat.Extrato.FastReport
{

    public static class Extensions
    {
        public static string Descricao(this CodigoMP codigo)
        {
            switch (codigo)
            {
                case CodigoMP.Dinheiro: return "Dinheiro";
                case CodigoMP.Cheque: return "Cheque";
                case CodigoMP.CartaodeCredito: return "Cartão de Crédito";
                case CodigoMP.CartaodeDebito: return "Cartão de Débito";
                case CodigoMP.CreditoLoja: return "Crédito Loja";
                case CodigoMP.ValeAlimentacao: return "Vale Alimentação";
                case CodigoMP.ValeRefeicao: return "Vale Refeição";
                case CodigoMP.ValePresente: return "Vale Presente";
                case CodigoMP.ValeCombustivel: return "Vale Combustível";
                case CodigoMP.Outros: return "Outros";
                default: return "Outros";
            }
        }

    }

}
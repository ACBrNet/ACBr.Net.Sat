using ACBr.Net.Core.Extensions;
using ACBr.Net.DFe.Core.Common;
using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Windows.Forms;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ACBr.Net.Sat.Demo
{
    public partial class FrmMain : Form
    {
        #region Fields

        private ILogger logger;
        private CFe cfeAtual;
        private CFeCanc cfeCancAtual;
        private SatRede redeAtual;
        private readonly ACBrConfig config;

        #endregion Fields

        #region Constructors

        public FrmMain()
        {
            InitializeComponent();
            config = ACBrConfig.CreateOrLoad(Path.Combine(Application.StartupPath, "sat.config"));
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            InitializeLog();
            Initialize();
        }

        #endregion Constructors

        #region Methods

        private void Initialize()
        {
            cmbAmbiente.EnumDataSource<DFeTipoAmbiente>(DFeTipoAmbiente.Homologacao);
            cmbModeloSat.EnumDataSource<ModeloSat>(ModeloSat.StdCall);
            cmbEmiRegTrib.EnumDataSource<RegTrib>(RegTrib.Normal);
            cmbEmiRegTribISSQN.EnumDataSource<RegTribIssqn>(RegTribIssqn.Nenhum);
            cmbEmiRatIISQN.EnumDataSource<RatIssqn>(RatIssqn.Nao);
        }

        private void InitializeLog()
        {
            var config = new LoggingConfiguration();
            var target = new RichTextBoxTarget
            {
                UseDefaultRowColoringRules = true,
                Layout = @"${date:format=dd/MM/yyyy HH\:mm\:ss} - ${message}",
                FormName = Name,
                ControlName = rtbLog.Name,
                AutoScroll = true
            };

            config.AddTarget("RichTextBox", target);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));

            var infoTarget = new FileTarget
            {
                FileName = "${basedir:dir=Logs:file=ACBrSat.log}",
                Layout = "${processid}|${longdate}|${level:uppercase=true}|" +
                         "${event-context:item=Context}|${logger}|${message}",
                CreateDirs = true,
                Encoding = Encoding.UTF8,
                MaxArchiveFiles = 93,
                ArchiveEvery = FileArchivePeriod.Day,
                ArchiveNumbering = ArchiveNumberingMode.Date,
                ArchiveFileName = "${basedir}/Logs/Archive/${date:format=yyyy}/${date:format=MM}/ACBrSat_{{#}}.log",
                ArchiveDateFormat = "dd.MM.yyyy"
            };

            config.AddTarget("infoFile", infoTarget);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, infoTarget));
            LogManager.Configuration = config;
            logger = LogManager.GetLogger("ACBrSAT");
        }

        private void GerarCFe()
        {
            logger.Info("Gerando CFe");

            var totalGeral = 0M;
            cfeAtual = acbrSat.NewCFe();
            cfeAtual.InfCFe.Ide.NumeroCaixa = 1;
            cfeAtual.InfCFe.Dest.CPF = "";
            cfeAtual.InfCFe.Dest.Nome = "CONSUMIDOR";
            cfeAtual.InfCFe.Entrega.XLgr = "logradouro";
            cfeAtual.InfCFe.Entrega.Nro = "112233";
            cfeAtual.InfCFe.Entrega.XCpl = "complemento";
            cfeAtual.InfCFe.Entrega.XBairro = "bairro";
            cfeAtual.InfCFe.Entrega.XMun = "municipio";
            cfeAtual.InfCFe.Entrega.UF = "MS";
            for (var i = 0; i < 3; i++)
            {
                var det = cfeAtual.InfCFe.Det.AddNew();
                det.NItem = 1 + i;
                det.Prod.CProd = $"ACBR{det.NItem:000}";
                det.Prod.CEAN = "6291041500213";
                det.Prod.XProd = "Assinatura SAC";
                det.Prod.NCM = "99";
                det.Prod.CFOP = "5120";
                det.Prod.UCom = "UN";
                det.Prod.QCom = 1;
                det.Prod.VUnCom = 120.00M;
                det.Prod.IndRegra = IndRegra.Truncamento;
                det.Prod.VDesc = i != 1 ? 1 : 0;

                var obs = new ProdObsFisco();
                obs.XCampoDet = "campo";
                obs.XTextoDet = "texto";
                det.Prod.ObsFiscoDet.Add(obs);

                var totalItem = det.Prod.QCom * det.Prod.VUnCom;
                totalGeral += totalItem;
                det.Imposto.VItem12741 = totalItem * 0.12M;

                det.Imposto.Imposto = new ImpostoIcms
                {
                    Icms = new ImpostoIcms00
                    {
                        Orig = OrigemMercadoria.Nacional,
                        Cst = "00",
                        PIcms = 18
                    }
                };

                det.Imposto.Pis.Pis = new ImpostoPisAliq
                {
                    Cst = "01",
                    VBc = totalItem,
                    PPis = 0.0065M
                };

                det.Imposto.Cofins.Cofins = new ImpostoCofinsAliq
                {
                    Cst = "01",
                    VBc = totalItem,
                    PCofins = 0.0065M
                };

                det.InfAdProd = "Informacoes adicionais";
            }

            cfeAtual.InfCFe.Total.DescAcrEntr.VDescSubtot = 2;
            cfeAtual.InfCFe.Total.VCFeLei12741 = 1.23M;

            var pgto1 = cfeAtual.InfCFe.Pagto.Pagamentos.AddNew();
            pgto1.CMp = CodigoMP.CartaodeCredito;
            pgto1.VMp = totalGeral / 2;
            pgto1.CAdmC = 999;

            var pgto2 = cfeAtual.InfCFe.Pagto.Pagamentos.AddNew();
            pgto2.CMp = CodigoMP.Dinheiro;
            pgto2.VMp = totalGeral / 2 + 10;

            cfeAtual.InfCFe.InfAdic.InfCpl = "Acesse www.projetoacbr.com.br para obter mais;informações sobre o componente ACBrSAT;" +
                                             "Precisa de um PAF-ECF homologado?;Conheça o DJPDV - www.djpdv.com.br";

            wbrXmlGerado.LoadXml(cfeAtual.GetXml());
            tbcXml.SelectedTab = tpgXmlGerado;
            logger.Info("CFe gerado com sucesso !");
        }

        private void ToogleInitialize()
        {
            if (acbrSat.Ativo)
            {
                acbrSat.Desativar();
                btnIniDesini.Text = @"Inicializar";
            }
            else
            {
                acbrSat.Ativar();
                btnIniDesini.Text = @"Desinicializar";
            }
        }

        private void LoadConfig()
        {
            if (acbrSat.Ativo) ToogleInitialize();

            cmbModeloSat.SelectedItem = config.Get("ModeloSat", ModeloSat.Cdecl);
            txtDllPath.Text = config.Get("DllPath", @"C:\SAT\SAT.dll");
            cmbAmbiente.SelectedItem = config.Get("Ambiente", DFeTipoAmbiente.Homologacao);
            txtAtivacao.Text = config.Get("Ativacao", "12345678");
            txtCodUF.Text = config.Get("CodUF", "35");
            nunPaginaCodigo.Value = config.Get("PaginaCodigo", 1252M);
            nunCaixa.Value = config.Get("Caixa", 1M);
            nunVersaoCFe.Value = config.Get("VersaoCFe", 0.06M);
            chkUTF8_CheckedChanged(nunVersaoCFe, EventArgs.Empty);

            chkUTF8.Checked = config.Get("UTF8", false);
            chkRemoveAcentos.Checked = config.Get("RemoveAcentos", false);
            chkSaveEnvio.Checked = config.Get("SaveEnvio", true);
            chkSaveCFe.Checked = config.Get("SaveCFe", true);
            chkSaveCFeCanc.Checked = config.Get("SaveCFeCanc", true);
            chkSepararCNPJ.Checked = config.Get("SepararCNPJ", true);
            chkSepararData.Checked = config.Get("SepararData", true);
            txtEmitCNPJ.Text = config.Get("EmitCNPJ", "11111111111111");
            txtEmitIE.Text = config.Get("EmitIE", string.Empty);
            txtEmitIM.Text = config.Get("EmitIM", string.Empty);
            cmbEmiRegTrib.SelectedItem = config.Get("EmiRegTrib", RegTrib.SimplesNacional);
            cmbEmiRegTribISSQN.SelectedItem = config.Get("EmiRegTribISSQN", RegTribIssqn.Nenhum);
            cmbEmiRegTrib.SelectedItem = config.Get("EmiRatIISQN", RatIssqn.Sim);
            txtIdeCNPJ.Text = config.Get("IdeCNPJ", "22222222222222");
            txtSignAC.Text = config.Get("SignAC", "1111111111111222222222222221111111111111122222222222222111111111111112222222222222211111" +
                                                            "111111111222222222222221111111111111122222222222222111111111111112222222222222211111111" +
                                                            "111111222222222222221111111111111122222222222222111111111111112222222222222211111111111" +
                                                            "1112222222222222211111111111111222222222222221111111111111122222222222222111111111");

            txtMFeEnvio.Text = config.Get("MFePathEnvio", @"C:\Integrador\Input\");
            txtMFeResposta.Text = config.Get("MFePathResposta", @"C:\Integrador\Output\");
            nunMFeTimeout.Value = config.Get("MFeTimeOut", 45000M);
            txtChaveAcessoValidador.Text = config.Get("ChaveAcessoValidador", @"25CFE38D-3B92-46C0-91CA-CFF751A82D3D");

            MessageBox.Show(this, @"Configurações Carregada com sucesso !", @"S@T Demo");
        }

        private void SaveConfig(bool msg = true)
        {
            config.Set("ModeloSat", cmbModeloSat.SelectedItem);
            config.Set("DllPath", txtDllPath.Text);
            config.Set("Ambiente", cmbAmbiente.SelectedItem);
            config.Set("Ativacao", txtAtivacao.Text);
            config.Set("CodUF", txtCodUF.Text);
            config.Set("PaginaCodigo", nunPaginaCodigo.Value);
            config.Set("Caixa", nunCaixa.Value);
            config.Set("VersaoCFe", nunVersaoCFe.Value);
            config.Set("UTF8", chkUTF8.Checked);
            config.Set("RemoveAcentos", chkRemoveAcentos.Checked);
            config.Set("SaveEnvio", chkSaveEnvio.Checked);
            config.Set("SaveCFe", chkSaveCFe.Checked);
            config.Set("SaveCFeCanc", chkSaveCFeCanc.Checked);
            config.Set("SepararCNPJ", chkSepararCNPJ.Checked);
            config.Set("SepararData", chkSepararData.Checked);
            config.Set("EmitCNPJ", txtEmitCNPJ.Text);
            config.Set("EmitIE", txtEmitIE.Text);
            config.Set("EmitIM", txtEmitIM.Text);
            config.Set("EmiRegTrib", cmbEmiRegTrib.SelectedItem);
            config.Set("EmiRegTribISSQN", cmbEmiRegTribISSQN.SelectedItem);
            config.Set("EmiRatIISQN", cmbEmiRatIISQN.SelectedItem);
            config.Set("IdeCNPJ", txtIdeCNPJ.Text);
            config.Set("SignAC", txtSignAC.Text);
            config.Set("MFePathEnvio", txtMFeEnvio.Text);
            config.Set("MFePathResposta", txtMFeResposta.Text);
            config.Set("MFeTimeOut", nunMFeTimeout.Value);
            config.Set("ChaveAcessoValidador", txtChaveAcessoValidador.Text);
            config.Save();

            if (msg)
            {
                MessageBox.Show(this, @"Configurações Salva com sucesso !", @"S@T Demo");
            }
        }

        private void ConsultarStatusOperacional()
        {
            var ret = acbrSat.ConsultarStatusOperacional();
            logger.Info($"NSERIE.........: {ret.Status.NSerie}");
            logger.Info($"LAN_MAC........: {ret.Status.LanMac}");
            logger.Info($"STATUS_LAN.....: {ret.Status.StatusLan}");
            logger.Info($"NIVEL_BATERIA..: {ret.Status.NivelBateria}");
            logger.Info($"MT_TOTAL.......: {ret.Status.MTTotal}");
            logger.Info($"MT_USADA.......: {ret.Status.MTUsada}");
            logger.Info($"DH_ATUAL.......: {ret.Status.DhAtual}");
            logger.Info($"VER_SB.........: {ret.Status.VerSb}");
            logger.Info($"VER_LAYOUT.....: {ret.Status.VerLayout}");
            logger.Info($"ULTIMO_CFe.....: {ret.Status.UltimoCFe}");
            logger.Info($"LISTA_INICIAL..: {ret.Status.ListaInicial}");
            logger.Info($"LISTA_FINAL....: {ret.Status.ListaFinal}");
            logger.Info($"DH_CFe.........: {ret.Status.DhCFe}");
            logger.Info($"DH_ULTIMA......: {ret.Status.DhUltima}");
            logger.Info($"CERT_EMISSAO...: {ret.Status.CertEmissao}");
            logger.Info($"ESTADO_OPERACAO: {ret.Status.EstadoOperacao}");
        }

        #endregion Methods

        #region EventHandlers

        #region Menu

        private void ativarSATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!acbrSat.Ativo) ToogleInitialize();
            acbrSat.AtivarSAT(1, txtEmitCNPJ.Text, txtCodUF.Text.ToInt32());
        }

        private void comunicarCertificadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!acbrSat.Ativo) ToogleInitialize();
            logger.Info("Comunicar certificado.");
            var file = Helpers.OpenFiles(@"Certificado|*.cer|Arquivo Texto|*.txt");
            if (file.IsEmpty())
            {
                logger.Info("Comunicar certificado Cancelado.");
                return;
            }

            acbrSat.ComunicarCertificadoIcpBrasil(File.ReadAllText(file));
        }

        private void associarAssinaturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!acbrSat.Ativo) ToogleInitialize();
            acbrSat.AssociarAssinatura(txtIdeCNPJ.Text + txtEmitCNPJ.Text, txtSignAC.Text);
        }

        private void bloquearSATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!acbrSat.Ativo) ToogleInitialize();
            acbrSat.BloquearSAT();
        }

        private void desbloquearSATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!acbrSat.Ativo) ToogleInitialize();
            acbrSat.DesbloquearSAT();
        }

        private void trocarCódigoDeAtivaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!acbrSat.Ativo) ToogleInitialize();

            var codigo = txtAtivacao.Text;
            if (InputBox.Show("Trocar Código de Ativação", "Entre com o Código de Ativação ou de Emergência:", ref codigo).Equals(DialogResult.Cancel))
                return;

            var tipoCodigo = "1";
            if (InputBox.Show("Trocar Código de Ativação",
                              "Qual o Tipo do Código Informado anteriormente ?" + Environment.NewLine +
                              "1 – Código de Ativação" + Environment.NewLine +
                              "2 – Código de Ativação de Emergência", ref tipoCodigo).Equals(DialogResult.Cancel))
                return;

            var novoCodigo = string.Empty;
            if (InputBox.Show("Trocar Código de Ativação", "Entre com o Número do Novo Código de Ativação:", ref novoCodigo).Equals(DialogResult.Cancel))
                return;

            var ret = acbrSat.TrocarCodigoDeAtivacao(codigo, tipoCodigo.ToInt32(1), novoCodigo);
            if (ret.CodigoDeRetorno != 1800)
                return;

            txtAtivacao.Text = novoCodigo;
            logger.Info("Codigo de Ativação trocado com sucesso");
            SaveConfig(false);
        }

        private void gerarVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerarCFe();
        }

        private void enviarVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!acbrSat.Ativo) ToogleInitialize();
            var ret = acbrSat.EnviarDadosVenda(cfeAtual);
            if (ret.CodigoDeRetorno != 6000)
                return;

            cfeAtual = ret.Venda;
            wbrXmlRecebido.LoadXml(ret.Venda.GetXml());
            tbcXml.SelectedTab = tpgXmlRecebido;
        }

        private void imprimirExtratoVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cfeAtual.IsNull()) return;
            acbrSat.ImprimirExtrato(cfeAtual);
        }

        private void imprimirExtratoVendaResumidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cfeAtual.IsNull()) return;
            acbrSat.ImprimirExtratoResumido(cfeAtual);
        }

        private void carregarXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logger.Info("Carregar XML CFe.");
            var file = Helpers.OpenFiles(@"CFe Xml | *.xml");
            if (file.IsEmpty())
            {
                logger.Info("Carregar XML CFe Cancelado.");
                return;
            }

            cfeAtual = CFe.Load(file);
            wbrXmlGerado.LoadXml(cfeAtual.GetXml());
            tbcXml.SelectedTab = tpgXmlGerado;
            logger.Info("XML CFe carregado com sucesso.");
        }

        private void gerarXMLCancelamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logger.Info("Gerando XML de Cancelamento !");

            if (cfeAtual == null)
            {
                logger.Warn("Nenhum Xml de Venda carregado !");
                return;
            }

            cfeCancAtual = new CFeCanc(cfeAtual);
            wbrXmlCancelamento.LoadXml(cfeCancAtual.GetXml());
            tbcXml.SelectedTab = tpgXmlCancelamento;
            logger.Info("CFe de Cancelamento gerado com sucesso !");
        }

        private void enviarCancelamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!acbrSat.Ativo) ToogleInitialize();
            var ret = cfeCancAtual != null ? acbrSat.CancelarUltimaVenda(cfeCancAtual) : acbrSat.CancelarUltimaVenda(cfeAtual);
            if (ret.CodigoDeRetorno != 7000)
                return;

            cfeCancAtual = ret.Cancelamento;
            wbrXmlRecebido.LoadXml(ret.Cancelamento.GetXml());
            tbcXml.SelectedTab = tpgXmlRecebido;
        }

        private void imprimirExtratoCancelamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cfeAtual.IsNull() || cfeCancAtual.IsNull()) return;
            acbrSat.ImprimirExtratoCancelamento(cfeCancAtual, cfeAtual.InfCFe.Ide.TpAmb ?? DFeTipoAmbiente.Homologacao);
        }

        private void consultarStatusOperacionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!acbrSat.Ativo) ToogleInitialize();
            ConsultarStatusOperacional();
        }

        private void consultarSATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!acbrSat.Ativo) ToogleInitialize();
            acbrSat.ConsultarSAT();
        }

        private void consultarNumeroDeSessãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!acbrSat.Ativo) ToogleInitialize();

            var sessao = string.Empty;
            if (InputBox.Show("Consultar Sessão", "Digite o número da sessão", ref sessao).Equals(DialogResult.Cancel))
                return;

            if (!sessao.IsNumeric())
                return;

            var ret = acbrSat.ConsultarNumeroSessao(sessao.ToInt32());

            if (ret.CodigoDeRetorno == 6000)
                wbrXmlRecebido.LoadXml(ret.Venda.GetXml());
            else if (ret.CodigoDeRetorno == 7000)
                wbrXmlRecebido.LoadXml(ret.Cancelamento.GetXml());
            else
                return;

            tbcXml.SelectedTab = tpgXmlRecebido;
        }

        private void atualizarSATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!acbrSat.Ativo) ToogleInitialize();
            acbrSat.AtualizarSoftwareSAT();
        }

        private void lerXMLConfiguraçãoDeInterfaceDeRedeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logger.Info("Carregar XML Rede.");
            var file = Helpers.OpenFiles(@"Xml Rede | *.xml");
            if (file.IsEmpty())
            {
                logger.Info("Carregar XML Rede Cancelado.");
                return;
            }

            redeAtual = SatRede.Load(file);
            wbrXmlRede.LoadXml(redeAtual.GetXml());
            tbcXml.SelectedTab = tpgRede;
            logger.Info("XML Rede carregado com sucesso.");
        }

        private void gravarXmlDeInterfaceDeRedeToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void configurarInterfaceDeRedeToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void testeFimAFimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!acbrSat.Ativo) ToogleInitialize();

            if (cfeAtual == null)
                GerarCFe();

            var ret = acbrSat.TesteFimAFim(cfeAtual);
            if (ret.CodigoDeRetorno != 9000)
                return;

            wbrXmlRecebido.LoadXml(ret.VendaTeste.GetXml());
            tbcXml.SelectedTab = tpgXmlRecebido;
        }

        private void extrairLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!acbrSat.Ativo) ToogleInitialize();
            var resposta = acbrSat.ExtrairLogs();
            var pathLog = Path.Combine(Application.StartupPath, "logSat.txt");
            File.WriteAllText(pathLog, resposta.Log);
            Process.Start(pathLog);
        }

        #endregion Menu

        #region ValueChanged

        private void cmbModeloSat_SelectedIndexChanged(object sender, EventArgs e)
        {
            acbrSat.Modelo = (ModeloSat)cmbModeloSat.SelectedItem;
        }

        private void txtDllPath_TextChanged(object sender, EventArgs e)
        {
            if (!File.Exists(txtDllPath.Text))
                return;

            acbrSat.PathDll = txtDllPath.Text;
        }

        private void txtAtivacao_TextChanged(object sender, EventArgs e)
        {
            if (txtAtivacao.Text.IsEmpty()) return;

            acbrSat.CodigoAtivacao = txtAtivacao.Text;
        }

        private void cmbAmbiente_SelectedIndexChanged(object sender, EventArgs e)
        {
            acbrSat.Configuracoes.IdeTpAmb = (DFeTipoAmbiente)cmbAmbiente.SelectedItem;
        }

        private void nunCaixa_ValueChanged(object sender, EventArgs e)
        {
            acbrSat.Configuracoes.IdeNumeroCaixa = (int)nunCaixa.Value;
        }

        private void nunPaginaCodigo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                var encoder = Encoding.GetEncoding((int)nunPaginaCodigo.Value);
                acbrSat.Encoding = encoder;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                acbrSat.Encoding = Encoding.UTF8;
            }
        }

        private void chkUTF8_CheckedChanged(object sender, EventArgs e)
        {
            nunPaginaCodigo.Value = chkUTF8.Checked ? 65001M : 0;
        }

        private void chkRemoveAcentos_CheckedChanged(object sender, EventArgs e)
        {
            acbrSat.Configuracoes.RemoverAcentos = chkRemoveAcentos.Checked;
        }

        private void nunVersaoCFe_ValueChanged(object sender, EventArgs e)
        {
            acbrSat.Configuracoes.InfCFeVersaoDadosEnt = nunVersaoCFe.Value;
        }

        private void chkSaveCFe_CheckedChanged(object sender, EventArgs e)
        {
            acbrSat.Arquivos.SalvarCFe = chkSaveCFe.Checked;
        }

        private void chkSaveEnvio_CheckedChanged(object sender, EventArgs e)
        {
            acbrSat.Arquivos.SalvarEnvio = chkSaveEnvio.Checked;
        }

        private void chkSaveCFeCanc_CheckedChanged(object sender, EventArgs e)
        {
            acbrSat.Arquivos.SalvarCFeCanc = chkSaveCFeCanc.Checked;
        }

        private void chkSepararCNPJ_CheckedChanged(object sender, EventArgs e)
        {
            acbrSat.Arquivos.SepararPorCNPJ = chkSepararCNPJ.Checked;
        }

        private void chkSepararData_CheckedChanged(object sender, EventArgs e)
        {
            acbrSat.Arquivos.SepararPorMes = chkSepararData.Checked;
        }

        private void txtEmitCNPJ_TextChanged(object sender, EventArgs e)
        {
            acbrSat.Configuracoes.EmitCNPJ = txtEmitCNPJ.Text.OnlyNumbers();
        }

        private void txtEmitIE_TextChanged(object sender, EventArgs e)
        {
            acbrSat.Configuracoes.EmitIE = txtEmitIE.Text.OnlyNumbers();
        }

        private void txtEmitIM_TextChanged(object sender, EventArgs e)
        {
            acbrSat.Configuracoes.EmitIM = txtEmitIM.Text.OnlyNumbers();
        }

        private void cmbEmiRegTrib_SelectedIndexChanged(object sender, EventArgs e)
        {
            acbrSat.Configuracoes.EmitCRegTrib = (RegTrib)cmbEmiRegTrib.SelectedItem;
        }

        private void cmbEmiRegTribISSQN_SelectedIndexChanged(object sender, EventArgs e)
        {
            acbrSat.Configuracoes.EmitCRegTribISSQN = (RegTribIssqn)cmbEmiRegTribISSQN.SelectedItem;
        }

        private void cmbEmiRatIISQN_SelectedIndexChanged(object sender, EventArgs e)
        {
            acbrSat.Configuracoes.EmitIndRatISSQN = (RatIssqn)cmbEmiRatIISQN.SelectedItem;
        }

        private void txtIdeCNPJ_TextChanged(object sender, EventArgs e)
        {
            acbrSat.Configuracoes.IdeCNPJ = txtIdeCNPJ.Text.OnlyNumbers();
        }

        private void txtSignAC_TextChanged(object sender, EventArgs e)
        {
            acbrSat.SignAC = txtSignAC.Text;
        }

        private void txtMFeEnvio_TextChanged(object sender, EventArgs e)
        {
            acbrIntegrador.Configuracoes.PastaInput = txtMFeEnvio.Text;
        }

        private void txtMFeResposta_TextChanged(object sender, EventArgs e)
        {
            acbrIntegrador.Configuracoes.PastaOutput = txtMFeResposta.Text;
        }

        private void nunMFeTimeout_ValueChanged(object sender, EventArgs e)
        {
            acbrIntegrador.Configuracoes.TimeOut = (int)nunMFeTimeout.Value;
        }

        private void txtChaveAcessoValidador_TextChanged(object sender, EventArgs e)
        {
            acbrIntegrador.Configuracoes.ChaveAcessoValidador = txtChaveAcessoValidador.Text;
        }

        #endregion ValueChanged

        #region Botoes

        private void btnIniDesini_Click(object sender, EventArgs e)
        {
            ToogleInitialize();
        }

        private void btnParamLoad_Click(object sender, EventArgs e)
        {
            LoadConfig();
        }

        private void btnParamSave_Click(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void btnSelDll_Click(object sender, EventArgs e)
        {
            var file = Helpers.OpenFiles(@"Sat Library | *.dll");
            if (!file.IsEmpty())
                txtDllPath.Text = file;
        }

        private void btnEnviarPagamento_Click(object sender, EventArgs e)
        {
            var _chaveRequisicao = Guid.NewGuid().ToString();
            var resposta = acbrIntegrador.EnviarPagamento(
                chaveRequisicao: _chaveRequisicao,
                estabelecimento: "10",
                serialPOS: new Random().Next(10000000, 99999999).ToString(),
                cnpj: txtEmitCNPJ.Text,
                icmsBase: 0.23m,
                valorTotalVenda: 1530,
                origemPagamento: "Mesa 1234",
                habilitarMultiplosPagamentos: true,
                habilitarControleAntiFraude: false,
                codigoMoeda: "BRL",
                emitirCupomNFCE: false
            );

            wbrXmlRecebido.LoadXml(resposta.GetXml());
        }

        private void btnEnviarStatusPagamento_Click(object sender, EventArgs e)
        {
            var _idfila = "00000000";
            InputBox.Show("ID da fila", "Informe o if da fila", ref _idfila);
            var resposta = acbrIntegrador.EnviarStatusPagamento(
                codigoAutorizacao: "20551",
                bin: "123456",
                donoCartao: "Teste",
                dataExpiracao: "01/18",
                instituicaoFinanceira: "STONE",
                parcelas: 1,
                codigoPagamento: "12846",
                valorPagamento: 1530,
                idFila: int.Parse(_idfila),
                tipo: "1",
                ultimosQuatroDigitos: 1234
             );

            wbrXmlRecebido.LoadXml(resposta.GetXml());
        }

        private void btnVerificarStatusValidador_Click(object sender, EventArgs e)
        {
            var _idfila = "00000000";
            InputBox.Show("ID da fila", "Informe o if da fila", ref _idfila);
            var resposta = acbrIntegrador.VerificarStatusValidador(
                idFila: int.Parse(_idfila),
                cnpj: txtEmitCNPJ.Text
            );

            wbrXmlRecebido.LoadXml(resposta.GetXml());
        }

        private void btnRespostaFiscal_Click(object sender, EventArgs e)
        {
            var _idfila = "00000000";
            InputBox.Show("ID da fila", "Id da fila", ref _idfila);

            var _chaveAcesso = "35170408723218000186599000113100000279731880";
            InputBox.Show("Chave de acesso", "Chave de acesso do CFe", ref _chaveAcesso);

            var resposta = acbrIntegrador.RespostaFiscal(
                idFila: int.Parse(_idfila),
                chaveAcesso: _chaveAcesso,
                nsu: _idfila.ToString(),
                numeroAprovacao: "1234",
                bandeira: "VISA",
                adquirinte: "STONE",
                impressaofiscal: "",
                numeroDocumento: _idfila.ToString(),
                cnpj: txtEmitCNPJ.Text
            );

            wbrXmlRecebido.LoadXml(resposta.GetXml());
        }

        #endregion Botoes

        #endregion EventHandlers
    }
}
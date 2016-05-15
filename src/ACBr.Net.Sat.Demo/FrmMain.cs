using ACBr.Net.Core.Extensions;
using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Windows.Forms;
using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ACBr.Net.Sat.Demo
{
	public partial class FrmMain : Form
	{
		#region Fields

		private ILogger logger;
		private ACBrSat acbrSat;
		private CFe cfeAtual;

		#endregion Fields

		#region Constructors

		public FrmMain()
		{
			InitializeComponent();
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
			acbrSat = new ACBrSat();
			cmbAmbiente.EnumDataSource<TipoAmbiente>(TipoAmbiente.Homologacao);
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

			var infoTarget = new FileTarget()
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
			cfeAtual.InfCFe.Dest.CPF = "09506738700";
			cfeAtual.InfCFe.Dest.Nome = "D.J. SYSTEM ÁÉÍÓÚáéíóúÇç";
			cfeAtual.InfCFe.Entrega.XLgr = "logradouro";
			cfeAtual.InfCFe.Entrega.Nro = "112233";
			cfeAtual.InfCFe.Entrega.XCpl = "complemento";
			cfeAtual.InfCFe.Entrega.XBairro = "bairro";
			cfeAtual.InfCFe.Entrega.XMun = "municipio";
			cfeAtual.InfCFe.Entrega.UF = "MS";
			for (var i = 0; i < 3; i++)
			{
				var det1 = cfeAtual.InfCFe.Det.AddNew();
				det1.NItem = 1 + i;
				det1.Prod.CProd = "ACBR001";
				det1.Prod.CEAN = "6291041500213";
				det1.Prod.XProd = "Assinatura SAC";
				det1.Prod.NCM = "99";
				det1.Prod.CFOP = "5120";
				det1.Prod.UCom = "UN";
				det1.Prod.QCom = 1;
				det1.Prod.VUnCom = 120.00M;
				det1.Prod.IndRegra = IndRegra.Truncamento;
				det1.Prod.VDesc = 1;
				var obs = det1.Prod.ObsFiscoDet.AddNew();
				obs.XCampoDet = "campo";
				obs.XTextoDet = "texto";

				var totalItem = det1.Prod.QCom * det1.Prod.VUnCom;
				totalGeral += totalItem;
				det1.Imposto.VItem12741 = totalItem * 0.12M;

				det1.Imposto.Imposto = new ImpostoIcms
				{
					ICMS = new ImpostoIcms00
					{
						Orig = OrigemMercadoria.Nacional,
						CST = "00",
						PICMS = 18
					}
				};

				det1.Imposto.PIS.PIS = new ImpostoPisAliq
				{
					CST = "01",
					VBc = totalItem,
					PPIS = 0.0065M
				};

				det1.Imposto.COFINS.Cofins = new ImpostoCofinsAliq()
				{
					Cst = "01",
					VBc = totalItem,
					PCOFINS = 0.0065M
				};

				det1.InfAdProd = "Informacoes adicionais";
			}

			cfeAtual.InfCFe.Total.DescAcrEntr.VDescSubtot = 5;
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

			wbrXmlGerado.LoadXml(acbrSat.GetXml(cfeAtual));
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
			var config = Helpers.GetConfiguration();
			cmbModeloSat.SelectedItem = Enum.Parse(typeof(ModeloSat), config.AppSettings.Settings["ModeloSat"]?.Value ?? "Cdecl");
			txtDllPath.Text = config.AppSettings.Settings["DllPath"]?.Value ?? @"C:\SAT\SAT.dll";
			cmbAmbiente.SelectedItem = Enum.Parse(typeof(TipoAmbiente), config.AppSettings.Settings["Ambiente"]?.Value ?? "Homologacao");
			txtAtivacao.Text = config.AppSettings.Settings["Ativacao"]?.Value ?? "12345678";
			txtCodUF.Text = config.AppSettings.Settings["CodUF"]?.Value ?? "35";
			nunPaginaCodigo.Value = config.AppSettings.Settings["PaginaCodigo"]?.Value.ToDecimal(0, CultureInfo.InvariantCulture) ?? 1252;
			nunCaixa.Value = config.AppSettings.Settings["Caixa"]?.Value.ToDecimal(1, CultureInfo.InvariantCulture) ?? 1;
			nunVersaoCFe.Value = config.AppSettings.Settings["VersaoCFe"]?.Value.ToDecimal(0.06M, CultureInfo.InvariantCulture) ?? 0.06M;
			chkUTF8.Checked = Convert.ToBoolean(config.AppSettings.Settings["UTF8"]?.Value ?? "False");
			chkFomartXML.Checked = Convert.ToBoolean(config.AppSettings.Settings["FomartXML"]?.Value ?? "True");
			chkRemoveAcentos.Checked = Convert.ToBoolean(config.AppSettings.Settings["RemoveAcentos"]?.Value ?? "False");
			chkSaveEnvio.Checked = Convert.ToBoolean(config.AppSettings.Settings["SaveEnvio"]?.Value ?? "True");
			chkSaveCFe.Checked = Convert.ToBoolean(config.AppSettings.Settings["SaveCFe"]?.Value ?? "True");
			chkSaveCFeCanc.Checked = Convert.ToBoolean(config.AppSettings.Settings["SaveCFeCanc"]?.Value ?? "True");
			chkSepararCNPJ.Checked = Convert.ToBoolean(config.AppSettings.Settings["SepararCNPJ"]?.Value ?? "True");
			chkSepararData.Checked = Convert.ToBoolean(config.AppSettings.Settings["SepararData"]?.Value ?? "True");
			txtEmitCNPJ.Text = config.AppSettings.Settings["EmitCNPJ"]?.Value ?? "11111111111111";
			txtEmitIE.Text = config.AppSettings.Settings["EmitIE"]?.Value ?? string.Empty;
			txtEmitIM.Text = config.AppSettings.Settings["EmitIM"]?.Value ?? string.Empty;
			cmbEmiRegTrib.SelectedItem = Enum.Parse(typeof(RegTrib), config.AppSettings.Settings["EmiRegTrib"]?.Value ?? "SimplesNacional");
			cmbEmiRegTribISSQN.SelectedItem = Enum.Parse(typeof(RegTribIssqn), config.AppSettings.Settings["EmiRegTribISSQN"]?.Value ?? "Nenhum");
			cmbEmiRegTrib.SelectedItem = Enum.Parse(typeof(RatIssqn), config.AppSettings.Settings["EmiRatIISQN"]?.Value ?? "Sim");
			txtIdeCNPJ.Text = config.AppSettings.Settings["IdeCNPJ"]?.Value ?? "22222222222222";
			txtSignAC.Text = config.AppSettings.Settings["SignAC"]?.Value ?? 
				"1111111111111222222222222221111111111111122222222222222111111111111112222222222222211111" +
				"111111111222222222222221111111111111122222222222222111111111111112222222222222211111111" +
				"111111222222222222221111111111111122222222222222111111111111112222222222222211111111111" +
				"1112222222222222211111111111111222222222222221111111111111122222222222222111111111"; ;

			MessageBox.Show(this, @"Configurações Carregada com sucesso !", @"S@T Demo");
		}

		private void SaveConfig()
		{
			var config = Helpers.GetConfiguration();
			config.AppSettings.Settings.AddValue("ModeloSat", cmbModeloSat.SelectedItem.ToString());
			config.AppSettings.Settings.AddValue("DllPath", txtDllPath.Text);
			config.AppSettings.Settings.AddValue("Ambiente", cmbAmbiente.SelectedItem.ToString());
			config.AppSettings.Settings.AddValue("Ativacao", txtAtivacao.Text);
			config.AppSettings.Settings.AddValue("CodUF", txtCodUF.Text);
			config.AppSettings.Settings.AddValue("PaginaCodigo", nunPaginaCodigo.Value.ToString(CultureInfo.InvariantCulture));
			config.AppSettings.Settings.AddValue("Caixa", nunCaixa.Value.ToString(CultureInfo.InvariantCulture));
			config.AppSettings.Settings.AddValue("VersaoCFe", nunVersaoCFe.Value.ToString(CultureInfo.InvariantCulture));
			config.AppSettings.Settings.AddValue("UTF8", chkUTF8.Checked.ToString());
			config.AppSettings.Settings.AddValue("FomartXML", chkFomartXML.Checked.ToString());
			config.AppSettings.Settings.AddValue("RemoveAcentos", chkRemoveAcentos.Checked.ToString());
			config.AppSettings.Settings.AddValue("SaveEnvio", chkSaveEnvio.Checked.ToString());
			config.AppSettings.Settings.AddValue("SaveCFe", chkSaveCFe.Checked.ToString());
			config.AppSettings.Settings.AddValue("SaveCFeCanc", chkSaveCFeCanc.Checked.ToString());
			config.AppSettings.Settings.AddValue("SepararCNPJ", chkSepararCNPJ.Checked.ToString());
			config.AppSettings.Settings.AddValue("SepararData", chkSepararData.Checked.ToString());
			config.AppSettings.Settings.AddValue("EmitCNPJ", txtEmitCNPJ.Text);
			config.AppSettings.Settings.AddValue("EmitIE", txtEmitIE.Text);
			config.AppSettings.Settings.AddValue("EmitIM", txtEmitIM.Text);
			config.AppSettings.Settings.AddValue("EmiRegTrib", cmbEmiRegTrib.SelectedItem.ToString());
			config.AppSettings.Settings.AddValue("EmiRegTribISSQN", cmbEmiRegTribISSQN.SelectedItem.ToString());
			config.AppSettings.Settings.AddValue("EmiRatIISQN", cmbEmiRatIISQN.SelectedItem.ToString());
			config.AppSettings.Settings.AddValue("IdeCNPJ", txtIdeCNPJ.Text);
			config.AppSettings.Settings.AddValue("SignAC", txtSignAC.Text);

			config.Save(ConfigurationSaveMode.Minimal, true);
			MessageBox.Show(this, @"Configurações Salva com sucesso !", @"S@T Demo");
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
		}

		private void associarAssinaturaToolStripMenuItem_Click(object sender, EventArgs e)
		{
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
		}

		private void gerarVendaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GerarCFe();
		}

		private void enviarVendaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!acbrSat.Ativo) ToogleInitialize();
			acbrSat.EnviarDadosVenda(cfeAtual);
		}

		private void imprimirExtratoVendaToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void imprimirExtratoVendaResumidoToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void carregarXMLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			logger.Info("Carregar XML CFe.");

			using (var ofd = new OpenFileDialog())
			{
				ofd.CheckPathExists = true;
				ofd.CheckFileExists = true;
				ofd.Multiselect = false;
				ofd.Filter = @"CFe Xml | *.xml";

				if (ofd.ShowDialog().Equals(DialogResult.Cancel))
				{
					logger.Info("Carregar XML CFe Cancelado.");
					return;
				}

				cfeAtual = CFe.Load(ofd.FileName);

				wbrXmlGerado.LoadXml(File.ReadAllText(ofd.FileName));
				tbcXml.SelectedTab = tpgXmlGerado;
				logger.Info("XML CFe carregado com sucesso.");
			}
		}

		private void consultarStatusOperacionalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!acbrSat.Ativo) ToogleInitialize();
			acbrSat.ConsultarStatusOperacional();
		}

		private void consultarSATToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!acbrSat.Ativo) ToogleInitialize();
			acbrSat.ConsultarSAT();
		}

		private void atualizarSATToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!acbrSat.Ativo) ToogleInitialize();
			acbrSat.AtualizarSoftwareSAT();
		}

		private void extrairLogsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!acbrSat.Ativo) ToogleInitialize();
			var resposta = acbrSat.ExtrairLogs();
		}

		#endregion Menu

		#region ValueChanged

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
			acbrSat.Configuracoes.IdeTpAmb = (TipoAmbiente)cmbAmbiente.SelectedValue;
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

		private void chkFomartXML_CheckedChanged(object sender, EventArgs e)
		{
			acbrSat.Configuracoes.FormatarXml = chkFomartXML.Checked;
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

		private void cmbEmiRegTrib_SelectedValueChanged(object sender, EventArgs e)
		{
			acbrSat.Configuracoes.EmitCRegTrib = (RegTrib) cmbEmiRegTrib.SelectedValue;
		}

		private void cmbEmiRegTribISSQN_SelectedValueChanged(object sender, EventArgs e)
		{
			acbrSat.Configuracoes.EmitCRegTribISSQN = (RegTribIssqn)cmbEmiRegTribISSQN.SelectedValue;
		}

		private void cmbEmiRatIISQN_SelectedValueChanged(object sender, EventArgs e)
		{
			acbrSat.Configuracoes.EmitIndRatISSQN = (RatIssqn)cmbEmiRatIISQN.SelectedValue;
		}

		private void txtIdeCNPJ_TextChanged(object sender, EventArgs e)
		{
			acbrSat.Configuracoes.IdeCNPJ = txtIdeCNPJ.Text.OnlyNumbers();
		}

		private void txtSignAC_TextChanged(object sender, EventArgs e)
		{
			acbrSat.SignAC = txtSignAC.Text;
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

		#endregion Botoes

		#endregion EventHandlers
	}
}
using System;
using System.Text;
using System.Windows.Forms;
using ACBr.Net.Core.Extensions;
using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Windows.Forms;

namespace ACBr.Net.Sat.Demo
{
	public partial class FrmMain : Form
	{
		#region Fields
		
		private ILogger logger;
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
			ACBrSat.CodigoAtivacao = @"123456789";
			cmbAmbiente.SelectedIndex = 0;
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
			cfeAtual = ACBrSat.NewCFe();
			cfeAtual.InfCFe.Ide.NumeroCaixa = 1;
			cfeAtual.InfCFe.Dest.CNPJ = "05481336000137";
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
				det1.NItem = 1 + i * 3;
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

				det1.Imposto.Imposto = new ImpostoICMS
				{
					ICMS = new ImpostoICMS00
					{
						Orig = OrigemMercadoria.Nacional,
						CST = "00",
						PICMS = 18
					}
				};

				det1.Imposto.PIS.PIS = new ImpostoPISAliq
				{
					CST = "01",
					VBc = totalItem,
					PPIS = 0.0065M
				};

				det1.Imposto.COFINS.COFINS = new ImpostoCOFINSAliq()
				{
					CST = "01",
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

			var pgto2 = cfeAtual.InfCFe.Pagto.Pagamentos.AddNew();
			pgto2.CMp = CodigoMP.Dinheiro;
			pgto2.VMp = totalGeral / 2 + 10;

			cfeAtual.InfCFe.InfAdic.InfCpl = "Acesse www.projetoacbr.com.br para obter mais;informações sobre o componente ACBrSAT;" +
										"Precisa de um PAF-ECF homologado?;Conheça o DJPDV - www.djpdv.com.br";

			wbrXmlGerado.LoadXml(cfeAtual.ToString());
			tbcXml.SelectedTab = tpgXmlGerado;
			logger.Info("CFe gerado com sucesso !");
		}


		#endregion Methods

		#region EventHandlers

		#region Menu

		private void ativarSATToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var sat = ACBrSat.CreateLibrary(ModeloSat.Cdecl);
			sat.AtivarSAT(1, txtEmitCNPJ.Text, txtCodUF.Text.ToInt32());
		}

		private void comunicarCertificadoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			
		}

		private void associarAssinaturaToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void bloquearSATToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var sat = ACBrSat.CreateLibrary(ModeloSat.Cdecl);
			sat.BloquearSAT();
		}

		private void desbloquearSATToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var sat = ACBrSat.CreateLibrary(ModeloSat.Cdecl);
			sat.DesbloquearSAT();
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
			var sat = ACBrSat.CreateLibrary(ModeloSat.Cdecl);
			sat.EnviarDadosVenda(cfeAtual);
		}

		private void imprimirExtratoVendaToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void imprimirExtratoVendaResumidoToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void carregarXMLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (var ofd = new OpenFileDialog())
			{
				ofd.CheckPathExists = true;
				ofd.CheckFileExists = true;
				ofd.Multiselect = false;
				ofd.Filter = @"CFe Xml | *.xml";

				if (ofd.ShowDialog().Equals(DialogResult.Cancel))
					return;

				cfeAtual = CFe.LoadCFe(ofd.FileName);
				wbrXmlGerado.LoadXml(cfeAtual?.ToString());
			}
		}

		private void consultarStatusOperacionalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var sat = ACBrSat.CreateLibrary(ModeloSat.Cdecl);
			sat.ConsultarStatusOperacional();
		}

		private void consultarSATToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var sat = ACBrSat.CreateLibrary(ModeloSat.Cdecl);
			sat.ConsultarSAT();
		}

		private void atualizarSATToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var sat = ACBrSat.CreateLibrary(ModeloSat.Cdecl);
			sat.AtualizarSoftwareSAT();
		}

		#endregion Menu

		#region Botoes

		private void btnSelDll_Click(object sender, EventArgs e)
		{
			using (var ofd = new OpenFileDialog())
			{
				ofd.CheckPathExists = true;
				ofd.CheckFileExists = true;
				ofd.Multiselect = false;
				ofd.Filter = @"Sat Library | *.dll";

				if(ofd.ShowDialog().Equals(DialogResult.Cancel))
					return;

				txtDllPath.Text = ofd.FileName;
			}
		}

		#endregion Botoes

		#endregion EventHandlers
	}
}

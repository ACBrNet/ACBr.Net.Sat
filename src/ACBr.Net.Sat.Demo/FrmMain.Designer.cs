namespace ACBr.Net.Sat.Demo
{
	partial class FrmMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
			this.tpgLog = new System.Windows.Forms.TabPage();
			this.rtbLog = new System.Windows.Forms.RichTextBox();
			this.tbcXml = new System.Windows.Forms.TabControl();
			this.tpgXmlGerado = new System.Windows.Forms.TabPage();
			this.wbrXmlGerado = new System.Windows.Forms.WebBrowser();
			this.tpgXmlRecebido = new System.Windows.Forms.TabPage();
			this.wbrXmlRecebido = new System.Windows.Forms.WebBrowser();
			this.tpgXmlCancelamento = new System.Windows.Forms.TabPage();
			this.wbrXmlCancelamento = new System.Windows.Forms.WebBrowser();
			this.tpgXmlRede = new System.Windows.Forms.TabPage();
			this.wbrXmlRede = new System.Windows.Forms.WebBrowser();
			this.stsStatus = new System.Windows.Forms.StatusStrip();
			this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.ativaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ativarSATToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.comunicarCertificadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.associarAssinaturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.bloquearSATToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.desbloquearSATToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.trocarCódigoDeAtivaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.vendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gerarVendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.enviarVendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.imprimirExtratoVendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.imprimirExtratoVendaResumidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.carregarXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cancelamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gerarXMLCancelamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.enviarCancelamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.imprimirExtratoCancelamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.consultarStatusOperacionalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.consultarSATToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.consultarNumeroDeSessãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.configuraçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.atualizarSATToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.lerXMLConfiguraçãoDeInterfaceDeRedeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gravarXmlDeInterfaceDeRedeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.configurarInterfaceDeRedeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.diversosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.testeFimAFimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.extrairLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.limparToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tbcDados = new System.Windows.Forms.TabControl();
			this.tpgConfig = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.chkSepararData = new System.Windows.Forms.CheckBox();
			this.chkSepararCNPJ = new System.Windows.Forms.CheckBox();
			this.chkSaveCFeCanc = new System.Windows.Forms.CheckBox();
			this.chkSaveEnvio = new System.Windows.Forms.CheckBox();
			this.chkSaveCFe = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.chkRemoveAcentos = new System.Windows.Forms.CheckBox();
			this.nunVersaoCFe = new System.Windows.Forms.NumericUpDown();
			this.chkFomartXML = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.chkUTF8 = new System.Windows.Forms.CheckBox();
			this.nunPaginaCodigo = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.nunCaixa = new System.Windows.Forms.NumericUpDown();
			this.txtCodUF = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtAtivacao = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbAmbiente = new System.Windows.Forms.ComboBox();
			this.txtDllPath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnSelDll = new System.Windows.Forms.Button();
			this.tpgEmitente = new System.Windows.Forms.TabPage();
			this.txtEmitIM = new System.Windows.Forms.TextBox();
			this.txtEmitIE = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtEmitCNPJ = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.tpgSwHouse = new System.Windows.Forms.TabPage();
			this.tpgRede = new System.Windows.Forms.TabPage();
			this.tpgImpressao = new System.Windows.Forms.TabPage();
			this.tpgLog.SuspendLayout();
			this.tbcXml.SuspendLayout();
			this.tpgXmlGerado.SuspendLayout();
			this.tpgXmlRecebido.SuspendLayout();
			this.tpgXmlCancelamento.SuspendLayout();
			this.tpgXmlRede.SuspendLayout();
			this.stsStatus.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.tbcDados.SuspendLayout();
			this.tpgConfig.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nunVersaoCFe)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nunPaginaCodigo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nunCaixa)).BeginInit();
			this.tpgEmitente.SuspendLayout();
			this.SuspendLayout();
			// 
			// tpgLog
			// 
			this.tpgLog.Controls.Add(this.rtbLog);
			this.tpgLog.Location = new System.Drawing.Point(4, 22);
			this.tpgLog.Name = "tpgLog";
			this.tpgLog.Padding = new System.Windows.Forms.Padding(3);
			this.tpgLog.Size = new System.Drawing.Size(657, 210);
			this.tpgLog.TabIndex = 0;
			this.tpgLog.Text = "Log de Comando";
			this.tpgLog.UseVisualStyleBackColor = true;
			// 
			// rtbLog
			// 
			this.rtbLog.BackColor = System.Drawing.Color.White;
			this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtbLog.Location = new System.Drawing.Point(3, 3);
			this.rtbLog.Name = "rtbLog";
			this.rtbLog.ReadOnly = true;
			this.rtbLog.Size = new System.Drawing.Size(651, 204);
			this.rtbLog.TabIndex = 0;
			this.rtbLog.Text = "";
			// 
			// tbcXml
			// 
			this.tbcXml.Controls.Add(this.tpgLog);
			this.tbcXml.Controls.Add(this.tpgXmlGerado);
			this.tbcXml.Controls.Add(this.tpgXmlRecebido);
			this.tbcXml.Controls.Add(this.tpgXmlCancelamento);
			this.tbcXml.Controls.Add(this.tpgXmlRede);
			this.tbcXml.Location = new System.Drawing.Point(0, 215);
			this.tbcXml.Name = "tbcXml";
			this.tbcXml.SelectedIndex = 0;
			this.tbcXml.Size = new System.Drawing.Size(665, 236);
			this.tbcXml.TabIndex = 0;
			// 
			// tpgXmlGerado
			// 
			this.tpgXmlGerado.Controls.Add(this.wbrXmlGerado);
			this.tpgXmlGerado.Location = new System.Drawing.Point(4, 22);
			this.tpgXmlGerado.Name = "tpgXmlGerado";
			this.tpgXmlGerado.Padding = new System.Windows.Forms.Padding(3);
			this.tpgXmlGerado.Size = new System.Drawing.Size(657, 210);
			this.tpgXmlGerado.TabIndex = 1;
			this.tpgXmlGerado.Text = "Xml Gerado";
			this.tpgXmlGerado.UseVisualStyleBackColor = true;
			// 
			// wbrXmlGerado
			// 
			this.wbrXmlGerado.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wbrXmlGerado.Location = new System.Drawing.Point(3, 3);
			this.wbrXmlGerado.MinimumSize = new System.Drawing.Size(20, 20);
			this.wbrXmlGerado.Name = "wbrXmlGerado";
			this.wbrXmlGerado.Size = new System.Drawing.Size(651, 204);
			this.wbrXmlGerado.TabIndex = 0;
			// 
			// tpgXmlRecebido
			// 
			this.tpgXmlRecebido.Controls.Add(this.wbrXmlRecebido);
			this.tpgXmlRecebido.Location = new System.Drawing.Point(4, 22);
			this.tpgXmlRecebido.Name = "tpgXmlRecebido";
			this.tpgXmlRecebido.Padding = new System.Windows.Forms.Padding(3);
			this.tpgXmlRecebido.Size = new System.Drawing.Size(657, 210);
			this.tpgXmlRecebido.TabIndex = 2;
			this.tpgXmlRecebido.Text = "Xml Recebido";
			this.tpgXmlRecebido.UseVisualStyleBackColor = true;
			// 
			// wbrXmlRecebido
			// 
			this.wbrXmlRecebido.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wbrXmlRecebido.Location = new System.Drawing.Point(3, 3);
			this.wbrXmlRecebido.MinimumSize = new System.Drawing.Size(20, 20);
			this.wbrXmlRecebido.Name = "wbrXmlRecebido";
			this.wbrXmlRecebido.Size = new System.Drawing.Size(651, 204);
			this.wbrXmlRecebido.TabIndex = 0;
			// 
			// tpgXmlCancelamento
			// 
			this.tpgXmlCancelamento.Controls.Add(this.wbrXmlCancelamento);
			this.tpgXmlCancelamento.Location = new System.Drawing.Point(4, 22);
			this.tpgXmlCancelamento.Name = "tpgXmlCancelamento";
			this.tpgXmlCancelamento.Padding = new System.Windows.Forms.Padding(3);
			this.tpgXmlCancelamento.Size = new System.Drawing.Size(657, 210);
			this.tpgXmlCancelamento.TabIndex = 3;
			this.tpgXmlCancelamento.Text = "Xml Cancelamento";
			this.tpgXmlCancelamento.UseVisualStyleBackColor = true;
			// 
			// wbrXmlCancelamento
			// 
			this.wbrXmlCancelamento.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wbrXmlCancelamento.Location = new System.Drawing.Point(3, 3);
			this.wbrXmlCancelamento.MinimumSize = new System.Drawing.Size(20, 20);
			this.wbrXmlCancelamento.Name = "wbrXmlCancelamento";
			this.wbrXmlCancelamento.Size = new System.Drawing.Size(651, 204);
			this.wbrXmlCancelamento.TabIndex = 0;
			// 
			// tpgXmlRede
			// 
			this.tpgXmlRede.Controls.Add(this.wbrXmlRede);
			this.tpgXmlRede.Location = new System.Drawing.Point(4, 22);
			this.tpgXmlRede.Name = "tpgXmlRede";
			this.tpgXmlRede.Padding = new System.Windows.Forms.Padding(3);
			this.tpgXmlRede.Size = new System.Drawing.Size(657, 210);
			this.tpgXmlRede.TabIndex = 4;
			this.tpgXmlRede.Text = "Xml Rede";
			this.tpgXmlRede.UseVisualStyleBackColor = true;
			// 
			// wbrXmlRede
			// 
			this.wbrXmlRede.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wbrXmlRede.Location = new System.Drawing.Point(3, 3);
			this.wbrXmlRede.MinimumSize = new System.Drawing.Size(20, 20);
			this.wbrXmlRede.Name = "wbrXmlRede";
			this.wbrXmlRede.Size = new System.Drawing.Size(651, 204);
			this.wbrXmlRede.TabIndex = 0;
			// 
			// stsStatus
			// 
			this.stsStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
			this.stsStatus.Location = new System.Drawing.Point(0, 454);
			this.stsStatus.Name = "stsStatus";
			this.stsStatus.Size = new System.Drawing.Size(665, 22);
			this.stsStatus.TabIndex = 1;
			this.stsStatus.Text = "statusStrip1";
			// 
			// lblStatus
			// 
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(650, 17);
			this.lblStatus.Spring = true;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ativaçãoToolStripMenuItem,
            this.vendaToolStripMenuItem,
            this.cancelamentoToolStripMenuItem,
            this.consultasToolStripMenuItem,
            this.configuraçãoToolStripMenuItem,
            this.diversosToolStripMenuItem,
            this.limparToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(665, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// ativaçãoToolStripMenuItem
			// 
			this.ativaçãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ativarSATToolStripMenuItem,
            this.comunicarCertificadoToolStripMenuItem,
            this.associarAssinaturaToolStripMenuItem,
            this.toolStripSeparator1,
            this.bloquearSATToolStripMenuItem,
            this.desbloquearSATToolStripMenuItem,
            this.toolStripSeparator2,
            this.trocarCódigoDeAtivaçãoToolStripMenuItem});
			this.ativaçãoToolStripMenuItem.Name = "ativaçãoToolStripMenuItem";
			this.ativaçãoToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
			this.ativaçãoToolStripMenuItem.Text = "Ativação";
			// 
			// ativarSATToolStripMenuItem
			// 
			this.ativarSATToolStripMenuItem.Name = "ativarSATToolStripMenuItem";
			this.ativarSATToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
			this.ativarSATToolStripMenuItem.Text = "Ativar SAT";
			this.ativarSATToolStripMenuItem.Click += new System.EventHandler(this.ativarSATToolStripMenuItem_Click);
			// 
			// comunicarCertificadoToolStripMenuItem
			// 
			this.comunicarCertificadoToolStripMenuItem.Name = "comunicarCertificadoToolStripMenuItem";
			this.comunicarCertificadoToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
			this.comunicarCertificadoToolStripMenuItem.Text = "Comunicar Certificado";
			this.comunicarCertificadoToolStripMenuItem.Click += new System.EventHandler(this.comunicarCertificadoToolStripMenuItem_Click);
			// 
			// associarAssinaturaToolStripMenuItem
			// 
			this.associarAssinaturaToolStripMenuItem.Name = "associarAssinaturaToolStripMenuItem";
			this.associarAssinaturaToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
			this.associarAssinaturaToolStripMenuItem.Text = "Associar Assinatura";
			this.associarAssinaturaToolStripMenuItem.Click += new System.EventHandler(this.associarAssinaturaToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(211, 6);
			// 
			// bloquearSATToolStripMenuItem
			// 
			this.bloquearSATToolStripMenuItem.Name = "bloquearSATToolStripMenuItem";
			this.bloquearSATToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
			this.bloquearSATToolStripMenuItem.Text = "Bloquear SAT";
			this.bloquearSATToolStripMenuItem.Click += new System.EventHandler(this.bloquearSATToolStripMenuItem_Click);
			// 
			// desbloquearSATToolStripMenuItem
			// 
			this.desbloquearSATToolStripMenuItem.Name = "desbloquearSATToolStripMenuItem";
			this.desbloquearSATToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
			this.desbloquearSATToolStripMenuItem.Text = "Desbloquear SAT";
			this.desbloquearSATToolStripMenuItem.Click += new System.EventHandler(this.desbloquearSATToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(211, 6);
			// 
			// trocarCódigoDeAtivaçãoToolStripMenuItem
			// 
			this.trocarCódigoDeAtivaçãoToolStripMenuItem.Name = "trocarCódigoDeAtivaçãoToolStripMenuItem";
			this.trocarCódigoDeAtivaçãoToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
			this.trocarCódigoDeAtivaçãoToolStripMenuItem.Text = "Trocar Código de Ativação";
			this.trocarCódigoDeAtivaçãoToolStripMenuItem.Click += new System.EventHandler(this.trocarCódigoDeAtivaçãoToolStripMenuItem_Click);
			// 
			// vendaToolStripMenuItem
			// 
			this.vendaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gerarVendaToolStripMenuItem,
            this.enviarVendaToolStripMenuItem,
            this.imprimirExtratoVendaToolStripMenuItem,
            this.imprimirExtratoVendaResumidoToolStripMenuItem,
            this.toolStripSeparator3,
            this.carregarXMLToolStripMenuItem});
			this.vendaToolStripMenuItem.Name = "vendaToolStripMenuItem";
			this.vendaToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
			this.vendaToolStripMenuItem.Text = "Venda";
			// 
			// gerarVendaToolStripMenuItem
			// 
			this.gerarVendaToolStripMenuItem.Name = "gerarVendaToolStripMenuItem";
			this.gerarVendaToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
			this.gerarVendaToolStripMenuItem.Text = "Gerar Venda";
			this.gerarVendaToolStripMenuItem.Click += new System.EventHandler(this.gerarVendaToolStripMenuItem_Click);
			// 
			// enviarVendaToolStripMenuItem
			// 
			this.enviarVendaToolStripMenuItem.Name = "enviarVendaToolStripMenuItem";
			this.enviarVendaToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
			this.enviarVendaToolStripMenuItem.Text = "Enviar Venda";
			this.enviarVendaToolStripMenuItem.Click += new System.EventHandler(this.enviarVendaToolStripMenuItem_Click);
			// 
			// imprimirExtratoVendaToolStripMenuItem
			// 
			this.imprimirExtratoVendaToolStripMenuItem.Name = "imprimirExtratoVendaToolStripMenuItem";
			this.imprimirExtratoVendaToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
			this.imprimirExtratoVendaToolStripMenuItem.Text = "Imprimir Extrato Venda";
			this.imprimirExtratoVendaToolStripMenuItem.Click += new System.EventHandler(this.imprimirExtratoVendaToolStripMenuItem_Click);
			// 
			// imprimirExtratoVendaResumidoToolStripMenuItem
			// 
			this.imprimirExtratoVendaResumidoToolStripMenuItem.Name = "imprimirExtratoVendaResumidoToolStripMenuItem";
			this.imprimirExtratoVendaResumidoToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
			this.imprimirExtratoVendaResumidoToolStripMenuItem.Text = "Imprimir Extrato Venda Resumido";
			this.imprimirExtratoVendaResumidoToolStripMenuItem.Click += new System.EventHandler(this.imprimirExtratoVendaResumidoToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(247, 6);
			// 
			// carregarXMLToolStripMenuItem
			// 
			this.carregarXMLToolStripMenuItem.Name = "carregarXMLToolStripMenuItem";
			this.carregarXMLToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
			this.carregarXMLToolStripMenuItem.Text = "Carregar XML";
			this.carregarXMLToolStripMenuItem.Click += new System.EventHandler(this.carregarXMLToolStripMenuItem_Click);
			// 
			// cancelamentoToolStripMenuItem
			// 
			this.cancelamentoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gerarXMLCancelamentoToolStripMenuItem,
            this.enviarCancelamentoToolStripMenuItem,
            this.imprimirExtratoCancelamentoToolStripMenuItem});
			this.cancelamentoToolStripMenuItem.Name = "cancelamentoToolStripMenuItem";
			this.cancelamentoToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
			this.cancelamentoToolStripMenuItem.Text = "Cancelamento";
			// 
			// gerarXMLCancelamentoToolStripMenuItem
			// 
			this.gerarXMLCancelamentoToolStripMenuItem.Name = "gerarXMLCancelamentoToolStripMenuItem";
			this.gerarXMLCancelamentoToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
			this.gerarXMLCancelamentoToolStripMenuItem.Text = "Gerar XML Cancelamento";
			// 
			// enviarCancelamentoToolStripMenuItem
			// 
			this.enviarCancelamentoToolStripMenuItem.Name = "enviarCancelamentoToolStripMenuItem";
			this.enviarCancelamentoToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
			this.enviarCancelamentoToolStripMenuItem.Text = "Enviar Cancelamento";
			// 
			// imprimirExtratoCancelamentoToolStripMenuItem
			// 
			this.imprimirExtratoCancelamentoToolStripMenuItem.Name = "imprimirExtratoCancelamentoToolStripMenuItem";
			this.imprimirExtratoCancelamentoToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
			this.imprimirExtratoCancelamentoToolStripMenuItem.Text = "Imprimir Extrato Cancelamento";
			// 
			// consultasToolStripMenuItem
			// 
			this.consultasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarStatusOperacionalToolStripMenuItem,
            this.consultarSATToolStripMenuItem,
            this.consultarNumeroDeSessãoToolStripMenuItem});
			this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
			this.consultasToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
			this.consultasToolStripMenuItem.Text = "Consultas";
			// 
			// consultarStatusOperacionalToolStripMenuItem
			// 
			this.consultarStatusOperacionalToolStripMenuItem.Name = "consultarStatusOperacionalToolStripMenuItem";
			this.consultarStatusOperacionalToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
			this.consultarStatusOperacionalToolStripMenuItem.Text = "Consultar Status Operacional";
			this.consultarStatusOperacionalToolStripMenuItem.Click += new System.EventHandler(this.consultarStatusOperacionalToolStripMenuItem_Click);
			// 
			// consultarSATToolStripMenuItem
			// 
			this.consultarSATToolStripMenuItem.Name = "consultarSATToolStripMenuItem";
			this.consultarSATToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
			this.consultarSATToolStripMenuItem.Text = "Consultar SAT";
			this.consultarSATToolStripMenuItem.Click += new System.EventHandler(this.consultarSATToolStripMenuItem_Click);
			// 
			// consultarNumeroDeSessãoToolStripMenuItem
			// 
			this.consultarNumeroDeSessãoToolStripMenuItem.Name = "consultarNumeroDeSessãoToolStripMenuItem";
			this.consultarNumeroDeSessãoToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
			this.consultarNumeroDeSessãoToolStripMenuItem.Text = "Consultar Numero de Sessão";
			// 
			// configuraçãoToolStripMenuItem
			// 
			this.configuraçãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.atualizarSATToolStripMenuItem,
            this.toolStripSeparator5,
            this.lerXMLConfiguraçãoDeInterfaceDeRedeToolStripMenuItem,
            this.gravarXmlDeInterfaceDeRedeToolStripMenuItem,
            this.toolStripSeparator4,
            this.configurarInterfaceDeRedeToolStripMenuItem});
			this.configuraçãoToolStripMenuItem.Name = "configuraçãoToolStripMenuItem";
			this.configuraçãoToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
			this.configuraçãoToolStripMenuItem.Text = "Configuração";
			// 
			// atualizarSATToolStripMenuItem
			// 
			this.atualizarSATToolStripMenuItem.Name = "atualizarSATToolStripMenuItem";
			this.atualizarSATToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
			this.atualizarSATToolStripMenuItem.Text = "Atualizar SAT";
			this.atualizarSATToolStripMenuItem.Click += new System.EventHandler(this.atualizarSATToolStripMenuItem_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(239, 6);
			// 
			// lerXMLConfiguraçãoDeInterfaceDeRedeToolStripMenuItem
			// 
			this.lerXMLConfiguraçãoDeInterfaceDeRedeToolStripMenuItem.Name = "lerXMLConfiguraçãoDeInterfaceDeRedeToolStripMenuItem";
			this.lerXMLConfiguraçãoDeInterfaceDeRedeToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
			this.lerXMLConfiguraçãoDeInterfaceDeRedeToolStripMenuItem.Text = "Ler Xml de Interface de Rede";
			// 
			// gravarXmlDeInterfaceDeRedeToolStripMenuItem
			// 
			this.gravarXmlDeInterfaceDeRedeToolStripMenuItem.Name = "gravarXmlDeInterfaceDeRedeToolStripMenuItem";
			this.gravarXmlDeInterfaceDeRedeToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
			this.gravarXmlDeInterfaceDeRedeToolStripMenuItem.Text = "Gravar Xml de Interface de Rede";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(239, 6);
			// 
			// configurarInterfaceDeRedeToolStripMenuItem
			// 
			this.configurarInterfaceDeRedeToolStripMenuItem.Name = "configurarInterfaceDeRedeToolStripMenuItem";
			this.configurarInterfaceDeRedeToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
			this.configurarInterfaceDeRedeToolStripMenuItem.Text = "Configurar Interface de Rede";
			// 
			// diversosToolStripMenuItem
			// 
			this.diversosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testeFimAFimToolStripMenuItem,
            this.extrairLogsToolStripMenuItem});
			this.diversosToolStripMenuItem.Name = "diversosToolStripMenuItem";
			this.diversosToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
			this.diversosToolStripMenuItem.Text = "Diversos";
			// 
			// testeFimAFimToolStripMenuItem
			// 
			this.testeFimAFimToolStripMenuItem.Name = "testeFimAFimToolStripMenuItem";
			this.testeFimAFimToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.testeFimAFimToolStripMenuItem.Text = "Teste Fim a Fim";
			// 
			// extrairLogsToolStripMenuItem
			// 
			this.extrairLogsToolStripMenuItem.Name = "extrairLogsToolStripMenuItem";
			this.extrairLogsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.extrairLogsToolStripMenuItem.Text = "Extrair Logs";
			// 
			// limparToolStripMenuItem
			// 
			this.limparToolStripMenuItem.Name = "limparToolStripMenuItem";
			this.limparToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
			this.limparToolStripMenuItem.Text = "Limpar";
			// 
			// tbcDados
			// 
			this.tbcDados.Controls.Add(this.tpgConfig);
			this.tbcDados.Controls.Add(this.tpgEmitente);
			this.tbcDados.Controls.Add(this.tpgSwHouse);
			this.tbcDados.Controls.Add(this.tpgRede);
			this.tbcDados.Controls.Add(this.tpgImpressao);
			this.tbcDados.Dock = System.Windows.Forms.DockStyle.Top;
			this.tbcDados.Location = new System.Drawing.Point(0, 24);
			this.tbcDados.Name = "tbcDados";
			this.tbcDados.SelectedIndex = 0;
			this.tbcDados.Size = new System.Drawing.Size(665, 185);
			this.tbcDados.TabIndex = 3;
			// 
			// tpgConfig
			// 
			this.tpgConfig.Controls.Add(this.groupBox2);
			this.tpgConfig.Controls.Add(this.label7);
			this.tpgConfig.Controls.Add(this.chkRemoveAcentos);
			this.tpgConfig.Controls.Add(this.nunVersaoCFe);
			this.tpgConfig.Controls.Add(this.chkFomartXML);
			this.tpgConfig.Controls.Add(this.groupBox1);
			this.tpgConfig.Controls.Add(this.label5);
			this.tpgConfig.Controls.Add(this.nunCaixa);
			this.tpgConfig.Controls.Add(this.txtCodUF);
			this.tpgConfig.Controls.Add(this.label4);
			this.tpgConfig.Controls.Add(this.txtAtivacao);
			this.tpgConfig.Controls.Add(this.label3);
			this.tpgConfig.Controls.Add(this.label2);
			this.tpgConfig.Controls.Add(this.cmbAmbiente);
			this.tpgConfig.Controls.Add(this.txtDllPath);
			this.tpgConfig.Controls.Add(this.label1);
			this.tpgConfig.Controls.Add(this.btnSelDll);
			this.tpgConfig.Location = new System.Drawing.Point(4, 22);
			this.tpgConfig.Name = "tpgConfig";
			this.tpgConfig.Padding = new System.Windows.Forms.Padding(3);
			this.tpgConfig.Size = new System.Drawing.Size(657, 159);
			this.tpgConfig.TabIndex = 0;
			this.tpgConfig.Text = "Dados CFe";
			this.tpgConfig.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.chkSepararData);
			this.groupBox2.Controls.Add(this.chkSepararCNPJ);
			this.groupBox2.Controls.Add(this.chkSaveCFeCanc);
			this.groupBox2.Controls.Add(this.chkSaveEnvio);
			this.groupBox2.Controls.Add(this.chkSaveCFe);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(427, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(222, 139);
			this.groupBox2.TabIndex = 15;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Salvar XMLs";
			// 
			// chkSepararData
			// 
			this.chkSepararData.AutoSize = true;
			this.chkSepararData.Checked = true;
			this.chkSepararData.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkSepararData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkSepararData.Location = new System.Drawing.Point(10, 111);
			this.chkSepararData.Name = "chkSepararData";
			this.chkSepararData.Size = new System.Drawing.Size(124, 17);
			this.chkSepararData.TabIndex = 4;
			this.chkSepararData.Text = "Separar Por Data";
			this.chkSepararData.UseVisualStyleBackColor = true;
			// 
			// chkSepararCNPJ
			// 
			this.chkSepararCNPJ.AutoSize = true;
			this.chkSepararCNPJ.Checked = true;
			this.chkSepararCNPJ.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkSepararCNPJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkSepararCNPJ.Location = new System.Drawing.Point(10, 89);
			this.chkSepararCNPJ.Name = "chkSepararCNPJ";
			this.chkSepararCNPJ.Size = new System.Drawing.Size(128, 17);
			this.chkSepararCNPJ.TabIndex = 3;
			this.chkSepararCNPJ.Text = "Separar Por CNPJ";
			this.chkSepararCNPJ.UseVisualStyleBackColor = true;
			// 
			// chkSaveCFeCanc
			// 
			this.chkSaveCFeCanc.AutoSize = true;
			this.chkSaveCFeCanc.Checked = true;
			this.chkSaveCFeCanc.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkSaveCFeCanc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkSaveCFeCanc.Location = new System.Drawing.Point(10, 67);
			this.chkSaveCFeCanc.Name = "chkSaveCFeCanc";
			this.chkSaveCFeCanc.Size = new System.Drawing.Size(117, 17);
			this.chkSaveCFeCanc.TabIndex = 2;
			this.chkSaveCFeCanc.Text = "Salvar CFeCanc";
			this.chkSaveCFeCanc.UseVisualStyleBackColor = true;
			// 
			// chkSaveEnvio
			// 
			this.chkSaveEnvio.AutoSize = true;
			this.chkSaveEnvio.Checked = true;
			this.chkSaveEnvio.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkSaveEnvio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkSaveEnvio.Location = new System.Drawing.Point(10, 44);
			this.chkSaveEnvio.Name = "chkSaveEnvio";
			this.chkSaveEnvio.Size = new System.Drawing.Size(98, 17);
			this.chkSaveEnvio.TabIndex = 1;
			this.chkSaveEnvio.Text = "Salvar Envio";
			this.chkSaveEnvio.UseVisualStyleBackColor = true;
			// 
			// chkSaveCFe
			// 
			this.chkSaveCFe.AutoSize = true;
			this.chkSaveCFe.Checked = true;
			this.chkSaveCFe.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkSaveCFe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkSaveCFe.Location = new System.Drawing.Point(10, 22);
			this.chkSaveCFe.Name = "chkSaveCFe";
			this.chkSaveCFe.Size = new System.Drawing.Size(88, 17);
			this.chkSaveCFe.TabIndex = 0;
			this.chkSaveCFe.Text = "Salvar CFe";
			this.chkSaveCFe.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(345, 114);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(46, 13);
			this.label7.TabIndex = 14;
			this.label7.Text = "Versão";
			// 
			// chkRemoveAcentos
			// 
			this.chkRemoveAcentos.AutoSize = true;
			this.chkRemoveAcentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkRemoveAcentos.Location = new System.Drawing.Point(203, 131);
			this.chkRemoveAcentos.Name = "chkRemoveAcentos";
			this.chkRemoveAcentos.Size = new System.Drawing.Size(126, 17);
			this.chkRemoveAcentos.TabIndex = 13;
			this.chkRemoveAcentos.Text = "Remover Acentos";
			this.chkRemoveAcentos.UseVisualStyleBackColor = true;
			// 
			// nunVersaoCFe
			// 
			this.nunVersaoCFe.DecimalPlaces = 2;
			this.nunVersaoCFe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.nunVersaoCFe.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.nunVersaoCFe.Location = new System.Drawing.Point(350, 131);
			this.nunVersaoCFe.Name = "nunVersaoCFe";
			this.nunVersaoCFe.Size = new System.Drawing.Size(71, 20);
			this.nunVersaoCFe.TabIndex = 13;
			this.nunVersaoCFe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nunVersaoCFe.Value = new decimal(new int[] {
            6,
            0,
            0,
            131072});
			// 
			// chkFomartXML
			// 
			this.chkFomartXML.AutoSize = true;
			this.chkFomartXML.Checked = true;
			this.chkFomartXML.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkFomartXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkFomartXML.Location = new System.Drawing.Point(203, 110);
			this.chkFomartXML.Name = "chkFomartXML";
			this.chkFomartXML.Size = new System.Drawing.Size(104, 17);
			this.chkFomartXML.TabIndex = 12;
			this.chkFomartXML.Text = "Formatar XML";
			this.chkFomartXML.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.chkUTF8);
			this.groupBox1.Controls.Add(this.nunPaginaCodigo);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(8, 94);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(189, 57);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Pagina de Codigo";
			// 
			// chkUTF8
			// 
			this.chkUTF8.AutoSize = true;
			this.chkUTF8.Location = new System.Drawing.Point(116, 25);
			this.chkUTF8.Name = "chkUTF8";
			this.chkUTF8.Size = new System.Drawing.Size(57, 17);
			this.chkUTF8.TabIndex = 12;
			this.chkUTF8.Text = "UTF8";
			this.chkUTF8.UseVisualStyleBackColor = true;
			// 
			// nunPaginaCodigo
			// 
			this.nunPaginaCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.nunPaginaCodigo.Location = new System.Drawing.Point(6, 25);
			this.nunPaginaCodigo.Name = "nunPaginaCodigo";
			this.nunPaginaCodigo.Size = new System.Drawing.Size(104, 20);
			this.nunPaginaCodigo.TabIndex = 11;
			this.nunPaginaCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(350, 52);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(71, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Num. Caixa";
			// 
			// nunCaixa
			// 
			this.nunCaixa.Location = new System.Drawing.Point(350, 69);
			this.nunCaixa.Name = "nunCaixa";
			this.nunCaixa.Size = new System.Drawing.Size(71, 20);
			this.nunCaixa.TabIndex = 9;
			this.nunCaixa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nunCaixa.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nunCaixa.ValueChanged += new System.EventHandler(this.nunCaixa_ValueChanged);
			// 
			// txtCodUF
			// 
			this.txtCodUF.Location = new System.Drawing.Point(281, 68);
			this.txtCodUF.Name = "txtCodUF";
			this.txtCodUF.Size = new System.Drawing.Size(63, 20);
			this.txtCodUF.TabIndex = 8;
			this.txtCodUF.Text = "35";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(278, 52);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(66, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Codigo UF";
			// 
			// txtAtivacao
			// 
			this.txtAtivacao.Location = new System.Drawing.Point(6, 68);
			this.txtAtivacao.Name = "txtAtivacao";
			this.txtAtivacao.Size = new System.Drawing.Size(269, 20);
			this.txtAtivacao.TabIndex = 6;
			this.txtAtivacao.Text = "123456";
			this.txtAtivacao.TextChanged += new System.EventHandler(this.txtAtivacao_TextChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(3, 52);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Codigo Ativação";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(310, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Ambiente";
			// 
			// cmbAmbiente
			// 
			this.cmbAmbiente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAmbiente.Items.AddRange(new object[] {
            "Homologação",
            "Produção"});
			this.cmbAmbiente.Location = new System.Drawing.Point(313, 28);
			this.cmbAmbiente.Name = "cmbAmbiente";
			this.cmbAmbiente.Size = new System.Drawing.Size(108, 21);
			this.cmbAmbiente.TabIndex = 3;
			this.cmbAmbiente.SelectedIndexChanged += new System.EventHandler(this.cmbAmbiente_SelectedIndexChanged);
			// 
			// txtDllPath
			// 
			this.txtDllPath.Location = new System.Drawing.Point(6, 29);
			this.txtDllPath.Name = "txtDllPath";
			this.txtDllPath.Size = new System.Drawing.Size(269, 20);
			this.txtDllPath.TabIndex = 2;
			this.txtDllPath.Text = "C:\\SAT\\SAT.dll";
			this.txtDllPath.TextChanged += new System.EventHandler(this.txtDllPath_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(3, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Nome Dll";
			// 
			// btnSelDll
			// 
			this.btnSelDll.Location = new System.Drawing.Point(281, 29);
			this.btnSelDll.Name = "btnSelDll";
			this.btnSelDll.Size = new System.Drawing.Size(26, 20);
			this.btnSelDll.TabIndex = 0;
			this.btnSelDll.Text = "...";
			this.btnSelDll.UseVisualStyleBackColor = true;
			this.btnSelDll.Click += new System.EventHandler(this.btnSelDll_Click);
			// 
			// tpgEmitente
			// 
			this.tpgEmitente.Controls.Add(this.txtEmitIM);
			this.tpgEmitente.Controls.Add(this.txtEmitIE);
			this.tpgEmitente.Controls.Add(this.label9);
			this.tpgEmitente.Controls.Add(this.txtEmitCNPJ);
			this.tpgEmitente.Controls.Add(this.label8);
			this.tpgEmitente.Controls.Add(this.label6);
			this.tpgEmitente.Location = new System.Drawing.Point(4, 22);
			this.tpgEmitente.Name = "tpgEmitente";
			this.tpgEmitente.Padding = new System.Windows.Forms.Padding(3);
			this.tpgEmitente.Size = new System.Drawing.Size(657, 159);
			this.tpgEmitente.TabIndex = 1;
			this.tpgEmitente.Text = "Dados Emitente";
			this.tpgEmitente.UseVisualStyleBackColor = true;
			// 
			// txtEmitIM
			// 
			this.txtEmitIM.Location = new System.Drawing.Point(441, 27);
			this.txtEmitIM.Name = "txtEmitIM";
			this.txtEmitIM.Size = new System.Drawing.Size(208, 20);
			this.txtEmitIM.TabIndex = 9;
			// 
			// txtEmitIE
			// 
			this.txtEmitIE.Location = new System.Drawing.Point(221, 27);
			this.txtEmitIE.Name = "txtEmitIE";
			this.txtEmitIE.Size = new System.Drawing.Size(214, 20);
			this.txtEmitIE.TabIndex = 8;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(218, 10);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(112, 13);
			this.label9.TabIndex = 7;
			this.label9.Text = "Inscrição Estadual";
			// 
			// txtEmitCNPJ
			// 
			this.txtEmitCNPJ.Location = new System.Drawing.Point(6, 27);
			this.txtEmitCNPJ.Name = "txtEmitCNPJ";
			this.txtEmitCNPJ.Size = new System.Drawing.Size(209, 20);
			this.txtEmitCNPJ.TabIndex = 6;
			this.txtEmitCNPJ.Text = "11111111111111";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(8, 10);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(38, 13);
			this.label8.TabIndex = 5;
			this.label8.Text = "CNPJ";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(438, 10);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(117, 13);
			this.label6.TabIndex = 3;
			this.label6.Text = "Inscrição Municipal";
			// 
			// tpgSwHouse
			// 
			this.tpgSwHouse.Location = new System.Drawing.Point(4, 22);
			this.tpgSwHouse.Name = "tpgSwHouse";
			this.tpgSwHouse.Padding = new System.Windows.Forms.Padding(3);
			this.tpgSwHouse.Size = new System.Drawing.Size(657, 159);
			this.tpgSwHouse.TabIndex = 2;
			this.tpgSwHouse.Text = "Dados Sw.House";
			this.tpgSwHouse.UseVisualStyleBackColor = true;
			// 
			// tpgRede
			// 
			this.tpgRede.Location = new System.Drawing.Point(4, 22);
			this.tpgRede.Name = "tpgRede";
			this.tpgRede.Padding = new System.Windows.Forms.Padding(3);
			this.tpgRede.Size = new System.Drawing.Size(657, 159);
			this.tpgRede.TabIndex = 3;
			this.tpgRede.Text = "Rede";
			this.tpgRede.UseVisualStyleBackColor = true;
			// 
			// tpgImpressao
			// 
			this.tpgImpressao.Location = new System.Drawing.Point(4, 22);
			this.tpgImpressao.Name = "tpgImpressao";
			this.tpgImpressao.Padding = new System.Windows.Forms.Padding(3);
			this.tpgImpressao.Size = new System.Drawing.Size(657, 159);
			this.tpgImpressao.TabIndex = 4;
			this.tpgImpressao.Text = "Impressão";
			this.tpgImpressao.UseVisualStyleBackColor = true;
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(665, 476);
			this.Controls.Add(this.tbcDados);
			this.Controls.Add(this.stsStatus);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.tbcXml);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FrmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "S@T Demo";
			this.Shown += new System.EventHandler(this.FrmMain_Shown);
			this.tpgLog.ResumeLayout(false);
			this.tbcXml.ResumeLayout(false);
			this.tpgXmlGerado.ResumeLayout(false);
			this.tpgXmlRecebido.ResumeLayout(false);
			this.tpgXmlCancelamento.ResumeLayout(false);
			this.tpgXmlRede.ResumeLayout(false);
			this.stsStatus.ResumeLayout(false);
			this.stsStatus.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tbcDados.ResumeLayout(false);
			this.tpgConfig.ResumeLayout(false);
			this.tpgConfig.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nunVersaoCFe)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nunPaginaCodigo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nunCaixa)).EndInit();
			this.tpgEmitente.ResumeLayout(false);
			this.tpgEmitente.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabPage tpgLog;
		private System.Windows.Forms.TabControl tbcXml;
		private System.Windows.Forms.RichTextBox rtbLog;
		private System.Windows.Forms.StatusStrip stsStatus;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem ativaçãoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ativarSATToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem comunicarCertificadoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem associarAssinaturaToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem bloquearSATToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem desbloquearSATToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem trocarCódigoDeAtivaçãoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem vendaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cancelamentoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem configuraçãoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem diversosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem testeFimAFimToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem extrairLogsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem limparToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem gerarVendaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem enviarVendaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem imprimirExtratoVendaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem imprimirExtratoVendaResumidoToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem carregarXMLToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel lblStatus;
		private System.Windows.Forms.ToolStripMenuItem gerarXMLCancelamentoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem enviarCancelamentoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem imprimirExtratoCancelamentoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem consultarStatusOperacionalToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem consultarSATToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem consultarNumeroDeSessãoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem atualizarSATToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem lerXMLConfiguraçãoDeInterfaceDeRedeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem gravarXmlDeInterfaceDeRedeToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem configurarInterfaceDeRedeToolStripMenuItem;
		private System.Windows.Forms.TabControl tbcDados;
		private System.Windows.Forms.TabPage tpgConfig;
		private System.Windows.Forms.TabPage tpgEmitente;
		private System.Windows.Forms.TabPage tpgSwHouse;
		private System.Windows.Forms.TabPage tpgRede;
		private System.Windows.Forms.TabPage tpgImpressao;
		private System.Windows.Forms.TextBox txtDllPath;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnSelDll;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbAmbiente;
		private System.Windows.Forms.TextBox txtCodUF;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtAtivacao;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown nunCaixa;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox chkUTF8;
		private System.Windows.Forms.NumericUpDown nunPaginaCodigo;
		private System.Windows.Forms.CheckBox chkRemoveAcentos;
		private System.Windows.Forms.CheckBox chkFomartXML;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.NumericUpDown nunVersaoCFe;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox chkSepararData;
		private System.Windows.Forms.CheckBox chkSepararCNPJ;
		private System.Windows.Forms.CheckBox chkSaveCFeCanc;
		private System.Windows.Forms.CheckBox chkSaveEnvio;
		private System.Windows.Forms.CheckBox chkSaveCFe;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtEmitCNPJ;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtEmitIM;
		private System.Windows.Forms.TextBox txtEmitIE;
		private System.Windows.Forms.TabPage tpgXmlGerado;
		private System.Windows.Forms.WebBrowser wbrXmlGerado;
		private System.Windows.Forms.TabPage tpgXmlRecebido;
		private System.Windows.Forms.WebBrowser wbrXmlRecebido;
		private System.Windows.Forms.TabPage tpgXmlCancelamento;
		private System.Windows.Forms.WebBrowser wbrXmlCancelamento;
		private System.Windows.Forms.TabPage tpgXmlRede;
		private System.Windows.Forms.WebBrowser wbrXmlRede;
	}
}


// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 03-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-05-2016
// ***********************************************************************
// <copyright file="ACBrSat.cs" company="ACBr.Net">
//     Copyright © ACBr.Net 2014 - 2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using ACBr.Net.Core;
using ACBr.Net.Core.Extensions;
using ACBr.Net.Core.Logging;
using ACBr.Net.DFe.Core.Serializer;
using ACBr.Net.Sat.Events;
using ACBr.Net.Sat.Interfaces;
using System;
using System.IO;
using System.Text;
using System.Xml;

namespace ACBr.Net.Sat
{
	public class ACBrSat : ACBrComponent
	{
		#region Fields

		internal readonly IInternalLogger Logger = LoggerProvider.LoggerFor(typeof(ACBrSat));

		private ISatLibrary sat;

		private string signAC;

		#endregion Fields

		#region Events

		public event EventHandler<ChaveEventArgs> OnGetCodigoDeAtivacao;

		public event EventHandler<ChaveEventArgs> OnGetSignAC;

		public event EventHandler<NumeroSessaoEventArgs> OnGetNumeroSessao;

		public event EventHandler<EventoDadosEventArgs> OnEnviarDadosVenda;

		public event EventHandler<EventoDadosEventArgs> OnCancelarUltimaVenda;

		public event EventHandler<EventoEventArgs> OnConsultaStatusOperacional;

		public event EventHandler<EventoEventArgs> OnExtrairLogs;

		public event EventHandler<EventoDadosEventArgs> OnConsultarNumeroSessao;

		public event EventHandler<SatMensagemEventArgs> OnMensagemSefaz;

		public event EventHandler<CalcPathEventEventArgs> OnCalcPath;

		#endregion Events

		#region Constructor

		public ACBrSat()
		{
			Configuracoes = new SatConfig();
			Arquivos = new CfgArquivos();
			Encoding = Encoding.ASCII;

			PathDll = @"C:\SAT\SAT.dll";
			CodigoAtivacao = "123456";
			signAC = string.Empty;
		}

		#endregion Constructor

		#region Properties

		public bool Ativo { get; private set; }

		public int Sessao { get; private set; }

		public SatConfig Configuracoes { get; private set; }

		public CfgArquivos Arquivos { get; private set; }

		public ModeloSat Modelo { get; set; }

		public string CodigoAtivacao { get; set; }

		public string SignAC
		{
			get
			{
				var e = new ChaveEventArgs { Chave = signAC };
				OnGetSignAC?.Invoke(this, e);

				signAC = e.Chave;
				return signAC;
			}
			set
			{
				signAC = value;
			}
		}

		public string PathDll { get; set; }

		public Encoding Encoding { get; set; }

		#endregion Properties

		#region Methods

		public void Ativar()
		{
			switch (Modelo)
			{
				case ModeloSat.Cdecl:
					sat = new SatCdecl(PathDll);
					break;

				case ModeloSat.StdCall:
					sat = new SatStdCall(PathDll);
					break;

				default:
					throw new NotImplementedException();
			}

			Ativo = true;
		}

		public void Desativar()
		{
			if (sat != null)
			{
				sat.Dispose();
				sat = null;
			}

			Ativo = false;
		}

		public CFe NewCFe()
		{
			var ret = new CFe();
			ret.InfCFe.Ide.CNPJ = Configuracoes.IdeCNPJ;
			ret.InfCFe.Ide.TpAmb = Configuracoes.IdeTpAmb;
			ret.InfCFe.Ide.NumeroCaixa = Configuracoes.IdeNumeroCaixa;
			ret.InfCFe.Ide.SignAC = SignAC;
			ret.InfCFe.Emit.CNPJ = Configuracoes.EmitCNPJ;
			ret.InfCFe.Emit.IM = Configuracoes.EmitIM;
			ret.InfCFe.Emit.IE = Configuracoes.EmitIE;
			ret.InfCFe.Emit.CRegTribISSQN = Configuracoes.EmitCRegTribISSQN;
			ret.InfCFe.Emit.IndRatISSQN = Configuracoes.EmitIndRatISSQN;
			ret.InfCFe.VersaoDadosEnt = Configuracoes.InfCFeVersaoDadosEnt;

			return ret;
		}

		public SatResposta AssociarAssinatura(string cnpj, string assinaturaCnpj)
		{
			IniciaComando($"AssociarAssinatura({cnpj}, {assinaturaCnpj})");
			var ret = sat.AssociarAssinatura(Sessao, CodigoAtivacao, cnpj, assinaturaCnpj);
			return FinalizaComando<SatResposta>(ret);
		}

		public SatResposta AtivarSAT(int subComando, string cnpj, int uf)
		{
			IniciaComando($"AtivarSAT({subComando}, {cnpj}, {uf})");
			var ret = sat.AtivarSAT(Sessao, subComando, CodigoAtivacao, cnpj.OnlyNumbers(), uf);
			return FinalizaComando<SatResposta>(ret);
		}

		public SatResposta AtualizarSoftwareSAT()
		{
			IniciaComando("AtualizarSoftwareSAT()");
			var ret = sat.AtualizarSoftwareSAT(Sessao, CodigoAtivacao);
			return FinalizaComando<SatResposta>(ret);
		}

		public SatResposta BloquearSAT()
		{
			IniciaComando("BloquearSAT()");
			var ret = sat.BloquearSAT(Sessao, CodigoAtivacao);
			return FinalizaComando<SatResposta>(ret);
		}

		public CancelamentoSatResposta CancelarUltimaVenda(string chave, CFeCanc cfeCanc)
		{
			var dadosCancelamento = GetXml(cfeCanc);

			IniciaComando($"CancelarUltimaVenda({chave}, {dadosCancelamento})");
			var ret = sat.CancelarUltimaVenda(Sessao, CodigoAtivacao, chave, dadosCancelamento);
			var resposta = FinalizaComando<CancelamentoSatResposta>(ret);

			if (Arquivos.SalvarCFe)
			{
				var path = Path.Combine(Arquivos.PastaCFeVenda, resposta.Cancelamento.Emit.CNPJ, $"{resposta.Cancelamento.Ide.DEmi:yyyyMM}");
				var e = new CalcPathEventEventArgs
				{
					CNPJ = resposta.Cancelamento.Emit.CNPJ,
					Data = resposta.Cancelamento.Ide.DEmi,
					Path = path
				};

				OnCalcPath?.Invoke(this, e);

				if (!Directory.Exists(e.Path))
				{
					Directory.CreateDirectory(e.Path);
				}

				var nomeArquivo = $"{Arquivos.PrefixoArqCFe}{resposta.Cancelamento.InfCFe.Id}";
				var fullPath = Path.Combine(e.Path, nomeArquivo);
				SalvarCFeCanc(resposta.Cancelamento, fullPath);
			}

			return resposta;
		}

		public SatResposta ComunicarCertificadoIcpBrasil(string certificado)
		{
			IniciaComando($"ComunicarCertificadoICPBRASIL({certificado})");
			var ret = sat.ComunicarCertificadoIcpBrasil(Sessao, CodigoAtivacao, certificado);
			return FinalizaComando<SatResposta>(ret);
		}

		public SatResposta ConfigurarInterfaceDeRede(string dadosConfiguracao)
		{
			IniciaComando($"ConfigurarInterfaceDeRede({dadosConfiguracao})");
			var ret = sat.ConfigurarInterfaceDeRede(Sessao, CodigoAtivacao, dadosConfiguracao);
			return FinalizaComando<SatResposta>(ret);
		}

		public SatResposta ConsultarNumeroSessao(int numeroSessao)
		{
			IniciaComando($"ConsultarNumeroSessao({numeroSessao})");
			var ret = sat.ConsultarNumeroSessao(Sessao, CodigoAtivacao, numeroSessao);
			return FinalizaComando<SatResposta>(ret);
		}

		public SatResposta ConsultarSAT()
		{
			IniciaComando($"ConsultarSAT()");
			var ret = sat.ConsultarSAT(Sessao);
			return FinalizaComando<SatResposta>(ret);
		}

		public SatResposta ConsultarStatusOperacional()
		{
			IniciaComando("ConsultarStatusOperacional()");
			var ret = sat.ConsultarStatusOperacional(Sessao, CodigoAtivacao);
			return FinalizaComando<SatResposta>(ret);
		}

		public SatResposta DesbloquearSAT()
		{
			IniciaComando($"DesbloquearSAT()");
			var ret = sat.DesbloquearSAT(Sessao, CodigoAtivacao);
			return FinalizaComando<SatResposta>(ret);
		}

		public VendaSatResposta EnviarDadosVenda(CFe cfe)
		{
			var dadosVenda = GetXml(cfe);

			IniciaComando($"EnviarDadosVenda({dadosVenda})");

			if (Arquivos.SalvarEnvio)
			{
				var envioPath = Path.Combine(Arquivos.PastaEnvio, Arquivos.PrefixoArqCFe, $"{DateTime.Now:yyyyMMddHHmmss}-{Sessao.ZeroFill(6)}-env.xml");
				SalvarCFe(cfe, envioPath);
			}

			var e = new EventoDadosEventArgs { DadosVenda = dadosVenda };
			OnEnviarDadosVenda?.Invoke(this, e);

			var ret = sat.EnviarDadosVenda(Sessao, CodigoAtivacao, e.DadosVenda);
			var resposta = FinalizaComando<VendaSatResposta>(ret);

			if (Arquivos.SalvarCFe)
			{
				var path = Path.Combine(Arquivos.PastaCFeVenda, resposta.Venda.InfCFe.Emit.CNPJ, $"{resposta.Venda.InfCFe.Ide.DEmi:yyyyMM}");

				var calcPathEventEventArgs = new CalcPathEventEventArgs
				{
					CNPJ = resposta.Venda.InfCFe.Emit.CNPJ,
					Data = resposta.Venda.InfCFe.Ide.DEmi,
					Path = path
				};

				OnCalcPath?.Invoke(this, calcPathEventEventArgs);

				if (!Directory.Exists(calcPathEventEventArgs.Path)) Directory.CreateDirectory(calcPathEventEventArgs.Path);

				var nomeArquivo = $"{Arquivos.PrefixoArqCFe}{resposta.Venda.InfCFe.Id}";
				var fullPath = Path.Combine(calcPathEventEventArgs.Path, nomeArquivo);
				SalvarCFe(resposta.Venda, fullPath);
			}

			return resposta;
		}

		public SatResposta ExtrairLogs()
		{
			IniciaComando($"ExtrairLogs()");
			var ret = sat.ExtrairLogs(Sessao, CodigoAtivacao);
			return FinalizaComando<SatResposta>(ret);
		}

		public SatResposta TesteFimAFim(CFe cfe)
		{
			var dadosVenda = GetXml(cfe);
			IniciaComando($"TesteFimAFim({dadosVenda})");

			var ret = sat.TesteFimAFim(Sessao, CodigoAtivacao, dadosVenda);
			return FinalizaComando<SatResposta>(ret);
		}

		public SatResposta TrocarCodigoDeAtivacao(int opcao, string novoCodigo, string confNovoCodigo)
		{
			IniciaComando($"TrocarCodigoDeAtivacao({opcao}, {novoCodigo}, {confNovoCodigo})");
			var ret = sat.TrocarCodigoDeAtivacao(Sessao, CodigoAtivacao, opcao, novoCodigo, confNovoCodigo);
			return FinalizaComando<SatResposta>(ret);
		}

		private int GerarNumeroSessao()
		{
			if (OnGetNumeroSessao == null)
			{
				Sessao = StaticRandom.Next(1, 999999);
				return Sessao;
			}
			else
			{
				var e = new NumeroSessaoEventArgs(Sessao);
				OnGetNumeroSessao(this, e);

				Sessao = e.Sessao;
				return Sessao;
			}
		}

		private void IniciaComando(string comandoLog)
		{
			GerarNumeroSessao();
			Logger.Info($"NumeroSessao: {Sessao} - Comando: {comandoLog}");
		}

		private T FinalizaComando<T>(string resposta) where T : SatResposta
		{
			resposta = Encoding.GetString(Encoding.ASCII.GetBytes(resposta));
			Logger.Info($"NumeroSessao: {Sessao} - Resposta: {resposta}");
			var resp = (T)Activator.CreateInstance(typeof(T), resposta);

			if (OnMensagemSefaz == null) return resp;

			if (resp.CodigoSEFAZ > 0 && !resp.MensagemSEFAZ.IsEmpty())
			{
				var e = new SatMensagemEventArgs(resp.CodigoSEFAZ, resp.MensagemSEFAZ);
				OnMensagemSefaz?.Invoke(this, e);
			}

			return resp;
		}

		private DFeSerializer<T> GetSerializer<T>() where T : class
		{
			var serializer = DFeSerializer.CreateSerializer<T>();
			serializer.Options.RemoverAcentos = Configuracoes.RemoverAcentos;
			serializer.Options.FormatarXml = Configuracoes.FormatarXml;
			return serializer;
		}

		private bool SalvarCFe(CFe cfe, string path)
		{
			var serializer = GetSerializer<CFe>();
			return serializer.Serialize(cfe, path);
		}

		private bool SalvarCFe(CFe cfe, Stream stream)
		{
			var serializer = GetSerializer<CFe>();
			return serializer.Serialize(cfe, stream);
		}

		public string GetXml(CFe cfe)
		{
			using (var stream = new MemoryStream())
			{
				SalvarCFe(cfe, stream);

				var xml = new XmlDocument();
				xml.Load(stream);

				return xml.AsString(true, true, Encoding.UTF8);
			}
		}

		private bool SalvarCFeCanc(CFeCanc cfeCanc, string path)
		{
			var serializer = GetSerializer<CFeCanc>();
			return serializer.Serialize(cfeCanc, path);
		}

		private bool SalvarCFeCanc(CFeCanc cfeCanc, Stream stream)
		{
			var serializer = GetSerializer<CFeCanc>();
			return serializer.Serialize(cfeCanc, stream);
		}

		public string GetXml(CFeCanc cfeCanc)
		{
			using (var stream = new MemoryStream())
			{
				SalvarCFeCanc(cfeCanc, stream);

				var xml = new XmlDocument();
				xml.Load(stream);

				return xml.AsString(true, true, Encoding.UTF8);
			}
		}

		protected override void OnInitialize()
		{
		}

		protected override void OnDisposing()
		{
			if (Ativo)
			{
				Desativar();
			}
		}

		#endregion Methods
	}
}
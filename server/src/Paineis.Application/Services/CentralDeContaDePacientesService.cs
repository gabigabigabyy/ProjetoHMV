using HMV.Core.DataAccess;
using NHibernate;
using NHibernate.Transform;
using Paineis.Application.DTO;
using Paineis.Application.Interfaces;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.Services
{
    public class CentralDeContaDePacientesService : ICentralDeContaDePacientesService
    {
        public IList<ContaEmProcessamentoDTO> GetContasEmProcessamento()
        {
            StringBuilder qry = LocaisContasEmProcessamento();
            IList<ContaEmProcessamentoDTO> lstContas = executaQuery(qry);

            ContaEmProcessamentoDTO totalDTO = new ContaEmProcessamentoDTO { Local = "TOTAL" };

            foreach (var totalConta in lstContas)
            {
                totalDTO.Valor += totalConta.Valor;
                totalDTO.Qtd += totalConta.Qtd;
            }

            lstContas.Add(totalDTO);

            return lstContas;
        }
        public IEnumerable<DetalhesContasEmProcessamentoDTO> GetDetalhesContasEmProcessamento(string nomeDaConta)
        {
            IList<DetalhesContasEmProcessamentoDTO> lstDetalhesConta = GetDetalheConta(nomeDaConta);

            DetalhesContasEmProcessamentoDTO total = new DetalhesContasEmProcessamentoDTO { Convenio = "TOTAL", };

            foreach (var contaDetalhe in lstDetalhesConta)
            {
                total.Valor += contaDetalhe.Valor;
                total.Quantidade += contaDetalhe.Quantidade;
            }
            lstDetalhesConta.Add(total);
            return lstDetalhesConta;
        }


        public IList<ContaEmProcessamentoDTO> GetDemaisOrigens()
        {
            StringBuilder qry = LocaisDemaisOrigens();
            IList<ContaEmProcessamentoDTO> lstDemaisOrigens = executaQuery(qry);

            ContaEmProcessamentoDTO totalDTO = new ContaEmProcessamentoDTO { Local = "TOTAL" };

            foreach (var total in lstDemaisOrigens)
            {
                totalDTO.Valor += total.Valor;
                totalDTO.Qtd += total.Qtd;
            }

            lstDemaisOrigens.Add(totalDTO);
            return lstDemaisOrigens;
        }

        public IEnumerable<DetalhesContasEmProcessamentoDTO> GetDetalhesContasDemaisOrigens(string nomeDaConta)
        {
            IList<DetalhesContasEmProcessamentoDTO> lstDemaisOrigens = GetDetalheConta(nomeDaConta);

            if (nomeDaConta.Equals("PENDÊNCIAS UNIDADES DE INTERNAÇÃO"))
            {
                lstDemaisOrigens = lstDemaisOrigens.OrderBy(x => x.UnidadeInternacao).ThenByDescending(x => x.Valor).ToList();
            }

            DetalhesContasEmProcessamentoDTO total = new DetalhesContasEmProcessamentoDTO { Convenio = "TOTAL", };
            foreach (var contaDetalhe in lstDemaisOrigens)
            {
                total.Valor += contaDetalhe.Valor;
                total.Quantidade += contaDetalhe.Quantidade;
            }
            lstDemaisOrigens.Add(total);
            return lstDemaisOrigens;
        }


        public List<DetalhesContasEmProcessamentoDTO> GetDetalhesTotalContasProcessamento()
        {
            string total = "TOTAL";

            List<DetalhesContasEmProcessamentoDTO> contasTotalList = new List<DetalhesContasEmProcessamentoDTO>();

            IList<ContaEmProcessamentoDTO> lstContasTotal = GetContasEmProcessamento();

            IList<ContaEmProcessamentoDTO> lstContas = lstContasTotal.Where(x => x.Local != total).ToList();
            ContaEmProcessamentoDTO totaisSomados = lstContasTotal.Where(x => x.Local == total).FirstOrDefault();

            DetalhesContasEmProcessamentoDTO totalDTO = new DetalhesContasEmProcessamentoDTO();
            totalDTO.Convenio = "TOTAL";
            totalDTO.Valor = totaisSomados.Valor;
            totalDTO.Quantidade = totaisSomados.Qtd;

            foreach (var conta in lstContas)
            {
                IEnumerable<DetalhesContasEmProcessamentoDTO> contasDetalhe = GetDetalhesContasEmProcessamento(conta.Local);
                IEnumerable<DetalhesContasEmProcessamentoDTO> _conta = contasDetalhe.Where(x => x.Local != total && x.Convenio != total);
                contasTotalList.AddRange(_conta);
            }

            contasTotalList.Add(totalDTO);
            return contasTotalList;
        }
        public List<DetalhesContasEmProcessamentoDTO> GetDetalhesTotalDemaisOrigens()
        {
            string total = "TOTAL";

            List<DetalhesContasEmProcessamentoDTO> contasTotalList = new List<DetalhesContasEmProcessamentoDTO>();

            IList<ContaEmProcessamentoDTO> lstTotal = GetDemaisOrigens();

            IList<ContaEmProcessamentoDTO> lstContas = lstTotal.Where(x => x.Local != total).ToList();
            ContaEmProcessamentoDTO totaisSomados = lstTotal.Where(x => x.Local == total).FirstOrDefault();

            DetalhesContasEmProcessamentoDTO totalDTO = new DetalhesContasEmProcessamentoDTO();
            totalDTO.Convenio = "TOTAL";
            totalDTO.Valor = totaisSomados.Valor;
            totalDTO.Quantidade = totaisSomados.Qtd;

            foreach (var conta in lstContas)
            {
                IEnumerable<DetalhesContasEmProcessamentoDTO> contasDetalhe = GetDetalhesContasDemaisOrigens(conta.Local);
                IEnumerable<DetalhesContasEmProcessamentoDTO> _conta = contasDetalhe.Where(x => x.Local != total && x.Convenio != total);
                contasTotalList.AddRange(_conta);
            }

            contasTotalList.Add(totalDTO);
            return contasTotalList;
        }
        public List<DetalhesContasEmProcessamentoDTO> GetDetalhesTotal()
        {
            string total = "TOTAL";

            IEnumerable<DetalhesContasEmProcessamentoDTO> detalheTotalContasProcessamento = GetDetalhesTotalContasProcessamento();
            IEnumerable<DetalhesContasEmProcessamentoDTO> contasProcessamento = detalheTotalContasProcessamento.Where(x => x.Local != total && x.Convenio != total);
            DetalhesContasEmProcessamentoDTO totalContasProcessamento = detalheTotalContasProcessamento.Where(x => x.Convenio == total).FirstOrDefault();

            IEnumerable<DetalhesContasEmProcessamentoDTO> detalheTotalDemaisOrigens = GetDetalhesTotalDemaisOrigens();
            IEnumerable<DetalhesContasEmProcessamentoDTO> demaisOrigens = detalheTotalDemaisOrigens.Where(x => x.Local != total && x.Convenio != total);
            DetalhesContasEmProcessamentoDTO totalDemaisOrigens = detalheTotalContasProcessamento.Where(x => x.Convenio == total).FirstOrDefault();

            DetalhesContasEmProcessamentoDTO totalDTO = new DetalhesContasEmProcessamentoDTO();
            totalDTO.Convenio = "TOTAL";
            totalDTO.Valor = totalContasProcessamento.Valor + totalDemaisOrigens.Valor;
            totalDTO.Quantidade = totalContasProcessamento.Quantidade + totalDemaisOrigens.Quantidade;

            List<DetalhesContasEmProcessamentoDTO> detalhesTotal = new List<DetalhesContasEmProcessamentoDTO>();
            detalhesTotal.AddRange(contasProcessamento);
            detalhesTotal.AddRange(demaisOrigens);
            detalhesTotal.Add(totalDTO);

            return detalhesTotal;
        }

        public IEnumerable<ContaEmProcessamentoDTO> GetTotalDeContas()
        {
            StringBuilder qry = new StringBuilder();
            qry.AppendFormat(@"SELECT  'TOTAL' as Local
                                       , SUM(F.VL_TOTAL_CONTA)      Valor
                                       , Count (f.CD_REG_FAT)       Qtd
                                FROM   DBAMV.REG_FAT                F
                                      ,DBAMV.CONVENIO               CONVENIO
                                      ,DBAMV.ATENDIME               A
                                      ,DBAMV.PACIENTE               p
                                      ,DBAHMV.view_local_conta vi
                                WHERE
                                         vi.cd_reg_fat            = f.cd_reg_fat
                                  AND    F.CD_CONVENIO            = CONVENIO.CD_CONVENIO
                                  AND    F.CD_ATENDIMENTO         = A.CD_ATENDIMENTO
                                  AND    A.CD_PACIENTE            = P.CD_PACIENTE
                                  AND    F.VL_TOTAL_CONTA         <> 0
                                  AND    F.VL_TOTAL_CONTA         Is Not NULL
                                  AND    F.DT_FINAL               Is Not Null
                                  AND    F.DT_FECHAMENTO          Is NULL
                                  AND    F.cd_remessa             IS NULL
                                  AND    A.TP_ATENDIMENTO         = 'I'");

            IQuery query = ObjectFactory.GetInstance<IUnitOfWork>().CurrentSession.CreateSQLQuery(qry.ToString())
                  .AddScalar("Local", NHibernateUtil.String)
                  .AddScalar("Valor", NHibernateUtil.Decimal)
                  .AddScalar("Qtd", NHibernateUtil.Int32);

            query.SetResultTransformer(Transformers.AliasToBean(typeof(ContaEmProcessamentoDTO)));
            return query.List<ContaEmProcessamentoDTO>();
        }

        private StringBuilder SqlContas(StringBuilder str)
        {
            StringBuilder qry = new StringBuilder();

            qry.AppendFormat(@"SELECT Tipo,
                                      Local, 
                                      Valor, 
                                      Qtd, 
                                      round(nvl(MediaDias, 0), 4) MediaDias, 
                                      Hint 
                                 FROM (SELECT 1                               AS  Tipo,
                                             vi.local_conta                   AS  LOCAL,
                                             Sum(F.vl_total_conta)            AS  Valor,
                                             Count(f.cd_reg_fat)              AS  Qtd,
                                             Sum(To_Number(Trim(SubStr(dbahmv.pkg_hmv_fnfi.fnc_hmv2620_dados_mov_doc2(F.cd_reg_fat,NULL), 61, 30))) ) / Count(f.cd_reg_fat)          AS MediaDias,
                                             'Posição das Contas por Etapas (Mov Doc). A portlet (P.1050) mostra o resumo do valor total das contas em relação as etapas (mov doc)'  AS hint
                                        FROM DBAMV.REG_FAT                F,
                                             DBAMV.CONVENIO               CONVENIO,
                                             DBAMV.ATENDIME               A,
                                             DBAMV.PACIENTE               p,
                                             DBAHMV.view_local_conta      vi
                                       WHERE vi.cd_reg_fat        =    f.cd_reg_fat            AND
                                             F.CD_CONVENIO        =    CONVENIO.CD_CONVENIO    AND
                                             F.CD_ATENDIMENTO     =    A.CD_ATENDIMENTO        AND
                                             A.CD_PACIENTE        =    P.CD_PACIENTE           AND
                                             F.VL_TOTAL_CONTA     <>   0                       AND
                                             F.VL_TOTAL_CONTA     IS   NOT NULL                AND
                                             F.DT_FINAL           IS   NOT NULL                AND
                                             F.DT_FECHAMENTO      IS   NULL                    AND
                                             F.cd_remessa         IS   NULL                    AND
                                             A.TP_ATENDIMENTO     =    'I'                     AND
                                             ( {0} )
                                       GROUP BY vi.local_conta)
                                ORDER BY Local", str);
            return qry;
        }
        private StringBuilder LocaisContasEmProcessamento()
        {
            StringBuilder qry = new StringBuilder();

            qry.AppendFormat(@"vi.local_conta  LIKE  'AUTORIZA%%ES (CENTRAL DE CONTAS)%'                OR
                               vi.local_conta  LIKE  'AUTORIZA%%ES CIR%RGICAS (CENTRAL DE CONTAS)%%'    OR
                               vi.local_conta  LIKE  'CONFERENCIA ADMINISTRATIVA (CENTRAL DE CONTAS)%'  OR
                               vi.local_conta  LIKE  'CONFER%NCIA T%CNICA (CENTRAL DE CONTAS)%'         OR
                               vi.local_conta  LIKE  'PENDENCIAS CIRURGICAS (CENTRAL DE CONTAS)%'       OR
                               vi.local_conta  LIKE  'PREPARA%%O (CENTRAL DE CONTAS)%'");
            return SqlContas(qry);
        }
        private StringBuilder LocaisDemaisOrigens()
        {
            StringBuilder qry = new StringBuilder();
            qry.AppendFormat(@" vi.local_conta  LIKE  'AJUSTES P%S-FECHAMENTO (CENTRAL DE CONTAS)%'        OR
                                vi.local_conta  LIKE  'AMBULAT%RIOS (CENTRAL DE CONTAS)%'                  OR
                                vi.local_conta  LIKE  'ARQUIVO - PARTICULAR%'                              OR
                                vi.local_conta  LIKE  'AUTORIZA%O P%S (FECHAMENTO BLOCO B)%'               OR
                                vi.local_conta  LIKE  'AUDITORIA HMV (PENDENCIAS TI - MV SOUL)%'           OR
                                vi.local_conta  LIKE  'CENTRO OBST%TRICO%'                                 OR
                                vi.local_conta  LIKE  'ENDOSCOPIA%'                                        OR
                                vi.local_conta  LIKE  'EMERGENCIA - INTERNACAO%'                           OR
                                vi.local_conta  LIKE  'FECHAMENTO BLOCO B%'                                OR
                                vi.local_conta  LIKE  'N%CLEO DE AUDITORIA CC%'                            OR
                                vi.local_conta  LIKE  'OPME P%S%'                                          OR
                                vi.local_conta  LIKE  'PEND%NCIAS COMERCIAIS (CENTRAL DE CONTAS)%'         OR
                                vi.local_conta  LIKE  'PEND%NCIAS CTIA%'                                   OR
                                vi.local_conta  LIKE  'PEND%NCIAS HONOR%RIOS M%DICOS (CENTRAL DE GUIAS)%'  OR
                                vi.local_conta  LIKE  'PEND%NCIAS LAB PATOLOGIA%'                          OR
                                vi.local_conta  LIKE  'PEND%NCIAS NOTAS FISCAIS OPME (COMPRAS)%'           OR
                                vi.local_conta  LIKE  'PEND%NCIAS UNIDADES DE INTERNA%%O%'                 OR
                                vi.local_conta  LIKE  'QUIMIOTERAPIA (ONCOLOGIA)%'                         OR
                                vi.local_conta  LIKE  'SAP%'");
            return SqlContas(qry);
        }
        private IList<ContaEmProcessamentoDTO> executaQuery(StringBuilder qry)
        {
            IQuery query = ObjectFactory.GetInstance<IUnitOfWork>().CurrentSession.CreateSQLQuery(qry.ToString())
                  .AddScalar("Tipo", NHibernateUtil.Int32)
                  .AddScalar("Local", NHibernateUtil.String)
                //.AddScalar("CdLocal", NHibernateUtil.Int32)
                  .AddScalar("Valor", NHibernateUtil.Decimal)
                  .AddScalar("Qtd", NHibernateUtil.Int32)
                  .AddScalar("MediaDias", NHibernateUtil.Decimal)
                  .AddScalar("Hint", NHibernateUtil.String);

            query.SetResultTransformer(Transformers.AliasToBean(typeof(ContaEmProcessamentoDTO)));
            return query.List<ContaEmProcessamentoDTO>();
        }
        private IList<DetalhesContasEmProcessamentoDTO> GetDetalheConta(string nomeDaConta)
        {
            StringBuilder qry = new StringBuilder();

            qry.AppendFormat(@"SELECT tipo, 
                                      unidadeinternacao, 
                                      atendimento, 
                                      paciente, 
                                      conta, 
                                      nroretornos, 
                                      diaslocalatual, 
                                      nomeusuario, 
                                      datainicial, 
                                      datafinal, 
                                      dataalta, 
                                      qtddiasfim, 
                                      convenio, 
                                      cdconvenio, 
                                      local, 
                                      valor, 
                                      status, 
                                      quantidade, 
                                      hint,
                                      avisoCirurgia
                                 FROM (SELECT 1 AS Tipo, 
                                              Nvl(UI.ds_unid_int, 'Não apurado') AS UnidadeInternacao, 
                                              F.cd_atendimento AS Atendimento, 
                                              p.nm_paciente AS Paciente, 
                                              F.cd_reg_fat AS Conta, 
                                              (SELECT Count(DISTINCT d2.seq_ras_documento) 
                                                 FROM dbahmv.ras_documento_conta dc2, 
                                                      dbahmv.ras_documento d2 
                                                WHERE dc2.seq_ras_documento = d2.seq_ras_documento 
                                                  AND dc2.cd_reg_fat = F.cd_reg_fat 
                                                  AND dc2.cd_atendimento = F.cd_atendimento 
                                                  AND d2.cod_localizacao_destino = vi.cod_localizacao 
                                                  AND d2.data_exclusao IS NULL) AS NroRetornos, 
                                              To_number(Trim(Substr(dbahmv.pkg_hmv_fnfi.Fnc_hmv2620_dados_mov_doc2(F.cd_reg_fat,NULL),61,30))) AS DiasLocalAtual, 
                                              Trim(Substr(dbahmv.pkg_hmv_fnfi.Fnc_hmv2620_dados_mov_doc2(F.cd_reg_fat,NULL),221,30)) AS NomeUsuario,
                                              F.dt_inicio AS DataInicial, 
                                              F.dt_final AS DataFinal, 
                                              A.dt_alta AS DataAlta, 
                                              CASE WHEN ( SYSDATE - F.dt_final ) > 50 THEN To_char(To_char(( SYSDATE - F.dt_final), '9,999')) 
                                                                                      ELSE To_char(To_char(( SYSDATE - F.dt_final ), '9,999')) END AS QtdDiasFim, 
                                              CASE WHEN F.cd_convenio = 916 OR F.cd_convenio = 241 THEN /*916 '%AMIL%'  241 '%UNIMED INTERCAMBIO NACIONAL%'*/ To_char(convenio.nm_convenio) 
                                                                                                   ELSE To_char(convenio.nm_convenio) END AS Convenio, 
                                              F.cd_convenio AS CdConvenio, 
                                              vi.local_conta AS Local, 
                                              CASE WHEN SUM(F.vl_total_conta) > 50000 THEN To_char(Replace(Replace(Replace(To_char(SUM(F.vl_total_conta), '999,999,999,999.99'),',', 'x'),'.', ','), 'x', '.'))
                                                                                      ELSE To_char(Replace(Replace(Replace(To_char(SUM(F.vl_total_conta),'999,999,999,999.99'),',', 'x'),'.', ','), 'x', '.')) END AS Valor, 
                                              CASE WHEN ( SYSDATE - Trunc(F.dt_final) ) IS NULL THEN 'verde'
                                                   WHEN Trim(vi.local_conta) = 'PENDÊNCIAS UNIDADES DE INTERNAÇÃO' THEN CASE WHEN ( SYSDATE - Trunc(F.dt_final) ) < 3 THEN 'verde' ELSE 'vermelho' end                                                    
                                                   WHEN ( SYSDATE - Trunc(F.dt_final) ) < 50 THEN 'verde' 
                                                   ELSE 'vermelho' END AS Status,

                                              '1' AS Quantidade, 
                                              'Contas por Etapas (Mov Doc)(P.1048). A portlet (P.1048) mostra o detalhamento das contas em relação aos prazos de faturamento por etapa(mov doc). A sinaleira verde mostra as contas menores que 15 dias da DATA DE FIM DE PERÍODO. A sinaleira amarela mostra as contas entre 15 e 40 dias e a sinaleira vermelha - por sua vez - mostra as contas que passaram de 40 dias da DATA DE FIM DE PERÍODO.' AS Hint,
                                              (SELECT LISTAGG(cd_aviso_cirurgia, ', ') WITHIN GROUP (ORDER BY cd_aviso_cirurgia DESC)  
                                                 FROM AVISO_CIRURGIA 
                                                WHERE CD_ATENDIMENTO = F.cd_atendimento
                                                  AND tp_situacao = 'R' 
                                                  AND ds_motivo_cancelamento IS NULL
                                                  AND dt_realizacao BETWEEN F.dt_inicio AND F.dt_final) AS avisoCirurgia
                                         FROM dbamv.reg_fat F, 
                                              dbamv.convenio CONVENIO, 
                                              dbamv.atendime A, 
                                              dbamv.paciente p, 
                                              dbahmv.view_local_conta vi, 
                                              dbamv.leito L, 
                                              dbamv.unid_int UI
                                        WHERE F.cd_convenio = convenio.cd_convenio 
                                          AND F.cd_atendimento = A.cd_atendimento 
                                          AND A.cd_paciente = P.cd_paciente 
                                          AND vi.cd_reg_fat(+) = f.cd_reg_fat 
                                          AND A.cd_leito = L.cd_leito(+) 
                                          AND L.cd_unid_int = UI.cd_unid_int(+) 
                                          AND F.vl_total_conta IS NOT NULL 
                                          AND F.vl_total_conta <> 0 
                                          AND F.dt_final IS NOT NULL 
                                          AND F.dt_fechamento IS NULL 
                                          AND F.cd_remessa IS NULL
                                          AND Trim(vi.local_conta) = Trim('{0}') 
                                        GROUP BY Nvl(UI.ds_unid_int, 'Não apurado'), 
                                              F.cd_atendimento, 
                                              p.nm_paciente, 
                                              F.cd_reg_fat, 
                                              F.dt_inicio, 
                                              F.dt_final, 
                                              A.dt_alta, 
                                              convenio.nm_convenio, 
                                              F.vl_total_conta, 
                                              F.cd_convenio, 
                                              vi.local_conta, 
                                              vi.cod_localizacao)
                               ORDER BY tipo,
                                        valor DESC, 
                                        diaslocalatual DESC, 
                                        status DESC, 
                                        unidadeinternacao, 
                                        convenio ", nomeDaConta);

            IQuery query = ObjectFactory.GetInstance<IUnitOfWork>().CurrentSession.CreateSQLQuery(qry.ToString())
                .AddScalar("Tipo", NHibernateUtil.Int32)
                .AddScalar("UnidadeInternacao", NHibernateUtil.String)
                .AddScalar("Atendimento", NHibernateUtil.Int32)
                .AddScalar("Paciente", NHibernateUtil.String)
                .AddScalar("Conta", NHibernateUtil.Int32)
                .AddScalar("NroRetornos", NHibernateUtil.Int32)
                .AddScalar("DiasLocalAtual", NHibernateUtil.Int32)
                .AddScalar("NomeUsuario", NHibernateUtil.String)
                .AddScalar("DataInicial", NHibernateUtil.DateTime)
                .AddScalar("DataFinal", NHibernateUtil.DateTime)
                .AddScalar("DataAlta", NHibernateUtil.DateTime)
                .AddScalar("QtdDiasFim", NHibernateUtil.String)
                .AddScalar("Convenio", NHibernateUtil.String)
                .AddScalar("CdConvenio", NHibernateUtil.Int32)
                .AddScalar("Valor", NHibernateUtil.Decimal)
                .AddScalar("Status", NHibernateUtil.String)
                .AddScalar("Quantidade", NHibernateUtil.Int32)
                .AddScalar("Local", NHibernateUtil.String)
                .AddScalar("Hint", NHibernateUtil.String)
                .AddScalar("AvisoCirurgia", NHibernateUtil.String);

            query.SetResultTransformer(Transformers.AliasToBean(typeof(DetalhesContasEmProcessamentoDTO)));

            return query.List<DetalhesContasEmProcessamentoDTO>();
        }

        public IList<PortletDTO> GetCirurgiasConfirmadas()
        {
            StringBuilder qry = new StringBuilder();

            qry.AppendFormat(@"SELECT av.cd_cen_cir AS codigo, 
                                      cc.ds_cen_cir AS descricao,
                                      Count(ate.cd_atendimento) AS quantidade,
                                      Round(Sum(Trunc(SYSDATE)-Trunc(av.dt_realizacao)) / Count(ate.cd_atendimento),2) AS mediaDias
                                 FROM dbamv.atendime        ate
                                 JOIN dbamv.paciente        pac   ON  pac.cd_paciente       =  ate.cd_paciente
                                 JOIN dbamv.aviso_cirurgia   av   ON  av.cd_atendimento     =  ate.cd_atendimento
                                 JOIN dbamv.cen_cir          cc   ON  cc.cd_cen_cir         =  av.cd_cen_cir
                                WHERE To_Char(av.dt_realizacao, 'yyyymm')  BETWEEN  To_Char(Add_Months(SYSDATE, -5), 'yyyymm') AND To_Char(SYSDATE, 'yyyymm') 
                                  AND av.cd_cen_cir IN(9, 17, 1)
                                  AND av.tp_situacao ='R'
                                  AND NOT EXISTS (SELECT 1 FROM dbahmv.ras_documento_diverso dd 
                                                   WHERE dd.numero_documento = av.cd_aviso_cirurgia)
                                GROUP BY av.cd_cen_cir,
                                         cc.ds_cen_cir
                                ORDER BY mediaDias DESC");

            IQuery query = ObjectFactory.GetInstance<IUnitOfWork>().CurrentSession.CreateSQLQuery(qry.ToString())
                            .AddScalar("Codigo", NHibernateUtil.Int32)
                            .AddScalar("Descricao", NHibernateUtil.String)
                            .AddScalar("Quantidade", NHibernateUtil.Int32)
                            .AddScalar("MediaDias", NHibernateUtil.Decimal);

            query.SetResultTransformer(Transformers.AliasToBean(typeof(PortletDTO)));

            return query.List<PortletDTO>();
        }

        public IEnumerable<DetalhesCirurgiasConfirmadasDTO> GetDetalhesCirurgiasConfirmadas(int codigoCentroCirurgico)
        {
            StringBuilder qry = new StringBuilder();

            qry.AppendFormat(@"SELECT ate.cd_atendimento AS codigoAtendimento,
                                      Decode(ate.tp_atendimento, 'A', 'Ambulatorial',
                                                                 'B', 'Busca Ativa',
                                                                 'E', 'Externo',
                                                                 'H', 'Home Care',
                                                                 'I', 'Internação',
                                                                 'S', 'SUS AIH',
                                                                 'U', 'Urgência', ate.tp_atendimento) AS tipoAtendimento,
                                      ate.cd_paciente, 
                                      pac.nm_paciente AS paciente, 
                                      av.cd_aviso_cirurgia AS AvisoCirurgia, 
                                      av.cd_cen_cir, 
                                      cc.ds_cen_cir AS centroCirurgico,
                                      Trunc(ate.dt_atendimento) AS dataAtendimento, 
                                      Trunc(av.dt_realizacao) AS dataCirurgia, 
                                      Trunc(ate.dt_alta) AS dataAlta,
                                      ate.cd_convenio, 
                                      co.nm_convenio AS convenio,
                                      Trunc(SYSDATE)-Trunc(av.dt_realizacao) AS quantidadeDiasFim
                                 FROM dbamv.atendime        ate
                                 JOIN dbamv.paciente        pac  ON  pac.cd_paciente    =  ate.cd_paciente
                                 JOIN dbamv.aviso_cirurgia   av  ON  av.cd_atendimento  =  ate.cd_atendimento
                                 JOIN dbamv.cen_cir          cc  ON  cc.cd_cen_cir      =  av.cd_cen_cir
                                 JOIN dbamv.convenio         co  ON  co.cd_convenio     =  ate.cd_convenio
                                WHERE To_Char(av.dt_realizacao, 'yyyymm')  BETWEEN  To_Char(Add_Months(SYSDATE, -5), 'yyyymm') AND To_Char(SYSDATE, 'yyyymm') 
                                  AND av.cd_cen_cir                         =  '{0}'     
                                  AND av.tp_situacao                        =   'R'
                                  AND NOT EXISTS (SELECT 1 
                                                    FROM dbahmv.ras_documento_diverso dd 
                                                   WHERE dd.numero_documento = av.cd_aviso_cirurgia)
                                ORDER BY quantidadeDiasFim desc", codigoCentroCirurgico);

            IQuery query = ObjectFactory.GetInstance<IUnitOfWork>().CurrentSession.CreateSQLQuery(qry.ToString())
                            .AddScalar("CodigoAtendimento", NHibernateUtil.Int32)
                            .AddScalar("TipoAtendimento", NHibernateUtil.String)
                            .AddScalar("Paciente", NHibernateUtil.String)
                            .AddScalar("AvisoCirurgia", NHibernateUtil.Int32)
                            .AddScalar("CentroCirurgico", NHibernateUtil.String)
                            .AddScalar("DataAtendimento", NHibernateUtil.DateTime)
                            .AddScalar("DataCirurgia", NHibernateUtil.DateTime)
                            .AddScalar("DataAlta", NHibernateUtil.DateTime)
                            .AddScalar("Convenio", NHibernateUtil.String)
                            .AddScalar("QuantidadeDiasFim", NHibernateUtil.Int32);

            query.SetResultTransformer(Transformers.AliasToBean(typeof(DetalhesCirurgiasConfirmadasDTO)));

            return query.List<DetalhesCirurgiasConfirmadasDTO>();
        }

        public IList<PortletDTO> GetAvisosEmAutorizacoesPendenciasDeCompras()
        {
            StringBuilder qry = new StringBuilder();

            qry.AppendFormat(@"SELECT av.cd_cen_cir AS cdLocal, 
                                      cc.ds_cen_cir AS descricao,
                                      Count(ate.cd_atendimento) AS quantidade,
                                      Round(Sum(Trunc(SYSDATE)-Trunc(av.dt_realizacao)) / Count(ate.cd_atendimento),2) AS mediaDias
                                 FROM dbamv.atendime        ate
                                 JOIN dbamv.paciente        pac   ON  pac.cd_paciente       =  ate.cd_paciente
                                 JOIN dbamv.aviso_cirurgia   av   ON  av.cd_atendimento     =  ate.cd_atendimento
                                 JOIN dbamv.cen_cir          cc   ON  cc.cd_cen_cir         =  av.cd_cen_cir
                                WHERE To_Char(av.dt_realizacao, 'yyyymm')  BETWEEN  To_Char(Add_Months(SYSDATE, -5), 'yyyymm') AND To_Char(SYSDATE, 'yyyymm') 
                                  AND av.cd_cen_cir IN(9, 17, 1)
                                  AND av.tp_situacao ='R'
                                  AND NOT EXISTS (SELECT 1 FROM dbahmv.ras_documento_diverso dd 
                                                   WHERE dd.numero_documento = av.cd_aviso_cirurgia)
                                GROUP BY av.cd_cen_cir,
                                         cc.ds_cen_cir
                                ORDER BY mediaDias DESC");

            IQuery query = ObjectFactory.GetInstance<IUnitOfWork>().CurrentSession.CreateSQLQuery(qry.ToString())
                            .AddScalar("Descricao", NHibernateUtil.String)
                            .AddScalar("Quantidade", NHibernateUtil.Int32)
                            .AddScalar("MediaDias", NHibernateUtil.Decimal);

            query.SetResultTransformer(Transformers.AliasToBean(typeof(PortletDTO)));

            return query.List<PortletDTO>();
        }
    }
}

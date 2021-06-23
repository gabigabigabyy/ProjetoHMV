using HMV.Core.DataAccess;
using Paineis.Application.DTO;
using Paineis.Application.Interfaces;
using NHibernate;
using NHibernate.Transform;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.Services
{
    public class NucleoDeContasCirurgicasService : INucleoDeContasCirurgicasService
    {

        //Portlet 1058
        public IEnumerable<PortletDTO> AvisosConferenciaTecnica()
        {
            StringBuilder qry = new StringBuilder();

            qry.AppendFormat(@"SELECT LOCAL AS descricao,
                                      Sum(qt_atend_des+qt_atend_ori_nao_recebeu_sem+qt_atend_ori_nao_recebeu_com) AS quantidade,
                                      round(Sum(soma_des + soma_nao_recebeu_sem_outra + soma_nao_recebeu_com_outra) / Sum(qt_atend_des + qt_atend_ori_nao_recebeu_sem + qt_atend_ori_nao_recebeu_com),2) AS mediaDias
                                 FROM (
                                        /*avisos que estão em fase conferencia técnica (Nucleo de auditoria CC 34) e que foram recebidos pela equipe destino - ini*/ 
                                        SELECT des.descricao AS local,
                                               Count(1) AS qt_atend_des,
                                               0 AS qt_atend_ori_nao_recebeu_sem,
                                               0 AS qt_atend_ori_nao_recebeu_com,
                                               Sum(Trunc(SYSDATE) - Trunc(dd.data_recebimento)) AS soma_des,
                                               0 AS soma_nao_recebeu_sem_outra,
                                               0 AS soma_nao_recebeu_com_outra
                                          FROM dbahmv.ras_documento         doc
                                          JOIN dbahmv.ras_tipo_documento     tp ON tp.cod_tipo          = doc.cod_tipo
                                          JOIN dbahmv.ras_localizacao       ori ON ori.cod_localizacao  = doc.cod_localizacao_origem
                                          JOIN dbahmv.ras_localizacao       des ON des.cod_localizacao  = doc.cod_localizacao_destino
                                          JOIN dbahmv.ras_documento_diverso  dd ON dd.seq_ras_documento = doc.seq_ras_documento
                                     LEFT JOIN dbasgu.usuarios                u ON u.cd_usuario         = dd.cd_usuario_recebeu
                                          JOIN dbamv.atendime               ate ON ate.cd_atendimento   = dd.cd_atendimento
                                          JOIN dbamv.paciente                 p ON p.cd_paciente        = ate.cd_paciente
                                          JOIN dbamv.aviso_cirurgia          ac ON ac.cd_aviso_cirurgia = dd.numero_documento
                                          JOIN dbamv.cen_cir                 cc ON cc.cd_cen_cir        = ac.cd_cen_cir
                                          JOIN dbamv.convenio                co ON co.cd_convenio       = ate.cd_convenio
                                         WHERE doc.cod_localizacao_destino = 34 --Nucleo de Auditoria CC
                                           AND doc.cod_tipo = 3 --BOLETIM SALA
                                           AND dd.data_recebimento IS NOT NULL 
                                           AND doc.data_exclusao IS NULL
                                           AND ac.tp_situacao = 'R'                             
                                           AND ac.dt_realizacao > To_Date('20151231','YYYYMMDD')  
                                           AND NOT EXISTS ( /*valida se aviso não esta em outro local no momento*/
                                                            SELECT 1  
                                                              FROM dbahmv.ras_documento doc2
                                                              JOIN dbahmv.ras_documento_diverso dd2 ON dd2.seq_ras_documento = doc2.seq_ras_documento
                                                             WHERE dd2.numero_documento = dd.numero_documento --aviso
                                                               AND doc2.cod_localizacao_origem = doc.cod_localizacao_destino --enviado com origem = 34
                                                               AND doc2.cod_tipo = doc.cod_tipo --documento do tipo boletim
                                                               AND Nvl(dd2.data_recebimento, SYSDATE) > dd.data_recebimento  --com data maior 
                                                          ) 
                                         GROUP BY des.descricao
                                               /*avisos que estão em fase conferencia técnica (Nucleo de auditoria CC 34) e que foram recebidos pela equipe destino - fim*/
                                              
                                         UNION
                                              
                                               /*avisos que estão em fase conferencia técnica (Nucleo de auditoria CC 34) e que foram enviados para outra equipe, porém esta outra equipe ainda não recebeu os avisos. Registo unico no mov doc para etapa 34 - ini*/
                                        SELECT ori.descricao AS local,
                                               0 AS qt_atend_des,
                                               Count(1) AS qt_atend_ori_nao_recebeu_sem,
                                               0 AS qt_atend_ori_nao_recebeu_com,
                                               0 AS soma_des,
                                               Sum(Trunc(SYSDATE) - Trunc(doc.data)) AS soma_nao_recebeu_sem_outra,
                                               0 AS soma_nao_recebeu_com_outra
                                          FROM dbahmv.ras_documento         doc
                                          JOIN dbahmv.ras_tipo_documento     tp ON tp.cod_tipo          = doc.cod_tipo
                                          JOIN dbahmv.ras_localizacao       ori ON ori.cod_localizacao  = doc.cod_localizacao_origem
                                          JOIN dbahmv.ras_localizacao       des ON des.cod_localizacao  = doc.cod_localizacao_destino
                                          JOIN dbahmv.ras_documento_diverso  dd ON dd.seq_ras_documento = doc.seq_ras_documento
                                     LEFT JOIN dbasgu.usuarios                u ON u.cd_usuario         = doc.cd_usuario_inclusao
                                          JOIN dbamv.atendime               ate ON ate.cd_atendimento   = dd.cd_atendimento
                                          JOIN dbamv.paciente                 p ON p.cd_paciente        = ate.cd_paciente
                                          JOIN dbamv.aviso_cirurgia          ac ON ac.cd_aviso_cirurgia = dd.numero_documento
                                          JOIN dbamv.cen_cir                 cc ON cc.cd_cen_cir        = ac.cd_cen_cir
                                          JOIN dbamv.convenio                co ON co.cd_convenio       = ate.cd_convenio
                                         WHERE doc.cod_localizacao_origem = 34 --Nucleo de Auditoria CC
                                           AND dd.data_recebimento IS NULL
                                           AND doc.cod_tipo = 3 --BOLETIM SALA
                                           AND doc.data_exclusao IS NULL
                                           AND ac.tp_situacao = 'R'
                                           AND ac.dt_realizacao > To_Date('20151231','YYYYMMDD')
                                           AND NOT EXISTS ( SELECT 1 FROM dbahmv.ras_documento doc2
                                                              JOIN dbahmv.ras_documento_diverso dd2 ON dd2.seq_ras_documento = doc2.seq_ras_documento
                                                             WHERE doc2.cod_localizacao_destino = doc.cod_localizacao_origem 
                                                               AND dd2.numero_documento = dd.numero_documento
                                                          )
                                         GROUP BY ori.descricao
                                        /*avisos que estão em fase conferencia técnica (Nucleo de auditoria CC 34) e que foram enviados para outra equipe, porém esta outra equipe ainda não recebeu os avisos. Registo unico no mov doc para etapa 34 - fim*/
                                              
                                         UNION
                                              
                                        /*avisos que estão em fase conferencia técnica (Nucleo de auditoria CC 34) e que foram enviados para outra equipe, porém esta outra equipe ainda não recebeu os avisos. Há outros registro no mov doc para etapa 34 - ini*/
                                        SELECT ori.descricao AS local,
                                               0 AS qt_atend_des,
                                               0 AS qt_atend_ori_nao_recebeu_sem,
                                               Count(1) AS qt_atend_ori_nao_recebeu_com,
                                               0 AS soma_des,
                                               0 AS soma_nao_recebeu_sem_outra,
                                               Sum( Trunc(SYSDATE) - ( SELECT Trunc(Max(dd1.data_recebimento)) 
                                                                         FROM dbahmv.ras_documento doc1
                                                                         JOIN dbahmv.ras_documento_diverso dd1 ON dd1.seq_ras_documento = doc1.seq_ras_documento
                                                                        WHERE doc1.cod_localizacao_destino = doc.cod_localizacao_origem 
                                                                          AND dd1.cd_atendimento = dd.cd_atendimento
                                                                     )
                                                  ) AS soma_nao_recebeu_com_outra
                                        FROM dbahmv.ras_documento         doc
                                        JOIN dbahmv.ras_tipo_documento     tp ON  tp.cod_tipo          = doc.cod_tipo
                                        JOIN dbahmv.ras_localizacao       ori ON  ori.cod_localizacao  = doc.cod_localizacao_origem
                                        JOIN dbahmv.ras_localizacao       des ON  des.cod_localizacao  = doc.cod_localizacao_destino
                                        JOIN dbahmv.ras_documento_diverso  dd ON  dd.seq_ras_documento = doc.seq_ras_documento
                                   LEFT JOIN  dbasgu.usuarios               u ON  u.cd_usuario         = doc.cd_usuario_inclusao
                                        JOIN dbamv.atendime               ate ON  ate.cd_atendimento   = dd.cd_atendimento
                                        JOIN dbamv.paciente                 p ON  p.cd_paciente        = ate.cd_paciente
                                        JOIN dbamv.aviso_cirurgia          ac ON  ac.cd_aviso_cirurgia = dd.numero_documento
                                        JOIN dbamv.cen_cir                 cc ON  cc.cd_cen_cir        = ac.cd_cen_cir
                                        JOIN dbamv.convenio                co ON  co.cd_convenio       = ate.cd_convenio
                                       WHERE doc.cod_localizacao_origem = 34 --Nucleo de Auditoria CC
                                         AND dd.data_recebimento IS NULL
                                         AND doc.cod_tipo = 3 --BOLETIM SALA
                                         AND doc.data_exclusao IS NULL
                                         AND ac.tp_situacao = 'R'
                                         AND ac.dt_realizacao > To_Date('20151231','YYYYMMDD')
                                         AND EXISTS ( SELECT 1 
                                                        FROM dbahmv.ras_documento doc2
                                                        JOIN dbahmv.ras_documento_diverso dd2 ON dd2.seq_ras_documento = doc2.seq_ras_documento
                                                       WHERE doc2.cod_localizacao_destino = doc.cod_localizacao_origem 
                                                         AND dd2.numero_documento = dd.numero_documento
                                                    )
                                       GROUP BY ori.descricao
                                       /*avisos que estão em fase conferencia técnica (Nucleo de auditoria CC 34) e que foram enviados para outra equipe, porém esta outra equipe ainda não recebeu os avisos. Há outros registro no mov doc para etapa 34 - fim*/
                                    )
                                GROUP BY local");

            IQuery query = ObjectFactory.GetInstance<IUnitOfWork>().CurrentSession.CreateSQLQuery(qry.ToString())
                  .AddScalar("Descricao", NHibernateUtil.String)
                  .AddScalar("Quantidade", NHibernateUtil.Int32)
                  .AddScalar("MediaDias", NHibernateUtil.Decimal);

            query.SetResultTransformer(Transformers.AliasToBean(typeof(PortletDTO)));

            return query.List<PortletDTO>();
        }

        public IEnumerable<AvisoCirurgiaDTO> DetalhesAvisosConferenciaTecnica()
        {
            StringBuilder qry = new StringBuilder();

            qry.AppendFormat(@"SELECT  dd.cd_atendimento, Decode(ate.tp_atendimento, 'A', 'Ambulatorial',
                                                                                  'B', 'Busca Ativa',
                                                                                  'E', 'Externo',
                                                                                  'H', 'Home Care',
                                                                                  'I', 'Internação',
                                                                                  'S', 'SUS AIH',
                                                                                  'U', 'Urgência',     ate.tp_atendimento) AS TipoAtendimento
                                    ,p.nm_paciente      AS NomePaciente
                                    ,ate.cd_convenio    AS IdConvenio
                                    ,co.nm_convenio     AS Convenio
                                    ,dd.numero_documento AS AvisoCirurgia
                                    ,cc.ds_cen_cir      AS CentroCirurgico
                                    ,ate.dt_atendimento AS  DataAtendimento
                                    ,ac.dt_realizacao AS DataCirurgia
                                    ,ate.dt_alta  AS DataAlta
                                    ,u.nm_usuario AS NomeUsuario
                                    ,( SELECT  Count(1)
                                          FROM  dbahmv.ras_documento         doc_c
                                          JOIN  dbahmv.ras_tipo_documento     tp_c ON tp_c.cod_tipo          = doc_c.cod_tipo
                                          JOIN  dbahmv.ras_localizacao       ori_c ON ori_c.cod_localizacao  = doc_c.cod_localizacao_origem
                                          JOIN  dbahmv.ras_localizacao       des_c ON des_c.cod_localizacao  = doc_c.cod_localizacao_destino
                                          JOIN  dbahmv.ras_documento_diverso  dd_c ON dd_c.seq_ras_documento = doc_c.seq_ras_documento
                                          WHERE doc_c.cod_localizacao_destino = doc.cod_localizacao_destino AND
                                            --dd_c.cd_atendimento           = dd.cd_atendimento           AND
                                            dd_c.numero_documento         = dd.numero_documento         AND
                                            doc_c.cod_tipo                = doc.cod_tipo                AND
                                            dd_c.data_recebimento         IS NOT NULL                   AND
                                            doc_c.data_exclusao           IS NULL
                                    ) AS Retornos
        
                                    ,Trunc(SYSDATE) - Trunc(ac.dt_realizacao)    AS DiasFim
                                    ,Trunc(SYSDATE) - Trunc(dd.data_recebimento) AS DiasLocalAtual

                                    ,Decode (cir.tp_cirurgia, 'P','PEQUENA', 'M', 'MEDIA', 'G', 'GRANDE', 'E', 'ESPECIAL', cir.tp_cirurgia) AS PorteCirurgico

                                    ,( SELECT pa.nm_prestador
                                        FROM dbamv.prestador_aviso pa
                                          WHERE pa.sn_principal = 'S'
                                            AND ac.cd_aviso_cirurgia = pa.cd_aviso_cirurgia
                                            AND ca.cd_cirurgia_aviso = pa.cd_cirurgia_aviso
                                            AND cir.cd_cirurgia = pa.cd_cirurgia
                                      ) CirurgiaoPrincipal

                            FROM  dbahmv.ras_documento         doc
                            JOIN  dbahmv.ras_tipo_documento     tp  ON  tp.cod_tipo          = doc.cod_tipo
                            JOIN  dbahmv.ras_localizacao       ori  ON  ori.cod_localizacao  = doc.cod_localizacao_origem
                            JOIN  dbahmv.ras_localizacao       des  ON  des.cod_localizacao  = doc.cod_localizacao_destino
                            JOIN  dbahmv.ras_documento_diverso  dd  ON  dd.seq_ras_documento = doc.seq_ras_documento
                            LEFT JOIN  dbasgu.usuarios           u  ON  u.cd_usuario         = dd.cd_usuario_recebeu
                            JOIN  dbamv.atendime               ate  ON  ate.cd_atendimento   = dd.cd_atendimento
                            JOIN  dbamv.paciente                 p  ON  p.cd_paciente        = ate.cd_paciente
                            JOIN  dbamv.aviso_cirurgia          ac  ON  ac.cd_aviso_cirurgia = dd.numero_documento
                            JOIN  dbamv.cen_cir                 cc  ON  cc.cd_cen_cir        = ac.cd_cen_cir
                            JOIN  dbamv.convenio                co  ON  co.cd_convenio       = ate.cd_convenio

                            JOIN dbamv.cirurgia_aviso            ca ON  ac.cd_aviso_cirurgia = ca.cd_aviso_cirurgia
                            JOIN dbamv.cirurgia                 cir ON  ca.cd_cirurgia       = cir.cd_cirurgia


                            WHERE ca.sn_principal             = 'S'   AND
                                  doc.cod_localizacao_destino = 34                              AND --Nucleo de Auditoria CC
                                  doc.cod_tipo                = 3                               AND --BOLETIM SALA
                                  dd.data_recebimento        IS NOT NULL                        AND
                                  doc.data_exclusao          IS NULL                            AND
                                  ac.tp_situacao              = 'R'                             AND
                                  ac.dt_realizacao            > To_Date('20201030','YYYYMMDD')  AND
                                  /*valida se aviso não esta em outro local no momento*/
                                  NOT EXISTS                    ( SELECT 1  FROM  dbahmv.ras_documento doc2
                                                                            JOIN  dbahmv.ras_documento_diverso dd2 ON dd2.seq_ras_documento = doc2.seq_ras_documento
                                                                            WHERE dd2.numero_documento        = dd.numero_documento         AND    --aviso
                                                                                  doc2.cod_localizacao_origem = doc.cod_localizacao_destino AND    --enviado com origem = 34
                                                                                  doc2.cod_tipo               = doc.cod_tipo                AND    --documento do tipo boletim
                                                                                  Nvl(dd2.data_recebimento, SYSDATE) > dd.data_recebimento         --com data maior
                                                                )   
                             ORDER BY 1, 6");

            IQuery query = ObjectFactory.GetInstance<IUnitOfWork>().CurrentSession.CreateSQLQuery(qry.ToString())
                .AddScalar("TipoAtendimento", NHibernateUtil.String)
                .AddScalar("NomePaciente", NHibernateUtil.String)
                .AddScalar("IdConvenio", NHibernateUtil.Int32)
                .AddScalar("Convenio", NHibernateUtil.String)
                .AddScalar("AvisoCirurgia", NHibernateUtil.Int32)
                .AddScalar("CentroCirurgico", NHibernateUtil.String)
                .AddScalar("DataAtendimento", NHibernateUtil.DateTime)
                .AddScalar("DataCirurgia", NHibernateUtil.DateTime)
                .AddScalar("DataAlta", NHibernateUtil.DateTime)
                .AddScalar("NomeUsuario", NHibernateUtil.String)
                .AddScalar("Retornos", NHibernateUtil.Int32)
                .AddScalar("DiasFim", NHibernateUtil.Int32)
                .AddScalar("DiasLocalAtual", NHibernateUtil.Int32)
                .AddScalar("PorteCirurgico", NHibernateUtil.String)
                .AddScalar("CirurgiaoPrincipal", NHibernateUtil.String);

            query.SetResultTransformer(Transformers.AliasToBean(typeof(AvisoCirurgiaDTO)));

            return query.List<AvisoCirurgiaDTO>();
        }
    }
}

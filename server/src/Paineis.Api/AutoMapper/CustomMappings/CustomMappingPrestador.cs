using AutoMapper;
using HMV.PortalMedicoServices.DTO;
using HMV.Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;

namespace HMV.PortalMedicoServices.Api.AutoMapper
{
    /// <summary>
    /// Custom mapping prestador
    /// </summary>
    public static class CustomMappingPrestador
    {
        /// <summary>
        /// Customer prestador
        /// </summary>
        /// <param name="prestadorDTO">Prestador dto</param>
        /// <returns>Customer prestador</returns>
        public static Prestador PrestadorDtoImportPrestador(PrestadorDTO prestadorDTO)
        {
            HMV.PortalMedicoServices.Interfaces.IPrestadorService pstSrv = ObjectFactory.GetInstance<HMV.PortalMedicoServices.Interfaces.IPrestadorService>();
            Prestador prestador = pstSrv.FiltraCodigo(prestadorDTO.Id);
            prestador.Email = prestadorDTO.Email;
            prestador.Email2 = prestadorDTO.Email2;
            prestador.Celular = prestadorDTO.Celular;
            prestador.ComoPodemosFalarComVoce = ConvertTypes.ConvertByteToEnumComoPodemosFalarComVcOrNull(prestadorDTO.ComoPodemosFalarComVoce);

            if (prestadorDTO.EnderecoResidencial != null)
            {
                prestador.EnderecoResidencial = Mapper.Map<Endereco>(prestadorDTO.EnderecoResidencial);
            }

            prestador.Telefone1Residencial = prestadorDTO.Telefone1Residencial;
            prestador.Telefone2Residencial = prestadorDTO.Telefone2Residencial;

            if (prestadorDTO.EnderecoProfissional != null)
            {
                prestador.EnderecoProfissional = Mapper.Map<Endereco>(prestadorDTO.EnderecoProfissional);
            }

            prestador.Telefone1Profissional = prestadorDTO.Telefone1Profissional;
            prestador.Telefone2Profissional = prestadorDTO.Telefone2Profissional;


            prestador.PlacaCarro1 = prestadorDTO.PlacaCarro1;
            prestador.PlacaCarro2 = prestadorDTO.PlacaCarro2;
            prestador.PlacaCarro3 = prestadorDTO.PlacaCarro3;

            if (prestadorDTO.EspecialidadePrincipal != null)
            {
                EspecialidadeDTO especialidadeDTO = prestadorDTO.EspecialidadePrincipal.Especialidade;
                prestador.setEspecialidadePrincipal(Mapper.Map<Especialidade>(especialidadeDTO));
            }

            Especialidade Especialidade01 = null;
            Especialidade Especialidade02 = null;

            if (prestadorDTO.EspecialidadeSecundaria01 != null)
            {
                EspecialidadeDTO especialidadeDTO = prestadorDTO.EspecialidadeSecundaria01.Especialidade;
                Especialidade01 = Mapper.Map<Especialidade>(especialidadeDTO);
            }

            if (prestadorDTO.EspecialidadeSecundaria02 != null)
            {
                EspecialidadeDTO especialidadeDTO = prestadorDTO.EspecialidadeSecundaria02.Especialidade;
                Especialidade02 = Mapper.Map<Especialidade>(especialidadeDTO);
            }

            prestador.adicionaEspecialidadesSecundarias(Especialidade01, Especialidade02);

            AreaAtuacao areaDeAtuacao1 = null;
            AreaAtuacao areaDeAtuacao2 = null;
            AreaAtuacao areaDeAtuacao3 = null;

            if (prestadorDTO.AreaAtuacao.Count() > 0)
            {
                AreaAtuacaoDTO areaAtuacaoDTO = prestadorDTO.AreaAtuacao[0].AreaAtuacao;
                areaDeAtuacao1 = Mapper.Map<AreaAtuacao>(areaAtuacaoDTO);
            }

            if (prestadorDTO.AreaAtuacao.Count() > 1)
            {
                AreaAtuacaoDTO areaAtuacaoDTO = prestadorDTO.AreaAtuacao[1].AreaAtuacao;
                areaDeAtuacao2 = Mapper.Map<AreaAtuacao>(areaAtuacaoDTO);
            }

            if (prestadorDTO.AreaAtuacao.Count() > 2)
            {
                AreaAtuacaoDTO areaAtuacaoDTO = prestadorDTO.AreaAtuacao[2].AreaAtuacao;
                areaDeAtuacao3 = Mapper.Map<AreaAtuacao>(areaAtuacaoDTO);
            }

            prestador.addAreaAtuacao(areaDeAtuacao1, areaDeAtuacao2, areaDeAtuacao3);

            return prestador;
        }
    }
}
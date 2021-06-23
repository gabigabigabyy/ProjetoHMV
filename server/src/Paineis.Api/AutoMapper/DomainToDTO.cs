using AutoMapper;
using HMV.PortalMedicoServices.DTO;
using HMV.Core.Domain.Enum;
using HMV.Core.Domain.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMV.PortalMedicoServices.Api.AutoMapper
{
    public class DomainToDTO : Profile
    {
        public DomainToDTO()
        {
            CreateMap<Prestador, PrestadorDTO>()
                .ForMember(dest => dest.DataNascimento, opts => opts.MapFrom(src => ConvertTypes.ConvertDateToString(src.DataNascimento)))
                .ForMember(dest => dest.EspecialidadePrincipal, opts => opts.MapFrom(src => src.getEspecialidadePrincipal()))
                .ForMember(dest => dest.EspecialidadeSecundaria01, opts => opts.MapFrom(src => src.getEspecialidadesSecundarias().FirstOrDefault()))
                .ForMember(dest => dest.EspecialidadeSecundaria02, opts => opts.MapFrom(src => CustomMappingPrestadorEspecialidade.GetEspecialidadesSecundariasNumeroDois(src.getEspecialidadesSecundarias())))
                .ForMember(dest => dest.AreaAtuacao, opts => opts.MapFrom(src => src.getAreasAtuacao().Take(3).OrderBy(x => x.AreaAtuacao.Descricao).ToList()))
                .ForMember(dest => dest.ComoPodemosFalarComVoce, opts => opts.MapFrom(src => src.ComoPodemosFalarComVoce.Value))
                .ForMember(dest => dest.EnderecoResidencial, opts => opts.MapFrom(src => src.EnderecoResidencial))
                .ForMember(dest => dest.EnderecoProfissional, opts => opts.MapFrom(src => src.EnderecoProfissional));

            CreateMap<Especialidade, EspecialidadeDTO>()
                .ForMember(dest => dest.ativo, opts => opts.MapFrom(src => ConvertTypes.ConvertStringS_ToBoolean(src.Status)));

            CreateMap<PrestadorEspecialidade, PrestadorEspecialidadeDTO>()
                .ForMember(dest => dest.Validada, opts => opts.MapFrom(src => ConvertTypes.ConvertEnumSimNaoToBoolean(src.Validada)))
                .ForMember(dest => dest.DataAlteracao, opts => opts.MapFrom(src => ConvertTypes.ConvertDateToString(src.DataAlteracao)));

            CreateMap<AreaAtuacao, AreaAtuacaoDTO>()
                .ReverseMap();

            CreateMap<PrestadorAreaAtuacao, PrestadorAreaAtuacaoDTO>()
                .ForMember(dest => dest.Validada, opts => opts.MapFrom(src => ConvertTypes.ConvertEnumSimNaoToBoolean(src.Validada)))
                .ForMember(dest => dest.DataAlteracao, opts => opts.MapFrom(src => ConvertTypes.ConvertDateToString(src.DataAlteracao)));

            CreateMap<Endereco, EnderecoDTO>()
                .ReverseMap();

            CreateMap<TipoLogradouro, TipoLogradouroDTO>()
                .ReverseMap();

            CreateMap<Cidade, CidadeDTO>()
                .ReverseMap();

            CreateMap<UF, UFDTO>()
                .ReverseMap();

            CreateMap<Convenio, ConvenioDTO>()
                .ForMember(dest => dest.Ativo, opts => opts.MapFrom(src => ConvertTypes.ConvertEnumSimNaoToBoolean(src.Ativo)));
        }
    }
}
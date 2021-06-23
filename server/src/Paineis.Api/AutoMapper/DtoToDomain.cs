using AutoMapper;
using HMV.PortalMedicoServices.DTO;
using HMV.Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMV.PortalMedicoServices.Api.AutoMapper
{
    public class DtoToDomain : Profile
    {
        public DtoToDomain()
        {
            CreateMap<PrestadorDTO, Prestador>()
                .ConstructUsing(CustomMappingPrestador.PrestadorDtoImportPrestador)
                .ForMember(dest => dest.ComoPodemosFalarComVoce, opts => opts.Ignore());

            CreateMap<EspecialidadeDTO, Especialidade>()
                .ForMember(dest => dest.Status, opts => opts.MapFrom(src => ConvertTypes.ConvertBooleanToStringS(src.ativo)));

            CreateMap<PrestadorEspecialidadeDTO, PrestadorEspecialidade>()
                .ForMember(dest => dest.Validada, opts => opts.MapFrom(src => ConvertTypes.ConvertBooleanToEnumSimNao(src.Validada)))
                .ForMember(dest => dest.DataAlteracao, opts => opts.MapFrom(src => ConvertTypes.ConvertStringToDateTime(src.DataAlteracao)));

            CreateMap<PrestadorAreaAtuacaoDTO, PrestadorAreaAtuacao>()
                .ForMember(dest => dest.Validada, opts => opts.MapFrom(src => ConvertTypes.ConvertBooleanToEnumSimNao(src.Validada)))
                .ForMember(dest => dest.DataAlteracao, opts => opts.MapFrom(src => ConvertTypes.ConvertStringToDateTime(src.DataAlteracao)));

            CreateMap<ConvenioDTO, Convenio>()
                .ForMember(dest => dest.Ativo, opts => opts.MapFrom(src => ConvertTypes.ConvertBooleanToEnumSimNao(src.Ativo)));
        }
    }
}
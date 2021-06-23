using AutoMapper;
using HMV.Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Paineis.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(i =>
            {
                i.AddProfile<DomainToDTO>();
                i.AddProfile<DtoToDomain>();
            });
        }
    }
}
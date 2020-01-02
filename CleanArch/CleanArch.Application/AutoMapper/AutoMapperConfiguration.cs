using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace CleanArch.Application.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ViewModelToDomainProfile());
                cfg.AddProfile(new DomainToViewModelProfile());
            });
        }
    }
}

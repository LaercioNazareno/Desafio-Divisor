using System;
using AutoMapper;

namespace Desafio.Application.Mapper
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new(() =>
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
            cfg.AddProfile<CustomDtoMapper>();
        });
        var mapper = config.CreateMapper();
        return mapper;
    });
        public static IMapper Mapper => Lazy.Value;
    }
}
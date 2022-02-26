using AutoMapper;
using Desafio.Application.DTO;
using Desafio.Domain.Entidades;

namespace Desafio.Application.Mapper
{
    public class CustomDtoMapper: Profile
    {
        public CustomDtoMapper()
        {
            CreateMap<Divisor, DivisorDTO>();
        }
    }
}
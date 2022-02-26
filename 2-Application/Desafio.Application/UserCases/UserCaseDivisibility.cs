using AutoMapper;
using Desafio.Application.DTO;
using Desafio.Application.Interfaces;
using Desafio.Application.Mapper;
using Desafio.Domain.Interfaces.Services;

namespace Desafio.Application.UserCases
{
    public class UserCaseDivisibility : IUseCaseDivisibility
    {
        private readonly IDivisibilityDomain _divisibilityDomain;
        public UserCaseDivisibility(IDivisibilityDomain divisibilityDomain)
        {
            _divisibilityDomain = divisibilityDomain;
        }
        public DivisorDTO GetDivisors(int number)
        {
            var divisor = _divisibilityDomain.GetDivisor(number);
            return ObjectMapper.Mapper.Map<DivisorDTO>(divisor);
        }
    }
}
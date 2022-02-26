using Desafio.Application.DTO;

namespace Desafio.Application.Interfaces
{
    public interface IUseCaseDivisibility
    {
        public DivisorDTO GetDivisors(int number);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Domain.Entidades;

namespace Desafio.Domain.Interfaces.Services
{
    public interface IDivisibilityDomain
    {
        public Divisor GetDivisor(int number);
    }
}
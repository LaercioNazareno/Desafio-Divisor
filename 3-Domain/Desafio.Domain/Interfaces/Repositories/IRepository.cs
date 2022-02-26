using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Domain.Entidades;

namespace Desafio.Domain.Interfaces.Repositories
{
    public interface IRepository
    {
        public Divisor GetDivisorsCalculatedBy(int number);
        void Save(Divisor divisor);
    }
}
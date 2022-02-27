using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Domain.Entidades
{
    public class Divisor
    {
        public int Number { get; set; }
        public List<int> AllDivisors { get; set; }
        public List<int> PrimeDivisors { get; set; }
    }
}
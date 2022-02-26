
using System.Collections.Generic;
namespace Desafio.Domain.Entidades
{
    public sealed class Divisor
    {
        public int Number { get; set; }
        public List<int> AllDividers { get; set; }
        public List<int> PrimeDivisors { get; set; }
    }
}
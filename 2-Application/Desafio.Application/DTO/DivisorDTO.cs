
using System.Collections.Generic;

namespace Desafio.Application.DTO
{
    public class DivisorDTO
    {
        public DivisorDTO(){
            Number = 1;
            AllDivisors = new List<int>();
            PrimeDivisors = new List<int>();

        }
        public int Number { get; set; }
        public List<int> AllDivisors { get; set; }
        public List<int> PrimeDivisors { get; set; }
    }
}
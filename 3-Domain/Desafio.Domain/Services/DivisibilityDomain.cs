using System;
using System.Collections.Generic;
using Desafio.Domain.Entidades;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Domain.Interfaces.Services;

namespace Desafio.Domain.Services
{
    public class DivisibilityDomain : IDivisibilityDomain
    {
        private readonly IRepository _repository;
        public DivisibilityDomain(IRepository repository)
        {
            _repository = repository;
        }
        public List<int> GetDivisors(int number)
        {
            var divisors = new List<int>();
            for (int divisor = number; divisor > 0; divisor--)
            {
                if (number % divisor == 0)
                {
                    divisors.Add(divisor);
                }
            }
            return divisors;
        }
        public List<int> GetPrimeDivisors(int number, List<int> divisors)
        {
            List<int> primeDivisors;
            if (number > 100)
            {
                primeDivisors = PrimeForSquareRoot(divisors);
            }
            else
            {
                primeDivisors = PrimeForFermatForm(divisors);
            }

            return primeDivisors;
        }
        private List<int> PrimeForSquareRoot(List<int> divisors)
        {
            var primeList = new List<int>();
            foreach (var divisor in divisors)
            {
                if (IsPrimeSquareRoot(divisor))
                {
                    primeList.Add(divisor);
                }
            }
            return primeList;
        }
        // Complexidade da busca O(n^n)
        public bool IsPrimeSquareRoot(int number)
        {
            if (number <= 1)
                return false;
            for (int divisor = 2; divisor * divisor <= number; divisor++)
            {
                if (number % divisor == 0)
                    return false;
            }
            return true;
        }
        // Complexidade da busca O(n) com limite computacional de 100
        private List<int> PrimeForFermatForm(List<int> divisors)
        {
            var primeDivisors = new List<int>();
            foreach (var divisor in divisors)
            {
                if (IsPrimeFermat(divisor))
                {
                    primeDivisors.Add(divisor);
                }
            }
            return primeDivisors;
        }
        public bool IsPrimeFermat(int number)
        {
            return (((Math.Pow(2, (number - 1))) % number) == 1 % number) || number == 2;
        }
        public Divisor GetDivisor(int number)
        {
            var divisor = _repository.GetDivisorsCalculatedBy(number);

            if (divisor != null)
            {
                return divisor;
            }
            else
            {
                var allDividers = GetDivisors(number);
                var primeDivisors = GetPrimeDivisors(number, allDividers);
                divisor = new Divisor()
                {
                    AllDivisors = allDividers,
                    PrimeDivisors = primeDivisors
                };
                _repository.Save(divisor);
            }
            return divisor;
        }
    }
}
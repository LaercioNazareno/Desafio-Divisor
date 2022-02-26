using Desafio.Domain.Services;
using Xunit;
using Desafio.Data.Repositories;

namespace Desafio.Domain.Test
{
    public class DivibilityTest
    {
        private readonly DivisibilityDomain _divisibilityDomain;

        public DivibilityTest(){
            _divisibilityDomain = new DivisibilityDomain(new Repository());   
        }

        [Theory]
        [InlineData (new object[] { new int[] { 45, 15, 9, 5, 3, 1 }, 45})]
        [InlineData (new object[] { new int[] {}, 0})]
        [InlineData (new object[] { new int[] {}, -45})]
        public void Divibility_Test(int[] expected, int number)
        {
            var divisors = _divisibilityDomain.GetDivisors(number);
            Assert.Equal(expected, divisors);
        }

        [Theory]
        [InlineData (new object[] { new int[] { 5, 3, 1 }, 45})]
        [InlineData (new object[] { new int[] { 2, 1 }, 2})]
        public void PrimeDivisors_Test(int[] expected, int number)
        {
            var divisors = _divisibilityDomain.GetDivisors(number);
            var primeDivisors = _divisibilityDomain.GetPrimeDivisors(number, divisors);
            Assert.Equal(expected, primeDivisors);
        }
        
        [Theory]
        [InlineData (2)]
        [InlineData (11)]
        [InlineData (127)]
        public void PrimeFermat_Test(int number)
        {
            Assert.True(_divisibilityDomain.IsPrimeFermat(number));
        }

        [Theory]
        [InlineData (2)]
        [InlineData (11)]
        [InlineData (173)]
        public void PrimeRoot_Test(int number)
        {
            Assert.True(_divisibilityDomain.IsPrimeSquareRoot(number));
        }
    }
}

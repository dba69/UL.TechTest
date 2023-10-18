using FluentResults;
using System.Numerics;

namespace UL.TestTest.Services.Factorial
{
    public interface IFactorialService
    {
        public Task<Result<BigInteger>> CalculateAsync(CalculateFactorialRequest request, CancellationToken cancellationToken = default);
    }
}

using FluentResults;
using FluentValidation;
using System.Numerics;

namespace UL.TestTest.Services.Factorial
{
    public record CalculateFactorialRequest(BigInteger InputInteger);

    public class FactorialService : IFactorialService
    {
        private readonly IValidator<CalculateFactorialRequest> _validator;

        public FactorialService(IValidator<CalculateFactorialRequest> validator)
        {
            _validator = validator;
        }

        public async Task<Result<BigInteger>> CalculateAsync(CalculateFactorialRequest request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid)
            {
                return Result.Ok(await Task.Run(() => CalculateFactorial(request.InputInteger)));
            }

            return Result.Fail<BigInteger>(validationResult.ToString());
        }

        private static BigInteger CalculateFactorial(BigInteger value)
        {
            BigInteger result = 1;

            for (BigInteger i = 2; i <= value; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
using FluentResults;

namespace UL.TestTest.Services.FizzBuzz
{
    public interface IFizzBuzzService
    {
        public Task<Result<IEnumerable<string>>> CalculateAsync(FizzBuzzRequest request, CancellationToken cancellationToken = default);
    }
}

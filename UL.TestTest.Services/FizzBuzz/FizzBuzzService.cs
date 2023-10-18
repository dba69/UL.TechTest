using FluentResults;

namespace UL.TestTest.Services.FizzBuzz
{
    public record FizzBuzzRequest(int Min, int Max);

    public class FizzBuzzService : IFizzBuzzService
    {
        public async Task<Result<IEnumerable<string>>> CalculateAsync(FizzBuzzRequest request, CancellationToken cancellationToken = default)
        {
            var results = await Task.Run(() => Process(request));
         
            return Result.Ok(results);
        }

        private static IEnumerable<string> Process(FizzBuzzRequest request)
        {
            var results = new List<string>();

            for (var i = request.Min; i <= request.Max; i++)
            {
                results.Add(Process(i));
            }

            return results;
        }

        private static string Process(int value)
        {
            return value switch
            {
               var x when x % 15 == 0 => "FizzBuzz",
               var x when x % 3 == 0 => "Fizz",
               var x when x % 5 == 0 => "Buzz",
                _ => value.ToString()
            };
        }
    }
}

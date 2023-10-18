using UL.TestTest.Services.Factorial;
using UL.TestTest.Services.FizzBuzz;

namespace UL.TestTest.Services
{
    public interface IServiceFactory
    {
        IFizzBuzzService GetFizzBuzzService();

        IFactorialService GetFactorialService();
    }
}
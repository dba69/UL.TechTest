using Microsoft.Extensions.DependencyInjection;
using UL.TestTest.Services.Factorial;
using UL.TestTest.Services.FizzBuzz;

namespace UL.TestTest.Services
{
    public class ServiceFactory : IServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IFizzBuzzService GetFizzBuzzService()
        {
            return _serviceProvider.GetRequiredService<IFizzBuzzService>();
        }

        public IFactorialService GetFactorialService()
        {
            return _serviceProvider.GetRequiredService<IFactorialService>();
        }
    }
}

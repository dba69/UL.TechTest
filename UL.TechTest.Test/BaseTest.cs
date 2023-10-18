using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using UL.TestTest.Services;
using UL.TestTest.Services.Factorial;
using UL.TestTest.Services.Factorial.Validator;
using UL.TestTest.Services.FizzBuzz;

namespace UL.TechTest.Test
{
    [TestClass]
    public class BaseTest
    {
        private readonly ServiceCollection _services = new();
        protected IServiceFactory? ServiceFactory;

        [TestInitialize]
        public void TestInitialize()
        {
            _services.AddValidatorsFromAssemblyContaining<CalculateFactorialValidator>(ServiceLifetime.Transient);

            _services.AddSingleton<IServiceFactory, ServiceFactory>();
            _services.AddTransient<IFizzBuzzService, FizzBuzzService>();
            _services.AddTransient<IFactorialService, FactorialService>();

            var servicesProvider = _services.BuildServiceProvider();

            ServiceFactory = servicesProvider.GetRequiredService<IServiceFactory>();
        }
    }
}

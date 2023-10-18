using System.Numerics;
using UL.TestTest.Services.Factorial;

namespace UL.TechTest.Test
{
    [TestClass]
    public class FactorialTests : BaseTest
    {
        IFactorialService Service => ServiceFactory.GetFactorialService();

        [TestMethod]
        public async Task Calculate10Factorial()
        {
            //Arrange
            var request = new CalculateFactorialRequest(new BigInteger(10));

            //Act
            var result = await Service.CalculateAsync(request);

            //Assert
            Assert.AreEqual(3628800, result.Value);
        }

        [TestMethod]
        public async Task Calculate100Factorial()
        {
            //Arrange
            var request = new CalculateFactorialRequest(new BigInteger(100));

            //Act
            var result = await Service.CalculateAsync(request);

            //Assert
            Assert.AreEqual("93326215443944152681699238856266700490715968264381621468592963895217599993229915608941463976156518286253697920827223758251185210916864000000000000000000000000", result.Value.ToString());
        }

        [TestMethod]
        public async Task HandleAZeroInput()
        {
            //Arrange
            var request = new CalculateFactorialRequest(new BigInteger(0));

            //Act
            var result = await Service.CalculateAsync(request);

            //Assert
            Assert.AreEqual(false, result.IsSuccess);
        }

        [TestMethod]
        public async Task HandleANegativeInput()
        {
            //Arrange
            var request = new CalculateFactorialRequest(new BigInteger(-10));

            //Act
            var result = await Service.CalculateAsync(request);

            //Assert
            Assert.AreEqual(false, result.IsSuccess);
        }
    }
}

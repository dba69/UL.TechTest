using UL.TestTest.Services.FizzBuzz;

namespace UL.TechTest.Test
{
    [TestClass]
    public class FizzBuzzTests : BaseTest
    {
        IFizzBuzzService Service => ServiceFactory.GetFizzBuzzService();

        [TestMethod]
        public async Task CalculateTest()
        {
            //Arrange
            var request = new FizzBuzzRequest(1,100);

            //Act
            var result = await Service.CalculateAsync(request);

            var listResult = result.Value.ToList();

            //Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual("FizzBuzz", listResult[14]);
            Assert.AreEqual("Fizz", listResult[2]);
            Assert.AreEqual("Buzz", listResult[4]);
        }
    }
}

using MvcSuperShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcSuperShop.Integration.Tests.Services
{
    [TestClass]
    public class UserServiceTests
    {
        private readonly UserService sut;
        public UserServiceTests()
        {
            sut = new UserService();
        }

        [TestMethod]
        public void Calling_api_should_map_properties()
        {
            var result = sut.Generate();

            Assert.IsNotNull(result.Country);
            Assert.IsNotNull(result.City);
            Assert.IsNotNull(result.FirstName);
            Assert.IsNotNull(result.LastName);
            Assert.IsNotNull(result.Username);
        }
    }
}

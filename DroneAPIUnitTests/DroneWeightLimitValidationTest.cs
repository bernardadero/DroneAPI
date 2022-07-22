using DroneAPI.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit.Sdk;

namespace DroneAPIUnitTests
{
    [TestClass]
    public class DroneWeightLimitValidationTest
    {
        [TestMethod]
        public void MaximumWeight_Over500_ReturnsFalse()
        {
            decimal weight = 500;
            //Arrange
            
            //Act
           
            //Assert
            //Assert.IsTrue(result);
        }
    }
}
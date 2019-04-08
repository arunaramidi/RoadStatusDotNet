using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoadStatusDotNet;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Valid_RoadID()
        {
            
                ConsumeRoadStatus objAsync = new ConsumeRoadStatus();

                objAsync.GetValidRoad("A2");
            
        }

        [TestMethod]
        public void Test_InValid_RoadID()
        {
            try
            {

                ConsumeRoadStatus objAsync = new ConsumeRoadStatus();
            objAsync.GetValidRoad("A233");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(1 == 1);
            }
            Assert.IsTrue(0 == 1);

        }
    }
}

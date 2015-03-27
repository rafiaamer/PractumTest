
using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PractumTest;

namespace UnitTestPractum
{
    [TestClass]
    public class UnitTestPractum
    {
        public TestContext TestContext { get; set; }
        private Diner diner;
        [TestInitialize()]
        public void Setup()
        {
            diner = Program.SetupDiner();
        }


        [TestMethod]
        public void VerifyEggToastCoffee()
        {
            var result = diner.Serve("morning,1,2,3");

            Assert.AreEqual("eggs,toast,coffee", result);
        }

        [TestMethod]
        public void VerifyEggToastError()
        {
            var result = diner.Serve("morning,1,2,4");

            Assert.AreEqual("eggs,toast,error", result);
        }

        [TestMethod]
        public void VerifyEggToastCoffee2()
        {
            var result = diner.Serve("morning,2,1,3");

            Assert.AreEqual("eggs,toast,coffee", result);
        }
        
        [TestMethod]
        public void VerifyEggToastCoffeeError()
        {
            var result = diner.Serve("morning,1,2,3,4");

            Assert.AreEqual("eggs,toast,coffee,error", result);
        }

        [TestMethod]
        public void VerifyEggToast3Coffee()
        {
            var result = diner.Serve("morning,1,2,3,3,3");

            Assert.AreEqual("eggs,toast,coffee(x3)", result);
        }

        [TestMethod]
        public void VerifySteakPotato2Wine()
        {
            var result = diner.Serve("night,1,2,2,3");

            Assert.AreEqual("steak,potato(x2),wine", result);
        }

        [TestMethod]
        public void VerifySteakPotatoWineCake()
        {
            var result = diner.Serve("night,1,2,3,4");

            Assert.AreEqual("steak,potato,wine,cake", result);
        }

        [TestMethod]
        public void VerifySteakError()
        {
            var result = diner.Serve("night,1,1,2,3,5");

            Assert.AreEqual("steak,error", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void VerifyInvalidTimeOfDay()
        {
            var result = diner.Serve("evening,1,2,3");
            //Assert is implicit in ExpectedException
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void VerifyArgumentOutOfRangeException()
        {
            var result = diner.Serve("morning");
            //Assert is implicit in ExpectedException
        }

        //sample of a parameterized unite test
        [TestMethod]
        [DeploymentItem(@"..\..\dataForTest.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\dataForTest.xml", "entre", DataAccessMethod.Sequential)]
        public void VerifyTests()
        {
            

            var input = (string)TestContext.DataRow["input"];
            var expected = (string)TestContext.DataRow["result"];
            var result = diner.Serve(input);

            Assert.AreEqual(expected, result);
        }

        [TestCleanup()]
        public void Cleanup()
        {
            // We don't need to cleanup anything
        }


    }
}

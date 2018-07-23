using NUnit.Framework;
using ZdrojDatProNunit;

namespace MyNUnitTest
{
    [TestFixture]
    public class NUnitTest2
    {
        private MyMath myMath = null;

        //[TestFixtureSetUp()]
        //public void TestSetup()
        //{
        //    myMath = new MyMath();
        //}

        [SetUp]
        public void Initialize()
        {
            myMath = new MyMath(); // projde pri kazdem spusteni test metody. Ne jen jednou !!
        }

        [TearDown]
        public void CleanUp()
        {
            myMath = null; // projde pri kazdem spusteni test metody. Ne jen jednou !!
        }

        [TestCase]
        public void GetTextFRomX_Test()
        {
            var result = myMath.GetTextFromX();
            Assert.AreEqual(result, "ABCD");
        }

        [Test]
        public void IsPositiveNumber_Test()
        {
            var result = myMath.IsPositiveNumber(-1);
            Assert.IsFalse(result);
        }
    }
}
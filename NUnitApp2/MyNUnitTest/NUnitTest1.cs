using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using ZdrojDatProNunit;

namespace MyNUnitTest
{
    [TestFixture]

    public class NUnitTest1
    {
        [TestCase]
        public void Add_Test()
        {
            MyMath myMath = new MyMath();
            Assert.AreEqual(33, myMath.Add(11,22));
        }

        [Ignore("Nic01")]
        public void GetTextFRomX_Test()
        {
            MyMath myMath = new MyMath();
            var result = myMath.GetTextFromX();
            Assert.AreEqual(result, "ABCD");
        }

        [Ignore("Nic02")]
        public void IsPositiveNumber_Test()
        {
            MyMath myMath = new MyMath();
            var result = myMath.IsPositiveNumber(-1);
            Assert.IsFalse(result);
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        [Ignore("Nic03")]
        public void IsPositiveNumber2_Test(decimal value)
        {
            MyMath myMath = new MyMath();
            var result = myMath.IsPositiveNumber(value);
            Assert.IsFalse(result);
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        [Ignore("Nic04")]
        public void IsPositiveNumber3_Test(decimal value)
        {
            MyMath myMath = new MyMath();
            var result = myMath.IsPositiveNumber(value);
            Assert.That(result,Is.Not.Null.And.EqualTo(true));
        }
    }
}

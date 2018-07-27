using System.Diagnostics.Eventing.Reader;
using Moq;
using NUnit.Framework;
using ZdrojDatProNunit;

namespace MyNUnitTest
{
    [TestFixture]
    public class BankaTest
    {
        private MockRepository mocks;
        private Banka banka;
        [SetUp]
        public void Initialize()
        {
            // projde pri kazdem spusteni test metody. Ne jen jednou !!
            
        }

        [TearDown]
        public void CleanUp()
        {
            // projde pri kazdem spusteni test metody. Ne jen jednou !!
            mocks = null;
            banka = null;
        }

        [Ignore("tady se nepouziva mock")]
        public void TestWithoutUsingMockObjects()
        {
            User user = new User()
            {
                UserName = "Roman",
                Password = "ABCD"
            };

            banka = new Banka( new WebovaSluzba());
            var balance = banka.GetAccountBalanceByUser(user);
            Assert.AreEqual(100, balance);
        }

        [Test]
        public void TestWithtUsingMockObjects()
        {
            User user = new User()
            {
                UserName = "Roman",
                Password = "ABCD"
            };
            
            Mock<IWebovaSluzba> webSvc = new Mock<IWebovaSluzba>();
            webSvc.Setup(m => m.Autentification(user.UserName, user.Password)).Returns(true);
            //IgnoreArguments


            banka = new Banka(webSvc.Object);
            var balance = banka.GetAccountBalanceByUser(user);
            Assert.AreEqual(100, balance);
            webSvc.VerifyAll();  // Ověří všechna očekávání bez ohledu na to, zda byla označena jako ověřitelná.
        }
    }
}
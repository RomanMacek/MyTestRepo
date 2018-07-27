using System;
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

        [Ignore("S pouzitim moq")]
        public void TestWithtUsingMockObjects()
        {
            User user = new User()
            {
                UserName = "Roman",
                Password = "ABCD"
            };
            int valueA = 10;
            int valueB = 90;
            
            Mock<IWebovaSluzba> webSvc = new Mock<IWebovaSluzba>();
            //webSvc.Setup(m => m.Autentification(user.UserName, user.Password)).Returns(true);
            //IgnoreArguments

            //Mock<IWebovaSluzba> webSvc2 = new Mock<IWebovaSluzba>();
            //webSvc2.Setup(mq => mq.Autentification(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            //webSvc2.Setup(mq => mq.Autentification(It.Is<string>(x=> x.StartsWith("S")), It.IsAny<string>())).Returns(true);
            //webSvc2.Setup(mq => mq.Autentification(It.Is<string>(x => x.StartsWith("S")), It.IsAny<string>()))
            //    .Callback(() =>
            //    {
            //        Console.WriteLine("ABCD");
            //    })
            //    .Returns(true);


          //  Assert.AreEqual(100, balance);
            webSvc.VerifyAll();  // Ověří všechna očekávání bez ohledu na to, zda byla označena jako ověřitelná.
        }

        [Ignore("chybne volani callback")]
        public void TestCallback_ChybneVolani()
        {
            // https://www.codeproject.com/Articles/829232/moq-Callback-The-Unknown

            Mock<IWebovaSluzba> webSvc2 = new Mock<IWebovaSluzba>();
            User user = new User()
            {
                UserName = "Roman",
                Password = "ABCD"
            };
            int valueA = 10;
            int valueB = 90;

            ////TOTO JE CHYBNE POUZITI CALLBACKU.
            ////pravdepodobne se provede prvne setup + potom hned returns => asi nikdy nedojde k zavolani callbacku
            webSvc2.Setup(m => m.Autentification(user.UserName, user.Password))
                .Callback((IBlaBlaBla nejakaClassa) =>
                {
                    nejakaClassa.NejakaMetoda(valueA, valueB);
                })
                .Returns(true);
        }

        [Test]
        public void TestCallback_SpravneVolani()
        {
            Mock<IWebovaSluzba> webSvc2 = new Mock<IWebovaSluzba>();
            User user = new User()
            {
                UserName = "Roman",
                Password = "ABCD"
            };
            int valueA = 10;
            int valueB = 90;


        }
    }
}
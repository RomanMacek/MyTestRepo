using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using Moq;
using NUnit.Framework;
using ZdrojDatProNunit;

namespace MyNUnitTest
{
//    Assert.AreEqual(100, balance);
//webSvc.VerifyAll();  // Ověří všechna očekávání bez ohledu na to, zda byla označena jako ověřitelná.
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

        /// <summary>
        ///  Naplneni global property na classe
        /// </summary>
        [Ignore("Funkcni test")]
        public void Test_WithMockCallback_9()
        {
            var hodnota = "Nejaka hodnota";

            Mock<IBlaBlaBla> mock = new Mock<IBlaBlaBla>();
            mock.Setup(x => x.NejakaPromennaString).Returns(hodnota); // bude v promenne hodnota z promenne hodnota
            mock.SetupProperty(x => x.NejakaPromennaString);          // bude v promenne null hodnota
            mock.SetupProperty(x => x.NejakaPromennaString, hodnota); // bude v promenne hodnota z promenne hodnota

            var result = mock.Object.NejakaPromennaString;
        }

        /// <summary>
        /// Naplneni global property na classe (VerifySet mi nefunguje)
        /// </summary>
        [Ignore("NEFunkcni test")]
        public void Test_WithMockCallback_8()
        {
            var hodnota = "Nejaka hodnota";
            Mock<IBlaBlaBla> mock = new Mock<IBlaBlaBla>();
            
            mock.SetupProperty(x => x.NejakaPromennaString , hodnota);
            // toto mi nefunguje
            //mock.VerifySet(x => x.NejakaPromennaString = hodnota);    

            // toto mi nefunguje
            //mock.VerifySet((x) =>
            //{
            //    x.NejakaPromennaString = hodnota;
            //});

        
        }

        /// <summary>
        /// Naplneni nejake globalni proprerty na classe (nefunguje mi)
        /// </summary>
        [Ignore("Funkcni test")]
        public void Test_WithMockCallback_7()
        {
            Mock<IBlaBlaBla> mock = new Mock<IBlaBlaBla>();
            
            //mock.SetupSet(x => x.NejakaPromennaString = "Nejaka hodnota");

            mock.SetupSet((x) =>
            {
                x.NejakaPromennaString = "Nejaka hodnota";
            });
        }

        /// <summary>
        /// Plneni/vraceni hodnoty z globalni property na classe
        /// </summary>
        [Ignore("Funkcni test")]
        public void Test_WithMockCallback_6()
        {
            Mock<IBlaBlaBla> mock = new Mock<IBlaBlaBla>();
            mock.Setup(foo => foo.NejakaPromennaString).Returns("navratova hodnota");
        }

        /// <summary>
        /// Test vstupniho parametru, jestli je modulo 2
        /// </summary>
        [Ignore("Funkcni test")]
        public void Test_WithMockCallback_5()
        {
            Mock<IBlaBlaBla> mock = new Mock<IBlaBlaBla>();
            mock.Setup(foo => foo.GetUserAccount(It.Is<int>(i => i % 2 == 0))).Returns(0);
        }

        /// <summary>
        /// Predavani ref parametru
        /// </summary>
        [Ignore("Funkcni test")]
        public void Test_WithMockCallback_4()
        {            
            Mock<IBlaBlaBla> mcq = new Mock<IBlaBlaBla>();
            mcq.Setup(set => set.GetUserAccount(ref It.Ref<string>.IsAny))
                .Returns(0);
        }

        /// <summary>
        /// 2x volani callbacku s naplnenim externi promenne
        /// </summary>
        [Ignore("Funkcni test")]
        public void Test_WithMockCallback_3()
        {
            // returning different values on each invocation
            int count = 0;

            Mock<IBlaBlaBla> mcq = new Mock<IBlaBlaBla>();
            mcq.Setup(set => set.GetUserAccount(It.IsAny<int>()))
                .Callback(() => count ++)
                .Returns(() => count)
                .Callback(() => count++);

            var result = mcq.Object.GetUserAccount(11);
        }

        /// <summary>
        /// Ruzne volani callbacku
        /// </summary>
        [Ignore("Funkcni test")]
        public void Test_WithMockCallback_2()
        {
            Mock<IWebovaSluzba> webSvc2 = new Mock<IWebovaSluzba>();
            webSvc2.Setup(set => set.Autentification(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            List<int> accountList = null;
            BlaBlaBla blalBlaBlaBla = null;
            OrderBy orderBy;
            // v tomto Callbacku si pomoci promenne "o" ulozim vstupni parametr metody GetUserAccounts
            // napr pro overeni co mi tam doopravdy vstoupilo za hodnotu
            Mock<IBlaBlaBla> mcq2 = new Mock<IBlaBlaBla>();
            mcq2.Setup(set => set.GetUserAccounts(It.IsAny<OrderBy>()))
                .Returns(GetListInt())
                .Callback< OrderBy > ((o) =>
                {
                    orderBy = o;
                });

            Mock<IBlaBlaBla> mcq3 = new Mock<IBlaBlaBla>();
            mcq3.Setup(set => set.GetUserAccounts(It.IsAny<OrderBy>()))
                .Returns(GetListInt())
                .Callback((OrderBy o) =>
                {
                    orderBy = o;
                });

            Mock<IBlaBlaBla> mcq4 = new Mock<IBlaBlaBla>();
            mcq4.Setup(set => set.GetUserAccounts(It.IsAny<OrderBy>()))
                .Callback(() => { Debug.WriteLine("Before callback"); })
                .Returns(GetListInt())
                .Callback((OrderBy o) =>
                {
                    orderBy = o;
                    Debug.WriteLine("After callback");
                });

            var result = mcq4.Object.GetUserAccounts(OrderBy.Desc).ToList();

            Assert.AreEqual(GetListInt(), result);
            mcq4.VerifyAll();  // Ověří všechna očekávání bez ohledu na to, zda byla označena jako ověřitelná.
        }

        /// <summary>
        /// zakladni plneni vstupnich param do metod
        /// </summary>
        [Ignore("Funkcni test")]
        public void Test_WithMockCallback_1()
        {
            var id = 51;
            User user = new User()
            {
                UserName = "Roman",
                Password = "ABCD"
            };

            Mock<IWebovaSluzba> webSvc = new Mock<IWebovaSluzba>();
            webSvc.Setup(set => set.Autentification(user.UserName, user.Password))
                  .Returns(true);

            Mock<IWebovaSluzba> webSvc2 = new Mock<IWebovaSluzba>();
            webSvc2.Setup(set => set.Autentification(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            BlaBlaBla blaBlaBla = new BlaBlaBla(webSvc.Object);
            var account = blaBlaBla.GetUserAccount(id);

            Assert.AreEqual(id, account);
            webSvc.VerifyAll();  // Ověří všechna očekávání bez ohledu na to, zda byla označena jako ověřitelná.

        }

        [Ignore("tady se nepouziva mock")]
        public void Test_WithoutMock()
        {
            User user = new User()
            {
                UserName = "Roman",
                Password = "ABCD"
            };

            banka = new Banka(new WebovaSluzba());
            var balance = banka.GetAccountBalanceByUser(user);
            Assert.AreEqual(100, balance);
        }

        private List<int> GetListInt()
        {
            var result = new List<int>();
            for (int i = 0; i < 11; i++)
            {
                result.Add(i);
            }
            return result;
        }
    }
}
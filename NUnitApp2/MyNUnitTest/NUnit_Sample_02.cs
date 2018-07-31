using System;
using System.Diagnostics;
using Moq;
using NUnit.Framework;
using ZdrojDatProNunit;

namespace MyNUnitTest
{
    public class NUnit_Sample_02
    {
        [SetUp]
        public void Initialize()
        {
            // projde pri kazdem spusteni test metody. Ne jen jednou !!

        }

        [TearDown]
        public void CleanUp()
        {
            // projde pri kazdem spusteni test metody. Ne jen jednou !!
        }

        [Test]
        public void TestNo_03()
        {
            Mock<IBlaBlaBla> mock = new Mock<IBlaBlaBla>();
            mock.Raise(x => x.AddNewAccountEvent += null, 222, "Nejaka zprava");
        }

        /// <summary>
        /// Vyvolani udalosti, ktera ma v parametru odesilatele (sender)
        /// </summary>
        [Ignore("Neotestovano")]
        public void TestNo_02()
        {
            // Raising an event on the mock that has sender in handler parameters
            Mock<IBlaBlaBla> mock = new Mock<IBlaBlaBla>();
            mock.Raise(m => m.AddNewAccountEvent += null, this, Bla_AddNewAccountEvent(100, "abcd"));

           // Jen zkopirovana moznost, ale nevyzkousena tato moznost
           // Causing an event to raise automatically when Submit is invoked
           // mock.Setup(foo => foo.Submit()).Raises(f => f.Sent += null, EventArgs.Empty);
        }

        /// <summary>
        /// Vyvolani udalosti - zakladni
        /// </summary>
        [Ignore("Funkcni")]
        public void TestNo_01()
        {
            var hodnota = "Nejaka hodnota";
            
            Mock<IBlaBlaBla> mock = new Mock<IBlaBlaBla>();
            mock.Raise(m => m.AddNewAccountEvent += null, Bla_AddNewAccountEvent(100, hodnota));

        }

        //private void TestNormal()
        //{
        //    BlaBlaBla bla = new BlaBlaBla(webSvc.Object);
        //    bla.AddNewAccountEvent += Bla_AddNewAccountEvent;
        //    bla.AddNewAccount(101, "Muj ucet");
        //}

        private bool Bla_AddNewAccountEvent(int accountId, string name)
        {
            Debug.WriteLine(accountId, name);
            Debug.WriteLine( name, accountId);
            Debug.WriteLine(accountId);
            Debug.WriteLine( name);
            return true;
        }
    }
}
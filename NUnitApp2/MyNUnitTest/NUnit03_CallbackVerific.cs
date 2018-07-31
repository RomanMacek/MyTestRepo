using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using ZdrojDatProNunit;

namespace MyNUnitTest
{
    public class NUnit03_CallbackVerific
    {
        [Test]
        public void AAA()
        {
            var repository = new MockRepository(MockBehavior.Strict)
            {
                DefaultValue = DefaultValue.Mock
            };

            var webSvc = repository.Create<IWebovaSluzba>();
            webSvc.Setup(set => set.Autentification(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            var bbb = repository.Create<IBlaBlaBla>(MockBehavior.Loose);

            var blaBla = new BlaBlaBla(webSvc.Object);
            var accountList = blaBla.GetUserAccounts();

            var blaBla2 = new BlaBlaBla(webSvc.Object);
            var resultCheckUser = blaBla2.CheckUserAccount("aaa", "bbb");

            // Verify all verifiable expectations on all mocks created through the repository
            repository.Verify();
        }

        [Ignore("OK")]
        public void TestVerifyTimes()
        {
            Mock<IBlaBlaBla> mock = new Mock<IBlaBlaBla>();

            mock.Setup(m => m.GetUserAccounts(It.IsAny<OrderBy>()))
                .Returns(GetListInt());

            mock.Verify( m => m.GetUserAccounts(OrderBy.Desc), Times.Never);

            // zalezi na hodnote parametru v zavorce. Testuje se jak volani konkretni metody,
            // tak i shodna hodnota v parametru metody
            //var result = mock.Object.GetUserAccounts(OrderBy.Desc);
            //mock.Verify(m => m.GetUserAccounts(OrderBy.Desc), Times.Once);

            //result = mock.Object.GetUserAccounts(OrderBy.Desc);
            //mock.Verify(m => m.GetUserAccounts(OrderBy.Desc), Times.Exactly(2));

            //mock.Verify(m => m.GetUserAccounts(OrderBy.Desc), Times.AtLeastOnce);
            //mock.Verify(m => m.GetUserAccounts(OrderBy.Desc), Times.AtLeast(2));
            //mock.Verify(m => m.GetUserAccounts(OrderBy.Desc), Times.AtMost(2));
            //mock.Verify(m => m.GetUserAccounts(OrderBy.Desc), Times.Between(0,3, Range.Inclusive));

            mock.Setup(m => m.NejakaPromennaString).Returns("ABCD");

            mock.Object.NejakaPromennaString = "123";
            mock.VerifySet(m => m.NejakaPromennaString);
            mock.VerifySet(m => m.NejakaPromennaString = "123"); // zkontroluje, jestli bylo do promenne prirazena konkretni hodnota
            //mock.VerifySet(foo => foo.Value = It.IsInRange(1, 5, Range.Inclusive));
            mock.VerifyNoOtherCalls();

            var nejakaPromenna = mock.Object.NejakaPromennaString;
            mock.VerifyGet(m => m.NejakaPromennaString);
        }

        [Ignore("OK")]
        public void TestCallback()
        {
            var calls = 0;
            var callArgs = new List<string>();
            Mock<IBlaBlaBla> mock = new Mock<IBlaBlaBla>();

            mock.Setup(set => set.GetUserAccount(It.IsAny<int>()))
                .Returns(110)
                .Callback((int inputValue) => calls++);

            var result = mock.Object.GetUserAccount(11);

            mock.Setup(set => set.GetUserAccount(It.IsAny<int>()))
                .Returns(120)
                .Callback((int inputValue) =>
                {
                    callArgs.Add(inputValue.ToString());
                    calls++;
                    callArgs.Add(inputValue.ToString());
                });

            result = mock.Object.GetUserAccount(21);

            mock.Setup(set => set.GetUserAccount(ref It.Ref<string>.IsAny))
                .Returns(130)
                .Callback((string inputValue) =>
                {
                    calls++;
                    callArgs.Add(inputValue);
                });
            var id = "41";
            var resultInt = mock.Object.GetUserAccount(ref id);
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

// http://www.blackwasp.co.uk/MoqTimes.aspx
// mock.Verify( m => m.GetUserAccounts(OrderBy.Desc), Times.Never);

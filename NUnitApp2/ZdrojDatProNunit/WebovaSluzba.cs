using System.Threading;

namespace ZdrojDatProNunit
{
    public class WebovaSluzba : IWebovaSluzba
    {
        public bool Autentification(string username, string password)
        {
            Thread.Sleep(5000);
            return true;
        }

    }
}
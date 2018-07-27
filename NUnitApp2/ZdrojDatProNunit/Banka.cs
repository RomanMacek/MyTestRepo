using System.Security;

namespace ZdrojDatProNunit
{
    public class Banka
    {
        private IWebovaSluzba WebovaSluzba;

        public Banka(IWebovaSluzba webovaSluzba)
        {
            WebovaSluzba = webovaSluzba;
        }

        public double GetAccountBalanceByUser(User user)
        {
            bool isAutentificate = WebovaSluzba.Autentification(user.UserName, user.Password);
            if (!isAutentificate)
            {
                throw new SecurityException("User is not authentificated");
            }
            return 100;
        }
    }
}
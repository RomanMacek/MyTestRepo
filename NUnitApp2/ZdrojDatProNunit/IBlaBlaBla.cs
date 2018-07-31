using System.Collections.Generic;

namespace ZdrojDatProNunit
{
    public interface IBlaBlaBla
    {
        bool CheckUserAccount(string userName, string password);
        int GetUserAccount(int id);
        int? GetUserAccount(ref string id);
        List<int> GetUserAccounts();
        List<int> GetUserAccounts(OrderBy orderBy);

        string NejakaPromennaString { get; set; }

        event BlaBlaBla.AddNewAccountEventArgs AddNewAccountEvent;
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ZdrojDatProNunit
{
    public class BlaBlaBla : IBlaBlaBla, IDisposable
    {
        private List<int> AccountNumberList;
        private IWebovaSluzba WebSvc;
        public string NejakaPromennaString { get; set; }

        public delegate bool AddNewAccountEventArgs(int accountId, string name);

        public event AddNewAccountEventArgs AddNewAccountEvent;



        public BlaBlaBla(IWebovaSluzba webSvc)
        {
            WebSvc = webSvc;
            FillAccountNumberList();
        }

        public bool CheckUserAccount(string userName, string password)
        {
            return WebSvc.Autentification(userName, password);
        }

        private void FillAccountNumberList()
        {
            AccountNumberList = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                AccountNumberList.Add(i);
            }
        }

        public bool AddNewAccount(int accountId, string name)
        {
            if (AccountNumberList == null)
            {
                AccountNumberList = new List<int>();
            }
            AccountNumberList.Add(accountId);

            AddNewAccountEvent?.Invoke(accountId, name);

            return true;
        }

        private bool BlaBlaBla_AddNewAccountEvent(int accountId, string name)
        {
            throw new NotImplementedException();
        }

        public int GetUserAccount(int id)
        {
            return AccountNumberList.FirstOrDefault(x => x == id);
        }

        public int? GetUserAccount(ref string id)
        {
            int idInt;
             if (!Int32.TryParse(id, out idInt))
             {
                 return null;
             }
            return AccountNumberList.FirstOrDefault(x => x == idInt);
        }

        public List<int> GetUserAccounts()
        {
            return AccountNumberList.OrderByDescending(x => x).ToList();
        }

        public List<int> GetUserAccounts(OrderBy orderBy)
        {
          //  OrderBy orderBy = OrderBy.Desc;
            if (orderBy == OrderBy.Asc)
            {
                return AccountNumberList.OrderBy(x => x).ToList();
            }
            return AccountNumberList.OrderByDescending(x => x).ToList();
        }

        public void Dispose()
        {
            Debug.Write("Disposable");
        }
    }

    public enum OrderBy
    {
        Asc,
        Desc
    }
}
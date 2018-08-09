using System.Collections.Generic;

namespace MyRestService.Business.Interfaces
{
    public interface IUserBusiness
    {
        string GetOneValue(int id);
        IEnumerable<string> GetAllValues();
    }
}
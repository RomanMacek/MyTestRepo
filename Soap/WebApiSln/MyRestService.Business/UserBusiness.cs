using System;
using System.Collections.Generic;
using MyRestService.Business.Interfaces;
using MyRestService.Repository.Interfaces;

namespace MyRestService.Business
{
    public class UserBusiness : IUserBusiness, IDisposable
    {
        private IUserRepository _userRepository;

        public UserBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string GetOneValue(int id)
        {
            return $@"Hodnota ziskana z UserBusiness.GetOneValue({id})";
        }

        public IEnumerable<string> GetAllValues()
        {
            return new string[] { "GetAllValues1", "GetAllValues2" };
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }
            _userRepository = null;
        }
    }
}
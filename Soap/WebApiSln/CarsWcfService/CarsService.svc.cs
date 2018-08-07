using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CarsWcfService
{
    public class CarsService : ICarsService
    {

        private List<Car> CarList;

        public CarsService()
        {
            CarList = new List<Car>
            {
                new Car() {Name = "prvni auto", Places = 2},
                new Car() {Name = "druhe auto", Places = 3}
            };
        }

        public bool AddCar(Car car)
        {
            CarList.Add(car);
            return true;
        }

        public List<Car> GetCars()
        {
            return CarList;
        }
    }
}

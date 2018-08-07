using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// https://www.youtube.com/watch?v=GzN1vHWlJjA

namespace CarsWcfService
{
    [ServiceContract]
    public interface ICarsService
    {
        [OperationContract]
        bool AddCar(Car car);

        [OperationContract]
        List<Car> GetCars();

    }
}

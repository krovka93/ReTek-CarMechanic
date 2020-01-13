using ReTek_CarMechanical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReTek_CarMechanical.Interfaces
{
    interface ICar
    {
        bool UploadNewCar(Car newCar);
        bool UpdateExistingCar(Car existingCar);
        Car GetSingleCar(Car oneCar);
        List<Car> GetAllCar();
    }
}

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
        bool GetSingleCar(Car oneCar);
        bool GetAllCar();
    }
}

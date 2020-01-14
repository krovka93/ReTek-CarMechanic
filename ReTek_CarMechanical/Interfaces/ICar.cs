using ReTek_CarMechanical.Models;
using System.Collections.Generic;

namespace ReTek_CarMechanical.Interfaces
{
    interface ICar
    {
        bool UploadNewCar(Car newCar);
        bool UpdateExistingCar(Car existingCar);
        List<Car> GetAllCar();
        List<Car> GetAllCarByUser(Client selectedClient);

    }
}

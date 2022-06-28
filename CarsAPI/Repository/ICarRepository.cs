using CarsAPI.Models;
using System.Collections.Generic;

namespace CarsAPI.Repository
{
    public interface ICarRepository
    {
        Car AddCar(Car car);
        List<Car> GetAllCars();
        Car GetCarById(int id);
        bool UpdateCar(int id, Car car);
        bool DeleteCar(int id);



    }
}

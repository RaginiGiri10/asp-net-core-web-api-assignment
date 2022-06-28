using CarsAPI.DBContext;
using CarsAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarsAPI.Repository
{
    public class CarRepository : ICarRepository
    {
        CarDbContext _carDbContext;
        public CarRepository(CarDbContext carDbContext)
        {
            _carDbContext = carDbContext;
        }

        public Car AddCar(Car car)
        {
            _carDbContext.Cars.Add(car);
            _carDbContext.SaveChanges();
            return car;

        }
        public List<Car> GetAllCars()
        {
            return _carDbContext.Cars.ToList();
        }

        public Car GetCarById(int id)
        {
            return _carDbContext.Cars.FirstOrDefault(p => p.Id == id);
        }

        public bool UpdateCar(int id, Car car)
        {
            bool isCarUpdated = false;
            var carTobeUpdated = _carDbContext.Cars.FirstOrDefault(p => p.Id == id);



            if (carTobeUpdated != null)
            {
                carTobeUpdated.Name = car.Name;
                carTobeUpdated.Category = car.Category;
                carTobeUpdated.Price = car.Price;
                _carDbContext.SaveChanges();
                isCarUpdated = true;
            }
            return isCarUpdated;

        }
        public bool DeleteCar(int id)
        {
            bool isCarRemoved = false;
            var carTobeRemoved = _carDbContext.Cars.FirstOrDefault(p => p.Id == id);
            if (carTobeRemoved != null)
            {
                _carDbContext.Cars.Remove(carTobeRemoved);
                _carDbContext.SaveChanges();
                isCarRemoved = true;
            }
            return isCarRemoved;

        }
    }
}

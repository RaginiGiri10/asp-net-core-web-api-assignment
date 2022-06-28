using CarsAPI.Models;
using CarsAPI.Repository;
using CarsAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ICarRepository _carRepository;
        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        [HttpPost]
        public IActionResult AddCar([FromBody] AddCarViewModel addCarViewModel)
        {
            Car car = new Car
            {
                Name = addCarViewModel.Name,
                Category = addCarViewModel.Category,
                Price = addCarViewModel.Price
            };

            var addedCar = _carRepository.AddCar(car);
            return Ok(addedCar);

        }



        [HttpGet]
        public IActionResult GetCars()
        {
            var cars = _carRepository.GetAllCars();
            if (cars == null)
            {
                NotFound("No Cars Found!!!");
            }

            return Ok(cars);
        }
        [HttpGet("{id}")]
        public IActionResult GetCarById(int id)
        {
            var car = _carRepository.GetCarById(id);
            if (car == null)
            {
                return NotFound($"Car with id ={id} is not found");
            }
            return Ok(car);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCar(int id, [FromBody] UpdateViewModel updateViewModel)
        {
            Car car = new Car
            {
                Name = updateViewModel.Name,
                Category = updateViewModel.Category,
                Price = updateViewModel.Price
            };

            bool isCarUpdated = _carRepository.UpdateCar(id, car);

            if (!isCarUpdated)
            {
                return NotFound($"Car with id = {id} is not found.");
            }
            return Ok($"Car with id = {id} is updated successfully.");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            bool isCarRemoved = _carRepository.DeleteCar(id);
            if (!isCarRemoved)
            {
                return NotFound($"Car with id = {id} is not found.");
            }
            return Ok($"Car with id = {id} is removed successfully.");
        }


       







    }
}

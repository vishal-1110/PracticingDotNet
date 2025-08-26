using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticingDotNet.Data;
using PracticingDotNet.Model;
using PracticingDotNet.Model.Entities;

namespace PracticingDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public CarsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllCars() 
        {
            var cars = dbContext.Cars.ToList();
            return Ok(cars);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetCarById(int id) 
        {
            var car = dbContext.Cars.Find(id);
            if (car == null) { return NotFound("Id not found"); }
            return Ok(car);
        }

        [HttpPut]
        public IActionResult PutCars(AddCarsDto addCarsDto)
        {
            var carsEntity = new Car()
            {
                Company = addCarsDto.Company,
                Model = addCarsDto.Model,
                Year = addCarsDto.Year,
                Price = addCarsDto.Price
            };
            dbContext.Cars.Add(carsEntity);
            dbContext.SaveChanges();
            return Ok(carsEntity);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateCar(int id, UpdateCarDto updateCarDto)
        {
            var car = dbContext.Cars.Find(id);
            if (car == null) { return NotFound("Id not found"); }
            car.Model = updateCarDto.Model;
            dbContext.SaveChanges();
            return Ok(car);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteCar(int id)
        {
            var car = dbContext.Cars.Find(id);
            if (car == null) { return NotFound("Id not found"); }
            dbContext.Cars.Remove(car);
            dbContext.SaveChanges();
            return Ok("Deleted the details regarding the given Id");
        }
    }
}

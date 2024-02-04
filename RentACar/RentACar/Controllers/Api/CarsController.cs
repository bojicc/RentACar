using AutoMapper;
using RentACar.Dtos;
using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RentACar.Controllers.Api
{
    public class CarsController : ApiController
    {
        private RentACarEntities _context;

        public CarsController()
        {
            _context = new RentACarEntities();
        }

        //GET /api/cars
        public IEnumerable<CarDto> GetCars()
        {
            return _context.Cars.ToList().Select(Mapper.Map<Car, CarDto>);      
        }

        //GET /api/cars/1
        public IHttpActionResult GetCar(int id)
        {
            var car = _context.Cars.SingleOrDefault(c => c.CarId == id);
            if (car == null)
                return NotFound();

            return Ok(Mapper.Map<Car, CarDto>(car));
        }

        //POST /api/cars
        [HttpPost]
        public IHttpActionResult CreateCar(CarDto carDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
           
            var car = Mapper.Map<CarDto, Car>(carDto);
            _context.Cars.Add(car);
            _context.SaveChanges();

            carDto.CarId = car.CarId;
            return Created(new Uri(Request.RequestUri + "/" + car.CarId), carDto);
        }

        //PUT /api/cars/1
        [HttpPut]
        public IHttpActionResult UpdateCar(int id, CarDto carDto)
        {                                                                           
            if (!ModelState.IsValid)
                return BadRequest();

            var carInDb = _context.Cars.SingleOrDefault(c => c.CarId == id);

            if (carInDb == null)
                return NotFound();

            Mapper.Map(carDto, carInDb);

            _context.SaveChanges();

            return Ok();
        }


        //DELETE /api/cars/1
        [HttpDelete]
        public IHttpActionResult DeleteCar(int id)
        {
            var carInDb = _context.Cars.SingleOrDefault(c => c.CarId == id);

            if (carInDb == null)
                return NotFound();

            _context.Cars.Remove(carInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}

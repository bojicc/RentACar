using RentACar.Dtos;
using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;

namespace RentACar.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private RentACarEntities _context;

        public RentalsController()
        {
            _context = new RentACarEntities();
        }

        //GET /api/rentals
        public IEnumerable<RentalDto> GetRentals()
        {
            var rental = _context.Rentals.Include(c => c.Car).Include(c => c.Customer);
            return rental.ToList().Select(Mapper.Map<Rental, RentalDto>);
        }

        //GET /api/rentals/1
        public IHttpActionResult GetRental(int id)
        {
            var rental = _context.Rentals.SingleOrDefault(c => c.RentalId == id);
            if (rental == null)
                return NotFound();

            return Ok(Mapper.Map<Rental, RentalDto>(rental));
        }

        //POST /api/rentals
        public IHttpActionResult CreateRental(RentalDto rentalDto)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var rental = Mapper.Map<RentalDto, Rental>(rentalDto);
            _context.Rentals.Add(rental);
            _context.SaveChanges();

            rentalDto.RentalId = rental.RentalId;

            return Created(new Uri(Request.RequestUri + "/" + rental.RentalId), rentalDto);
        }

        //PUT /api/rentals/1
        [HttpPut]
        public IHttpActionResult UpdateRental(int id, RentalDto rentalDto)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var rentalInDb = _context.Rentals.SingleOrDefault(c => c.RentalId == id);

            if(rentalInDb == null)
                return NotFound();

            Mapper.Map(rentalDto, rentalInDb);

            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/rentals/1
        [HttpDelete]
        public IHttpActionResult DeleteRental(int id) 
        {
            var rentalInDb = _context.Rentals.SingleOrDefault(c => c.RentalId == id);

            if(rentalInDb == null)
                return NotFound();

            _context.Rentals.Remove(rentalInDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}

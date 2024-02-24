using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.Dtos
{
    public class RentalDto
    {
        public int RentalId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<int> CarId { get; set; }
        public Nullable<System.DateTime> DateRented { get; set; }
        public Nullable<System.DateTime> DateReturned { get; set; }

        public CarDto Car { get; set; }
        public CustomerDto Customer { get; set; }
    }
}
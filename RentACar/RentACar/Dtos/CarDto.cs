using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.Dtos
{
    public class CarDto
    {
        public int CarId { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<bool> Available { get; set; }
    }
}
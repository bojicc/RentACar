using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.Dtos
{
    public class CustomerDto
    {
        public int CustomerId{ get; set; }
        public string Name { get; set; }
        public string DriverLicNo { get; set; }
    }
}
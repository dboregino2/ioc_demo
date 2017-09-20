using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcmeStorageUnitRental.Models
{
    public class StorageUnit
    {
        public int UnitNumber { get; set; }
        public string Size { get; set; }
        public string MonthlyCost { get; set; }
        public bool CurrentlyRented { get; set; }

    }
}
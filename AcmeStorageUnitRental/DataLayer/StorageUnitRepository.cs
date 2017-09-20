using AcmeStorageUnitRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcmeStorageUnitRental.DataLayer
{
    public class StorageUnitRepository : IStorageUnitRepository
    {
        private List<StorageUnit> StorageUnits;
        public StorageUnitRepository()
        {
            InitStorageUnits();
        }        
  
        public List<StorageUnit> GetStorageUnits()
        {
            return StorageUnits;
        }

        public List<StorageUnit> GetAvailableStorageUnits()
        {
            return new List<StorageUnit>(StorageUnits.Where(u =>
            u.CurrentlyRented == false));

        }
        public StorageUnit GetStorageUnit(int unitnumber)
        {
            return StorageUnits.Where(u => u.UnitNumber == unitnumber).FirstOrDefault();
        }



        private void InitStorageUnits()
        {
            StorageUnits = new List<StorageUnit>();
            StorageUnits.Add(new StorageUnit()
            {
                UnitNumber = 101,
                CurrentlyRented = false,
                MonthlyCost = "$120.00",
                Size = "12 x 12"

            });

            StorageUnits.Add(new StorageUnit()
            {
                UnitNumber = 102,
                CurrentlyRented = true,
                MonthlyCost = "$120.00",
                Size = "12 x 12"

            });

            StorageUnits.Add(new StorageUnit()
            {
                UnitNumber = 103,
                CurrentlyRented = true,
                MonthlyCost = "$90.00",
                Size = "8 x 8"

            });


            StorageUnits.Add(new StorageUnit()
            {
                UnitNumber = 104,
                CurrentlyRented = false,
                MonthlyCost = "$90.00",
                Size = "8 x 8"

            });

            StorageUnits.Add(new StorageUnit()
            {
                UnitNumber = 105,
                CurrentlyRented = false,
                MonthlyCost = "$130.00",
                Size = "15 x 15"

            });


        }
    }
}
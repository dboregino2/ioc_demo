using System.Collections.Generic;
using AcmeStorageUnitRental.Models;

namespace AcmeStorageUnitRental.DataLayer
{
    public interface IStorageUnitRepository
    {
        List<StorageUnit> GetAvailableStorageUnits();
        StorageUnit GetStorageUnit(int unitnumber);
        List<StorageUnit> GetStorageUnits();
    }
}
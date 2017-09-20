using AcmeStorageUnitRental.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcmeStorageUnitRental.Controllers
{
    public class StorageUnitsController : Controller
    {
        private IStorageUnitRepository _storageUnitRepository;
        public StorageUnitsController(IStorageUnitRepository storageUnitRepository)
        {
            _storageUnitRepository = storageUnitRepository;
        }
       
        public ActionResult Index()
        {
            return View(_storageUnitRepository.GetStorageUnits());
        }
       
    }
}
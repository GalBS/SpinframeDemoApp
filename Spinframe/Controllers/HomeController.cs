using Common.Models;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Spinframe.Models;
using System;
using System.Diagnostics;

namespace Spinframe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var cars = _unitOfWork.Cars.GetAll();

            return View(cars);
        }

        public IActionResult SaveCar(Car car)
        {
            try
            {
                if (car.Id == 0) //determine whether it's a new car or an existing one to edit.
                {
                    if (_unitOfWork.Cars.GetCarByLicensePlate(car.LicensePlate) != null) //check whether there's another car with the same license plate already in the database.
                    {
                        TempData["Message"] = "The car with the given license plate already exists.";

                        return RedirectToAction("Index");
                    }

                    _unitOfWork.Cars.Add(car);
                }
                else
                {
                    _unitOfWork.Cars.Update(car);
                }

                _unitOfWork.Complete(); //save the changes to the database in both cases.
            }
            catch (Exception e)
            {
                TempData["Message"] = "Something failed.";

                _logger.LogError(e.Message);
            }

            return RedirectToAction("Index");
        }

        public IActionResult DeleteCar(int carId)
        {
            try
            {
                var car = _unitOfWork.Cars.Get(carId);
                _unitOfWork.Cars.Remove(car);

                _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                TempData["Message"] = "Something failed.";

                _logger.LogError(e.Message);
            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

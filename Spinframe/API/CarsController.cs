using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Spinframe.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Spinframe.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public CarsController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        // GET: api/<CarsController>
        [HttpGet]
        public IActionResult Get()
        {
            var cars = _unitOfWork.Cars.GetAll();

            return new JsonResult(cars);
        }

        // GET api/<CarsController>/5
        [HttpGet("{licensePlate}")]
        public IActionResult Get(string licensePlate)
        {
            var car = _unitOfWork.Cars.GetCarByLicensePlate(licensePlate);

            if (car == null) return NotFound("The car with the given license plate was not found.");

            return new JsonResult(car);
        }
    }
}

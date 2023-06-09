using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ICarService _carService;
        
        public CarController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {

            //Thread.Sleep(5000);
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getbyId")]
        public IActionResult GetById(int carId)
        {
            var result = _carService.GetById(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getCarByBrandIdAndColorId")]
        public IActionResult getCarByBrandIdAndColorId(int colorId, int brandId)
        {
            var result = _carService.GetCarByBrandIdAndColorId(colorId,brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetCarDetailByCarId")]
        public IActionResult GetCarDetailByCarId(int carId)
        {
            var result = _carService.GetCarDetailByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getcardetaildto")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetCarDetailWithImagesByCarId")]
        public IActionResult GetCarDetailWithImagesByCarId(int carId)
        {
            var result = _carService.GetCarDetailWithImagesByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}

using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _brandService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getbyıd")]
        public IActionResult Get(int brandId)
        {
            var result = _brandService.GetById(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();

        }

        [HttpGet("getCarByBrandId")]
        public IActionResult GetCarByBrandId(int brandId)
        {
            var result = _brandService.GetCarByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();

        }

        [HttpPost("add")]
        public IActionResult Add(Brand brand)
        {
            var result = _brandService.Add(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("update")]
        public IActionResult Update(Brand brand)
        {
            var result = _brandService.Update(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("delete")]
        public IActionResult Delete(Brand brand)
        {
            var result = _brandService.Delete(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}

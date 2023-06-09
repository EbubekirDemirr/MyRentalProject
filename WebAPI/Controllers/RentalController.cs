using Business.Abstract;
using Entities.Concrete;
using Entities.Concrete.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }
        [HttpGet("getrentaldetail")]
        public IActionResult GetRentalDetail()
        {
            var result =_rentalService.GetRentalDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _rentalService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("add")]
        public IActionResult Add([FromBody]CreateRental createRental)
        {
            var result = _rentalService.Add(createRental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalService.Delete(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("iscaravaible")]
        public IActionResult IsCarAvaible(int cardId)
        {
            var result = _rentalService.IsCarAvaible(cardId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("totalprice")]
        public IActionResult TotalPrice(DateTime rentDate, DateTime returnDate, int carId, object totalAmount)
        {
            var result = _rentalService.CalculateTotalPrice( rentDate,  returnDate, carId);
            if (result!=null)
            {
            return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

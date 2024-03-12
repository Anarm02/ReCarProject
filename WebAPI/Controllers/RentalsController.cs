using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;
        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result= _rentalService.GetAll();
            if (result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result=_rentalService.Get(id);
            if (result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result=_rentalService.Add(rental);
            if (result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(Rental rental)
        {
            var result=_rentalService.Update(rental);
            if (result.success)
            {
                return Ok(result);
            }
                return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result=_rentalService.Delete(rental);
            if (result.success)
            {
                return Ok(result);
            }
                return BadRequest(result);
        }
        [HttpPut("deliver")]
        public IActionResult Deliver(int id)
        {
            var result=_rentalService.CarDelivery(id);
            if (result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }

}

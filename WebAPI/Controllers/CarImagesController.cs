using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService; 
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result=_carImageService.GetImages();
            if (result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile file,[FromForm]  CarImage img) {
            var result = _carImageService.Add(file, img) ;
            if (result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
            //return Ok(Request.Form);




        }
        [HttpPut("update")]
        public IActionResult Update([FromForm] IFormFile file,[FromForm] CarImage img) {
        var result=_carImageService.Update(file, img);
            if (result.success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result=_carImageService.Delete(carImage);
            if (result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getimagesbycarid")]
        public IActionResult GetImagesByCarId(int carId)
        {
            var result=_carImageService.GetImagesByCarId(carId);
            if (result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getimage")]
        public IActionResult GetImage(int id)
        {
            var result=_carImageService.GetImage(id);
            if (result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

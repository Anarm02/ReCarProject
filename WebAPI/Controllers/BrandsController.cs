﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BrandsController : ControllerBase
	{
		private readonly IBrandService _brandService;

		public BrandsController(IBrandService brandService)
		{
			_brandService = brandService;
		}
		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			var result= _brandService.GetAll();
			if (result.success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpGet("getbyid")]
		public IActionResult GetById(int id)
		{
			var result = _brandService.GetById(id);
			if (result.success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpPost("add")]
		public IActionResult Add(Brand brand)
		{
			var result=_brandService.Add(brand);
			if (result.success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpPut("update")]
		public IActionResult Update(Brand brand)
		{
			var result=_brandService.Update(brand);
			if(result.success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpDelete("delete")]
		public IActionResult Delete(Brand brand)
		{
			var result =_brandService.Delete(brand);
			if (result.success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
	}
}

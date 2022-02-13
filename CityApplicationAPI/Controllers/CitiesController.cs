using AutoMapper;
using CityBL.Dto;
using CityBL.InterFace;
using CityDAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace CityApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICity c;
        private readonly IMapper m;
        public CitiesController(ICity c, IMapper m)
        {

            this.c = c;
            this.m = m;
        }
        [HttpGet]
        public IActionResult GetAllCities()
        {
            var data = m.Map<IEnumerable<CityDto>>(c.GetAllCities());
            return Ok(data);

        }
        [HttpPost("{id}")]
        public IActionResult GetCity(int id)
        {
            var data = m.Map<CityDto>(c.GetCity(id));
            if (data == null)
            {
                return NotFound("no data");

            }
            return Ok(data);


        }
        [HttpPost]
        public IActionResult PostCity([FromForm] CityDto city)
        {
            try
            {
                if (city.Logo == null)
                {
                    return BadRequest("Logo is mandatory");
                }

                using var datastream = new MemoryStream();
                city.Logo.CopyTo(datastream);

                var data = m.Map<City>(city);
                data.Logo = datastream.ToArray();
                var res = c.AddCity(data);
                return Ok(res);


            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }



        }
        [HttpPut("{id}")]
        public IActionResult PutCity(int id, [FromForm] CityDto city)
        {
            var city2 = c.GetCity(id);
            try
            {
                if (city.Logo == null)
                {
                    return BadRequest("Logo is mandatory");
                }

                using var datastream = new MemoryStream();
                city.Logo.CopyTo(datastream);
                city2.Logo = datastream.ToArray();
                using var dataStream = new MemoryStream();



                //var data = m.Map<City>(city);
                city2.Name = city.Name;

                c.UpdateCity(city2);
                return Ok(city2);


            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }



        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id )
        { 
        var data=c.GetCity(id);
            var deleted=  c.DeleteCity(data);
            return Ok(deleted);
        
        
        }
    }
}

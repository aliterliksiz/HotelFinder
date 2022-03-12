using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // [ApiController] attribute'u validation işlemlerini kendisi yapıyor
    public class HotelsController : ControllerBase
    {
        private IHotelService _hotelService;
        public HotelsController()
        {
            _hotelService = new HotelManager();
        }

        /// <summary>
        /// Get all hotels
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult Get()
        {
            var hotels = _hotelService.GetAllHotels();
            return Ok(hotels); //200 + data
        }

        /// <summary>
        /// Get hotel by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetHotelById(int id)
        {
            var hotel = _hotelService.GetHotelById(id);
            if (hotel != null)
            {
                return Ok(hotel); //200 + data
            }
            return NotFound(); //404
        }

        [HttpGet]
        [Route("[action]/{name}")]
        public IActionResult GetHotelByName(string name)
        {
            var hotel = _hotelService.GetHotelByName(name);
            if (hotel != null)
            {
                return Ok(hotel); //200 + data
            }
            return NotFound();
        }

        [HttpGet]
        [Route("[action]/{id}/{name}")]
        public IActionResult GetHotelByIdWithName(int id, string name)
        {
            return Ok();
        }
        //burada id ve name ile aramak için bir fonksiyon yazdık bunu query string ile yazmak daha iyidir
        //localhost:XXXXX/api/hotels/GetHotelByIdWithName?id=3&name=titanic


        //Actionları artık route attribute'u ile kullanacağız

        /// <summary>
        /// Create a hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("[action]")] //CreateHotel=[action]
        public IActionResult CreateHotel([FromBody]Hotel hotel)
        {

            //Validation işlemi

            //if (ModelState.IsValid)
            //{
            //    var createdHotel = _hotelService.CreateHotel(hotel);
            //    return CreatedAtAction("Get", new { id = createdHotel.Id }, createdHotel); //201 + data
            //}
            //return BadRequest(ModelState); // 400 + validation errors


            var createdHotel = _hotelService.CreateHotel(hotel);
            return CreatedAtAction("Get", new { id = createdHotel.Id }, createdHotel); //201 + data
        }

        /// <summary>
        /// Update the hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>

        [HttpPut]
        [Route("[action]")]
        public IActionResult Put([FromBody]Hotel hotel)
        {
            if (_hotelService.GetHotelById(hotel.Id) != null)
            {
                return Ok(_hotelService.UpdateHotel(hotel)); //200 + data
            }
            return NotFound();
        }

        /// <summary>
        /// Delete the hotel
        /// </summary>
        /// <param name="id"></param>

        [HttpDelete]
        [Route("[action]/{id}")]
        public IActionResult Delete(int id)
        {
            if (_hotelService.GetHotelById(id) != null)
            {
                _hotelService.DeleteHotel(id);
                return Ok(); //200
            }
            return NotFound();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiTest.BusinessLayer.Abstract;
using WebApiTest.Entities;

namespace WebApiTest.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HotelController : ControllerBase
    {
        private IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetHotel()
        {
            var hotels = await _hotelService.TGetAllHotel();
            return Ok(hotels);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetHotelByID(int id)
        {
            var hotel = await _hotelService.TGetHotelById(id);
            if (hotel != null)
            {
                return Ok(hotel);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("[action]/{name}")]

        public async Task<IActionResult> GetHotelByName(string name)
        {
            var hotel = await _hotelService.TGetHotelByName(name);
            if (hotel != null)
            {
                return Ok(hotel); //200 + Data Status Code
            }
            return NotFound();
        }

        [HttpGet]
        [Route("[action]/{cityname}")]
        public async Task<IActionResult> GetHotelByCityName(string cityname)
        {
            var hotel = await _hotelService.TGetHotelByCityName(cityname);
            if (hotel != null)
            {
                return Ok(hotel); //200 + Data Status Code
            }
            return NotFound();
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateHotel([FromBody] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                var createHotel = await _hotelService.TCreateHotel(hotel);
                return CreatedAtAction("Get", new { id = createHotel.ID }, createHotel);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateHotel([FromBody] Hotel hotel)
        {
            if (_hotelService.TGetHotelById(hotel.ID) != null)
            {
                return Ok(await _hotelService.TUpdateHotel(hotel)); //200 + Data
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            if (_hotelService.TGetHotelById(id) != null)
            {
                await _hotelService.TDeleteHotel(id);
                return Ok(); //200
            }
            return NotFound(); //404
        }
    }
}

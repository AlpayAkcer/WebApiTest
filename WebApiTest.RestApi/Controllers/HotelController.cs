using Microsoft.AspNetCore.Mvc;
using WebApiTest.BusinessLayer.Abstract;
using WebApiTest.Entities;

namespace WebApiTest.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        //[HttpGet]
        //public List<Hotel> GetList()
        //{
        //    return _hotelService.TGetAllHotel();
        //}

        //[HttpGet("{id}")]
        //public Hotel GetList(int id)
        //{
        //    return _hotelService.TGetHotelById(id);
        //}

        //[HttpPost]
        //public Hotel Post([FromBody] Hotel hotel)
        //{
        //    return _hotelService.TCreateHotel(hotel);
        //}

        //[HttpPut]
        //public Hotel Update([FromBody] Hotel hotel)
        //{
        //    return _hotelService.TUpdateHotel(hotel);
        //}

        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    _hotelService.TDeleteHotel(id);
        //}
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetHotel()
        {
            var hotels = _hotelService.TGetAllHotel();
            return Ok(hotels);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetHotelByID(int id)
        {
            var hotel = _hotelService.TGetHotelById(id);
            if (hotel != null)
            {
                return Ok(hotel);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("[action]/{name}")]
        public IActionResult GetHotelByName(string name)
        {
            var hotel = _hotelService.TGetHotelByName(name);
            if (hotel != null)
            {
                return Ok(hotel); //200 + Data Status Code
            }
            return NotFound();
        }

        [HttpGet]
        [Route("[action]/{cityname}")]
        public IActionResult GetHotelByCityName(string cityname)
        {
            var hotel = _hotelService.TGetHotelByCityName(cityname);
            if (hotel != null)
            {
                return Ok(hotel); //200 + Data Status Code
            }
            return NotFound();
        }


        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateHotel([FromBody] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                var createHotel = _hotelService.TCreateHotel(hotel);
                return CreatedAtAction("Get", new { id = createHotel.ID }, createHotel);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateHotel([FromBody] Hotel hotel)
        {
            if (_hotelService.TGetHotelById(hotel.ID) != null)
            {
                return Ok(_hotelService.TUpdateHotel(hotel)); //200 + Data
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public IActionResult DeleteHotel(int id)
        {
            if (_hotelService.TGetHotelById(id) != null)
            {
                _hotelService.TDeleteHotel(id);
                return Ok(); //200
            }
            return NotFound(); //404
        }
    }
}

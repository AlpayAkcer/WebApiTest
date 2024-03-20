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
        public IActionResult GetList()
        {
            var hotels = _hotelService.TGetAllHotel();
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public IActionResult GetList(int id)
        {
            var hotel = _hotelService.TGetHotelById(id);
            if (hotel != null)
            {
                return Ok(hotel);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                var createHotel = _hotelService.TCreateHotel(hotel);
                return CreatedAtAction("Get", new { id = createHotel.ID }, createHotel);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Hotel hotel)
        {
            if (_hotelService.TGetHotelById(hotel.ID) != null)
            {
                return Ok(_hotelService.TUpdateHotel(hotel)); //200 + Data
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
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

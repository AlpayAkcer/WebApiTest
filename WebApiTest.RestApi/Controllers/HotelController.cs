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

        [HttpGet]
        public List<Hotel> GetList()
        {
            return _hotelService.TGetAllHotel();
        }

        [HttpGet("{id}")]
        public Hotel GetList(int id)
        {
            return _hotelService.TGetHotelById(id);
        }

        [HttpPost]
        public Hotel Post([FromBody] Hotel hotel)
        {
            return _hotelService.TCreateHotel(hotel);
        }

        [HttpPut]
        public Hotel Update([FromBody] Hotel hotel)
        {
            return _hotelService.TUpdateHotel(hotel);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _hotelService.TDeleteHotel(id);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTest.BusinessLayer.Abstract;
using WebApiTest.BusinessLayer.Concrete;
using WebApiTest.Entities;

namespace WebApiTest.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = new HotelManager();
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
    }
}

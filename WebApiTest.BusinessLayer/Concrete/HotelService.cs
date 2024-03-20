using WebApiTest.BusinessLayer.Abstract;
using WebApiTest.DataAccessLayer.Abstract;
using WebApiTest.Entities;

namespace WebApiTest.BusinessLayer.Concrete
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<Hotel> TCreateHotel(Hotel hotel)
        {
            return await _hotelRepository.CreateHotel(hotel);
        }

        public async Task TDeleteHotel(int id)
        {
            await _hotelRepository.DeleteHotel(id);
        }

        public async Task<List<Hotel>> TGetAllHotel()
        {
            return await _hotelRepository.GetAllHotel();
        }

        public async Task<Hotel> TGetHotelByCityName(string cityname)
        {
            return await _hotelRepository.GetHotelByCityName(cityname);
        }

        public async Task<Hotel> TGetHotelById(int id)
        {
            if (id > 0)
            {
                return await _hotelRepository.GetHotelById(id);
            }
            throw new Exception("ID değeri 1den küçük olamaz");
        }

        public async Task<Hotel> TGetHotelByName(string name)
        {
            return await _hotelRepository.GetHotelByName(name);
        }

        public async Task<Hotel> TUpdateHotel(Hotel hotel)
        {
            return await _hotelRepository.UpdateHotel(hotel);
        }
    }
}

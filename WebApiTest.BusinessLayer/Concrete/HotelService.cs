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

        public Hotel TCreateHotel(Hotel hotel)
        {
            return _hotelRepository.CreateHotel(hotel);
        }

        public void TDeleteHotel(int id)
        {
            _hotelRepository.DeleteHotel(id);
        }

        public List<Hotel> TGetAllHotel()
        {
            return _hotelRepository.GetAllHotel();
        }

        public Hotel TGetHotelByCityName(string cityname)
        {
            return _hotelRepository.GetHotelByCityName(cityname);
        }

        public Hotel TGetHotelById(int id)
        {
            if (id > 0)
            {
                return _hotelRepository.GetHotelById(id);
            }
            throw new Exception("ID değeri 1den küçük olamaz");
        }

        public Hotel TGetHotelByName(string name)
        {
            return _hotelRepository.GetHotelByName(name);
        }

        public Hotel TUpdateHotel(Hotel hotel)
        {
            return _hotelRepository.UpdateHotel(hotel);
        }
    }
}

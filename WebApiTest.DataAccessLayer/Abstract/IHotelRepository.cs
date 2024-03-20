using WebApiTest.Entities;

namespace WebApiTest.DataAccessLayer.Abstract
{
    public interface IHotelRepository
    {
        List<Hotel> GetAllHotel();
        Hotel GetHotelById(int id);
        Hotel GetHotelByName(string name);
        Hotel GetHotelByCityName(string cityname);
        Hotel CreateHotel(Hotel hotel);
        Hotel UpdateHotel(Hotel hotel);
        void DeleteHotel(int id);
    }
}

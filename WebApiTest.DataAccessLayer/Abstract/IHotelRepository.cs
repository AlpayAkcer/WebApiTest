using WebApiTest.Entities;

namespace WebApiTest.DataAccessLayer.Abstract
{
    public interface IHotelRepository
    {
        List<Hotel> GetAllHotel();
        Hotel GetHotelById(int id);
        Hotel CreateHotel(Hotel hotel);
        Hotel UpdateHotel(Hotel hotel);
        void DeleteHotel(int id);
    }
}

using WebApiTest.Entities;

namespace WebApiTest.BusinessLayer.Abstract
{
    public interface IHotelService
    {
        List<Hotel> TGetAllHotel();
        Hotel TGetHotelById(int id);
        Hotel TCreateHotel(Hotel hotel);
        Hotel TUpdateHotel(Hotel hotel);
        void TDeleteHotel(int id);
    }
}

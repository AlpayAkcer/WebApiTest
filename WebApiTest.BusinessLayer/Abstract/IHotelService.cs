using WebApiTest.Entities;

namespace WebApiTest.BusinessLayer.Abstract
{
    public interface IHotelService
    {
        List<Hotel> TGetAllHotel();
        Hotel TGetHotelById(int id);
        Hotel TGetHotelByName(string name);
        Hotel TGetHotelByCityName(string cityname);
        Hotel TCreateHotel(Hotel hotel);
        Hotel TUpdateHotel(Hotel hotel);
        void TDeleteHotel(int id);
    }
}

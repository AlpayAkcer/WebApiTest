using WebApiTest.Entities;

namespace WebApiTest.BusinessLayer.Abstract
{
    public interface IHotelService
    {
        Task<List<Hotel>> TGetAllHotel();
        Task<Hotel> TGetHotelById(int id);
        Task<Hotel> TGetHotelByName(string name);
        Task<Hotel> TGetHotelByCityName(string cityname);
        Task<Hotel> TCreateHotel(Hotel hotel);
        Task<Hotel> TUpdateHotel(Hotel hotel);
        Task TDeleteHotel(int id);
    }
}

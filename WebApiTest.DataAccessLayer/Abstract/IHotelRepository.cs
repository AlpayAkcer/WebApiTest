using WebApiTest.Entities;

namespace WebApiTest.DataAccessLayer.Abstract
{
    public interface IHotelRepository
    {
        Task<List<Hotel>> GetAllHotel();
        Task<Hotel> GetHotelById(int id);
        Task<Hotel> GetHotelByName(string name);
        Task<Hotel> GetHotelByCityName(string cityname);
        Task<Hotel> CreateHotel(Hotel hotel);
        Task<Hotel> UpdateHotel(Hotel hotel);
        Task DeleteHotel(int id);
    }
}

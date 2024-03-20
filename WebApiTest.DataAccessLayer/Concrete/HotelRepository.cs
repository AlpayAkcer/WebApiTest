using WebApiTest.DataAccessLayer.Abstract;
using WebApiTest.Entities;

namespace WebApiTest.DataAccessLayer.Concrete
{
    public class HotelRepository : IHotelRepository
    {
        public Hotel CreateHotel(Hotel hotel)
        {
            using (var _hotelDbContext = new HotelDbContext())
            {
                _hotelDbContext.Hotels.Add(hotel);
                _hotelDbContext.SaveChanges();
                return hotel;
            }
        }

        public void DeleteHotel(int id)
        {
            using (var _hotelDbContext = new HotelDbContext())
            {
                var deleteHotel = GetHotelById(id);
                _hotelDbContext.Hotels.Remove(deleteHotel);
                _hotelDbContext.SaveChanges();
            }
        }

        public List<Hotel> GetAllHotel()
        {
            using (var _hotelDbContext = new HotelDbContext())
            {
                return _hotelDbContext.Hotels.ToList();
            }
        }

        public Hotel GetHotelById(int id)
        {
            using (var _hotelDbContext = new HotelDbContext())
            {
                return _hotelDbContext.Hotels.Find(id);
            }
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            using (var _hotelDbContext = new HotelDbContext())
            {
                _hotelDbContext.Hotels.Update(hotel);
                _hotelDbContext.SaveChanges();
                return hotel;
            }
        }
    }
}

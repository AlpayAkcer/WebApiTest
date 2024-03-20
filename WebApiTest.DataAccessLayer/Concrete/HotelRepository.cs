using Microsoft.EntityFrameworkCore;
using WebApiTest.DataAccessLayer.Abstract;
using WebApiTest.Entities;

namespace WebApiTest.DataAccessLayer.Concrete
{
    public class HotelRepository : IHotelRepository
    {
        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            using (var _hotelDbContext = new HotelDbContext())
            {
                _hotelDbContext.Hotels.Add(hotel);
                await _hotelDbContext.SaveChangesAsync();
                return hotel;
            }
        }

        public async Task DeleteHotel(int id)
        {
            using (var _hotelDbContext = new HotelDbContext())
            {
                var deletehotel = await GetHotelById(id);
                _hotelDbContext.Hotels.Remove(deletehotel);
                await _hotelDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Hotel>> GetAllHotel()
        {
            using (var _hotelDbContext = new HotelDbContext())
            {
                return await _hotelDbContext.Hotels.ToListAsync();
            }
        }

        public async Task<Hotel> GetHotelByCityName(string cityname)
        {
            using (var _hotelDbContext = new HotelDbContext())
            {
                return await _hotelDbContext.Hotels.FirstOrDefaultAsync(x => x.City.Contains(cityname));
            }
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            using (var _hotelDbContext = new HotelDbContext())
            {
                return await _hotelDbContext.Hotels.FindAsync(id);
            }
        }

        public async Task<Hotel> GetHotelByName(string name)
        {
            using (var _hotelDbContext = new HotelDbContext())
            {
                return await _hotelDbContext.Hotels.FirstOrDefaultAsync(x => x.Name.Contains(name));
            }
        }

        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            using (var _hotelDbContext = new HotelDbContext())
            {
                _hotelDbContext.Hotels.Update(hotel);
                await _hotelDbContext.SaveChangesAsync();
                return hotel;
            }
        }
    }
}

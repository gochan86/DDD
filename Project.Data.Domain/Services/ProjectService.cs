
using Project.Domain.Modules.HotelAggregate.Entities;

namespace Project.Domain.Services
{
    public class ProjectService : IProjectService
    {
        public Hotel CreateHotel(int _propertyID, string _name, int _geoId, int _rating)
        {
            return new Hotel() { PropertyID = _propertyID, Name = _name, GeoId = _geoId, Rating = _rating };
        }
    }
}

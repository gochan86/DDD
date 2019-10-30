using Project.Domain.Modules.HotelAggregate.Entities;

namespace Project.Domain.Services
{
    public interface IProjectService
    {
        Hotel CreateHotel(int _propertyID, string _name, int _geoId, int _rating);
    }
}

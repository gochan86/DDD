using Project.Domain.Modules.HotelAggregate.Entities;
using System.Collections.Generic;

namespace Project.Domain.Connectors
{
    public interface IHotelConnector
    {
        List<Hotel> GetHotels(int destinationId, int nights);
    }
}

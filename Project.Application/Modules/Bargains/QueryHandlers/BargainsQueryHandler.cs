using Project.Application.Core;
using Project.Application.Dto.Bargains.Query;
using Project.Application.Dto.Bargains.QueryResult;
using Project.Application.DtoConverter.Modules.HotelAggregate;
using Project.Domain.Connectors;
using System.Collections.Generic;

namespace Project.Application.Modules.Bargains.QueryHandlers
{
    public class BargainsQueryHandler : IQueryHandler<BargainsQuery, BargainsQueryResult>
    {
        private readonly IHotelConnector _hotelConnector;

        public BargainsQueryHandler(IHotelConnector hotelConnector)
        {
            _hotelConnector = hotelConnector;
        }

        public void Dispose()
        {
            //throw new System.NotImplementedException();
        }

        public BargainsQueryResult Retrieve(BargainsQuery query)
        {
            var hotelList = _hotelConnector.GetHotels(destinationId: query.destinationId, nights: query.nights);

            List<BargainsHotelDto> resultDto = new List<BargainsHotelDto>();

            if (hotelList != null)
                resultDto = HotelConverter.Instance.ToDto(hotelList);

            return new BargainsQueryResult() { Bargains = resultDto };
        }
    }
}

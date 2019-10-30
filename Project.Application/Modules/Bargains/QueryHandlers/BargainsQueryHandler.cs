using Project.Application.Core;
using Project.Application.Dto.Bargains.Query;
using Project.Application.Dto.Bargains.QueryResult;
using Project.Application.DtoConverter.Modules.HotelAggregate;
using Project.Domain.Connectors;
using Project.Tools;
using Project.Tools.Cache;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

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
            var response = ApplicationContext.Cache.Get<BargainsQueryResult>("search[" + query.destinationId + "#" + query.nights + "]");

            if (response != null) { return response; }

            response = DoSearch(query);

            if (response.Bargains != null & response.Bargains.Any())
            {
                ApplicationContext.Cache.Set("search[" + query.destinationId + "#" + query.nights + "]", response);
            }

            return response;
        }

        public BargainsQueryResult DoSearch(BargainsQuery query)
        {

            var hotelList = _hotelConnector.GetHotels(destinationId: query.destinationId, nights: query.nights);

            List<BargainsHotelDto> resultsDto = new List<BargainsHotelDto>();

            if (hotelList != null)
                resultsDto = HotelConverter.Instance.ToDto(hotelList);

            var response = new BargainsQueryResult();
            response.Bargains = resultsDto;

            return response;
        }

        public void ThrowTask(BargainsQuery query, List<BargainsHotelDto> response)
        {
            var tasks = new List<Task>();
            var connectivityTask = Task.Factory.StartNew(() => DoSearch(query));
            connectivityTask.ContinueWith(t => { }, TaskContinuationOptions.OnlyOnFaulted);
            tasks.Add(connectivityTask);
            Task.WaitAll(tasks.ToArray<Task>(), TimeSpan.FromMilliseconds(int.Parse(ConfigurationManager.AppSettings["SearchTimeOutMilliseconds"])));

        }
    }
}

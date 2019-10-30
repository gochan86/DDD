using Project.Data.Connectors.BargainsConnector.Dto;
using Project.Domain.Connectors;
using Project.Domain.Modules.HotelAggregate.Entities;
using Project.Domain.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Project.Data.Connectors.BargainsConnector.Connector
{
    public class BargainsConnector : IHotelConnector
    {
        private readonly IWebApiConnector _webApiConnector;
        private readonly IProjectService _projectService;
        public BargainsConnector(IWebApiConnector webApiConnector, IProjectService projectService)
        {
            _webApiConnector = webApiConnector;
            _projectService = projectService;
        }

        public List<Hotel> GetHotels(int destinationId, int nights)
        {
            try
            {
                var url = string.Format(ConfigurationManager.AppSettings["CheapAwsomeEndPoint"], destinationId, nights, ConfigurationManager.AppSettings["SecretAuthenticationCheapAwsome"]);

                var data = _webApiConnector.Get<List<BargainsItemDto>>(url);

                return getDataFromResponse(data, nights);
            }
            catch (Exception ex)
            {
                //we can log the error here
                return new List<Hotel>();
            }
        }

        public List<Hotel> getDataFromResponse(List<BargainsItemDto> data, int nights)
        {
            var hotelList = new List<Hotel>();

            if (data != null)
            {
                foreach (var hotel in data)
                {
                    if (hotel != null)
                    {
                        Hotel hotelToAdd = null;

                        if (!String.IsNullOrEmpty(hotel.hotel.name))
                        {
                            hotelToAdd = _projectService.CreateHotel(_propertyID: hotel.hotel.propertyID, _name: hotel.hotel.name, _geoId: hotel.hotel.geoId, _rating: hotel.hotel.rating);
                        }
                        else
                        {
                            //here we can launch a task or event to save for example in a table of warnings: "warning propertyID = id has no name",
                            //and in another process send a sumary of warnings for example each hour
                            continue;
                        }


                        foreach (var rate in hotel.rates)
                        {
                            if (rate != null)
                            {

                                if (rate.value > 0)
                                {
                                    if (rate.rateType == "Stay")
                                    {
                                        hotelToAdd.AddHotelRate(_nights: nights, _rateType: RateType.Stay, _boardType: rate.boardType, _value: Convert.ToDecimal(rate.value));
                                    }
                                    else if (rate.rateType == "PerNight")
                                    {
                                        hotelToAdd.AddHotelRate(_nights: nights, _rateType: RateType.PerNight, _boardType: rate.boardType, _value: Convert.ToDecimal(rate.value));
                                    }
                                }
                                else
                                {
                                    //here we can launch a task or event to save for example in a table of warnings: "warning propertyID = id has incorrect price",
                                    //and in another process send a sumary of warnings for example each hour
                                    continue;
                                }
                            }
                        }

                        if (hotelToAdd.Rates.Any())
                        {
                            hotelList.Add(hotelToAdd);
                        }
                        else
                        {
                            //here we can launch a task or event to save for example in a table of warnings: "warning propertyID = id has no rates",
                            //and in another process send a sumary of warnings for example each hour 
                        }
                    }
                }
            }

            return hotelList;
        }
    }
}

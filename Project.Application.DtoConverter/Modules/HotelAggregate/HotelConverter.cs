using Project.Application.Dto.Bargains.QueryResult;
using Project.Application.DtoConverter.Base;
using Project.Domain.Modules.HotelAggregate.Entities;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Project.Application.DtoConverter.Modules.HotelAggregate
{
    public class HotelConverter : IDtoTranslatable
    {

        private static HotelConverter _instance = null;

        public static HotelConverter Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new HotelConverter();

                return _instance;
            }
        }

        private HotelConverter() { }

        public List<BargainsHotelDto> ToDto(IEnumerable<Hotel> hotels)
        {
            var bargains = new List<BargainsHotelDto>();

            foreach (var hotelElement in hotels)
            {
                var itemToAdd = new BargainsHotelDto() { geoId = hotelElement.GeoId, name = hotelElement.Name, propertyID = hotelElement.PropertyID, rating = hotelElement.Rating };

                itemToAdd.rates = RatesToDto(hotelElement.Rates);

                bargains.Add(itemToAdd);
            }

            return bargains;
        }

        public List<BargainsRateDto> RatesToDto(IEnumerable<HotelRate> rates)
        {
            var bargainsRatesDto = new List<BargainsRateDto>();

            bargainsRatesDto = rates.Select(b => RateToDto(b)).ToList();

            return bargainsRatesDto;
        }

        private BargainsRateDto RateToDto(HotelRate rate)
        {
            return new BargainsRateDto()
            {
                boardType = rate.BoardType,
                rateType = rate.RateType.ToString(),
                Price = rate.HotelRateCost()
            };
        }
    }
}

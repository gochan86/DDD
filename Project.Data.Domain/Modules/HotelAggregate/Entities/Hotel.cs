using Project.Domain.Base;
using System;
using System.Collections.Generic;

namespace Project.Domain.Modules.HotelAggregate.Entities
{
    public class Hotel : AggregateRoot
    {
        public int PropertyID { get; set; }
        public string Name { get; set; }
        public int GeoId { get; set; }
        public int Rating { get; set; }


        private List<HotelRate> _rates = new List<HotelRate>();
        public IEnumerable<HotelRate> Rates { get { return _rates; } }

        public void AddHotelRate(int _nights, RateType _rateType, string _boardType, Decimal _value)
        {
            this._rates.Add(new HotelRate(_nights: _nights, _rateType: _rateType, _boardType: _boardType, _value: _value));
        }
    }
}

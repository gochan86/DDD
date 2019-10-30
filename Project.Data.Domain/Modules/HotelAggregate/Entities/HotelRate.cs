using Project.Domain.Base;
using System;

namespace Project.Domain.Modules.HotelAggregate.Entities
{

    public enum RateType { Stay = 1, PerNight = 2 }
    public class HotelRate : Entity
    {
        public int Nights { get; set; }
        public RateType RateType { get; set; }
        public string BoardType { get; set; }
        public Decimal Value { get; set; }

        public HotelRate(int _nights, RateType _rateType, string _boardType, Decimal _value)
        {
            Nights = _nights;
            RateType = _rateType;
            BoardType = _boardType;
            Value = _value;
        }

        public decimal HotelRateCost()
        {
            if (RateType == RateType.PerNight)
            {
                return Nights * Value;
            }
            else if (RateType == RateType.Stay)
            {
                return Value;
            }

            return 0;
        }
    }
}

using System.Collections.Generic; 

namespace Project.Data.Connectors.BargainsConnector.Dto
{
    public class BargainsHotel
    {
        public int propertyID { get; set; }
        public string name { get; set; }
        public int geoId { get; set; }
        public int rating { get; set; }
    }

    public class BargainsRate
    {
        public string rateType { get; set; }
        public string boardType { get; set; }
        public double value { get; set; }
    }

    public class BargainsItemDto
    {
        public BargainsHotel hotel { get; set; }
        public List<BargainsRate> rates { get; set; }
    }
}

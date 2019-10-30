using Project.Application.Dto.Base;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Project.Application.Dto.Bargains.QueryResult
{

    [XmlRoot("Bargainsesponse")]
    public class BargainsQueryResult : IQueryResult
    {
        public List<BargainsHotelDto> Bargains { get; set; }
    }

    public class BargainsHotelDto
    {
        public int propertyID { get; set; }
        public string name { get; set; }
        public int geoId { get; set; }
        public int rating { get; set; }
        public List<BargainsRateDto> rates { get; set; }
    }

    public class BargainsRateDto
    {
        public string rateType { get; set; }
        public string boardType { get; set; } 
        public Decimal Price { get; set; }
    } 
}

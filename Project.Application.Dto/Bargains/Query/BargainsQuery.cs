using Project.Application.Dto.Base; 

namespace Project.Application.Dto.Bargains.Query
{
    public class BargainsQuery : IQuery
    {
        public int destinationId { get; set; }
        public int nights { get; set; }
    }
}

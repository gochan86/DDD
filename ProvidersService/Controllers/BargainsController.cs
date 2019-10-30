using Project.Application.Core;
using Project.Application.Dto.Bargains.Query;
using Project.Application.Dto.Bargains.QueryResult;
using Project.Tools;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.DistributedServices.Controllers
{
    public class BargainsController : ApiController
    {
        //private readonly IQueryDispatcher _queryDispatcher;

        public BargainsController()
        {
        }
        //public BargainsController(IQueryDispatcher queryDispatcher)
        //{
        //    _queryDispatcher = queryDispatcher;
        //}

        public HttpResponseMessage Get(int destinationId, int nights)
        {
            var bargainsQuery = new BargainsQuery() { destinationId = destinationId, nights = nights }; 
            //_queryDispatcher = ApplicationContext.Container.Resolve<IQueryDispatcher>().Dispatch; 
            var queryResponse = ApplicationContext.Container.Resolve<IQueryDispatcher>().Dispatch<BargainsQuery, BargainsQueryResult>(bargainsQuery);

            var okResponse = this.Request.CreateResponse(HttpStatusCode.OK, queryResponse);

            return okResponse;

        }
    }
}

using Project.Application.Core;
using Project.Application.Dto.Bargains.Query;
using Project.Application.Dto.Bargains.QueryResult;
using Project.Application.Modules.Bargains.QueryHandlers;
using Project.Data.Connectors.BargainsConnector.Connector;
using Project.Data.WebApi;
using Project.Domain.Connectors;
using Project.Domain.Services;
using Project.Tools.Cache;
using Project.Tools.IoC;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Crosscutting.Bootstrapper
{
    public static class IocRegistration
    {
        public static void Register(IIocContainer container)
        {
            container.RegisterInstance<IIocContainer>(container);

            // Model services Domain
            container.Register<IHotelConnector, BargainsConnector>();
            container.Register<IProjectService, ProjectService>();

            // Command and query 
            container.Register<IQueryDispatcher, QueryDispatcher>();
            container.RegisterType(typeof(IQueryHandler<BargainsQuery, BargainsQueryResult>), typeof(BargainsQueryHandler));

            // Tools
             

            //// Connectors 
            container.Register<IWebApiConnector, WebApiConnector>();

        }
    }
}

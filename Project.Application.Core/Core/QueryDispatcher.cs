using Project.Application.Dto.Base;
using Project.Tools.IoC;
using System;
using System.Diagnostics; 

namespace Project.Application.Core
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IIocContainer _container;  

        public QueryDispatcher(IIocContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            _container = container; 
        }

        public TResult Dispatch<TParameter, TResult>(TParameter query)
            where TParameter : IQuery
            where TResult : IQueryResult
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            IQueryHandler<TParameter, TResult> handler = null;

            try
            {
                handler = _container.Resolve<IQueryHandler<TParameter, TResult>>();
                var results = handler.Retrieve(query);
                 
                stopwatch.Stop(); 

                return results;
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                //NotifyError(ex, query, stopwatch.ElapsedMilliseconds);
                throw;
            }
            finally
            {
                handler.Dispose();
            }
        } 
    }
}
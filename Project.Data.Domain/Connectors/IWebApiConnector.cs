using System;

namespace Project.Domain.Connectors
{
    public interface IWebApiConnector
    {
        T Get<T>(string url);
    }
}

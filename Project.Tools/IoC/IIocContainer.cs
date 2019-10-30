using Microsoft.Practices.Unity;
using System; 

namespace Project.Tools.IoC
{
    public interface IIocContainer
    {
        void Register<TAbstract, TConcrete>() where TConcrete : TAbstract; 
        void RegisterInstance<TInterface>(TInterface instance);
        T Resolve<T>(); 
        UnityContainer CurrentObject { get; } 
        void RegisterType(Type abstractType, Type concreteType );

        //System.Web.Http.Dependencies.IDependencyResolver GetDependencyResolverWebApi();
    }
}

using Microsoft.Practices.Unity;
using System;
using System.Web.Http.Dependencies;

namespace Project.Tools.IoC
{
    public class UnityIocContainer : IIocContainer, IDisposable
    {
        private readonly UnityContainer _current = new UnityContainer();

        public UnityContainer CurrentObject { get { return _current; } }

        public void Register<TAbstract, TConcrete>() where TConcrete : TAbstract
        {
            _current.RegisterType<TAbstract, TConcrete>();
        }

        public T Resolve<T>()
        {
            return _current.Resolve<T>();
        }

        public void RegisterInstance<T>(T instance)
        {
            _current.RegisterInstance<T>(instance);
        }

        //public System.Web.Http.Dependencies.IDependencyResolver GetDependencyResolverWebApi()
        //{

        //    var kk = new IDependencyResolver();
             
        //    return new Microsoft.Practices.Unity.Utility.web.UnityDependencyResolver(_current);
        //}

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _current.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void RegisterType(Type abstractType, Type concreteType)
        {
            _current.RegisterType(abstractType, concreteType);
        }
    }
}
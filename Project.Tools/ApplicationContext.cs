using Project.Tools.Cache;
using Project.Tools.IoC; 

namespace Project.Tools
{
    public static class ApplicationContext
    {
        static ApplicationContext()
        {
            Container = new UnityIocContainer(); 
            Cache = new SystemRuntimeCache(); 
        }
          
        public static IIocContainer Container { get; set; }
        public static ICache Cache { get; set; }  
    }
}

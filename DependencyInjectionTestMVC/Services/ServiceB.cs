using DependencyInjectionTestMVC.Interfaces;

namespace DependencyInjectionTestMVC.Services
{

    public class ServiceB : IServiceB
    {

        private readonly ILogger<IServiceB> _logger;
        private readonly DateTime instantiationTime;
        public string registrationTime { get; set; } = "";

        private DateTime factoryMethodRunTime;

        public ServiceB(ILogger<IServiceB> logger)
        {
            _logger = logger;
            instantiationTime = DateTime.Now;
        }

        public string GetInstantiationTime()
        {
            return instantiationTime.ToString();
        }

        public string GetTime()
        {
            return DateTime.Now.ToString();
        }

        public string GetFactoryTime()
        {
            return factoryMethodRunTime.ToString();
        }

        public static IServiceB Factory(IServiceProvider services)
        {
           
            var logger = services.GetRequiredService<ILogger<IServiceB>>();
            ServiceB serviceB = new ServiceB(logger);
            var factoryExecution = DateTime.Now;
            serviceB.factoryMethodRunTime = factoryExecution;
            return serviceB;
        }

        public static IServiceB Factory(IServiceProvider services, DateTime registrationTime)
        {
            IServiceB serviceB = Factory(services);
            serviceB.registrationTime = registrationTime.ToString();
            return serviceB;
        }

    }
}

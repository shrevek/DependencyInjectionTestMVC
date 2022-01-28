using DependencyInjectionTestMVC.Interfaces;

namespace DependencyInjectionTestMVC.Services
{

    public class ServiceA : IServiceA
    {

        private readonly ILogger<IServiceA> _logger;
        private readonly DateTime instantiationTime;

        public ServiceA(ILogger<IServiceA> logger)
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

    }
}

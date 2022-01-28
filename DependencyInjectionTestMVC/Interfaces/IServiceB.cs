namespace DependencyInjectionTestMVC.Interfaces
{
    public interface IServiceB
    {
        // Property declaration:
       public string registrationTime
        {
            get;
            set;
        }

        public string GetFactoryTime();
        public string GetInstantiationTime();
        public string GetTime();
        //public static IServiceB Factory();

    }
}

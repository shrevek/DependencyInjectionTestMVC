using DependencyInjectionTestMVC.Interfaces;
using DependencyInjectionTestMVC.Models;
using DependencyInjectionTestMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DependencyInjectionTestMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceA _serviceA;
        private readonly IServiceB _serviceB;


        public HomeController(ILogger<HomeController> logger, IServiceA serviceA, IServiceB serviceB)
        {
            _logger = logger;
            _serviceA = serviceA;
            _serviceB = serviceB;
        }

        public IActionResult Index()
        {
            TimeViewModel tvm = new TimeViewModel
            {
                InstTime = _serviceA.GetInstantiationTime(),
                Time = _serviceA.GetTime(),
                //FactoryTime = _serviceA.GetFactoryTime(),
                //RegistrationTime = _serviceA.registrationTime
            };

            return View(tvm);
        }

        public IActionResult Privacy()
        {
            TimeViewModel tvm = new TimeViewModel
            {
                InstTime = _serviceB.GetInstantiationTime(),
                Time = _serviceB.GetTime(),
                FactoryTime = _serviceB.GetFactoryTime(),
                RegistrationTime = _serviceB.registrationTime
            };
            return View(tvm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
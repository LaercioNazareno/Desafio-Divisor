using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Application.DTO;
using Desafio.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Desafio.Presentation.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUseCaseDivisibility _useCaseDivisibility;

        public HomeController(IUseCaseDivisibility useCaseDivisibility)
        {
            _useCaseDivisibility = useCaseDivisibility;
        }

        public IActionResult Index()
        {
            return View(new DivisorDTO());
        }

        public IActionResult GetDividers(int number)
        {
            var dividers = _useCaseDivisibility.GetDivisors(number);
            return View("Index", dividers);
        }
    }
}

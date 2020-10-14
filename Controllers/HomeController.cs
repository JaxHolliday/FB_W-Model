using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Modal.Models;

namespace Modal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Solve()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Solve(string userInput1, string userInput2)
        {
            var fizzBuzzModel = new FizzBuzzModel(); //fizzBuzzModel is Object of FizzBuzzModel Class
            fizzBuzzModel.FizzNum = Convert.ToInt32(userInput1);//FizzBuzzModel's FizzNum Prop
            fizzBuzzModel.BuzzNum = Convert.ToInt32(userInput2);//FizzBuzzModel's BuzzNum Prop
            fizzBuzzModel.Output = $"You gave me FizzNum: {userInput1} and BuzzNum: {userInput2}";//
            fizzBuzzModel.ReturnValue = "";


            for (var i = 1; i <= 100; i++)
            {
                if (i % fizzBuzzModel.FizzNum == 0 && i % fizzBuzzModel.BuzzNum == 0)
                {
                    fizzBuzzModel.ReturnValue += "FizzBuzz ";
                }
                else if (i % fizzBuzzModel.FizzNum == 0)
                {
                    fizzBuzzModel.ReturnValue += "Fizz ";
                }
                else if (i % fizzBuzzModel.BuzzNum == 0)
                {
                    fizzBuzzModel.ReturnValue += "Buzz ";
                }
                else
                {
                    fizzBuzzModel.ReturnValue += $"{i} ";
                }

            }
                return RedirectToAction("Result",fizzBuzzModel);// diverting to resultAction; making "New" instance 

        }

        public IActionResult Result(FizzBuzzModel model)
        {
            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

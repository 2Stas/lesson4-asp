using Microsoft.AspNetCore.Mvc;
using lesson4.Models;

namespace lesson4.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            else
            {
                UserModel person = new UserModel
                {
                    Name = model.Name,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Age = model.Age,
                    Password = model.Password,
                    ConfirmPassword = model.ConfirmPassword,
                    Line = model.Line
                };

                System.IO.File.AppendAllText("user.txt", $"name: {person.Name}, email: {person.Email},phone: {person.PhoneNumber}, age: {person.Age}, password: {person.Password}, confirm password: {person.ConfirmPassword}, line: {person.Line}\n");
                return View("Details", person);


            }

        }
    }
}

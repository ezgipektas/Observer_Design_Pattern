using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Observer_Design_Pattern.DAL;
using Observer_Design_Pattern.Models;
using Observer_Design_Pattern.ObserverDesignPattern;
using System.Threading.Tasks;

namespace Observer_Design_Pattern.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly UserObserverSubject _userObserverSubject;

        public RegisterController(UserManager<AppUser> userManager, UserObserverSubject userObserverSubject)
        {
            _userManager = userManager;
            _userObserverSubject = userObserverSubject;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel p)
        {
            var appuser = new AppUser()
            {
                Email = p.Mail,
                UserName = p.Username,
                Name = p.Name,
                Surname = p.Surname
            };
            var result = await _userManager.CreateAsync(appuser, p.Password);
            if (result.Succeeded)
            {
                _userObserverSubject.NotifyObserver(appuser);                ViewBag.message = "İşlemler başarılı bir şekilde tamamlandı";
                return View();
            }
            else
            {
                ViewBag.message = "İşlemler hatalı oldu";
                return View();
            }
        }
    }
}

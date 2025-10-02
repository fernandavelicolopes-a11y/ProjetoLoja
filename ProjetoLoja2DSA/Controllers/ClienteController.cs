using Microsoft.AspNetCore.Mvc;

namespace ProjetoLoja2DSA.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

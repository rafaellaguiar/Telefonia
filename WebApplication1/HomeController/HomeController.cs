using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.HomeController
{
    public class HomeController : Controller
    {
        [Route("/")]
        [HttpGet]
        public IActionResult Index()
        {

            List<string> telefones = GetListaTelefones();

            ViewData["ListaTelefones"] = telefones;

            return View();
        }
        private List<string> GetListaTelefones()
        {
            var lista = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                lista.Add("TELEFONO" + i.ToString());
            }

            return lista;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Telefonia.Core.Models;
using Telefonia.Core.Repositories;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly TelefoneRepository _telefoneRepository;
        public HomeController(TelefoneRepository telefoneRepository)
        {
            _telefoneRepository = telefoneRepository;
        }

        [Route("/")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            IEnumerable<Contato> telefones = await GetListaTelefones();

            ViewData["ListaTelefones"] = telefones;

            return View();
        }
        private async Task<IEnumerable<Contato>> GetListaTelefones()
        {
            return await _telefoneRepository.GetContatos("13fe5d8f-dd71-4fc5-af1d-d687b3c253f9");
        }
    }
}

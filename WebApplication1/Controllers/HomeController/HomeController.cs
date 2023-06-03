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

        [HttpGet]
        [Route("contato/delete")]
        public async Task<bool> DeletarContato(int idContato)
        {
            return await _telefoneRepository.DeleteContato(idContato);
        }

        [HttpGet]
        [Route("contato/editar")]
        public async Task<bool> EditarContato(int idContato, string novoNomeContato)
        {
            return await _telefoneRepository.AlterarNomeContato(idContato, novoNomeContato);
        }

        [HttpGet]
        [Route("contato/criar")]
        public async Task CriarContato(string telefone, string nomeContato, string idUsuario)
        {
            await _telefoneRepository.InserirContato(telefone, nomeContato, idUsuario);
        }

    }
}

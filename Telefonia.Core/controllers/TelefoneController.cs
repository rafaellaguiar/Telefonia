using Microsoft.AspNetCore.Mvc;
using Telefonia.Core.Repositories;

namespace Telefonia.Core.Controllers;

[ApiController]
[Route(("api/v1[controller]"))]
public class TelefoneController : ControllerBase
{
    private readonly TelefoneRepository _telefoneRepository;

    public TelefoneController(TelefoneRepository telefoneRepository)
        => _telefoneRepository = telefoneRepository;


    [HttpGet("contato/{idUsuario}")]
    public async Task<IActionResult> GetContatos(Guid idUsuario)
    {
        var contatos = await _telefoneRepository.GetContatos(idUsuario.ToString());

        return Ok(contatos);
    }
}

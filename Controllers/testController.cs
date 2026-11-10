using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[Controller]")]
public class AlunosController : ControllerBase
{
    private static readonly List<Aluno> ListadeAlunos = new List<Aluno>()
    {
        new Aluno {Id = 1, Nome = "Fulano"},
        new Aluno {Id = 2, Nome = "Ciclano"}
    };

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(ListadeAlunos);
    }

    [HttpPost]
    public IActionResult Post(Aluno novoAluno)
    {
        ListadeAlunos.Add(novoAluno);

        return Ok(novoAluno);
    }
}


using Microsoft.AspNetCore.Mvc;
using MinhaBiblioteca.Repositories;
using MinhaBiblioteca.Models;
namespace MinhaBiblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Define a rota base como: api/materiais
    public class MateriaisController : ControllerBase
    {
        private readonly IMaterialRepository _repository;

        public MateriaisController(IMaterialRepository repository)
        {
            _repository = repository;
        }

        // 1. GET /api/Materiais -> Lista todos (200 OK)
        [HttpGet]
        public IActionResult ObterTodos()
        {
            var materiais = _repository.ObterTodos();
            return Ok(materiais);
        }

        // 2. GET /api/Materiais/{id} -> Busca por ID (200 OK ou 404)
        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var material = _repository.ObterPorId(id);
            if (material == null)
                return NotFound();

            return Ok(material);
        }

        // 3. POST /api/Materiais/livro
        [HttpPost("livro")]
        public IActionResult AdicionarLivro([FromBody] Livro livro)
        {
            if (string.IsNullOrWhiteSpace(livro.Titulo))
                return BadRequest("O título é obrigatório e não pode conter apenas espaços.");

            if (livro.AnoPublicacao < 0)
                return BadRequest("O ano de publicação não pode ser menor que 0.");

            if (string.IsNullOrWhiteSpace(livro.Autor))
                return BadRequest("O autor do livro é obrigatório.");

            if (livro.Paginas <= 0)
                return BadRequest("O número de páginas deve ser maior que 0.");

            var criado = _repository.Adicionar(livro);
            return CreatedAtAction(nameof(ObterPorId), new { id = criado!.Id }, criado);
        }

        // 4. POST /api/Materiais/revista
        [HttpPost("revista")]
        public IActionResult AdicionarRevista([FromBody] Revista revista)
        {
            if (string.IsNullOrWhiteSpace(revista.Titulo))
                return BadRequest("O título é obrigatório e não pode conter apenas espaços.");

            if (revista.AnoPublicacao < 0)
                return BadRequest("O ano de publicação não pode ser menor que 0.");

            if (revista.Edicao <= 0)
                return BadRequest("A edição da revista deve ser maior que 0.");

            if (revista.MesPublicacao < 1 || revista.MesPublicacao > 12)
                return BadRequest("O mês de publicação deve estar entre 1 e 12.");

            var criado = _repository.Adicionar(revista);
            return CreatedAtAction(nameof(ObterPorId), new { id = criado!.Id }, criado);
        }

        // 5. PUT /api/Materiais/livro/{id}
        [HttpPut("livro/{id}")]
        public IActionResult AtualizarLivro(int id, [FromBody] Livro livro)
        {
            if (string.IsNullOrWhiteSpace(livro.Titulo))
                return BadRequest("O título é obrigatório e não pode conter apenas espaços.");

            if (livro.AnoPublicacao < 0)
                return BadRequest("O ano de publicação não pode ser menor que 0.");

            if (string.IsNullOrWhiteSpace(livro.Autor))
                return BadRequest("O autor do livro é obrigatório.");

            if (livro.Paginas <= 0)
                return BadRequest("O número de páginas deve ser maior que 0.");

            bool atualizou = _repository.Atualisar(id, livro);
            if (!atualizou)
                return NotFound();

            return Ok(livro);
        }

        // 6. PUT /api/Materiais/revista/{id}
        [HttpPut("revista/{id}")]
        public IActionResult AtualizarRevista(int id, [FromBody] Revista revista)
        {
            if (string.IsNullOrWhiteSpace(revista.Titulo))
                return BadRequest("O título é obrigatório e não pode conter apenas espaços.");

            if (revista.AnoPublicacao < 0)
                return BadRequest("O ano de publicação não pode ser menor que 0.");

            if (revista.Edicao <= 0)
                return BadRequest("A edição da revista deve ser maior que 0.");

            if (revista.MesPublicacao < 1 || revista.MesPublicacao > 12)
                return BadRequest("O mês de publicação deve estar entre 1 e 12.");

            bool atualizou = _repository.Atualisar(id, revista);
            if (!atualizou)
                return NotFound();

            return Ok(revista);
        }

        // 7. DELETE /api/Materiais/{id} -> Exclui material (204 No Content ou 404)
        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            bool removeu = _repository.Remover(id);
            if (!removeu)
                return NotFound();

            return NoContent();
        }

        // 8. GET /api/Materiais/{id}/descricao -> Mostra descrição e prazo (200 OK ou 404)
        [HttpGet("{id}/descricao")]
        public IActionResult ObterDescricao(int id)
        {
            var material = _repository.ObterPorId(id);
            if (material == null)
                return NotFound();

            return Ok(new
            {
                id = material.Id,
                tipo = material.GetType().Name, // Retorna "Livro" ou "Revista" automaticamente
                descricao = material.Descricao(),
                prazoEmprestimo = material.CalcularPrazo()
            });
        }

        // 9. POST /api/Materiais/{id}/emprestar
        [HttpPost("{id}/emprestar")]
        public IActionResult Emprestar(int id)
        {
            // 1. Buscar o material
            var material = _repository.ObterPorId(id);

            // 2. Verificar se existe
            if (material == null)
                return NotFound();

            // 3. Verificar se implementa a interface utilizando "is not"[cite: 7]
            if (material is not IEmprestavel emprestavel)
                return BadRequest("Este material não pode ser emprestado."); // 5. Retornar 400 Bad Request[cite: 7]

            // 4. Chamar Emprestar() e retornar 200 OK com a mensagem[cite: 7]
            string mensagem = emprestavel.Emprestar();
            return Ok(mensagem);
        }

    }

}
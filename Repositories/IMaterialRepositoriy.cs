using MinhaBiblioteca.Models;
namespace MinhaBiblioteca.Repositories;
public interface IMaterialRepository
{
    IEnumerable<MaterialBiblioteca> ObterTodos();
    MaterialBiblioteca? ObterPorId(int id);
    MaterialBiblioteca? Adicionar(MaterialBiblioteca material);
    bool Atualisar(int id, MaterialBiblioteca material);
    bool Remover(int id);
}

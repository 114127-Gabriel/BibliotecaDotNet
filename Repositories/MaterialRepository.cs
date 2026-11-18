using MinhaBiblioteca.Models;
namespace MinhaBiblioteca.Repositories;
using System.Linq;

    public class MaterialRepository : IMaterialRepository
    {

        private readonly Dictionary<int,MaterialBiblioteca> _materiais = new();
        
        // private int GerarNovoId()
        // {
        //     if (_materiais.Count == 0)
        //         return 1;
        
        //     return _materiais.Keys.Max() + 1;
        // }

        private int _proximoId = 1;
        
        private int GerarNovoId()
        {
            return _proximoId++;
        }

        public IEnumerable<MaterialBiblioteca> ObterTodos()
        {
            return _materiais.Values;
        }

        public MaterialBiblioteca? ObterPorId(int id)
        {
            return _materiais.GetValueOrDefault(id);
        }

        public MaterialBiblioteca? Adicionar(MaterialBiblioteca material)
        {
            material.Id = GerarNovoId();
            _materiais[material.Id] = material;
            return material;
        }

        public bool Atualisar(int id, MaterialBiblioteca material)
        {
            // 1. Verificar se o ID existe
            if (_materiais.ContainsKey(id))
            {
                // 2. Manter o ID recebido na URL
                material.Id = id;

                // 3. Substituir o objeto no dicionário
                _materiais[id] = material;

                // 4. Retornar true
                return true;
            }

            return false;
        }

        public bool Remover(int id)
        {
            if (_materiais.ContainsKey(id))
            {
                _materiais.Remove(id);
                return true;
            }
            return false;
        }
    }

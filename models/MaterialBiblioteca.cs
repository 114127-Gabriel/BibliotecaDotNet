using System.Text.Json.Serialization;


namespace MinhaBiblioteca.Models
{
    [JsonDerivedType(typeof(Livro))]
    [JsonDerivedType(typeof(Revista))]
    public abstract class MaterialBiblioteca
    {
        

        //O ID é gerado pelo sistema e não deve ser informado manualmente pelo usuário no cadastro.
        public int Id { get; set; }
        private String? _titulo = string.Empty;// Começa vazio, nunca nulo
        public String? Titulo { 
            get => _titulo;
            set{_titulo = value.Trim();} 
        }
        //O título do material é obrigatório e não pode ser vazio ou conter somente espaços.
        // Validação: se o nome for vazio ou apenas espaços, define "Sem Nome".
        // Se for válido, remove espaços extras no início e fim com Trim().

        public int AnoPublicacao { get; set; }
        //O ano de publicação não pode ser menor que 0.
        
        public abstract int CalcularPrazo();
        public virtual string Descricao()
        {
            return "descrição em branco";
        }
    }
}
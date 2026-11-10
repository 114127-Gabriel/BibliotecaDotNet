namespace MinhaBiblioteca.Models{
    public abstract class MaterialBiblioteca
    {
        public int Id { get; init; }
        private String? _titulo = string.Empty;
        public String? AnoPublicado { get; set; }
        public String? Titulo { 
            get => _titulo;
            set{_titulo = string.IsNullOrWhiteSpace(value) ? "Sem Título" : value.Trim();} 
        }
        public abstract int CalcularPrazo();
        public virtual string Descricao()
        {
            return "descrição em branco";
        }
    }
}
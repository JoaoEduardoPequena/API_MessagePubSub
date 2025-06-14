using Domain.Entites;

namespace Domain.Models
{
    public class CategoriaDTO
    {
        public int Id_Categoria { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Produto> Produto { get; set; }
    }
}


namespace Domain.Entites
{
    public class Categoria
    {
        public int Id_Categoria { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Produto> Produto { get; set; }
    }
}

using Domain.Entites;

namespace Domain.Interfaces
{
    public  interface ICategoria
    {
        public Task<bool> CriarCategoria(Categoria dto);
    }
}

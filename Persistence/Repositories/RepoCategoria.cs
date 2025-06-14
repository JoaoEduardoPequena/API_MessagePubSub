using Domain.Entites;
using Domain.Interfaces;
using Persistence.DbContexts;

namespace Persistence.Repositories
{
    public class RepoCategoria : ICategoria
    {
        private readonly ApplicationDbContextLoja _context;
        public RepoCategoria(ApplicationDbContextLoja context)
        {
            _context = context;
        }
   
        public async Task<bool> CriarCategoria(Categoria dto)
        {   
            try
            {
                await _context.Categoria.AddAsync(dto);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

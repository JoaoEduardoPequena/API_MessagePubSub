﻿using Domain.Entites;
using Domain.Interfaces;
using Persistence.DbContexts;

namespace Persistence.Repositories
{
    public class RepoPedido: IRepoPedido
    {
        private readonly ApplicationDbContextLoja _context;
        
        public RepoPedido(ApplicationDbContextLoja context)
        {
            _context = context;
        }
        public async Task<bool> CriarPedido(Pedido pedido)
        {
            try
            {
                await _context.Pedido.AddAsync(pedido);
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

using Microsoft.EntityFrameworkCore;
using ProjetoRumo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoRumo.Data
{
    public class PedidoContext : DbContext
    {
        public PedidoContext(DbContextOptions<PedidoContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
        }

        public DbSet <Pedido> Pedidos { get; set; }
        public DbSet <Cozinha> Cozinha { get; set; }
        public DbSet <Copa> Copa { get; set; }
        public DbSet <PedidoCozinha> PedidoCozinha { get; set; }
        public DbSet <PedidoCopa> PedidoCopa { get; set; }


    }
}

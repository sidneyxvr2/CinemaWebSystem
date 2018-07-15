using CinemaWebSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebSystem.Data
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var cascadeFKs = builder.Model.GetEntityTypes()
                             .SelectMany(t => t.GetForeignKeys())
                             .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(builder);
        }

        public DbSet<Assento> Assentos { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Ingresso> Ingressos { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }
        public DbSet<Venda> Vendas { get; set; }

    }
}

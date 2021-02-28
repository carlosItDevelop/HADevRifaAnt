using HADev.Delivery.Domain.Entities;
using HADev.Delivery.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HADeveloper.Date.ORM
{
    public class HADeveloperDBContext : DbContext
    {
        public HADeveloperDBContext(DbContextOptions<HADeveloperDBContext> options)
            :base(options)
        {}

        public DbSet<Mural> Mural { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Bairro> Bairro { get; set; }
        public DbSet<Eleitor> Eleitor { get; set; }
        public DbSet<Visita> Visista { get; set; }
        public DbSet<GrupoPessoa> GrupoPessoa { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        //public DbSet<Eleitor> Eleitor { get; set; }



    }
}

using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VetS.Core.Models;

namespace VetS.Data
{
    public class VetSDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<Animal> Animales { get; set; }
        public DbSet<Raza> Razas { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ClienteMascota> ClienteMascotas { get; set; }
        public DbSet<HistoriaMascota> HistoriaMascotas { get; set; }
        public DbSet<HistoriaClinica> HistoriaClinicas { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<TipoTurno> TipoTurnos { get; set; }


        public VetSDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Raza>()
            .HasOne<Animal>(r => r.Animal)
            .WithMany(a => a.Razas)
            .HasForeignKey(r => r.AnimalId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ClienteMascota>().HasKey(cm =>
             new { cm.ClienteId, cm.MascotaId });

            modelBuilder.Entity<HistoriaMascota>()
                .HasOne(hm => hm.HistoriaClinica)
                .WithMany()
                .HasForeignKey(hm => hm.HistoriaClinicaId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<HistoriaMascota>()
                .HasOne(hm => hm.Mascota)
                .WithMany()
                .HasForeignKey(hm => hm.MascotaId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<HistoriaMascota>().HasKey(hm =>
             new { hm.HistoriaClinicaId, hm.MascotaId });






        }

    }
}

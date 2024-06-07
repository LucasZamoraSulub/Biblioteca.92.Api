using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WepApis92.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options): base(options) { }

        //Modelos a mapear

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuider)
        {
            //Insertar en la tabla usuario
            modelBuider.Entity<Usuario>().HasData(
                new Usuario
                {
                    PkUsuario= 1,
                    Nombre= "Lucas",
                    User= "Usuario1",
                    Password= "123",
                    FkRol= 1
            }
            );
            //Insertar en la tabla Rol
            modelBuider.Entity<Rol>().HasData
                (
                new Rol{
                    PkRol= 1,
                    Nombre= "sa"

            });
        }

    }
}

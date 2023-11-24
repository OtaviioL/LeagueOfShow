using LeagueOfShow.Migrations;
using Microsoft.EntityFrameworkCore;

namespace LeagueOfShow.Models
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto>options): base(options) { }

        

        public  DbSet<Artista> Artistas { get; set; }

        public DbSet<Show> Shows { get; set; }
       
    }
}

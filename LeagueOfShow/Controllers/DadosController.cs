using LeagueOfShow.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeagueOfShow.Controllers
{
    public class DadosController : Controller
    {
        private readonly Contexto contexto;
        public DadosController(Contexto context)
        {
            contexto = context;
        }

        public IActionResult Artista()
        {
            contexto.Database.ExecuteSqlRaw("delete from artistas");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('cliente', RESEED, 0)");
            Random randNum = new Random();

            string[] vNomeMas = { "Otávio", "Leonan", "Gael", "Noah", "Almir", "Anthony", "Murilo", "Felipe", "Levi", };
            string[] vNomeFem = { "Helena", "Alice", "Otávio", "Laura", "Eloá", "Cecília", "Liz", "Aurora", "Luna", };
            string[] vNacionalidade = { "afegão", "brasileiro", "bechuano", "belizenho", "argelino", "colombiano", "canadense", "holandês", "japonês", };
            for (int i = 0; i < 27; i++) 
            {
                Artista artista = new Artista();

                artista.Nome = (i % 2 == 0) ? vNomeMas[i / 2] : vNomeFem[i / 2];
                artista.Nacionalidade = vNacionalidade[randNum.Next() % 8];
                contexto.Artistas.Add(artista);
             }
            contexto.SaveChanges();

            return View(contexto.Artistas.OrderBy(o => o.Id).ToList());
        }

    }
}

using LeagueOfShow.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeagueOfShow.Controllers
{
    public class ConsultaController : Controller
    {
        private readonly Contexto contexto;
            public ConsultaController(Contexto context)
        {
            contexto = context;
        }

        public async Task<IActionResult> League()
        {
            var Leag = contexto.Artistas.ToList();
            return View(Leag);
        }
    }
}

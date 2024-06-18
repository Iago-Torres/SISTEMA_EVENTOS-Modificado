using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SISTEMA_EVENTOS.MODEL.Models;
using System.Reflection.Metadata.Ecma335;




namespace SISTEMA_EVENTOS.Controllers
{
    public class EventoController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var db = new GerenciamentoEventosContext();

            return View(await db.Eventos.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Evento evento)
        {
            var db = new GerenciamentoEventosContext();
            if (ModelState.IsValid)
            {
                db.Entry(evento).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await db.SaveChangesAsync();
                ViewData["Mensagem"] = "Dados salvos com sucesso. ";
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao salvar os dados.";
            }
            return View(evento);
        }

        public async Task<IActionResult> Edit (int id)
        {
            var db = new GerenciamentoEventosContext();
            var evento = await db.Eventos.FindAsync(id);
            return View(evento);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Evento evento)
        {
            var db = new GerenciamentoEventosContext();
            if (ModelState.IsValid)
            {
                db.Entry(evento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                ViewData["Mensagem"] = "Dados alterados com sucesso.";
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao alterar os dados.";
            }
            return View(evento);
        }

        public async Task<IActionResult> Details(int id)
        {
            var db = new GerenciamentoEventosContext();
            var evento = await db.Eventos.FirstOrDefaultAsync(x => x.Id == id);
            return View(evento);

        }
    
        public async Task<IActionResult> Delete(int id)
        {
            var db = new GerenciamentoEventosContext();
            var evento = await db.Eventos.FirstOrDefaultAsync(x => x.Id == id);
            return View(evento);

        }

        [HttpPost]
        public async Task <IActionResult> Delete(Evento evento)
        {
            var db = new GerenciamentoEventosContext();
            db.Entry(evento).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

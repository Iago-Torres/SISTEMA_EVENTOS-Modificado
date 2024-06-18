using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SISTEMA_EVENTOS.MODEL.Models;
using System.Reflection.Metadata.Ecma335;

namespace SISTEMA_EVENTOS.Controllers
{
    public class InscricaoController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var db = new GerenciamentoEventosContext();

            return View(await db.Inscricaos.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Inscricao inscricao)
        {
            var db = new GerenciamentoEventosContext();
            if (ModelState.IsValid)
            {
                db.Entry(inscricao).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await db.SaveChangesAsync();
                ViewData["Mensagem"] = "Dados salvos com sucesso. ";
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao salvar os dados.";
            }
            return View(inscricao);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var db = new GerenciamentoEventosContext();
            var inscricao = await db.Inscricaos.FindAsync(id);
            return View(inscricao);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Inscricao inscricao)
        {
            var db = new GerenciamentoEventosContext();
            if (ModelState.IsValid)
            {
                db.Entry(inscricao).State = EntityState.Modified;
                await db.SaveChangesAsync();
                ViewData["Mensagem"] = "Dados alterados com sucesso.";
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao alterar os dados.";
            }
            return View(inscricao);
        }

        public async Task<IActionResult> Details(int id)
        {
            var db = new GerenciamentoEventosContext();
            var inscricao = await db.Inscricaos.FirstOrDefaultAsync(x => x.Id == id);
            return View(inscricao);

        }

        public async Task<IActionResult> Delete(int id)
        {
            var db = new GerenciamentoEventosContext();
            var inscricao = await db.Inscricaos.FirstOrDefaultAsync(x => x.Id == id);
            return View(inscricao);

        }

        [HttpPost]
        public async Task<IActionResult> Delete(Inscricao inscricao)
        {
            var db = new GerenciamentoEventosContext();
            db.Entry(inscricao).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

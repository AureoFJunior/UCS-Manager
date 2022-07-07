using Californication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Californication.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PessoaController : Controller
    {
        private readonly Context Context;

        public PessoaController(Context context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pessoas = await Context.Pessoa.ToListAsync();
            return Ok(pessoas);
        }

        [HttpGet("{pessoaId}")]
        public async Task<IActionResult> GetById(int pessoaId)
        {
            return Ok(await Context.Pessoa.FindAsync(pessoaId));
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Pessoa pessoa)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            await Context.Pessoa.AddAsync(pessoa);
            await Context.SaveChangesAsync();

            return Ok(pessoa);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Pessoa pessoa)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Context.Pessoa.Update(pessoa);
            await Context.SaveChangesAsync();

            return Ok(pessoa);
        }

        [HttpDelete("{pessoaId}")]
        public async Task<IActionResult> Delete(int pessoaId)
        {
            var pessoa = await Context.Pessoa.FindAsync(pessoaId);

            Context.Pessoa.Remove(pessoa!);
            await Context.SaveChangesAsync();
            return Ok(true);
        }
    }
}

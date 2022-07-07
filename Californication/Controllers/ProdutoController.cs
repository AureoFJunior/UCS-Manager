using Californication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Californication.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProdutoController : Controller
    {
        private readonly Context Context;

        public ProdutoController(Context context)
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
            var pessoas = await Context.Produto.ToListAsync();
            return Ok(pessoas);
        }

        [HttpGet("{produtoid}")]
        public async Task<IActionResult> GetById(int produtoid)
        {
            return Ok(await Context.Produto.FindAsync(produtoid));
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Produto produto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            await Context.Produto.AddAsync(produto);
            await Context.SaveChangesAsync();

            return Ok(produto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Produto produto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Context.Produto.Update(produto);
            await Context.SaveChangesAsync();

            return Ok(produto);
        }

        [HttpDelete("{produtoId}")]
        public async Task<IActionResult> Delete(int produtoId)
        {
            var produto = await Context.Produto.FindAsync(produtoId);

            Context.Produto.Remove(produto!);
            await Context.SaveChangesAsync();
            return Ok(true);
        }
    }
}

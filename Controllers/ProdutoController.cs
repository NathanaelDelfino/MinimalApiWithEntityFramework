using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MinimalApiWithEntityFramework.Data;
using MinimalApiWithEntityFramework.Entities;
using MinimalApiWithEntityFramework.ViewModel;

namespace MinimalApiWithEntityFramework.Controllers
{
    [ApiController]
    [Route("v1")]
    public class ProdutoController : ControllerBase
    {
        //O DataAppContext é a instancia do banco de dados
        [HttpGet]
        [Route("produtos")]
        public IActionResult ObterProdutos([FromServices] DataAppContext context)
        {
            return Ok(context.Produtos.Take(100).ToList());
        }

        [HttpGet]
        [Route("produtos/{id}")]
        public IActionResult ObterProdutoPorId([FromServices] DataAppContext context, string id)
        {
            var produto = context.Produtos.FirstOrDefault(x => x.Id == id);
            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpPost]
        [Route("produtos")]
        public IActionResult InserirProduto([FromServices] DataAppContext context, [FromBody] ProdutoViewModel produto)
        {
            var novoProduto = Produto.Criar(produto);            
            context.Produtos.Add(novoProduto);
            context.SaveChanges();
            return CreatedAtAction(nameof(ObterProdutoPorId), new { id = novoProduto.Id }, produto);
        }

        [HttpPut]
        [Route("produtos/{id}")]
        public IActionResult AtualizarProduto([FromServices] DataAppContext context, string id, [FromBody] ProdutoViewModel produto)
        {
            var produtoAtual = context.Produtos.FirstOrDefault(x => x.Id == id);
            if (produtoAtual == null)
                return NotFound();

            produtoAtual.Atualizar(produto);
            context.Produtos.Update(produtoAtual);
            context.SaveChanges();
            return Ok(new { message = "Produto atualizado com sucesso!" });
        }

        [HttpDelete]
        [Route("produtos/{id}")]
        public IActionResult DeletarProduto([FromServices] DataAppContext context, string id)
        {
            var produto = context.Produtos.FirstOrDefault(x => x.Id == id);
            if (produto == null)
                return NotFound();

            context.Produtos.Remove(produto);
            context.SaveChanges();
            return Ok(new { message = "Produto removido com sucesso!" });
        }
    }
}
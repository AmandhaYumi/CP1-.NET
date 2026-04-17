using Kova.Application.Interfaces.Repositories;
using Kova.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Kova.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var produtos = produtoRepository.GetAll();
        return Ok(produtos);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var produto = produtoRepository.GetById(id);
        if (produto is null)
            return NotFound();

        return Ok(produto);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateProdutoRequest request)
    {
        var categoria = categoriaRepository.GetById(request.CategoriaId);
        if (categoria is null)
            return BadRequest("CategoriaId inválido.");

        var produto = new Produto(request.Nome, request.Descricao, request.Preco, request.CategoriaId);
        produtoRepository.Add(produto);
        produtoRepository.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        var produto = produtoRepository.GetById(id);
        if (produto is null)
            return NotFound();

        produtoRepository.Delete(produto);
        produtoRepository.SaveChanges();
        return NoContent();
    }

    public sealed record CreateProdutoRequest(string Nome, string Descricao, decimal Preco, Guid CategoriaId);
}
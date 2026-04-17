using Kova.Application.Interfaces.Repositories;
using Kova.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Kova.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController(ICategoriaRepository categoriaRepository) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var categorias = categoriaRepository.GetAll();
        return Ok(categorias);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var categoria = categoriaRepository.GetById(id);
        if (categoria is null)
            return NotFound();

        return Ok(categoria);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateCategoriaRequest request)
    {
        var categoria = new Categoria(request.Nome, request.Descricao);
        categoriaRepository.Add(categoria);
        categoriaRepository.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = categoria.Id }, categoria);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        var categoria = categoriaRepository.GetById(id);
        if (categoria is null)
            return NotFound();

        categoriaRepository.Delete(categoria);
        categoriaRepository.SaveChanges();
        return NoContent();
    }

    public sealed record CreateCategoriaRequest(string Nome, string Descricao);
}
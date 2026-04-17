using Kova.Application.Interfaces.Repositories;
using Kova.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Kova.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController(IClienteRepository clienteRepository) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var clientes = clienteRepository.GetAll();
        return Ok(clientes);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var cliente = clienteRepository.GetById(id);
        if (cliente is null)
            return NotFound();

        return Ok(cliente);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateClienteRequest request)
    {
        var cliente = new Cliente(request.Nome, request.Email, request.Telefone);
        clienteRepository.Add(cliente);
        clienteRepository.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        var cliente = clienteRepository.GetById(id);
        if (cliente is null)
            return NotFound();

        clienteRepository.Delete(cliente);
        clienteRepository.SaveChanges();
        return NoContent();
    }

    public sealed record CreateClienteRequest(string Nome, string Email, string Telefone);
}
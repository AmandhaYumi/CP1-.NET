using Kova.Application.Interfaces.Repositories;
using Kova.Domain.Entities;
using Kova.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Kova.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidoController(
    IPedidoRepository pedidoRepository,
    IClienteRepository clienteRepository,
    IPagamentoRepository pagamentoRepository) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var pedidos = pedidoRepository.GetAll();
        return Ok(pedidos);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var pedido = pedidoRepository.GetById(id);
        if (pedido is null)
            return NotFound();

        return Ok(pedido);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreatePedidoRequest request)
    {
        var cliente = clienteRepository.GetById(request.ClienteId);
        if (cliente is null)
            return BadRequest("ClienteId inválido.");

        var pagamento = pagamentoRepository.GetById(request.PagamentoId);
        if (pagamento is null)
            return BadRequest("PagamentoId inválido.");

        var pedido = new Pedido(request.ValorTotal, request.Status, request.ClienteId, request.PagamentoId);
        pedidoRepository.Add(pedido);
        pedidoRepository.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = pedido.Id }, pedido);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        var pedido = pedidoRepository.GetById(id);
        if (pedido is null)
            return NotFound();

        pedidoRepository.Delete(pedido);
        pedidoRepository.SaveChanges();
        return NoContent();
    }

    public sealed record CreatePedidoRequest(decimal ValorTotal, StatusPedido Status, Guid ClienteId, Guid PagamentoId);
}
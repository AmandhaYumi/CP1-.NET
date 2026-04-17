using Kova.Application.Interfaces.Repositories;
using Kova.Domain.Entities;
using Kova.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Kova.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PagamentoController(IPagamentoRepository pagamentoRepository) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var pagamentos = pagamentoRepository.GetAll();
        return Ok(pagamentos);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var pagamento = pagamentoRepository.GetById(id);
        if (pagamento is null)
            return NotFound();

        return Ok(pagamento);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreatePagamentoRequest request)
    {
        var pagamento = new Pagamento(request.Status, request.Tipo);
        pagamentoRepository.Add(pagamento);
        pagamentoRepository.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = pagamento.Id }, pagamento);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        var pagamento = pagamentoRepository.GetById(id);
        if (pagamento is null)
            return NotFound();

        pagamentoRepository.Delete(pagamento);
        pagamentoRepository.SaveChanges();
        return NoContent();
    }

    public sealed record CreatePagamentoRequest(StatusPagamento Status, TipoPagamento Tipo);
}
using Kova.Domain.Commons;
using Kova.Domain.Enums;

namespace Kova.Domain.Entities;

public class Pedido : BaseEntity
{
    public decimal ValorTotal { get; private set; }

    public StatusPedido Status { get; private set; }

    public Guid ClienteId { get; private set; }

    public Cliente Cliente { get; private set; }

    public Guid PagamentoId { get; private set; }

    public Pagamento Pagamento { get; private set; }

    public List<Produto> Produtos { get; private set; } = new();

    public Pedido(decimal valorTotal, StatusPedido status, Guid clienteId, Guid pagamentoId)
    {
        if (valorTotal < 1)
            throw new Exception("Valor Total inválido");

        ValorTotal = valorTotal;
        Status = status;
        ClienteId = clienteId;
        PagamentoId = pagamentoId;
    }
}


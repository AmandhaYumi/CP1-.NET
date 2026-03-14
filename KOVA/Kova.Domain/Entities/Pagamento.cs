using Kova.Domain.Commons;
using Kova.Domain.Enums;

namespace Kova.Domain.Entities;

public class Pagamento : BaseEntity
{
    public StatusPagamento Status { get; private set; }

    public TipoPagamento Tipo { get; private set; }

    public Pagamento(StatusPagamento status, TipoPagamento tipo)
    {
        Status = status;
        Tipo = tipo;
    }
}

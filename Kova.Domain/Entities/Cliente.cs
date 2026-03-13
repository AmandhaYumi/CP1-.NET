using Kova.Domain.Commons;

namespace Kova.Domain.Entities;

public class Cliente : BaseEntity
{
    public string Nome { get; private set; }

    public string Email { get; private set; }

    public string Telefone { get; private set; }

    public List<Pedido> Pedidos { get; private set; } = new();

    public Cliente(string nome, string email, string telefone)
    {
        if (nome == null || nome.Length < 2)
            throw new Exception("Nome inválido");

        Nome = nome;

        if (email == null || email.Length < 5)
            throw new Exception("Email inválido");

        Email = email;

        if (telefone == null || telefone.Length != 11)
            throw new Exception("Telefone inválido");

        Telefone = telefone;
    }
}

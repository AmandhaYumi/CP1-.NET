# 📄 CP1 - .NET | KOVA

## 👥 Integrantes do Grupo

| Nome | RM |
|-----|-----|
| Amandha Yumi Toyota Artulino | 563549 |
| Erick Takeshi Andrade Nakajune | 566059 |
| Giovanna Bardella Gomes | 561439 |

---

## 🛍️ Domínio do Projeto

O projeto **KOVA** representa um **e-commerce de roupas**, onde clientes podem:

- visualizar produtos
- realizar pedidos
- efetuar pagamentos

O sistema foi modelado para representar o fluxo básico de compras em uma loja online.

---

## 🗂️ Entidades Modeladas

As principais entidades do sistema são:

- **Cliente**
- **Pedido**
- **Pagamento**
- **Produto**
- **Categoria**

---

## 🔗 Relacionamentos do Sistema

Os relacionamentos entre as entidades foram definidos da seguinte forma:

- **Cliente → Pedido**  
  Um cliente pode realizar um ou mais pedidos.

- **Pedido → Pagamento**  
  Todo pedido necessita de um pagamento para ser concluído.

- **Pedido → Produto**  
  Um pedido contém produtos selecionados pelo cliente.

- **Produto → Categoria**  
  Cada produto pertence a uma categoria.

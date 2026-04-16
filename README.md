# CP2 - Persistência com EF Core | KOVA

## Integrantes do Grupo

| Nome | RM |
|------|----|
| Amandha Yumi Toyota Artulino | 563549 |
| Erick Takeshi Andrade Nakajune | 566059 |
| Giovanna Bardella Gomes | 561439 |

---

## Domínio do Projeto

O projeto **KOVA** representa um **e-commerce de roupas**, modelado com foco no fluxo principal de compra em uma loja online.

O sistema permite que clientes visualizem produtos, realizem pedidos e efetuem pagamentos, com as entidades organizadas em camadas seguindo os princípios de **Clean Architecture**.

---

## Objetivo desta Entrega

Esta entrega corresponde ao **CP2**, com foco em:

- persistência com Entity Framework Core
- organização em camadas
- criação de DbContext
- mapeamentos com Fluent API
- criação e versionamento de migrations
- implementação de repositórios por contrato
- configuração de injeção de dependência
- uso de connection string de forma segura

---

## Tecnologias Utilizadas

- .NET
- ASP.NET Core Web API
- Entity Framework Core
- Oracle Entity Framework Core Provider
- Oracle Database

---

## Estrutura da Solução

A solução está organizada em camadas:

- Kova.Domain  
  Contém as entidades e regras centrais do domínio.

- Kova.Application  
  Contém as interfaces de repositório e contratos da aplicação.

- Kova.Infrastructure  
  Contém:
  - DbContext
  - configurações de mapeamento com Fluent API
  - implementações de repositório
  - migrations

- Kova.api  
  Projeto responsável pela exposição da API e configuração de DI.

---

## Entidades Modeladas

As principais entidades do sistema são:

- Cliente
- Pedido
- Pagamento
- Produto
- Categoria

---

## Relacionamentos do Sistema

Os relacionamentos foram modelados da seguinte forma:

- Cliente -> Pedido  
  Um cliente pode realizar um ou mais pedidos.

- Pedido -> Pagamento  
  Todo pedido possui um pagamento associado.

- Pedido -> Produto  
  Vários pedidos podem conter vários produtos.

- Produto -> Categoria  
  Cada produto possui uma categoria.

- Pedido <-> Produto  
  Relacionamento muitos-para-muitos mapeado explicitamente.

---

## Persistência com EF Core

A persistência foi implementada na camada Infrastructure, contendo:

- KovaDbContext
- configurações por entidade com IEntityTypeConfiguration<T>
- mapeamentos com Fluent API
- migration inicial com o esquema do banco
- repositórios concretos

---

## Repositórios

As interfaces dos repositórios foram definidas na camada Application, e suas implementações foram criadas na camada Infrastructure.

Exemplos:

- IClienteRepository
- ICategoriaRepository
- IProdutoRepository
- IPedidoRepository
- IPagamentoRepository

---

## Injeção de Dependência

O registro de dependências foi configurado no projeto da API, utilizando um método de extensão da camada Infrastructure, incluindo:

- AddDbContext
- registro dos repositórios

---

## Banco de Dados Utilizado

O SGBD utilizado neste projeto é:

Oracle SQL Developer

---

## Connection String

A connection string deve ser configurada no arquivo appsettings.Development.json do projeto da API.

Exemplo seguro:

```json
{
  "ConnectionStrings": {
    "KovaOracle": "Data Source=oracle.fiap.com.br:1521/orcl;User ID=<USUARIO>;Password=<SENHA>;"
  }
}
---

## Como Executar o Projeto

1. Restaurar os pacotes

```
dotnet restore
```

2. Compilar a solução

```
dotnet build
```

3. Aplicar a migration no banco

```
dotnet ef database update --project KOVA/Kova.Infrastructure --startup-project KOVA/Kova.api
```

4. Executar a API

```
dotnet run --project KOVA/Kova.api
```

---

## Migrations

A solução contém migration versionada para criação inicial do schema do banco.

Exemplo de comando para gerar migrations:

```
dotnet ef migrations add InitialCreate --project KOVA/Kova.Infrastructure --startup-project KOVA/Kova.api
```

Exemplo de comando para aplicar:

```
dotnet ef database update --project KOVA/Kova.Infrastructure --startup-project KOVA/Kova.api
```

---

## Evidências

As evidências complementares da entrega podem ser encontradas na pasta /docs, incluindo:

- diagrama do esquema
- MER atualizado
- prints do banco
- justificativas de ajustes realizados

---

## Observações Finais

O projeto foi estruturado respeitando os princípios de separação por camadas, mantendo a persistência concentrada na Infrastructure, os contratos na Application e a configuração da API no projeto Kova.api.

Nenhuma regra de negócio complexa foi colocada na camada de infraestrutura, mantendo o foco da entrega em persistência, mapeamento e organização arquitetural.

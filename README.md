# API Minha Loja

Este é um projeto de API para gerenciar uma loja, incluindo funcionalidades para clientes, pedidos, produtos e a relação entre pedidos e produtos.

## Estrutura do Projeto

A estrutura do projeto está organizada da seguinte forma:

```
/APIminhaLoja
├── /Controllers
│   ├── ClienteController.cs
│   ├── PedidoController.cs
│   ├── PedidoProdutoController.cs
│   └── ProdutoController.cs
├── /Models
│   ├── Cliente.cs
│   ├── Pedido.cs
│   ├── PedidoProduto.cs
│   └── Produto.cs
├── /Data
│   ├── ApplicationDbContext.cs
│   └── Migrations/
├── appsettings.json
├── Program.cs
└── Startup.cs
```

- **Controllers**: Contém os controladores que gerenciam as requisições HTTP.
- **Models**: Contém as classes que representam as entidades do banco de dados.
- **Data**: Contém a configuração do contexto do banco de dados e as migrações do Entity Framework.
- **appsettings.json**: Arquivo de configuração da aplicação.
- **Program.cs**: Ponto de entrada da aplicação.
- **Startup.cs**: Configuração dos serviços e do pipeline de requisições da aplicação.


## Configuração do Projeto

### Pré-requisitos

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Visual Studio Code](https://code.visualstudio.com/) ou [Visual Studio](https://visualstudio.microsoft.com/)

### Passo a Passo

1. **Clone o repositório:**

    ```sh
    git clone https://github.com/alvesjaov/APIminhaLoja
    cd seu-repositorio/minhaLoja
    ```

2. **Restaurar pacotes NuGet:**

    ```sh
    dotnet restore
    ```

3. **Configurar o banco de dados:**

    Edite o arquivo `appsettings.json` para configurar a string de conexão com o seu banco de dados. Exemplo:

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=seu-servidor;Database=sua-base-de-dados;User Id=seu-usuario;Password=sua-senha;"
      },
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "AllowedHosts": "*"
    }
    ```

4. **Aplicar migrações do Entity Framework:**

    ```sh
    dotnet ef database update
    ```

5. **Executar o projeto:**

    ```sh
    dotnet run
    ```

## Estrutura dos Controladores

- **ClienteController**: Gerencia operações relacionadas aos clientes.
- **PedidoController**: Gerencia operações relacionadas aos pedidos.
- **PedidoProdutoController**: Gerencia operações relacionadas à relação entre pedidos e produtos.
- **ProdutoController**: Gerencia operações relacionadas aos produtos.

## Endpoints

### Clientes

- `GET /api/cliente`: Retorna todos os clientes.
- `GET /api/cliente/{id}`: Retorna um cliente específico.
- `POST /api/cliente`: Cria um novo cliente.
- `PUT /api/cliente/{id}`: Atualiza um cliente existente.
- `DELETE /api/cliente/{id}`: Deleta um cliente.

### Pedidos

- `GET /api/pedido`: Retorna todos os pedidos.
- `GET /api/pedido/{id}`: Retorna um pedido específico.
- `POST /api/pedido`: Cria um novo pedido.
- `PUT /api/pedido/{id}`: Atualiza um pedido existente.
- `DELETE /api/pedido/{id}`: Deleta um pedido.

### Produtos

- `GET /api/produto`: Retorna todos os produtos.
- `GET /api/produto/{id}`: Retorna um produto específico.
- `POST /api/produto`: Cria um novo produto.
- `PUT /api/produto/{id}`: Atualiza um produto existente.
- `DELETE /api/produto/{id}`: Deleta um produto.

### PedidoProduto

- `GET /api/pedidoproduto`: Retorna todas as relações entre pedidos e produtos.
- `GET /api/pedidoproduto/{pedidoId}/{produtoId}`: Retorna uma relação específica entre pedido e produto.
- `POST /api/pedidoproduto`: Cria uma nova relação entre pedido e produto.
- `PUT /api/pedidoproduto/{pedidoId}/{produtoId}`: Atualiza uma relação existente entre pedido e produto.
- `DELETE /api/pedidoproduto/{pedidoId}/{produtoId}`: Deleta uma relação entre pedido e produto.

## Contribuição

Sinta-se à vontade para contribuir com este projeto. Para isso, siga os passos abaixo:

1. Faça um fork do projeto.
2. Crie uma branch para sua feature (`git checkout -b feature/nova-feature`).
3. Commit suas mudanças (`git commit -am 'Adiciona nova feature'`).
4. Faça o push para a branch (`git push origin feature/nova-feature`).
5. Crie um novo Pull Request.

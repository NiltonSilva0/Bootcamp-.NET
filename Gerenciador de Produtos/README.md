# Gerenciador de Produtos API

Esta é uma API desenvolvida em ASP.NET Core 8 para gerir um catálogo de produtos, permitindo operações de consulta, criação, atualização e exclusão.

## Pré-requisitos

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) ou superior.
- Um editor de código como [Visual Studio Code](https://code.visualstudio.com/) ou [JetBrains Rider](https://www.jetbrains.com/rider/).
- Uma ferramenta para testar APIs, como [Postman](https://www.postman.com/) ou o próprio Swagger UI da aplicação.

## Como Configurar e Executar o Projeto

### 1. Clonar o Repositório

Clone este repositório para a sua máquina local:

```bash
git clone <URL_DO_SEU_REPOSITORIO>
cd <NOME_DA_PASTA_DO_PROJETO>
```

### 2. Restaurar as Dependências

Abra um terminal na pasta raiz do projeto e execute o comando abaixo para restaurar os pacotes NuGet necessários:

```bash
dotnet restore
```

### 3. Aplicar as Migrações do Banco de Dados

A aplicação utiliza o Entity Framework Core com um banco de dados SQLite. Para criar o banco de dados e aplicar as migrações, execute o seguinte comando no terminal, dentro da pasta `Gerenciador de Produtos`:

```bash
dotnet ef database update -p "Gerenciador de Produtos/Gerenciador de Produtos.csproj" -s "Gerenciador de Produtos/Gerenciador de Produtos.csproj"
```
Este comando irá criar o ficheiro `gerenciador.db` na raiz do projeto com todas as tabelas necessárias.

### 4. Executar a API

Após a configuração do banco de dados, inicie a aplicação com o comando:

```bash
dotnet run --project "Gerenciador de Produtos/Gerenciador de Produtos.csproj"
```

A API estará disponível em `https://localhost:XXXX` e `http://localhost:YYYY`. As portas exatas são definidas no ficheiro `Properties/launchSettings.json`.

Por defeito, ao aceder a `https://localhost:XXXX/swagger`, a interface do Swagger UI será aberta, permitindo-lhe explorar e testar todos os endpoints da API.

## Exemplo de Uso: Criar Produtos

Para criar novos produtos, pode usar o endpoint `POST /api/Gerenciador/criar-produto`.

**URL:** `https://localhost:XXXX/api/Gerenciador/criar-produto`

**Corpo da Requisição (JSON):**

```json
[
  {
    "nomeCategoria": "Alimentos",
    "nome": "Arroz Branco",
    "descricao": "Pacote de 5kg de arroz tipo 1",
    "preco": 25.50,
    "qtdEmEstoque": 150
  },
  {
    "nomeCategoria": "Eletronicos",
    "nome": "Teclado Mecânico",
    "descricao": "Teclado com switches azuis e RGB",
    "preco": 350.00,
    "qtdEmEstoque": 30
  },
  {
    "nomeCategoria": "Livros",
    "nome": "O Guia do Mochileiro das Galáxias",
    "descricao": "Edição de colecionador",
    "preco": 42.00,
    "qtdEmEstoque": 0
  }
]
```

**Nota:** O `status` do produto (`EmEstoque` ou `Indisponivel`) é definido automaticamente com base na `qtdEmEstoque`
ou quando o produto é deletado (soft delete).

## Endpoints Principais

- `GET /api/Gerenciador/obter-todos-produtos`: Retorna todos os produtos em estoque.
- `GET /api/Gerenciador/obter-produto-por-id/{id}`: Retorna um produto específico pelo seu ID.
- `GET /api/Gerenciador/obter-produtos-por-categoria/{categoryId}`: Retorna todos os produtos de uma determinada categoria.
- `POST /api/Gerenciador/criar-produto`: Cria um ou mais produtos.
- `DELETE /api/Gerenciador/deletar-produto/{id}`: Marca um produto como indisponível (soft delete).
- `GET /api/Gerenciador/obter-produtos-indisponiveis`: Retorna todos os produtos marcados como indisponíveis.


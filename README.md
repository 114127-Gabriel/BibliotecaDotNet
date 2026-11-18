TENTATIVA DE BIBLIOTECA

1. PIFER THE FIRST (Gabriel Pifer Matias Galvão de França)
2. PIFER THE SECOND (Guilherme Pifer Matias Galvão de França)

VOU SER SINSERO, NÃO TIVE TEMPO DE TESTAR TUDO MAS POR EU TER VERIFICADO VARIAS VEZES ANTES DE TERMINAR EU ACHO QUE ESTÁ TUDO CERTO. PEDI AO CHAT GPT PRA FAZER OS TESTES PARA MIM. ENTÃO SE TIVER ALGO MUITO FORA DA CURVA JÁ ESTÁ EXPLICADO.

# Sistema de Gerenciamento de Biblioteca

## 1. Descrição do sistema

O projeto consiste no desenvolvimento de uma Web API para o gerenciamento de uma biblioteca universitária, permitindo realizar operações de cadastro, consulta, atualização e exclusão de materiais do acervo.

O sistema trabalha com dois tipos de materiais: livros e revistas. Cada tipo possui características e comportamentos específicos, como autor e quantidade de páginas para livros, edição e mês de publicação para revistas.

A aplicação foi desenvolvida utilizando conceitos de Programação Orientada a Objetos, como herança, abstração, encapsulamento e polimorfismo, além de interfaces e do padrão Repository para organizar e separar as responsabilidades do código.

Os dados são armazenados em memória utilizando um `Dictionary`, sem a necessidade de um banco de dados. O padrão Singleton é utilizado para manter uma única instância do repositório durante a execução da aplicação.

## 2. Tecnologias utilizadas

- **C#** – Linguagem de programação utilizada no desenvolvimento.
- **.NET 10** – Plataforma utilizada para executar a aplicação.
- **ASP.NET Core Web API** – Framework utilizado para desenvolver os endpoints da API.
- **Swagger (Swashbuckle)** – Ferramenta utilizada para documentar e testar as requisições HTTP.
- **Dictionary** – Estrutura utilizada para armazenar os materiais em memória.
- **Repository Pattern** – Padrão utilizado para separar o gerenciamento dos dados da Controller.
- **Injeção de Dependência** – Recurso utilizado para fornecer o repositório à Controller.
- **Singleton** – Padrão utilizado para manter uma única instância do repositório durante a execução.
- **CORS** – Configuração que permite que aplicações externas possam consumir a API.

## 3. Como executar

### Pré-requisitos

- SDK do .NET 10 instalado.
- Git instalado.

### Passo a passo

**1. Clonar o repositório:**

```bash
git clone https://github.com/114127-Gabriel/BibliotecaDotNet.git
```

**2. Entrar na pasta do projeto:**

```bash
cd BibliotecaDotNet
```

**3. Restaurar as dependências:**

```bash
dotnet restore
```

**4. Executar a aplicação:**

```bash
dotnet run --launch-profile https
```

**5. Acessar o Swagger:**

Após iniciar a aplicação, abra o navegador e acesse:

https://localhost:7073/swagger

O Swagger permite visualizar os endpoints disponíveis e realizar testes de cadastro, consulta, atualização e exclusão de materiais.

**Observação:** Os dados são armazenados somente em memória. Portanto, ao encerrar a aplicação, os materiais cadastrados durante a execução serão perdidos.

## 4. Principais endpoints

A API disponibiliza operações para gerenciar livros e revistas por meio dos seguintes endpoints:

| Método HTTP | Endpoint | Descrição |
|---|---|---|
| GET | `/api/Materiais` | Lista todos os materiais cadastrados. |
| GET | `/api/Materiais/{id}` | Consulta um material pelo ID. |
| POST | `/api/Materiais/livro` | Cadastra um novo livro. |
| POST | `/api/Materiais/revista` | Cadastra uma nova revista. |
| PUT | `/api/Materiais/livro/{id}` | Atualiza os dados de um livro. |
| PUT | `/api/Materiais/revista/{id}` | Atualiza os dados de uma revista. |
| DELETE | `/api/Materiais/{id}` | Exclui um material pelo ID. |
| GET | `/api/Materiais/{id}/descricao` | Retorna a descrição e o prazo de empréstimo do material. |
| POST | `/api/Materiais/{id}/emprestar` | Verifica se o material permite empréstimo. |

## 5. Exemplos de testes

Os testes são realizados por meio do Swagger, utilizando os métodos HTTP disponíveis na API.

### 5.1. Cadastro de livro

**Endpoint:** `POST /api/Materiais/livro`

**Corpo da requisição:**

```json
{
  "titulo": "Clean Code",
  "anoPublicacao": 2008,
  "autor": "Robert C. Martin",
  "paginas": 464
}
```

**Resultado esperado:** `201 Created`, com os dados do livro cadastrado e seu ID gerado automaticamente pelo sistema.

### 5.2. Cadastro de revista

**Endpoint:** `POST /api/Materiais/revista`

**Corpo da requisição:**

```json
{
  "titulo": "Tecnologia e Inovação",
  "anoPublicacao": 2024,
  "edicao": 15,
  "mesPublicacao": 8
}
```

**Resultado esperado:** `201 Created`, com os dados da revista e seu ID gerado automaticamente.

### 


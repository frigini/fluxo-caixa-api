# API Fluxo Caixa
Este é um projeto de API RESTful para gerenciamento de fluxo de caixa de uma empresa. Com ele, é possível cadastrar lançamentos de crédito e débito e verificar o saldo diário.

## Desenho da arquitetura


## Padrões de microserviço utilizados
* Separação em camadas (Core, Presentation, Application, Domain e Infra)
* Injeção de dependências
* Uso de DTOs para transferência de dados entre a API e o banco de dados

## Padrões de projetos utilizados
- `Factory`: utilizado para construir objetos entre as camadas.
- `Repository`: utilizado para abstrair a camada de acesso ao banco de dados.
- `DTO`: utilizado para transferência de dados entre as camadas.
- `DDD`: desenvolvimento focado no domínio

## Tecnologias e bibliotecas usadas
- ``.Net 8.0``
- ``Entity Framework Core 8.0.6``
- ``JWT``
- ``SQL Server Database``
- ``Swagger 3``

## Endpoints
- `POST users/adicionar-usuario`: endpoint para adicionar um usuário.
- `POST users/autenticar-usuario`: endpoint para realizar a autenticação de um usuário e gerar um token JWT.
- `GET users/listar-usuarios`: endpoint para listar todos os usuários.
- `GET balances/listar-saldo-consolidado/{data}`: endpoint para calcular o saldo diário de uma determinada data.
- `POST payments/lancar-pagamento`: endpoint para lançar um pagamento.
- `GET payments/buscar-lancamento/{id}`: endpoint para buscar um lançamento por id.
- `GET payments/listar-lancamentos`: endpoint para listar todos os lançamentos.
- `GET payments/listar-lancamentos-por-data?data={data}`: endpoint para listar todos os lançamentos de uma determinada data.

## Execução do projeto
Para executar o projeto, é necessário ter o Visual Studio ou o Visual Studio Code instalados.

## Como usar
Para usar a API, é necessário ter o Docker e o Docker Compose instalados.
## Clone o repositório:

```
git clone https://github.com/frigini/desafio-carrefour.git
```
## Entre na pasta do projeto:
```
cd ../desafio-carrefour
```

## Execute o docker-compose:
```bash
docker-compose up --build
```

## Autenticação por token
Para utilizar as funcionalidades da API, é necessário realizar a autenticação e obter um token JWT.

Endpoint de autenticação:
POST users/autenticar-usuario
```
Body:
{
    "login": "admin",
    "password": "123"
}
```

A resposta será um token JWT, que deve ser incluído no header da API, no formato "Bearer {token}".
## Testes unitários
Para rodar os testes unitários, execute o comando abaixo:



## Observability
A aplicação possui o Spring Boot Actuator configurado para expor os endpoints /health, /info e /metrics na porta 1979. 
Para acessá-los, utilize o seguinte endereço: 

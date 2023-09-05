<div align="center">
     <img src="./ArmazemDoMagoLogo.png" width="450px">
</div>

<h4 align="center">Cansado de bagunça no seu armazém mágico? Deixe a desordem desaparecer com ArmazemDoMago! ✨ </h4>

<p align="center">
    <img src="https://img.shields.io/github/last-commit/yagopeixinho/ArmazemDoMago?color=84A3E3">
    <img src="https://img.shields.io/github/languages/count/yagopeixinho/veiacoPlataforma?color=FFD700">
</p>

<p align="center">
  <a href="#visão-geral">Visão Geral</a> •
  <a href="#funcionalidades">Funcionalidades</a> •
  <a href="#instalação">Instalação</a> •   
  <a href="#recursos">Recursos</a> 
</p>

## Visão Geral
O ArmazemDoMago é a solução perfeita para magos que desejam manter um inventário organizado de seus itens mágicos. 

## Funcionalidades
### Principais funcionalidades:
- Adicionar novos itens ao seu armazém mágico.
- Remover itens que não são mais necessários.
- Listar todos os seus itens para uma visão geral rápida.
- Atualizar informações sobre itens existentes.
- Notificação de baixo estoque
- Listagem organizada

### Tecnologias utilizadas:
- .Net Core 6
- Entity Framework Core 
- SQLite
- JWT para Autenticação

## Instalação

Antes de rodar o projeto, é necessário ter instalado em sua máquina:

- [Git](https://git-scm.com/)
- DB Browser (SQLite) - Opcional
- Um IDE de sua preferência (Recomendo o Visual Studio 2022)

### 📦 Clonando repositório

```bash
$ git clone git@github.com:yagopeixinho/ArmazemDoMago.gitt
```

### Banco de Dados
O ArmazemDoMago API utiliza o SQLite como seu banco de dados principal. Um arquivo chamado `database.db` já está incluso no projeto, minimamente populado com algumas informações e contendo todas as atualizações necessárias. Isso significa que não é necessário executar nenhum comando de migração ou configuração adicional do banco de dados.

### Autenticação
Para garantir a segurança e o acesso às rotas protegidas, foi implementado um sistema de autenticação baseado em JSON Web Tokens (JWT).
  
Para começar, você deve registrar um usuário para obter acesso às funcionalidades protegidas. Para fazer isso, faça uma requisição para a rota de registro:

#### /api/Autenticacao/registrar
Informe os dados de registro do usuário no corpo da requisição

```json
{
  "email": "seu-email@example.com",
  "senha": "senha-segura"
}
```

Geração de Token de Acesso
Uma vez registrado, você pode gerar um Token de Acesso para autenticar suas futuras solicitações às rotas seguras. Acesse a rota de login:
##### /api/Autenticacao/login

Novamente, forneça as informações de login no corpo da requisição, utilizando o mesmo endereço de e-mail e senha definidos durante o registro:
```json
{
  "email": "seu-email@example.com",
  "senha": "senha-segura"
}
```

<details>
  <summary>Continuar autenticação com o Swagger</summary>
     
### Swagger
Após uma autenticação bem-sucedida, você receberá um token no formato JWT que deve ser incluído no cabeçalho de suas solicitações às rotas protegidas. Para fazer isso no Swagger, clique em "Authorize" e insira o token no seguinte formato:
```
Bearer {seu-token-aqui}
````
Um exemplo real seria:
```
Bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMTIzQGdtYWlsLmNvbSIsImV4cCI6MTY5Mzk1Mzc3M30.mVKVDUpYUt8IltWPEVFs9ikkcqQw5eUYkoq2EnWGMOWjbw0OfJEqRVN1o3hzk_jKOgfi25htQjGcVGdYLPkKSw
```

Agora você pode acessar todas as rotas seguras da API com segurança!

</details>

<details>
  <summary>Continuar autenticação com o Postman</summary>
     
### Postman
Após uma autenticação bem-sucedida, você receberá um token no formato JWT que deve ser incluído no cabeçalho de suas solicitações às rotas protegidas. Para fazer isso no Postman, clique em "Authorization" 
no método selecionado e informe o Type: __Bearer Token__.

Na variável _Token_, basta informar o Token que foi gerado e agora você pode acessar todas as rotas seguras da API com segurança!

</details>

## Recursos

### GET /api/Armazem
Obtém a lista de todos os itens mágicos no armazém, ordenados do item mais poderoso para o mais fraco.

### GET /api/Armazem/{id}
Obtém informações detalhadas sobre um item mágico específico no armazém.

### POST /api/Armazem
Adiciona um novo item mágico ao armazém.

### PUT /api/Armazem/{id}
Atualiza informações sobre um item mágico existente no armazém.

### DELETE /api/Armazem/{id}
Remove um item mágico do armazém.




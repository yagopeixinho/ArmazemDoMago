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
  <a href="#recursos">Recursos</a> • 
  <a href="#contato">Contato</a> •   
  <a href="#licença">Licença</a>   

</p>

## Visão Geral
O ArmazemDoMago é um projeto encantador que combina o mundo da magia com a tecnologia moderna para criar uma experiência única para magos e entusiastas do oculto. Este projeto tem como objetivo principal fornecer uma plataforma onde os usuários possam gerenciar seus itens mágicos de forma eficaz e organizada, tudo com a ajuda de uma API robusta e amigável.

## Funcionalidades

1. **Catalogação Mágica:** O coração do ArmazemDoMago é a capacidade de catalogar e listar todos os tipos de itens mágicos, desde amuletos e ingredientes misteriosos até grimórios e artefatos encantados.

2. **Gerenciamento Simplificado:** Os usuários podem listar, adicionar, atualizar e remover itens mágicos com facilidade, permitindo-lhes manter um controle preciso de seu inventário.

3. **Ordenação Mágica:** Os itens são apresentados de forma organizada, permitindo o usuário classificar a listagem pelos itens mais poderosos primeiro.

4. **Notificações Místicas:** O sistema de notificação alerta os usuários quando seus estoques mágicos estão ficando baixos, garantindo que nunca fiquem despreparados.

5. **Segurança Mágica:** A autenticação de usuário baseada em JWT garante que apenas os magos autorizados tenham acesso aos segredos de seu armazém.


## 🛠 Tecnologias
- .Net Core 6
- Entity Framework Core 
- SQLite
- JWT para Autenticação

## Instalação
Antes de rodar o projeto, é necessário ter instalado em sua máquina:

- [Git](https://git-scm.com/)
- DB Browser (SQLite) - Opcional
- Um IDE de sua preferência (Windows: Recomendo o Visual Studio 2022; Linux: Recomendo o JetBrains Rider)

### 📦 Clonando repositório

```bash
$ git clone git@github.com:yagopeixinho/ArmazemDoMago.git
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
#### /api/Autenticacao/login

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
#### [Fiz um vídeo tutorial caso preferível](https://youtu.be/c9_hKGWocaY?list=TLPQMDUwOTIwMjMmNx0y8RgL7w)

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
#### [Fiz um vídeo tutorial caso preferível](https://youtu.be/V5SyWx0YooI)

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
##### Exemplo de requisição
```json
{
  "id": 0,
  "nome": "Caneca mágica!",
  "descricao": "Sabe o que isso significa?! Café mágico para todos os magos programadores!",
  "quantidade": 4,
  "poderMagico": 4
}
```

### PUT /api/Armazem/{id}
Atualiza informações sobre um item mágico existente no armazém.
##### Exemplo de requisição
```json
{
  "nome": "Anéis mágicos",
  "descricao": "Quem sabe eu finalmente encontro o amor da minha vida...",
  "quantidade": 100,
  "poderMagico": 6
}
```

### DELETE /api/Armazem/{id}
Remove um item mágico do armazém.

## Contato
- 📬 Me envie um e-mail: peixinhoyago@gmail.com
- Se você tem alguma dúvida ou quer entrar em contato comigo por qualquer outro motivo, você pode encontrar minhas redes sociais e mais informação sobre mim [clicando aqui](https://github.com/yagopeixinho/yagopeixinho/blob/master/README.md)

## Licença
Esse projeto não possui nenhuma licença.



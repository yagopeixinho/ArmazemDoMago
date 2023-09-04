<div align="center">
     <img src="assets/images/readmeTemplateIcon.png" width="300px">
</div>

<h4 align="center">Guardando a magia em cada byte!</h4>

<p align="center">
    <img src="https://img.shields.io/github/last-commit/yagopeixinho/armazemDoMago?color=58ADE2">
    <img src="https://img.shields.io/github/languages/count/yagopeixinho/armazemDoMago?color=E390D2">
    <img src="https://img.shields.io/github/license/yagopeixinho/armazemDoMago?color=fecf10">
</p>


Restful API em .Net Core 6 [veiaco](https://github.com/yagopeixinho/veiacoPlataforma)
<br/>

## Visão Geral
O ArmazemDoMago é a solução perfeita para magos que desejam manter um inventário organizado de seus itens mágicos. Com esta API, você pode facilmente:

- Adicionar novos itens ao seu armazém mágico.
- Remover itens que não são mais necessários.
- Listar todos os seus itens para uma visão geral rápida.
- Atualizar informações sobre itens existentes.
- Notificação de baixo estoque
- Listagem organizada

A tecnologias utilizadas
- .Net Core 6
- Entity Framework Core 
- SQLite

## Instalação &nbsp;

Antes de rodar o projeto, é necessário ter instalado em sua máquina:

- [Git](https://git-scm.com/)
- DB Browser (SQLite) - Opcional
- Um IDE de sua preferência (Recomendo o Visual Studio 2022)

### Clonando repositório

```bash
$ git clone git@github.com:yagopeixinho/ArmazemDoMago.gitt
```

### Banco de Dados
O Banco de Dados utilizado foi o SQLite e já existe um arquivo chamando database.db 
com todas as atualizações de modo em que não vai ser necessário nenhum comando de migração.

### Autenticação
- Foi usado o JWT para autenticação de usuário
  
Para se autenticar e poder acessar rotas com camada de segurança é necessário acessar a rota
```bash
/api/Autenticacao/registrar
```

Informe os dados de registro do usuário no corpo da requisição

```json
{
  "email": "emailteste@gmail.com",
  "senha": "senhaforte"
}
```

Após isso, o usuário já foi criado no banco de dados SQLite com sucesso. Esse usuário já pode gerar o Token de acesso e para isso vamos acessar a rota de autenticação:
```bash
/api/Autenticacao/login
```
Basta informa no corpo da requisição os dados que foram criados previamente
```json
{
  "email": "emailteste@gmail.com",
  "senha": "senhaforte"
}
```
Após isso será gerado um _token_ que você irá utilizar para acessar as rotas seguras.

#### Swagger
Para acessar essas rotas no Swagger basta você clicar em Authorize e em _Value_ digite no seguinte formato:
```
Bearer  {token}
````
Um exemplo real seria:
```
Bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMTIzQGdtYWlsLmNvbSIsImV4cCI6MTY5Mzk1Mzc3M30.mVKVDUpYUt8IltWPEVFs9ikkcqQw5eUYkoq2EnWGMOWjbw0OfJEqRVN1o3hzk_jKOgfi25htQjGcVGdYLPkKSw
```

Agora você pode acessar todos os Endpoints da aplicação.

## Recursos
| Método                  | Endpoint           | Descrição                                                                                |
|-------------------------|--------------------|------------------------------------------------------------------------------------------|
| GET                     | /api/Armazem       | Obtém a lista de todos os itens mágicos ordenado do item mais poderoso pro mais fraco    |
| GET                     | /api/Armazem/{id}  | Obtém informações detalhadas sobre um item.                                              |
| POST                    | /api/Armazem       | Adiciona um novo item mágico ao armazém.                                                 |
| PUT                     | /api/Armazem/{id}  | Atualiza informações sobre um item existente.                                            |
| DELETE                  | /api/Armazem/{id}  | Remove um item mágico do armazém.                                                        |




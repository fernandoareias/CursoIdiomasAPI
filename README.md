## O que é

É uma API para um curso de idiomas fictício

### Configurações necessárias

Deve se configurar duas informações em appsettings.json, são elas:

#### Configurar o Elmah  

Sua **KEY** e **ID** do app.elmah.io
```
"Elmah": {
   "Key": "SUA KEY",
   "Id": "SEU ID"
}
```

#### Configurar connection string

A **connection string** com seu banco de dados.

```
"ConnectionStrings": {
  "connectionString": "SUA CONNECTION STRING"
},
```

#### Como rodar

- Restore nos pacotes `` dotnet restore ``
- Atualizar o banco ``update-database``
- Buildar o projeto `` dotnet build ``
- Rodar o projeto `` dotnet run `` ou `` dotnet watch run ``

##### Documentação disponível em
``http://localhost:<port>/swagger/index.html``

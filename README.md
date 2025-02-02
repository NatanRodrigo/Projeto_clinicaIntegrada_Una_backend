## 🔄 **Migração de Banco de Dados com Entity Framework**  

Para gerenciar as migrações do banco de dados no projeto, utilize os seguintes comandos do **Entity Framework (EF Core)**. 


### 📌 **Estrutura do Comando**  

```bash

dotnet ef migrations add "NomeDaMigracao" --project Infrastructure --startup-project WebApi --output-dir Migrations
```

- **`--project Infrastructure`** → Define o projeto onde as migrações serão criadas. *(Opcional se estiver na pasta raiz)*
- 
- **`--startup-project WebApi`** → Especifica o projeto de inicialização (API).
-  
- **`--output-dir Migrations`** → Define o diretório onde as migrações serão armazenadas.
- 

### 📌 **Exemplo de Uso**  

Caso esteja na pasta raiz do projeto, você pode criar uma nova migração executando:  

```bash

dotnet ef migrations add "Sample_Migration" --project Infrastructure --startup-project WebApi --output-dir Migrations

```

Após adicionar a migração, aplique as alterações ao banco de dados com: 

```bash

dotnet ef database update --project Infrastructure --startup-project WebApi

```


🔹 **Dica:** Certifique-se de que a **Connection String** no **appsettings.json** está configurada corretamente antes de rodar as migrações. 🚀

Clínica Integrada UNA - Sete Lagoas 🏥💻

📌 Solicitação do Projeto

Tema: Tecnologia na Gestão em Saúde: do Analógico para o Digital

🔎 Descrição

Este projeto nasceu da necessidade identificada dentro do próprio campus da UNA Sete Lagoas/MG, onde professoras dos cursos da área da Saúde, especialmente da Psicologia, destacaram a importância de informatizar e automatizar os processos internos da clínica universitária.


Além disso, conforme relatos das docentes, essas dificuldades não se restringem apenas ao ambiente acadêmico, mas também refletem desafios enfrentados em outras clínicas e consultórios da região.


🎯 Objetivo

Desenvolver um sistema de gestão digital completo no formato de um software híbrido (web + mobile), permitindo uma administração mais eficiente dos atendimentos clínicos, inicialmente voltado para clínicas de Psicologia.


🛠 Principais Funcionalidades

✅ Cadastro de pacientes com histórico de atendimentos.

✅ Agendamento de consultas de forma otimizada.

✅ Gerenciamento de prontuários e evolução clínica.

✅ Extração de relatórios para acompanhamento dos atendimentos.

✅ Acessibilidade via Web e Aplicativo Móvel para maior flexibilidade.


Com essa solução, buscamos modernizar a gestão de clínicas, proporcionando mais eficiência, segurança e organização tanto para profissionais quanto para pacientes. 🚀







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

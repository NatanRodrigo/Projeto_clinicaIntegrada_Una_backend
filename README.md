### Database Migrations

* `--project Infrastructure` (optional if in root folder)
* `--startup-project WebApi`
* `--output-dir Migrations`

For example, to add a new migration from the root folder:
 
dotnet ef migrations add "Sample_Migration" --project Infrastructure --startup-project WebApi --output-dir Migrations


# CleanArquitectureExample
CleanArquitectureExample


# Comandos iniciales
Infra 
- entrar a infra/sqlserver y en la consola ejecutar:
  
  docker compose up -d
  
Backend
- Agregar un archivo .env basado en example.env en el proyecto API
- crear las migraciones, en la consola de comandos ejecutar el siguiente comando
  
  dotnet ef migrations add NewMigration --project Infrastructure --startup-project API
  
- Actualizar cambios en la base de datos
  
  dotnet ef database update --project Infrastructure --startup-project API



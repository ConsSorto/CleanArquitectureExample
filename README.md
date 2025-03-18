# CleanArquitectureExample
CleanArquitectureExample


# Comandos iniciales
Infraestructura
- Entrar a infra/sqlserver y en la consola ejecutar:
  
  docker compose up -d
  
Backend
- Ejecutar solo una vez el siguiente comando para restaurar la configuracion

  dotnet tool restore

- Agregar un archivo .env basado en example.env en el proyecto API

- Crear las migraciones, en la consola de comandos ejecutar el siguiente comando
  
  dotnet ef migrations add InitialMigration --project Infrastructure --startup-project API
  
- Actualizar cambios en la base de datos
  
  dotnet ef database update --project Infrastructure --startup-project API

# Construccion de la imagen 
- Situarse en la carpeta Backend y ejecutar el siguiente comando
 docker build -t api:dev -f API/Dockerfile .

 # Ejecucion (mismo entorno donde se creo la imagen)
 - En una carpeta con una archivo .env con los parametros necesarios ejecutar el siguiente comando
 docker run -d --env-file .env -p 8080:8080 api:dev
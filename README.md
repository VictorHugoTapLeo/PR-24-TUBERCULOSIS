# PR-24-TUBERCULOSIS

Manual de Usuario

Paso 1:

Descargar la base de datos tuberculosis y regenerarla en mysql
En opciones ir a:
Server
Data Import
Import from Self-Contained File
Cargar el .sql
Start Import

Paso 2:

Abrir el proyecto
Ir a:
Implementacion
BaseImpl.cs
Cambiar la cadena de conexion por la de tu mysql aqui:

public string connectionString = @"Server=localhost;Database=tuberculosis;User Id=root;Password=1860;";

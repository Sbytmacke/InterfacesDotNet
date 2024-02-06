
### 1. Dirigirnos a la carpeta Scripts dentro del proyecto
```cd ./P05_01_DI_Contactos_MAROTO_angel/Scripts```


### 2. Crear la imagen
```docker build -t mssql-custom .```


### 3. Levantar el contenedor con las variables de entorno y la imagen anterior
```docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=StrongPassw0rd' -p 1433:1433 --name sqls_prueba -d mssql-custom```

ℹ️ **Aviso!** El contenedor es funcional cuando en los "Logs" del contenedor aparezcan varias: ```(1 rows affected)```

:warning: **Cuidado!** A veces hace falta parar el contenedor y levantarlo de nuevo si no sale lo anterior comentado, a la segunda siempre funciona.

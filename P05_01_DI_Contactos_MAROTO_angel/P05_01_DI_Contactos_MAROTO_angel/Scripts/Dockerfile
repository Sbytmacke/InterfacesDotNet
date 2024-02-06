FROM mcr.microsoft.com/mssql/server:2017-latest

# Create a config directory
RUN mkdir -p /usr/config
WORKDIR /usr/config

# Bundle config source
COPY ./* /usr/config/

# Convertir formato de fin de línea del script, ya que el salto de línea de error
RUN apt-get update && apt-get install dos2unix -y && dos2unix /usr/config/*

# Grant permissions for to our scripts to be executable
RUN chmod +x /usr/config/entrypoint.sh
RUN chmod +x /usr/config/configure-db.sh

ENTRYPOINT ["sh","/usr/config/entrypoint.sh"]
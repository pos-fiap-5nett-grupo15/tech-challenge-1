Criação e configuração de uma banco de dados SQL Sever local para uso pessoal.


[Imagem base](https://hub.docker.com/r/microsoft/mssql-server)
[Configuração de Entrypoint](https://github.com/microsoft/mssql-docker/tree/master/linux/preview/examples/mssql-customize)

MSSQL_PID=Developer
ACCEPT_EULA=Y


```shell
docker build -t mssql-tech-1 .

docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=Q1w2e3r4' -p 1433:1433 --name sql1 -d mssql-custom
```
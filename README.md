## Tech Challenge 1

API desenvolvida pelo grupo 15 da Postech-Fiap com o objetivo de atender os requisitos do Tech Challenge

## Inicialização da aplicação

### Configurar a base de dados através do docker

Realizar a configuração da base de dados SQL Server seguindo o passo a passo disponível em [Configuração DB SQL Server - Docker](./docker/sql-server/README.md).

### Configurar as variáveis de ambiente

Executar os seguintes comandos no prompt de comando para gerar as variáveis de ambiente necessárias para a aplicação.

#### Windows(CMD)

```
setx TECH1_API_SEC_KEY "IGVRaqQssHbDh3adxV22rw73SmOusqrKHomyJe33TrM="
setx TECH1_API_SEC_IV "iqs1k4XU6wADBBOP3cpg5A=="
```

#### Linux(BASH)

```
export TECH1_API_SEC_KEY="IGVRaqQssHbDh3adxV22rw73SmOusqrKHomyJe33TrM="
export TECH1_API_SEC_IV="iqs1k4XU6wADBBOP3cpg5A=="
```

## Informações importantes sobre a aplicação

### Banco de Dados

| Atributo | Valor |
|---|---|
| Banco de Dados | SQL Server(Docker) |
| Endereço | Localhost(127.0.0.1) |
| Porta | 1433 |
| Base de Dados | tech_1 |
| String de Conexão | Server=127.0.0.1;Database=tech_1;User Id=svc_con_mngt;Password=340$Uuxwp7Mcxo7Khy;TrustServerCertificate=True;MultipleActiveResultSets=true |

#### Acessos
| Descrição | Usuário | Senha |
|---|---|---|
| Usuário SA | sa | Q1w2e3r4 |
| Usuário SVC | svc_con_mngt | 340$Uuxwp7Mcxo7Khy |

### Variáveis de Ambiente

**Citação:** Variáveis utilizadas para armazenar os valores chave para criptografia de dados.

| Variável | Valor |
|---|---|
| TECH1_API_SEC_KEY | IGVRaqQssHbDh3adxV22rw73SmOusqrKHomyJe33TrM= |
| TECH1_API_SEC_IV | iqs1k4XU6wADBBOP3cpg5A== |

### Usuários padrão da API

| Usuário | Senha | Tipo |
|---|---|---|
| Admin | Admin01 | Administrador |
| User | User01 | Comum |

### Chave JWT

| Atributo | Valor |
|---|---|
| Valor | 2024Fiap_ContactManagmentAPI_Group15_TechChallenge1 | 

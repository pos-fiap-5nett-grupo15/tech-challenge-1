# Conteúdo da Apresentação

## Quais foram os passos
	Quais foram os passos para o desenvolvimento do projeto?
	O que?
	Porque?
	Como?

**Processo de Desenvolvimento**
Fizemos o acompanhamento do projeto utilizando ferramenta de kanban, no nosso caso, o Trello.
Utilizamos git como ferramenta de versionamento, desenvolvendo as tasks em branchs separadas, realizando PRs e revisão de código. Práticas importantes na melhoria do qualidade do código.
No nosso processo nós partimos da 
O nosso processo nos partimos dos requisitos passados, sem refinamento técnico, dada a simplicidade da solução.
Fizemos uma reunião para definir a arquitetura a ser utilizada
Fizemos a quebra dos itens de desenvolvimento e estimativas
Seguimos com o desenvolvimento realizando Revisões de Código.




## Arquitetura Adotada
	Aqui podemos mostrar a arquitetura conceitual adotada


Em nossa reunião definimos que usaríamos a arquitetura em camadas. Esta decisão foi tomada considerando aspectos como simplicidade, flexibilidade, boas práticas de código. Embora tenhamos cogitado arquiteturas mais simples, como a Minimal API, decidimos por utilizar a arquitetura em camadas pelas seguintes vantagens.

Delimitação das regiões do código associadas a regras de negócio.
Abstração de camada de persistência de dados.
Redução de acoplamento e aumento da facilidade de implantar testes.

As camadas utilizadas por nós foram as seguintes:

Camada de apresentação, responsável por receber as requisições da API via controllers. 
Camada de Aplicação, responsável por comportar os serviços e handlers.
Camada de Domínio, responsável por comportar *Entities* e *Value Objects*.
Camada de Infraestrutura, responsável por abstrair a persistência de dados e comportar *Repositories*, contextos de conexão e *queries*.

Agora falando especificamente de cada camada:




## Camada de Infraestrutura e Configuração de Persistência

O banco de dados escolhido para o trabalho foi um banco relacional SQL Server pois os integrantes do grupo já tinham certa familiaridade com e, para solução em questão, não havia motivação para a escolha de um outro tipo de banco ou de um outro provider. Já com relação a escolha de onde rodar o nosso banco de dados, escolhemos utilizar um container, pois seria mais prático e mais fácil de repetir o comportamento nas máquinas de todos os integrantes. Deste modo selecionamos uma imagem inicial do SQL Server 2017, que possui uma licença de uso para desenvolvimento e que permite a criação de uma imagem custom. Esta imagem custom permitiu que pudéssemos realizar toda a configuração do banco, dando praticidade ao processo.
Esta configuração consistiu da definição das tabelas, seeding de dados de teste e configuração de usuário de serviço para aplicação. Este usuário contou com grants específicas para que a aplicação acessasse apenas as devidas tabelas e não realizasse operações distintas daquelas previamente definidas.
Quanto ao framework ORM selecionado optamos pelo Dapper, pelo fato deste ser mais leve.
Com relação ao gerenciamento de conexões e transações escolhemos trabalhar com o padrão Unit of Work. Dentre as vantagens que nos motivaram a empregar este padrão estão;
- Abstração do acesso a dados, escrita e resolução de concorrência.
- Gerenciamento da transação na camada de serviço.
- Permitir escopo cross repositório
Na definição da nossa arquitetura a camada de Infraestrutura permite o acesso da camada de aplicação e possui acesso à camada de domínio.

Falando da Classe ``UnitOfWork``, esta classe implementa uma interface ``IUnitOfWork``, para desacoplar o código e depender de abstrações ao invés de implementações. Esta classe recebe uma instância da conexão disponibilizada pelo *containter* de injeção e durante a sua construção ela instancia as classes dos repositórios.
Escolhemos esta estrutura para que não precisássemos deixar isto sobre a responsabilidade do container de injeção.
Escolhemos ainda implementar um método factory para criar a transação e passamos a responsabilidade de gerenciamento do *commit* a do *rollback* para a ``ITransaction``. 

## Camada de Domínio

Na camada de domínio colocamos as entidade e os objetos de valor, o que seria basicamente as nossas classes de model e os nossos enum.

## Camada de Aplicação

Na camada de aplicação colocamos os nossos handles e utilizamos esta estrutura para que ganhássemos vantagens como segregação de responsabilidades, simplificar possíveis testes, facilitar manutenção ou possíveis ampliações do sistema.


## Camada de Apresentação

Nesta camada colocamos as controllers, responsáveis por receber as requisições, fazer o controle de autorização.


## Middleware


### ExceptionMiddleware

Este middleware é responsável por padronizar as respostas das requisições em que ocorreram exceções. Deste modo, além de termos uma estrutura definida, temos a segurança de que detalhes da nossa aplicação não será exibida nas respostas da API.

### Swagger

Um outro middleware que nós utilizamos foi Swagger, para que pudéssemos documentar a nossa aplicação bem como facilitar os testes.

### Authorization

Utilizamos o middleware padrão da Microsoft para fazer o processo de autorização da nossa aplicação.


## Autorização e Autenticação



## Testes Unitários






# Anotações

Single Responsability -> Justificativa para usar os handlers

>> Não houve necessidade de incluir uma camada de serviço entre o repositório e os handlers, pois praticamente não tivemos regras de negócio.

### Vantagens

- **Separação de Preocupações**: Cada classe tem uma responsabilidade bem definida.
- **Facilidade de Testes**: Testar cada handler individualmente é mais simples e direto.
- **Escalabilidade**: É fácil adicionar novos recursos ou modificar os existentes sem impactar outras partes do sistema.
- **Manutenibilidade**: O código é organizado e modular, facilitando a manutenção e evolução da aplicação.
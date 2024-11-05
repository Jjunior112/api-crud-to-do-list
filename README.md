# Minimal CRUD API de Tarefas em C#

Esta é uma API CRUD minimal desenvolvida em C# com .NET e Entity Framework. A API permite a criação, visualização, atualização e exclusão de tarefas, além de modificar a prioridade e a completude de cada tarefa individualmente.

## Tecnologias Utilizadas
C#
.NET 9 
Entity Framework Core
Banco de Dados (SQLite)
*Funcionalidades*

## A API permite:

- Criar uma nova tarefa.
- Visualizar todas as tarefas.
- Alterar título de uma tarefa.
- Modificar a prioridade de uma tarefa.
- Atualizar o status de completude de uma tarefa.
- Excluir uma tarefa.
  
## Endpoints

1. Criar Tarefa
 
  - **Rota: POST /tasks**

  - Descrição: Cria uma nova tarefa.
  
  - Exemplo de Corpo da Requisição:
  
        {
          "Title": "Estudar Entity Framework",
        }

2. Visualizar Tarefas

   2.1 **Rota: GET /tasks/**
    
      - Descrição: Retorna todas as tarefas.
  
    2.2 **Rota: GET /tasks/{id}**
  
      - Descrição: Retorna uma tarefa específica.

4. Alterar prioridade Tarefa

  - **Rota: PUT /tasks/priority/{id}**
  
  - Descrição: Atualiza a prioridade de uma tarefa.
  
  - Exemplo de Corpo da Requisição:

        {
          "priority": true
        }

4. Alterar completeude da Tarefa
  - **Rota: PUT tasks/completed/{id}**
  
  - Descrição: muda o status de completude da tarefa.
  
  - Exemplo de Corpo da Requisição:

        {
          "IsCompleted": true
        }

6. Deletar Tarefa
   
  - **Rota: DELETE /tasks/{id}**
  
  - Descrição: Exclui uma tarefa específica pelo ID.

## Contribuição
Contribuições são bem-vindas! Por favor, envie um Pull Request com melhorias ou correções.

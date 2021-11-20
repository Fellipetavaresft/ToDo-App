using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler : Notifiable, IHandler<CreateTodoCommand>
    {
        private readonly ITodoRepository _repository;
        public TodoHandler(ITodoRepository repository)
        { 
            _repository = repository;
        }
        public ICommandResult Handle(CreateTodoCommand Command)
        {
            //Fail fast validation
            Command.Validate();
            if (Command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Ops, parece que sua tarefa está errada!",
                    Command.Notifications);
            
            //Gera o TodoItem
            var todo = new TodoItem(Command.Title,Command.User,Command.Date);

            //Salva no banco
            _repository.Create(todo);

            //Retorna o resultado
            return new GenericCommandResult(true, "Tarefa salva", todo);
        }
    }
}
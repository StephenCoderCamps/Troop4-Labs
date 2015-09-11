using System;
namespace ToDos.Services
{
    public interface IToDoService
    {
        ToDos.Models.ToDo CreateToDo(ToDos.Models.ToDo toDo);
        System.Collections.Generic.IList<ToDos.Models.ToDo> List();
    }
}

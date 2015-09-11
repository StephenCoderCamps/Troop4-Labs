using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using ToDos.Models;

namespace ToDos.Services
{
    public class ToDoService : ToDos.Services.IToDoService
    {
        private IGenericRepository _repo;

        public ToDoService(IGenericRepository repo)
        {
            _repo = repo;
        }

        public IList<ToDo> List()
        {
            return _repo.Query<ToDo>().ToList();
        }

        public ToDo CreateToDo(ToDo toDo)
        {
             _repo.Add<ToDo>(toDo);
             _repo.SaveChanges();
             return toDo;
        }
    }
}
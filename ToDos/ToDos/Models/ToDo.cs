using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDos.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
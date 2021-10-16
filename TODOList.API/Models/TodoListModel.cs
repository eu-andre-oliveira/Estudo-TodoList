using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TODOList.API.Models
{
    public class TodoListModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime DataTodo { get; set; }
        public bool Feito { get; set; }

    }
}

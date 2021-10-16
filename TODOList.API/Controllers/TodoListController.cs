using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TODOList.API.Data;
using TODOList.API.Models;

namespace TODOList.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoListController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TodoListController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("list")]
        public IActionResult GetTodoList()
        {
            return Ok(_context.TodoLists.ToList());
        }

        [HttpPost("create")]
        public IActionResult CreateTodoItem(TodoListModel todoListModel)
        {
            _context.TodoLists.Add(todoListModel);
            _context.SaveChanges();

            return Ok(_context.TodoLists.ToList());
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateTodoItem(TodoListModel todoListModel, int id )
        {
            TodoListModel itemAtualizar = _context.TodoLists.Where(item => item.Id == id).FirstOrDefault();

            if (itemAtualizar == null)
                return BadRequest("Item não encontrado");
            itemAtualizar.Titulo = todoListModel.Titulo;
            itemAtualizar.DataTodo = todoListModel.DataTodo;
            itemAtualizar.Feito = todoListModel.Feito;

            _context.TodoLists.Update(itemAtualizar);
            _context.SaveChanges();

            return Ok(itemAtualizar);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult UpdateTodoItem(int id)
        {
            TodoListModel itemAtualizar = _context.TodoLists.Where(item => item.Id == id).FirstOrDefault();

            if (itemAtualizar == null)
                return BadRequest("Item não encontrado");

            _context.TodoLists.Remove(itemAtualizar);
            _context.SaveChanges();

            return Ok("Item removido");
        }


    }
}

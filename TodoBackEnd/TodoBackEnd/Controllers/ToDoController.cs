using Microsoft.AspNetCore.Mvc;
using TodoBackEnd.Model;
using TodoBackEnd.Service.Todos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoBackEnd.Controllers
{
    [Route("v1/api/todos")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ITodosService _todosService;

        // Khởi tạo dịch vụ trong constructor
        public ToDoController(ITodosService todosService)
        {
            _todosService = todosService;
        }

        // GET: api/<ToDoController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_todosService.GetTodos());
        }

        // GET api/<ToDoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ToDoController>
        [HttpPost]
        public IActionResult Post(Todo todo)
        {
            return Ok(_todosService.AddTodo(todo));
        }

        // PUT api/<ToDoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Todo todo)
        {
            return Ok(_todosService.UpdateTodo(todo));
        }

        // DELETE api/<ToDoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_todosService.DeleteTodo(id));
        }
    }
}

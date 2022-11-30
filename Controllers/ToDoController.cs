using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoWebAPI.Models;
using ToDoWebAPI.Repository;

namespace ToDoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ToDoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public ToDoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet("")]
        [Authorize]
        public async Task<IActionResult> GetAllTodos()
        {
            var todos = await _todoRepository.GetAllTodoAsync();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoById([FromRoute] int id)
        {
            var todo = await _todoRepository.GetTodoByIdAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }


        [HttpPost("")]
        public async Task<IActionResult> AddNewTodo([FromBody] TodoModel todoModel)
        {
            var id = await _todoRepository.AddTodoAsync(todoModel);
            return CreatedAtAction(nameof(GetTodoById), new { id = id, Controller = "todos" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo([FromBody] TodoModel todoModel, [FromRoute] int id)
        {
            await _todoRepository.UpdateTodoAsync(id, todoModel);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateTodoPatch([FromBody] JsonPatchDocument todoModel, [FromRoute] int id)
        {
            await _todoRepository.UpdateTodoPatchAsync(id, todoModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo([FromRoute] int id)
        {
            await _todoRepository.DeleteTodoAsync(id);
            return Ok();
        }
    }

}

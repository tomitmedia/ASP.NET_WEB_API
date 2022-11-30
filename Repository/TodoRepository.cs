using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoWebAPI.Data;
using ToDoWebAPI.Models;

namespace ToDoWebAPI.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;

        public readonly IMapper _mapper;

        public TodoRepository(TodoContext context, IMapper mapper)
        {
            _context = context;
           _mapper = mapper;
        }

        public async Task<List<TodoModel>> GetAllTodoAsync()
        {
            //var records = await _context.Todos.Select(x => new TodoModel()
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Description = x.Description
            //}).ToListAsync();
            // return records;

            var records = await _context.Todos.ToListAsync();
            return _mapper.Map<List<TodoModel>>(records);
        }

        public async Task<TodoModel> GetTodoByIdAsync(int todoId)
        {
            //var records = await _context.Todos.Where(x=> x.Id == todoId).Select(x => new TodoModel()
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Description = x.Description
            //}).FirstOrDefaultAsync();
             
            //return records;

            var todo = await _context.Todos.FindAsync(todoId);   
            return _mapper.Map<TodoModel>(todo);
        }

        public async Task<int> AddTodoAsync(TodoModel todoModel)
        {
            var todo = new Todo()
            {
                Title = todoModel.Title,
                Description = todoModel.Description
            };

            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();

            return todo.Id;
        }
        public async Task UpdateTodoAsync(int todoId, TodoModel todoModel)
        {
            //var todo = await _context.Todos.FindAsync(todoId);
            //if (todo != null)
            //{
            //    todo.Title = todoModel.Title;
            //        todo.Description = todoModel.Description;
            //    await _context.SaveChangesAsync();

            //}

            var todo = new Todo()
            {
                Id=todoId, 
                Title = todoModel.Title,
                Description = todoModel.Description
            };

            _context.Todos.Update(todo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTodoPatchAsync(int todoId, JsonPatchDocument todoModel)
        {
            var todo = await _context.Todos.FindAsync(todoId);
            if (todo != null)
            {
                todoModel.ApplyTo(todo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTodoAsync(int todoId)
        {

            //var todo = _context.Todos.Where(x => x.Title == "").FirstOrDefault();
            var todo = new Todo()
            {
                Id = todoId
            };
            
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();

        }

    }

}

using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoWebAPI.Models;

namespace ToDoWebAPI.Repository
{
    public interface ITodoRepository
    {
        Task<List<TodoModel>> GetAllTodoAsync();
        Task<TodoModel> GetTodoByIdAsync(int todoId);
        Task<int> AddTodoAsync(TodoModel todoModel);
        Task UpdateTodoAsync(int todoId, TodoModel todoModel);
        Task UpdateTodoPatchAsync(int todoId, JsonPatchDocument todoModel);
        Task DeleteTodoAsync(int todoId);
    }
}

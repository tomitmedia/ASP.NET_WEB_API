using AutoMapper;
using ToDoWebAPI.Data;
using ToDoWebAPI.Models;

namespace ToDoWebAPI.Helpers
{
    public class ApplicationMapper: Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Todo, TodoModel>().ReverseMap();
        }
    }
}

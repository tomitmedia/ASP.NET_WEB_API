using System.ComponentModel.DataAnnotations;

namespace ToDoWebAPI.Models
{
    public class TodoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Add title property")]
        
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

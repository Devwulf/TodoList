using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [Display(Name = "Date Created")]
        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; private set; }

        [Display(Name = "Is Done?")]
        public bool IsDone { get; set; }

        public TodoItem()
        {
            DateCreated = DateTime.Now;
        }
    }
}

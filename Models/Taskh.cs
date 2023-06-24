using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Azurecopilothackthon.Models
{
    public class Taskh
    {
        // create a model class with id and name with dataannoattion
        // public Task(int id, string name) 
        // {
        //     this.Id = id;
        //     this.Name = name;

        // }
        // public int Id { get; set; }
        // [Required(ErrorMessage = "Task name is required")]
        // public required string Name { get; set; }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Task name is required")]
        public string TaskName { get; set; }
        public bool IsCompleted { get; set; }
    }
}
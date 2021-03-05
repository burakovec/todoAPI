using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoAPI.Models
{
    public class Todo
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public TodoStatus Status { get; set; }
    }
    public enum TodoStatus
    {
        Activate = 0,
        Process = 1,
        Complated = 2
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string userRole { get; set; }
        public string FullName { get; set; }
    }

    public class LogRequest
    {
        [Key]
        public int LogId { get; set; }
        public string UserId { get; set; }
        public string searchValue { get; set; }
        public string Response { get; set; }
    }
}

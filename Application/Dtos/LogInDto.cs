using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class LogInDto
    {
        public  required string UserName { get; set; }
        public string Password { get; set; }
    }
}

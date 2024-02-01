using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Course
{
    public class Course
    {
        [Key]
        public virtual Guid Id { get; set; }
        public virtual string CourseName { get; set; } = string.Empty;
    }
}

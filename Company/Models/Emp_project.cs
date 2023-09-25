using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Models
{
    [PrimaryKey("emp_id", "proj_id")]
    public class Emp_project
    {
        //forigen key
        [ForeignKey("Employee")]
        public int emp_id { get; set; }
        [ForeignKey("Project")]
        public int? proj_id { get; set; }
        public int? workingHours { get; set; }

        //Navigation Prop
        public Employee? Employee { get; set; }
        public Project? Project { get; set; }


    }
}

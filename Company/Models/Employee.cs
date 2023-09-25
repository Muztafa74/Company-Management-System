using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int Age { get; set; }
        public string? Address { get; set; }
        public float? Salary { get; set; }
        public string? Email { get; set; }
        public int? Password { get; set; }

        //foriegn key
        [ForeignKey("office")]
        public int Office_id { get; set; }

        //Navigation Prop
        public Office? office { get; set; }
        public List<Emp_project>? projects { get; set; }


    }
}

namespace Company.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        //Navigation Prop
        public List<Emp_project>? emp_Projects { get; set; }

    }
}

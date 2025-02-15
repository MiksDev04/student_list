using System.ComponentModel.DataAnnotations;

namespace student_list.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Program { get; set; }
        public int Year { get; set; }
        public string? Section { get; set; }
        public string? Status { get; set; }
        public string? School { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public ulong Phone { get; set; }
        public string? Address { get; set; }
    }
}

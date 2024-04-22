using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PrimaryTask1.EF
{
    [Table("students")]
    public class Student
    {
        [Key, Required]
        public int S_Id { get; set; }

        [Required]
        public string First_Name { get; set;}

        [Required]
        public string Last_Name { get; set; }

        [Required,EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Phone_number { get; set; }

        [Required]
        public string Address { get; set; }
    }
}

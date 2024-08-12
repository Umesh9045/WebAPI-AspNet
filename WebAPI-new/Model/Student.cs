using System.ComponentModel.DataAnnotations;

namespace WebAPI_new.Model
{
    public class Student
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Standard { get; set; }
    }
}

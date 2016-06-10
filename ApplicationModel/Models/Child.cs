using System.Runtime.InteropServices;

namespace ApplicationModel.Models
{
    public enum Gender
    {
        Male = 1,
        Female = 2
    }
    public class Child
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
    }
}

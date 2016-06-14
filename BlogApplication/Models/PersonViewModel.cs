using System;
using System.Collections.Generic;
using ApplicationModel.Models;

namespace BlogApplication.Models
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Child> Children { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
    }
}
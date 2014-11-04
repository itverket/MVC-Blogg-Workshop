using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationModel
{
    public class AboutInformation
    {
        [Key]
        public int AboutInformationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string AboutMe { get; set; }
    }
}
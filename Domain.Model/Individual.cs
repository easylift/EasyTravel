using System;
using DataService.MongoDB.Concrete;

namespace Domain.Model
{
    public class Individual : EntityBase
    {
        public string IndividualRef { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Username { get; set; }
    }
}

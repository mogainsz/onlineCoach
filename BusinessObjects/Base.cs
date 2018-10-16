using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Base
    {
    }

    public class Users
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }
        public DateTime CreatedDate { get; set; }
        public double? Weight { get; set; }
        public double? Height { get; set; }
        public string Birthday { get; set; }
        public string ActivityLevel { get; set; }
        public double? BMI { get; set; }
        public string About { get; set; }
        public double? GoalWeight { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
    }

    public class Booking
    {
        public int BookingId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public int ContactNo { get; set; }
        public string LectDate { get; set; }
        public DateTime DatePlaced { get; set; }
        public string Status { get; set; }
    }

    public class Feedback
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string Comment { get; set; }
        public DateTime DateSent { get; set; }
        public int Overall { get; set; }
    }




}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstApi.Models
{
    public class User
    {
        [Key]
        public int User_Id { get; set; }
        public int MembershipType_Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public DateTime DOB { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Contact_no { get; set; }
        public string Employer { get; set; }
        public string Email { get; set; }
        public string Insurance { get; set; }
        public string License_no { get; set; }
        public string Password { get; set; }
        public int Status { get; set; } 

    }
}
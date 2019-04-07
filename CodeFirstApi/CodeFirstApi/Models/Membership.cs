using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstApi.Models
{
    public class Membership
    {
        [Key]
        public int MembershipType_Id { get; set; }
        public string MembershipType { get; set; }
        public int MembershipCharge { get; set; }
        public int Status { get; set; }


    }
}
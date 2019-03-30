using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstApi.Models
{
    public class Subscription
    {
        [Key]
        public int Subscription_Id { get; set; }
        public int User_Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Start_DateTime { get; set; }
        public DateTime Renew_DateTime { get; set; }
        public string Subscription_Status { get; set; }
        public int Status { get; set; }

    }
}
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
        public int txn_id { get; set; }
      
        public DateTime payment_date { get; set; }
       
        public string payment_status { get; set; }
        public int Status { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstApi.Models
{
    public class Contact
    {
        [Key]
        public int Contact_Id { get; set; }
       
        public string From_Contact { get; set; }
        public string Message{ get; set; }

        public int Status { get; set; }

    }
}
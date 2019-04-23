using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstApi.Models
{
    public class Prescription
    {
        [Key]
        public int Prescription_Id { get; set; }
        public string from_Prescription { get; set; }
        public string To_Prescription { get; set; }
        public string Prescription_Info { get; set; }
        public DateTime Prescription_DateTime { get; set; }
        public int Status { get; set; }
    }
}
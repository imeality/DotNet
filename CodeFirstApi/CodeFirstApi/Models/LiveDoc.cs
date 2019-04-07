using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstApi.Models
{
    public class LiveDoc
    {
        [Key]
        public int LiveDoc_Id { get; set; }
        public int Doctor_Id { get; set; }
        public int Patient_Id { get; set; }
        public string Symptom { get; set; }     
        public DateTime LiveDocDateTime { get; set; }
        public int Status { get; set; }

    }
}
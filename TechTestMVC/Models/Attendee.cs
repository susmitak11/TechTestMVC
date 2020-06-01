using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TechTestMVC.Areas.Identity.Data;

namespace TechTestMVC.Models
{
    public class Attendee
    {
        [Key]
        public int Id { get; set; }
        public TechTestMVCUser User { get; set; }
        public Technology Tech { get; set; }
        
        public int TechnologyId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}

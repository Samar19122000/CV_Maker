using System;
using System.Collections.Generic;

#nullable disable

namespace SamarApp.Models
{
    public partial class TbWork
    {
        public string JobName { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? Id { get; set; }
    }
}

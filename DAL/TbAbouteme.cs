using System;
using System.Collections.Generic;

#nullable disable

namespace SamarApp.Models
{
    public partial class TbAbouteme
    {
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string WorkStatus { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Freelancer { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int? Id { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace SamarApp.Models
{
    public partial class TbEducation
    {
        public string Qualification { get; set; }
        public string AcademyName { get; set; }
        public DateTime QualiDate { get; set; }
        public DateTime QualiEndDate { get; set; }
        public int? Id { get; set; }
    }
}

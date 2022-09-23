
using System.Collections.Generic;
namespace SamarApp.Models
{
    public class SliderViewModel
    {
        public IEnumerable<TbSlider> slider { get; set; }

        public IEnumerable<TbAbouteme> abouteme { get; set; }

        public IEnumerable<TbWork> work { get; set; }

        public IEnumerable<TbEducation> tbEducation { get; set; }

        public IEnumerable<TbLanguage> tbLanguage { get; set; }

        public IEnumerable<TbProject> tbProjects { get; set; }


    }
}

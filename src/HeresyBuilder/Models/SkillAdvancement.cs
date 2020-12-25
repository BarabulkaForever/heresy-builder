using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.Models
{
    public class SkillAdvancement
    {
        public string Name { get; set; }
        
        public string Aptitude1 { get; set; }
        
        public string Aptitude2 { get; set; }
        
        public string Descriptors { get; set; }
        
        public string AlternateCharacteristics { get; set; }

        public bool IsSpecialist { get; set; }
    }
}

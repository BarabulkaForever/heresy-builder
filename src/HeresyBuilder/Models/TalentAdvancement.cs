using HeresyBuilder.Models.PrerequisitesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.Models
{
    public class TalentAdvancement
    {
        public string Name { get; set; }
        
        public Prerequisites Prerequisites { get; set; }
        
        public int Tier { get; set; }
        
        public string Aptitude1 { get; set; }
        
        public string Aptitude2 { get; set; }
        
        public string Benefit { get; set; }
    }
}

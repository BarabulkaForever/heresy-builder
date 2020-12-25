using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.Models.Prerequisites
{
    public class Prerequisites
    {
        public List<CharacteristicPrerequisites> Characteristic { get; set; }
        
        public List<List<CharacteristicPrerequisites>> OneOffCharacteristics { get; set; }
        
        public List<SkillPrerequisites> Skills { get; set; }
        
        public List<string> Traits { get; set; }
        
        public List<string> Talents { get; set; }
        
        public List<List<string>> OneOffTalents { get; set; }
        
        public List<string> Cybernetics { get; set; }
        
        public int PsyRating { get; set; }
    }
}

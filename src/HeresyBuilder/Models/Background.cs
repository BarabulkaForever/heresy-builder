using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.Models
{
    public class Background
    {
        public string Code;

        public string Name;

        public string Description;

        public List<string> StartingSkills;

        public List<List<string>> StartingSkillsToPick;

        public List<string> StartingTalents;

        public List<List<string>> StartingTalentsToPick;

        public List<string> StartingEquipment;

        public List<List<string>> StartingEquipmentToPick;

        public string BackgroundBonus;

        public List<string> BackgroundAptitude;

        public List<List<string>> BackgroundAptitudeToPick;
    }

}

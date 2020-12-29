using HeresyBuilder.Enums;
using HeresyBuilder.Models;
using HeresyBuilder.Services;
using HeresyBuilder.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.Helpers
{
    public class SkillHelper
    {
        private static List<SkillAdvancement> skillAdvancements;

        public static SkillPrise GetPriceForSkill(string skillName, SkillLevel skillLevel)
        {
            skillName = skillName.Split('(').FirstOrDefault().Trim();
            if (skillAdvancements == null)
            {
                skillAdvancements = (new FileAccessService()).LoadSkills();
            }

            var skillAdvancement = skillAdvancements.FirstOrDefault(x => x.Name.ToLower().Contains(skillName.ToLower()));
            var aptitudes = CurrentCharacterData.Instance.Character.Aptitudes;

            if (aptitudes.Contains(skillAdvancement.Aptitude1))
            {
                if (aptitudes.Contains(skillAdvancement.Aptitude2))
                {
                    // contains two apptitudes
                    return new SkillPrise 
                    {
                        Prise = (((int)skillLevel) + 1) * 100,
                        Aptitudes = ContainsAptitudes.Two
                    };
                }
                else
                {
                    // contains one apptitude
                    return new SkillPrise 
                    {
                        Prise = (((int)skillLevel) + 1) * 200,
                        Aptitudes = ContainsAptitudes.One
                    }; 
                }
            }
            else
            {
                if (aptitudes.Contains(skillAdvancement.Aptitude2))
                {
                    // contains one apptitude
                    return new SkillPrise
                    {
                        Prise = (((int)skillLevel) + 1) * 200,
                        Aptitudes = ContainsAptitudes.One
                    };
                }
                else
                {
                    // contains zero apptitudes
                    return new SkillPrise
                    {
                        Prise = (((int)skillLevel) + 1) * 300,
                        Aptitudes = ContainsAptitudes.None
                    };
                }
            }
        }

        public class SkillPrise
        {
            public int Prise { get; set; }
            public ContainsAptitudes Aptitudes { get; set; }
        }
    }
}

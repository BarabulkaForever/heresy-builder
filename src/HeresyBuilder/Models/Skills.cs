using HeresyBuilder.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.Models
{
    public class Skills
    {
        public Skills()
        {

        }

        public Skills(List<string> skills)
        {
            NormalSkills = new List<Skill>()
            {
                new Skill(){ Name = "Acrobatics", Level = SkillLevel.UnKnown },
                new Skill(){ Name = "Athletics", Level = SkillLevel.UnKnown },
                new Skill(){ Name = "Awareness", Level = SkillLevel.UnKnown },
                new Skill(){ Name = "Charm", Level = SkillLevel.UnKnown },
                new Skill(){ Name = "Command", Level = SkillLevel.UnKnown },
                new Skill(){ Name = "Commerce", Level = SkillLevel.UnKnown },
                new Skill(){ Name = "Deceive", Level = SkillLevel.UnKnown },
                new Skill(){ Name = "Dodge", Level = SkillLevel.UnKnown },
                new Skill(){ Name = "Inquiry", Level = SkillLevel.UnKnown },
                new Skill(){ Name = "Interrogation", Level = SkillLevel.UnKnown },
                new Skill(){ Name = "Intimidate", Level = SkillLevel.UnKnown },
                new Skill(){ Name = "Logic", Level = SkillLevel.UnKnown },
                new Skill(){ Name = "Medicae", Level = SkillLevel.UnKnown },
                new Skill(){ Name = "Parry", Level = SkillLevel.UnKnown },
                new Skill(){ Name = "Psyniscience", Level = SkillLevel.UnKnown },
                new Skill(){ Name = "Scrutiny", Level = SkillLevel.UnKnown },
                new Skill(){ Name = "Security", Level = SkillLevel.UnKnown },
                new Skill(){ Name = "Sleight Of Hand", Level = SkillLevel.UnKnown },
                new Skill(){ Name = "Stealth", Level = SkillLevel.UnKnown },
                new Skill(){ Name = "Survival", Level = SkillLevel.UnKnown },
                new Skill(){ Name = "Tech-Use", Level = SkillLevel.UnKnown }
            };

            Navigate = new List<Skill>()
            {
                new Skill(){ Name = "Surface", Level = SkillLevel.UnKnown },
                new Skill(){ Name = "Stellar", Level = SkillLevel.UnKnown },
                new Skill(){ Name = "Warp", Level = SkillLevel.UnKnown },
            };

            Operate = new List<Skill>()
            {
                new Skill(){ Name = "Aeronautica", Level = SkillLevel.UnKnown },
                new Skill(){ Name = "Surface", Level = SkillLevel.UnKnown },
                new Skill(){ Name = "Voidship", Level = SkillLevel.UnKnown },
            };

            Parse(skills);
        }

        public List<Skill> NormalSkills { get; set; } 

        public List<Skill> Navigate { get; set; }

        public List<Skill> Operate { get; set; } 

        public List<Skill> Linguistics { get; set; } = new List<Skill>();

        public List<Skill> Trade { get; set; } = new List<Skill>();

        // Lore
        public List<Skill> CommonLore { get; set; } = new List<Skill>();

        public List<Skill> ScholasticLore { get; set; } = new List<Skill>();

        public List<Skill> ForbiddenLore { get; set; } = new List<Skill>();

        public void Parse(List<string> skills)
        {
            foreach (var skill in skills)
            {
                if (skill.Contains("Linguistics"))
                {
                    Linguistics.Add(new Skill 
                    {
                        Name = skill.Replace("Linguistics", "").Replace("(", "").Replace(")", "").Trim(),
                        Level = SkillLevel.Known
                    });
                }
                else if (skill.Contains("Trade"))
                {
                    Trade.Add(new Skill
                    {
                        Name = skill.Replace("Trade", "").Replace("(", "").Replace(")", "").Trim(),
                        Level = SkillLevel.Known
                    });
                }
                else if (skill.Contains("Lore"))
                {
                    if (skill.Contains("Common"))
                    {
                        CommonLore.Add(new Skill
                        {
                            Name = skill.Replace("Lore", "").Replace("Common", "").Replace("(", "").Replace(")", "").Trim(),
                            Level = SkillLevel.Known
                        });
                    }
                    else if (skill.Contains("Scholastic"))
                    {
                        CommonLore.Add(new Skill
                        {
                            Name = skill.Replace("Lore", "").Replace("Scholastic", "").Replace("(", "").Replace(")", "").Trim(),
                            Level = SkillLevel.Known
                        });
                    }
                    else if (skill.Contains("Forbidden"))
                    {
                        CommonLore.Add(new Skill
                        {
                            Name = skill.Replace("Lore", "").Replace("Forbidden", "").Replace("(", "").Replace(")", "").Trim(),
                            Level = SkillLevel.Known
                        });
                    }
                }
                else if (skill.Contains("Navigate"))
                {
                    Navigate.FirstOrDefault(x => skill.Contains(x.Name)).Level = SkillLevel.Known;
                }
                else if (skill.Contains("Operate"))
                {
                    Operate.FirstOrDefault(x => skill.Contains(x.Name)).Level = SkillLevel.Known;
                }
                else
                {
                    NormalSkills.FirstOrDefault(x => skill.Contains(x.Name)).Level = SkillLevel.Known;
                }
            }
        }
    }
}

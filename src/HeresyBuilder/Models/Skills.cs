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
            Parse(skills);
        }

        public SkillLevel Acrobatics { get; set; } = SkillLevel.UnKnown;

        public SkillLevel Athletics { get; set; } = SkillLevel.UnKnown;

        public SkillLevel Awareness { get; set; } = SkillLevel.UnKnown;

        public SkillLevel Charm { get; set; } = SkillLevel.UnKnown;

        public SkillLevel Command { get; set; } = SkillLevel.UnKnown;

        public SkillLevel Commerce { get; set; } = SkillLevel.UnKnown;

        public SkillLevel Deceive { get; set; } = SkillLevel.UnKnown;

        public SkillLevel Dodge { get; set; } = SkillLevel.UnKnown;

        public SkillLevel Inquiry { get; set; } = SkillLevel.UnKnown;

        public SkillLevel Interrogation { get; set; } = SkillLevel.UnKnown;

        public SkillLevel Intimidate { get; set; } = SkillLevel.UnKnown;

        public SkillLevel Logic { get; set; } = SkillLevel.UnKnown;

        public SkillLevel Medicae { get; set; } = SkillLevel.UnKnown;

        public SkillLevel Parry { get; set; } = SkillLevel.UnKnown;

        public SkillLevel Psyniscience { get; set; } = SkillLevel.UnKnown;

        public SkillLevel Scrutiny { get; set; } = SkillLevel.UnKnown;

        public SkillLevel Security { get; set; } = SkillLevel.UnKnown;

        public SkillLevel SleightOfHand { get; set; } = SkillLevel.UnKnown;

        public SkillLevel Stealth { get; set; } = SkillLevel.UnKnown;

        public SkillLevel Survival { get; set; } = SkillLevel.UnKnown;

        public SkillLevel TechUse { get; set; } = SkillLevel.UnKnown;

        // Navigate 
        public SkillLevel NavigateSurface { get; set; } = SkillLevel.UnKnown;

        public SkillLevel NavigateStellar { get; set; } = SkillLevel.UnKnown;

        public SkillLevel NavigateWarp { get; set; } = SkillLevel.UnKnown;

        // Operate 
        public SkillLevel OperateAeronautica { get; set; } = SkillLevel.UnKnown;

        public SkillLevel OperateSurface { get; set; } = SkillLevel.UnKnown;

        public SkillLevel OperateVoidship { get; set; } = SkillLevel.UnKnown;

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
                if (skill.Contains("Acrobatics"))
                {
                    Acrobatics = SkillLevel.Known;
                }
                else if (skill.Contains("Athletics"))
                {
                    Athletics = SkillLevel.Known;
                }
                else if (skill.Contains("Awareness"))
                {
                    Awareness = SkillLevel.Known;
                }
                else if (skill.Contains("Charm"))
                {
                    Charm = SkillLevel.Known;
                }
                else if (skill.Contains("Command"))
                {
                    Command = SkillLevel.Known;
                }
                else if (skill.Contains("Commerce"))
                {
                    Commerce = SkillLevel.Known;
                }
                else if (skill.Contains("Deceive"))
                {
                    Deceive = SkillLevel.Known;
                }
                else if (skill.Contains("Dodge"))
                {
                    Dodge = SkillLevel.Known;
                }
                else if (skill.Contains("Inquiry"))
                {
                    Inquiry = SkillLevel.Known;
                }
                else if (skill.Contains("Interrogation"))
                {
                    Interrogation = SkillLevel.Known;
                }
                else if (skill.Contains("Intimidate"))
                {
                    Intimidate = SkillLevel.Known;
                }
                else if (skill.Contains("Logic"))
                {
                    Logic = SkillLevel.Known;
                }
                else if (skill.Contains("Medicae"))
                {
                    Medicae = SkillLevel.Known;
                }
                else if (skill.Contains("Parry"))
                {
                    Parry = SkillLevel.Known;
                }
                else if (skill.Contains("Psyniscience"))
                {
                    Psyniscience = SkillLevel.Known;
                }
                else if (skill.Contains("Scrutiny"))
                {
                    Scrutiny = SkillLevel.Known;
                }
                else if (skill.Contains("Security"))
                {
                    Security = SkillLevel.Known;
                }
                else if (skill.Contains("Sleight") && skill.Contains("Of") && skill.Contains("Hand"))
                {
                    SleightOfHand = SkillLevel.Known;
                }
                else if (skill.Contains("Stealth"))
                {
                    Stealth = SkillLevel.Known;
                }
                else if (skill.Contains("Survival"))
                {
                    Survival = SkillLevel.Known;
                }
                else if (skill.Contains("Tech") && skill.Contains("Use"))
                {
                    TechUse = SkillLevel.Known;
                }
                else if (skill.Contains("Surface") && skill.Contains("Navigate"))
                {
                    NavigateSurface = SkillLevel.Known;
                }
                else if (skill.Contains("Navigate") && skill.Contains("Stellar"))
                {
                    NavigateStellar = SkillLevel.Known;
                }
                else if (skill.Contains("Navigate") && skill.Contains("Warp"))
                {
                    NavigateWarp = SkillLevel.Known;
                }
                else if (skill.Contains("Operate") && skill.Contains("Aeronautica"))
                {
                    OperateAeronautica = SkillLevel.Known;
                }
                else if (skill.Contains("Operate") && skill.Contains("Surface"))
                {
                    OperateSurface = SkillLevel.Known;
                }
                else if (skill.Contains("Voidship") && skill.Contains("Operate"))
                {
                    OperateVoidship = SkillLevel.Known;
                }
                else if (skill.Contains("Linguistics"))
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
            }
        }
    }
}

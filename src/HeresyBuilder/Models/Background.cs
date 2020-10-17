using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.Models
{
    public class Background
    {
        public string Code { get; set; }

        public string Url
        {
            get
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var heresyBuilderPath = Path.Combine(path, "HeresyBuilder");
                var homeworldsPath = Path.Combine(heresyBuilderPath, "background");
                var imagesPath = Path.Combine(homeworldsPath, "images");
                return Path.Combine(imagesPath, Code.ToLower() + ".png");
            }
        }


        public string Name { get; set; }

        public string Description { get; set; }

        public List<string> StartingSkills { get; set; }

        public List<List<string>> StartingSkillsToPick { get; set; }

        public List<string> StartingTalents { get; set; }

        public List<List<string>> StartingTalentsToPick { get; set; }

        public List<string> StartingEquipment { get; set; }

        public List<List<string>> StartingEquipmentToPick { get; set; }

        public string BackgroundBonus { get; set; }

        public List<string> BackgroundAptitude { get; set; }

        public List<List<string>> BackgroundAptitudeToPick { get; set; }

        public string StartingSkillsStr 
        {
            get
            {
                var statickSkills = string.Join(", ", StartingSkills);
                var dynamicSkills = "";

                foreach(var skillsSet in StartingSkillsToPick)
                {
                    string[] asd = { dynamicSkills, string.Join(" or ", skillsSet) };
                    dynamicSkills += string.Join(", ", asd);
                }

                return statickSkills + dynamicSkills;
            }
        }

        public string StartingEquipmentStr
        {
            get
            {
                var statickSkills = string.Join(", ", StartingEquipment);
                var dynamicSkills = "";

                foreach(var skillsSet in StartingEquipmentToPick)
                {
                    string[] asd = { dynamicSkills, string.Join(" or ", skillsSet) };
                    dynamicSkills += string.Join(", ", asd);
                }

                return statickSkills + dynamicSkills;
            }
        }

        public string StartingTalentsStr
        {
            get
            {
                var statickSkills = "";

                if (StartingTalents.Count > 1)
                {
                    statickSkills = string.Join(", ", StartingTalents);
                }
                else if (StartingTalents.Count == 1)
                {
                    statickSkills = StartingTalents.First();
                }

                var dynamicSkills = "";

                foreach(var skillsSet in StartingTalentsToPick)
                {
                    if (dynamicSkills.Length > 0)
                    {
                        string[] asd = { dynamicSkills, string.Join(" or ", skillsSet) };
                        dynamicSkills += string.Join(", ", asd);
                    }
                    else
                    {
                        dynamicSkills = string.Join(" or ", skillsSet);
                    }
                }

                return statickSkills + dynamicSkills;
            }
        }

        public string StartingAptitudesStr
        {
            get
            {
                var statickSkills = string.Join(", ", BackgroundAptitude);
                var dynamicSkills = "";

                foreach(var skillsSet in BackgroundAptitudeToPick)
                {
                    if (dynamicSkills.Length > 0)
                    {
                        string[] asd = { dynamicSkills, string.Join(" or ", skillsSet) };
                        dynamicSkills += string.Join(", ", asd);
                    }
                    else
                    {
                        dynamicSkills = string.Join(" or ", skillsSet);
                    }
                }

                return statickSkills + dynamicSkills;
            }
        }
    }
}

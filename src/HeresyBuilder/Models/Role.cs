﻿using System;
using System.Collections.Generic;
using System.IO;

namespace HeresyBuilder.Models
{
    public class Role
    {
        public string Code { get; set; }

        public string Url 
        { 
            get
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var heresyBuilderPath = Path.Combine(path, "HeresyBuilder");
                var homeworldsPath = Path.Combine(heresyBuilderPath, "role");
                var imagesPath = Path.Combine(homeworldsPath, "images");
                return Path.Combine(imagesPath, Code.ToLower() + ".png");
            }
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<string> RoleAptitude { get; set; }

        public List<List<string>> RoleAptitudeToPick { get; set; }

        public List<string> RoleTalent { get; set; }

        public List<List<string>> RoleTalentToPick { get; set; }

        public string RoleBonus { get; set; }

        public string RoleAptitudesStr
        {
            get
            {
                var statickSkills = string.Join(", ", RoleAptitude);
                var dynamicSkills = "";

                foreach (var aptitude in RoleAptitudeToPick)
                {
                    if (dynamicSkills.Length > 0)
                    {
                        string[] asd = { dynamicSkills, string.Join(" or ", aptitude) };
                        dynamicSkills += string.Join(", ", asd);
                    }
                    else
                    {
                        dynamicSkills = string.Join(" or ", aptitude);
                    }
                }

                return statickSkills + dynamicSkills;
            }
        }

        public string RoleTalentsStr
        {
            get
            {
                var statickSkills = string.Join(", ", RoleTalent);
                var dynamicSkills = "";

                foreach (var tallent in RoleTalentToPick)
                {
                    if (dynamicSkills.Length > 0)
                    {
                        string[] asd = { dynamicSkills, string.Join(" or ", tallent) };
                        dynamicSkills += string.Join(", ", asd);
                    }
                    else
                    {
                        dynamicSkills = string.Join(" or ", tallent);
                    }
                }

                return statickSkills + dynamicSkills;
            }
        }
    }
}

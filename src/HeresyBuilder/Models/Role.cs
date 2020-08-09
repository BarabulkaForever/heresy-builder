using System.Collections.Generic;

namespace HeresyBuilder.Models
{
    public class Role
    {
        public string Code;

        public string Name;

        public string Description;

        public List<string> RoleAptitude;

        public List<List<string>> RoleAptitudeToPick;

        public List<string> RoleTalent;

        public List<List<string>> RoleTalentToPick;

        public string RoleBonus;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.Models
{
    public class Characteristics
    {
        public CharacteristicModel WeaponSkill { get; set; }

        public CharacteristicModel BallisticSkill { get; set; }

        public CharacteristicModel Strength { get; set; }

        public CharacteristicModel Toughness { get; set; }

        public CharacteristicModel Agility { get; set; }

        public CharacteristicModel Intelligence { get; set; }

        public CharacteristicModel Perception { get; set; }

        public CharacteristicModel Willpower { get; set; }

        public CharacteristicModel Fellowship { get; set; }

        public CharacteristicModel Influence { get; set; }
    }
}

using HeresyBuilder.Enums;
using HeresyBuilder.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.Helpers
{
    public class CharacteristicsHelper
    {
        private static List<CharacteristicAdvancement> characteristicsAdvancements = new List<CharacteristicAdvancement>
        {
            new CharacteristicAdvancement{ Characteristic = Characteristic.WeaponSkill, Aptitude1 = "Weapon Skill" , Aptitude2 = "Offence" },
            new CharacteristicAdvancement{ Characteristic = Characteristic.BallisticSkill, Aptitude1 = "Ballistic Skill" , Aptitude2 = "Finesse" },
            new CharacteristicAdvancement{ Characteristic = Characteristic.Strength, Aptitude1 = "Strength" , Aptitude2 = "Offence" },
            new CharacteristicAdvancement{ Characteristic = Characteristic.Toughness, Aptitude1 = "Toughness" , Aptitude2 = "Defence" },
            new CharacteristicAdvancement{ Characteristic = Characteristic.Agility, Aptitude1 = "Agility" , Aptitude2 = "Finesse" },
            new CharacteristicAdvancement{ Characteristic = Characteristic.Intelligence, Aptitude1 = "Intelligence" , Aptitude2 = "Knowledge" },
            new CharacteristicAdvancement{ Characteristic = Characteristic.Perception, Aptitude1 = "Perception" , Aptitude2 = "Fieldcraft" },
            new CharacteristicAdvancement{ Characteristic = Characteristic.Willpower, Aptitude1 = "Willpower" , Aptitude2 = "Psyker" },
            new CharacteristicAdvancement{ Characteristic = Characteristic.Fellowship, Aptitude1 = "Fellowship" , Aptitude2 = "Social" }
        };

        public static CharacteristicsPrise GetPriceForCharacteristic(Enums.Characteristic characteristic, CharacteristicLevel characteristicLevel)
        {
            var characteristicAdvancement = characteristicsAdvancements.FirstOrDefault(x => x.Characteristic == characteristic);
            var aptitudes = CurrentCharacterData.Instance.Character.Aptitudes;

            if (aptitudes.Contains(characteristicAdvancement.Aptitude1))
            {
                if (aptitudes.Contains(characteristicAdvancement.Aptitude2))
                {
                    // contains two apptitudes
                    return new CharacteristicsPrise
                    {
                        Prise = GetPriceForTwoAptitudes(characteristicLevel),
                        Aptitudes = ContainsAptitudes.Two
                    };
                }
                else
                {
                    // contains one apptitude
                    return new CharacteristicsPrise
                    {
                        Prise = GetPriceForOneAptitude(characteristicLevel),
                        Aptitudes = ContainsAptitudes.One
                    };
                }
            }
            else
            {
                if (aptitudes.Contains(characteristicAdvancement.Aptitude2))
                {
                    // contains one apptitude
                    return new CharacteristicsPrise
                    {
                        Prise = GetPriceForOneAptitude(characteristicLevel),
                        Aptitudes = ContainsAptitudes.One
                    };
                }
                else
                {
                    // contains zero apptitudes
                    return new CharacteristicsPrise
                    {
                        Prise = GetPriceForZeroAptitudes(characteristicLevel),
                        Aptitudes = ContainsAptitudes.None
                    };
                }
            }
        }

        private static int GetPriceForTwoAptitudes(CharacteristicLevel characteristicLevel)
        {
            if (characteristicLevel == CharacteristicLevel.None)
            {
                return 100;
            }
            else if (characteristicLevel == CharacteristicLevel.Simple)
            {
                return 250;
            }
            else if (characteristicLevel == CharacteristicLevel.Intermediate)
            {
                return 500;
            }
            else if (characteristicLevel == CharacteristicLevel.Trained)
            {
                return 750;
            }
            else
            {
                return 1250;
            }
        }

        private static int GetPriceForOneAptitude(CharacteristicLevel characteristicLevel)
        {
            if (characteristicLevel == CharacteristicLevel.None)
            {
                return 250;
            }
            else if (characteristicLevel == CharacteristicLevel.Simple)
            {
                return 500;
            }
            else if (characteristicLevel == CharacteristicLevel.Intermediate)
            {
                return 750;
            }
            else if (characteristicLevel == CharacteristicLevel.Trained)
            {
                return 1000;
            }
            else
            {
                return 1500;
            }
        }

        private static int GetPriceForZeroAptitudes(CharacteristicLevel characteristicLevel)
        {
            if (characteristicLevel == CharacteristicLevel.None)
            {
                return 500;
            }
            else if (characteristicLevel == CharacteristicLevel.Simple)
            {
                return 750;
            }
            else if (characteristicLevel == CharacteristicLevel.Intermediate)
            {
                return 1000;
            }
            else if (characteristicLevel == CharacteristicLevel.Trained)
            {
                return 1500;
            }
            else
            {
                return 2500;
            }
        }

        public class CharacteristicsPrise
        {
            public int Prise { get; set; }
            public ContainsAptitudes Aptitudes { get; set; }
        }

        public class CharacteristicAdvancement
        {
            public Enums.Characteristic Characteristic { get; set; }
            public string Aptitude1 { get; set; }
            public string Aptitude2 { get; set; }
        }
    }
}

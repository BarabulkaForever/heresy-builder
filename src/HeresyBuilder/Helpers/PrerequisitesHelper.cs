using HeresyBuilder.Models;
using HeresyBuilder.Models.PrerequisitesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.Helpers
{
    public class PrerequisitesHelper
    {
        public static bool Validate(TalentAdvancement talent, Character character)
        {
            if (talent.Prerequisites.Characteristic.Any() && !talent.Prerequisites.Characteristic.All(x => ValidateCharacteristic(x, character)))
            {
                return false;
            }
            else if (talent.Prerequisites.OneOffCharacteristics.Any() && !talent.Prerequisites.OneOffCharacteristics.All(y => y.Any(x => ValidateCharacteristic(x, character))))
            {
                return false;
            }
            else if (talent.Prerequisites.Skills.Any() && !talent.Prerequisites.Skills.All(x => ValidateSkills(x, character)))
            {
                return false;
            }
            else if (talent.Prerequisites.OneOffSkills != null && talent.Prerequisites.OneOffSkills.Any() && !talent.Prerequisites.OneOffSkills.All(y => y.Any(x => ValidateSkills(x, character))))
            {
                return false;
            }
            else if (talent.Prerequisites.Traits.Any() && !talent.Prerequisites.Traits.All(x => ValidateTraits(x, character)))
            {
                return false;
            }
            else if (talent.Prerequisites.Talents.Any() && !talent.Prerequisites.Talents.All(x => ValidateTalents(x, character)))
            {
                return false;
            }
            else if (talent.Prerequisites.Cybernetics.Any() && !talent.Prerequisites.Cybernetics.All(x => ValidateCybernetics(x, character)))
            {
                return false;
            }
            else if (talent.Prerequisites.PsyRating > character.PsyRating)
            {
                return false;
            }

            return true;
        }

        private static bool ValidateCharacteristic(CharacteristicPrerequisites characteristic, Character character)
        {
            if (characteristic.Name.ToLower().Contains("Weapon skill".ToLower()))
            {
                return characteristic.Value <= character.Characteristics.WeaponSkill.Value;
            }
            else if (characteristic.Name.ToLower().Contains("Ballistic skill".ToLower()))
            {
                return characteristic.Value <= character.Characteristics.BallisticSkill.Value;
            }
            else if (characteristic.Name.ToLower().Contains("Strength".ToLower()))
            {
                return characteristic.Value <= character.Characteristics.Strength.Value;
            }
            else if (characteristic.Name.ToLower().Contains("Toughness".ToLower()))
            {
                return characteristic.Value <= character.Characteristics.Toughness.Value;
            }
            else if (characteristic.Name.ToLower().Contains("Agility".ToLower()))
            {
                return characteristic.Value <= character.Characteristics.Agility.Value;
            }
            else if (characteristic.Name.ToLower().Contains("Intelligence".ToLower()))
            {
                return characteristic.Value <= character.Characteristics.Intelligence.Value;
            }
            else if (characteristic.Name.ToLower().Contains("Perception".ToLower()))
            {
                return characteristic.Value <= character.Characteristics.Perception.Value;
            }
            else if (characteristic.Name.ToLower().Contains("Willpower".ToLower()))
            {
                return characteristic.Value <= character.Characteristics.Willpower.Value;
            }
            else if (characteristic.Name.ToLower().Contains("Fellowship".ToLower()))
            {
                return characteristic.Value <= character.Characteristics.Fellowship.Value;
            }
            else if (characteristic.Name.ToLower().Contains("Influence".ToLower()))
            {
                return characteristic.Value <= character.Characteristics.Influence.Value;
            }
            else
            {
                return true;
            }
        }

        private static bool ValidateSkills(SkillPrerequisites skill, Character character)
        {
            if (skill.Name.Contains("Linguistics"))
            {
                return ValidateSkills(skill, character.Skills.Linguistics);
            }
            else if (skill.Name.Contains("Trade"))
            {
                return ValidateSkills(skill, character.Skills.Trade);
            }
            else if (skill.Name.Contains("Lore"))
            {
                if (skill.Name.Contains("Common"))
                {
                    return ValidateSkills(skill, character.Skills.CommonLore);
                }
                else if (skill.Name.Contains("Scholastic"))
                {
                    return ValidateSkills(skill, character.Skills.ScholasticLore);
                }
                else if (skill.Name.Contains("Forbidden"))
                {
                    return ValidateSkills(skill, character.Skills.ForbiddenLore);
                }
                else
                {
                    var lors = new List<Skill>();
                    lors.AddRange(character.Skills.CommonLore);
                    lors.AddRange(character.Skills.ScholasticLore);
                    lors.AddRange(character.Skills.ForbiddenLore);
                    return ValidateSkills(skill, lors);
                }
            }
            else if (skill.Name.Contains("Navigate"))
            {
                return ValidateSkills(skill, character.Skills.Navigate);
            }
            else if (skill.Name.Contains("Operate"))
            {
                return ValidateSkills(skill, character.Skills.Operate);
            }
            else
            {
                return ValidateSkills(skill, character.Skills.NormalSkills);
            }
        }

        private static bool ValidateSkills(SkillPrerequisites skill, List<Skill> skills)
        {
            if (skill.Name.Contains("Any"))
            {
                return skills.Any(x => ((int)x.Level) >= ((int)skill.Level));
            }
            else
            {
                return skills.Any(x => skill.Name.Contains(x.Name) && ((int)x.Level) >= ((int)skill.Level));
            }
        }

        private static bool ValidateTraits(string trait, Character character)
        {
            return character.Traits.Contains(trait);
        }

        private static bool ValidateTalents(string talent, Character character)
        {
            return character.Talents.Contains(talent);
        }

        private static bool ValidateCybernetics(string cybernetic, Character character)
        {
            return character.Cybernetics.Contains(cybernetic);
        }
    }
}

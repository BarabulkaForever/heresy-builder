using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.Enums
{
    public enum Characteristic
    {
        [Description("Weapon Skill measures a character’s competence in all forms of close - quarters combat.")]
        WeaponSkill,

        [Description("Ballistic Skill measures a character’s accuracy with all forms of ranged weapons.")]
        BallisticSkill,

        [Description("Strength measures a character’s muscle and physical power.")]
        Strength,

        [Description("Toughness measures a character’s health, stamina, and resistance.")]
        Toughness,

        [Description("This measures a character’s quickness, reflex, and poise.")]
        Agility,

        [Description("Intelligence measures a character’s acumen, reason, and general knowledge.")]
        Intelligence,

        [Description("This measures a character’s awareness and the acuteness of his senses.")]
        Perception,

        [Description("Willpower measures a character’s mental strength and resilience.")]
        Willpower,

        [Description("Fellowship measures a character’s persuasiveness, ability to lead, and force of personality")]
        Fellowship,

        [Description("This measures a character’s connections, reputation, and resources.")]
        Influence
    }
}

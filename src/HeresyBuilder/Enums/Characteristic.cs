using HeresyBuilder.Attributes;
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
        [ShortName("WS")]
        WeaponSkill = 0,

        [Description("Ballistic Skill measures a character’s accuracy with all forms of ranged weapons.")]
        [ShortName("BS")]
        BallisticSkill = 1,

        [Description("Strength measures a character’s muscle and physical power.")]
        [ShortName("S")]
        Strength = 2,

        [Description("Toughness measures a character’s health, stamina, and resistance.")]
        [ShortName("T")]
        Toughness = 3,

        [Description("This measures a character’s quickness, reflex, and poise.")]
        [ShortName("A")]
        Agility = 4,

        [Description("Intelligence measures a character’s acumen, reason, and general knowledge.")]
        [ShortName("Int")]
        Intelligence = 5,

        [Description("This measures a character’s awareness and the acuteness of his senses.")]
        [ShortName("Per")]
        Perception = 6,

        [Description("Willpower measures a character’s mental strength and resilience.")]
        [ShortName("WP")]
        Willpower = 7,

        [Description("Fellowship measures a character’s persuasiveness, ability to lead, and force of personality")]
        [ShortName("Fel")]
        Fellowship = 8,

        [Description("This measures a character’s connections, reputation, and resources.")]
        [ShortName("Inf")]
        Influence = 9
    }
}

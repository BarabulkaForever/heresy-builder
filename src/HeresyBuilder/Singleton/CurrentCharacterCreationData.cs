using HeresyBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.Singleton
{
    public sealed class CurrentCharacterCreationData
    {
        private static CurrentCharacterCreationData instance = null;

        private CurrentCharacterCreationData()
        {
        }

        public static CurrentCharacterCreationData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CurrentCharacterCreationData();
                }
                return instance;
            }
        }

        public string Name { get; set; }

        public Background Background { get; set; }

        public World World { get; set; }

        public Role Role { get; set; }

        public Characteristics Characteristics { get; set; }

        public List<string> Aptitudes { get; set; }

        public List<string> Talents { get; set; }

        public List<string> Items { get; set; }

        public List<string> Skills { get; set; }

        public int TotalWounds { get; set; }

        public int TotalFateThreshold { get; set; }

        public Character ToCharacter()
        {
            var character = new Character 
            {
                Name = Name,
                WorldCode = World.Code,
                BackgroundCode = Background.Code,
                RoleCode = Role.Code,
                Characteristics = Characteristics,
                Aptitudes = Aptitudes,
                Items = Items,
                Skills = new Skills(Skills),
                Talents = Talents,
                TotalFateThreshold = TotalFateThreshold,
                TotalWounds = TotalWounds,
                XPToSpend = 1000,
                XPSpended = 0
            };

            return character;
        }
    }
}

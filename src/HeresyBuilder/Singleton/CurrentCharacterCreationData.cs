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

        public Background Background { get; set; }

        public World World { get; set; }

        public Role Role { get; set; }

        public Characteristics Characteristics { get; set; }

        public List<string> Aptitudes { get; set; }

        public List<string> Talents { get; set; }

        public List<string> Items { get; set; }

        public List<string> Skills { get; set; }
    }
}

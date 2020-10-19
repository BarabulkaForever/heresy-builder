using HeresyBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.Singleton
{
    public sealed class CurrentCharacterData
    {
        private static CurrentCharacterData instance = null;

        private CurrentCharacterData()
        {
        }

        public static CurrentCharacterData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CurrentCharacterData();
                }
                return instance;
            }
        }

        public Character Character { get; set; }
    }
}

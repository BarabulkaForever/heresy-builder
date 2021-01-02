using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.Models
{
    public class CharacteristicModel
    {
        public Enums.Characteristic CharacteristicType { get; set; }

        public Enums.CharacteristicLevel CharacteristicLevel { get; set; }

        public int Value { get; set; }
    }
}

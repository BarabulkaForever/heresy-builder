using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.Models
{
    public class Character
    {
        public string Name { get; set; }

        public string WorldCode { get; set; }
        
        public string BackgroundCode { get; set; }

        public string RoleCode { get; set; }

        public Characteristics Characteristics { get; set; }

        public List<string> Aptitudes { get; set; }

        public List<string> Talents { get; set; }

        public List<string> Items { get; set; }

        public Skills Skills { get; set; }

        public int TotalWounds { get; set; }

        public int TotalFateThreshold { get; set; }

    }
}

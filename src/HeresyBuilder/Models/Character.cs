﻿using Newtonsoft.Json;
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

        public List<string> Traits { get; set; } = new List<string>();//todo remuve after create traits.

        public List<string> Cybernetics { get; set; }

        public Skills Skills { get; set; }

        public int TotalWounds { get; set; }

        public int TotalFateThreshold { get; set; }

        public int XPToSpend { get; set; }

        public int XPSpended { get; set; }

        public int PsyRating { get; set; }

        public Character Clone()
        {
            return JsonConvert.DeserializeObject<Character>(JsonConvert.SerializeObject(this));
        }
    }
}

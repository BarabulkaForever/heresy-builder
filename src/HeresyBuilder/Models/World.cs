using HeresyBuilder.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.Models
{
    public class World
    {
        public string Code { get; set; }

        public string Url
        {
            get
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var heresyBuilderPath = Path.Combine(path, "HeresyBuilder");
                var homeworldsPath = Path.Combine(heresyBuilderPath, "homeworlds");
                var imagesPath = Path.Combine(homeworldsPath, "images");
                return Path.Combine(imagesPath, Code.ToLower() + ".png");
            }
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ModifierOne { get; set; }

        public string ModifierTwo { get; set; }

        public string ModifierNegative { get; set; }

        public int FateThreshold { get; set; }

        public int EmperorsBlessing { get; set; }

        public string HomeWorldBonus { get; set; }

        public string Aptitude { get; set; }

        public string Wounds { get; set; }

        public string Modifiers 
        {
            get 
            {
                return ModifierOne + " +, " + ModifierTwo + " +, " + ModifierNegative + " -";
            }
            set { }
        }

        public string FateAndWounds 
        {
            get 
            {
                return "Base Fate: " + FateThreshold + ", Base Wounds: " + Wounds;
            }
            set { }
        }
        
        public string AptitudeWithText
        {
            get
            {
                return "Aptitude: " + Aptitude;
            }
            set { }
        }
    }
}

using HeresyBuilder.Enums;
using HeresyBuilder.Models;
using HeresyBuilder.Services;
using HeresyBuilder.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.ViewModels.CharacterViewModels
{
    public class CharacterViewModel : BaseViewModel
    {
        private Character Character { get; set; }

        private FileAccessService _fileAccessService;

        public CharacterViewModel()
        {
            _fileAccessService = new FileAccessService();
            Init();
        }

        private void Init()
        {
            Character = CurrentCharacterData.Instance.Character;
        }

        #region Header

        public string Name
        {
            get
            {
                return Character.Name;
            }
        }

        public string HomeWorld
        {
            get
            {
                return _fileAccessService.GetHomeworlds().First(x => x.Code == Character.WorldCode).Name;
            }
        }

        public string Background
        {
            get
            {
                return _fileAccessService.GetBackgrounds().First(x => x.Code == Character.BackgroundCode).Name;
            }
        }

        public string Role
        {
            get
            {
                return _fileAccessService.GetRoles().First(x => x.Code == Character.RoleCode).Name;
            }
        }

        #endregion

        #region Characteristics

        public string WeaponSkill
        {
            get
            {
                return "WS " + Character.Characteristics.WeaponSkill;
            }
        }

        public string BallisticSkill
        {
            get
            {
                return "BS " + Character.Characteristics.BallisticSkill;
            }
        }

        public string Strength
        {
            get
            {
                return "Str " + Character.Characteristics.Strength;
            }
        }

        public string Toughness
        {
            get
            {
                return "Tou " + Character.Characteristics.Toughness;
            }
        }

        public string Agility
        {
            get
            {
                return "Agi " + Character.Characteristics.Agility;
            }
        }

        public string Intelligence
        {
            get
            {
                return "Int " + Character.Characteristics.Intelligence;
            }
        }

        public string Perception
        {
            get
            {
                return "Per " + Character.Characteristics.Perception;
            }
        }

        public string Willpower
        {
            get
            {
                return "Wil " + Character.Characteristics.Willpower;
            }
        }

        public string Fellowship
        {
            get
            {
                return "Fel " + Character.Characteristics.Fellowship;
            }
        }

        public string Influence
        {
            get
            {
                return "Inf " + Character.Characteristics.Influence;
            }
        }
        #endregion

        public string FatePoints
        {
            get
            {
                return "Threshold " + Character.TotalFateThreshold;
            }
        }

        public string Wounds
        {
            get
            {
                return "" + Character.TotalWounds;
            }
        }

        #region Skills

        public int Acrobatics 
        { 
            get 
            {
                return (int) Character.Skills.Acrobatics;    
            }
        }

        public int Athletics 
        {
            get 
            {
                return (int) Character.Skills.Athletics;    
            }
        }

        public int Awareness
        {
            get
            {
                return (int) Character.Skills.Awareness;
            }
        }

        public int Charm
        {
            get
            {
                return (int) Character.Skills.Charm;
            }
        }

        public int Command
        {
            get
            {
                return (int) Character.Skills.Command;
            }
        }

        public int Commerce
        {
            get
            {
                return (int) Character.Skills.Commerce;
            }
        }

        public int Deceive
        {
            get
            {
                return (int) Character.Skills.Deceive;
            }
        }

        public int Dodge
        {
            get
            {
                return (int) Character.Skills.Dodge;
            }
        }

        public int Inquiry
        {
            get
            {
                return (int) Character.Skills.Inquiry;
            }
        }

        public int Interrogation
        {
            get
            {
                return (int) Character.Skills.Interrogation;
            }
        }

        public int Intimidate
        {
            get
            {
                return (int) Character.Skills.Intimidate;
            }
        }

        public int Logic
        {
            get
            {
                return (int)Character.Skills.Logic;
            }
        }

        public int Medicae
        {
            get
            {
                return (int)Character.Skills.Medicae;
            }
        }

        public int Parry
        {
            get
            {
                return (int)Character.Skills.Parry;
            }
        }

        public int Psyniscience
        {
            get
            {
                return (int)Character.Skills.Psyniscience;
            }
        }

        public int Scrutiny
        {
            get
            {
                return (int)Character.Skills.Scrutiny;
            }
        }

        public int Security
        {
            get
            {
                return (int)Character.Skills.Security;
            }
        }

        public int SleightOfHand
        {
            get
            {
                return (int)Character.Skills.SleightOfHand;
            }
        }

        public int Stealth
        {
            get
            {
                return (int)Character.Skills.Stealth;
            }
        }

        public int Survival
        {
            get
            {
                return (int)Character.Skills.Survival;
            }
        }

        public int TechUse
        {
            get
            {
                return (int)Character.Skills.TechUse;
            }
        }

        // Navigate 
        public int NavigateSurface
        {
            get
            {
                return (int)Character.Skills.NavigateSurface;
            }
        }

        public int NavigateStellar
        {
            get
            {
                return (int)Character.Skills.NavigateStellar;
            }
        }

        public int NavigateWarp
        {
            get
            {
                return (int)Character.Skills.NavigateWarp;
            }
        }

        // Operate 
        public int OperateAeronautica
        {
            get
            {
                return (int)Character.Skills.OperateAeronautica;
            }
        }

        public int OperateSurface
        {
            get
            {
                return (int)Character.Skills.OperateSurface;
            }
        }

        public int OperateVoidship
        {
            get
            {
                return (int)Character.Skills.OperateVoidship;
            }
        }

        public List<Skill> Linguistics
        {
            get
            {
                return Character.Skills.Linguistics;
            }
        }

        public List<Skill> Trade
        {
            get
            {
                return Character.Skills.Trade;
            }
        }

        // Lore
        public List<Skill> CommonLore
        {
            get
            {
                return Character.Skills.CommonLore;
            }
        }


        public List<Skill> ScholasticLore
        {
            get
            {
                return Character.Skills.ScholasticLore;
            }
        }

        public List<Skill> ForbiddenLore
        {
            get
            {
                return Character.Skills.ForbiddenLore;
            }
        }


        #endregion

        #region Skills

        public List<string> Talents
        {
            get
            {
                return Character.Talents;
            }
        }

        #endregion
    }
}

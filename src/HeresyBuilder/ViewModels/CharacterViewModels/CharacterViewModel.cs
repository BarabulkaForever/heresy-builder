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

        public string XPToSpend
        {
            get
            {
                return Character.XPToSpend.ToString();
            }
        }

        public string XPSpended
        {
            get
            {
                return Character.XPSpended.ToString();
            }
        }

        public string TotalXP
        {
            get
            {
                return (Character.XPSpended + Character.XPToSpend).ToString();
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

        public List<SkillInListViewModel> NormalSkills
        {
            get
            {
                return Character.Skills.NormalSkills.Select(x =>new SkillInListViewModel(null, x)).ToList();
            }
        }

        public List<SkillInListViewModel> Operate
        {
            get
            {
                return Character.Skills.Operate.Select(x => new SkillInListViewModel(null, x)).ToList();
            }
        }

        public List<SkillInListViewModel> Navigate
        {
            get
            {
                return Character.Skills.Navigate.Select(x => new SkillInListViewModel(null, x)).ToList();
            }
        }

        public List<SkillInListViewModel> Linguistics
        {
            get
            {
                return Character.Skills.Linguistics.Select(x => new SkillInListViewModel(null, x)).ToList();
            }
        }

        public List<SkillInListViewModel> Trade
        {
            get
            {
                return Character.Skills.Trade.Select(x => new SkillInListViewModel(null, x)).ToList();
            }
        }

        // Lore
        public List<SkillInListViewModel> CommonLore
        {
            get
            {
                return Character.Skills.CommonLore.Select(x => new SkillInListViewModel(null, x)).ToList();
            }
        }


        public List<SkillInListViewModel> ScholasticLore
        {
            get
            {
                return Character.Skills.ScholasticLore.Select(x => new SkillInListViewModel(null, x)).ToList();
            }
        }

        public List<SkillInListViewModel> ForbiddenLore
        {
            get
            {
                return Character.Skills.ForbiddenLore.Select(x => new SkillInListViewModel(null, x)).ToList();
            }
        }


        #endregion

        #region Talents

        public List<string> Talents
        {
            get
            {
                return Character.Talents;
            }
        }

        #endregion

        public void AddXP(int newXP)
        {
            Character.XPToSpend += newXP;

            SetPropertyChanged(nameof(XPToSpend));
            SetPropertyChanged(nameof(TotalXP));
        }

        public void SpendXP(int spendXP)
        {
            Character.XPToSpend -= spendXP;
            Character.XPSpended += spendXP;

            SetPropertyChanged(nameof(XPToSpend));
            SetPropertyChanged(nameof(XPSpended));
            SetPropertyChanged(nameof(TotalXP));
        }
    }
}

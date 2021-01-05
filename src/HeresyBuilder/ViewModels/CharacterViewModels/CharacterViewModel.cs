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

        public void Save()
        {
            CurrentCharacterData.Instance.Character = Character;
            _fileAccessService.SaveEditedCharacter(Character);
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

        public CharacteristicViewModel WeaponSkill
        {
            get
            {
                return new CharacteristicViewModel(Character.Characteristics.WeaponSkill);
            }
        }

        public CharacteristicViewModel BallisticSkill
        {
            get
            {
                return new CharacteristicViewModel(Character.Characteristics.BallisticSkill);
            }
        }

        public CharacteristicViewModel Strength
        {
            get
            {
                return new CharacteristicViewModel(Character.Characteristics.Strength);
            }
        }

        public CharacteristicViewModel Toughness
        {
            get
            {
                return new CharacteristicViewModel(Character.Characteristics.Toughness);
            }
        }

        public CharacteristicViewModel Agility
        {
            get
            {
                return new CharacteristicViewModel(Character.Characteristics.Agility);
            }
        }

        public CharacteristicViewModel Intelligence
        {
            get
            {
                return new CharacteristicViewModel(Character.Characteristics.Intelligence);
            }
        }

        public CharacteristicViewModel Perception
        {
            get
            {
                return new CharacteristicViewModel(Character.Characteristics.Perception);
            }
        }

        public CharacteristicViewModel Willpower
        {
            get
            {
                return new CharacteristicViewModel(Character.Characteristics.Willpower);
            }
        }

        public CharacteristicViewModel Fellowship
        {
            get
            {
                return new CharacteristicViewModel(Character.Characteristics.Fellowship);
            }
        }

        public CharacteristicViewModel Influence
        {
            get
            {
                return new CharacteristicViewModel(Character.Characteristics.Influence);
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

        #region Apptitudes

        public List<string> Apptitudes
        {
            get
            {
                return Character.Aptitudes;
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

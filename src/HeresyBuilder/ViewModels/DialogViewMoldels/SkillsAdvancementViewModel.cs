using HeresyBuilder.Enums;
using HeresyBuilder.Models;
using HeresyBuilder.Services;
using HeresyBuilder.Singleton;
using HeresyBuilder.ViewModels.CharacterViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.ViewModels.DialogViewMoldels
{
    public class SkillsAdvancementViewModel : BaseViewModel
    {
        public Character Character { get; set; }
        private FileAccessService _fileAccessService;
        private int _XPToSpend;
        private int _spendedXP;

        public SkillsAdvancementViewModel()
        {
            _fileAccessService = new FileAccessService();
            Init();
        }

        private void Init()
        {
            Character = CurrentCharacterData.Instance.Character.Clone();

            XPToSpend = Character.XPToSpend;
        }

        #region XP

        public int XPToSpend
        {
            get
            {
                return _XPToSpend;
            }
            set
            {
                _XPToSpend = value;
                SetPropertyChanged(nameof(XPToSpend));
                SetPropertyChanged(nameof(XPToSpendText));
            }
        }

        public string XPToSpendText
        {
            get
            {
                return "You have " + _XPToSpend + " XP left";
            }
        }

        public void SpendXP(int xp)
        {
            _XPToSpend -= xp;
            _spendedXP += xp;
            SetPropertyChanged(nameof(XPToSpend));
            SetPropertyChanged(nameof(XPToSpendText));
        } 

        public int SpendedXP
        {
            get
            {
                return _spendedXP;
            }
        }

        public bool CanSpendXP(int xp)
        {
            return XPToSpend >= xp;
        }

        #endregion

        #region Skills

        public int Acrobatics
        {
            get
            {
                return (int)Character.Skills.Acrobatics;
            }
            set
            {
                Character.Skills.Acrobatics = (SkillLevel)value;
                SetPropertyChanged(nameof(Acrobatics));
            }
        }

        public int Athletics
        {
            get
            {
                return (int)Character.Skills.Athletics;
            }
            set
            {
                Character.Skills.Athletics = (SkillLevel)value;
                SetPropertyChanged(nameof(Athletics));
            }
        }

        public int Awareness
        {
            get
            {
                return (int)Character.Skills.Awareness;
            }
            set
            {
                Character.Skills.Awareness = (SkillLevel)value;
                SetPropertyChanged(nameof(Awareness));
            }
        }

        public int Charm
        {
            get
            {
                return (int)Character.Skills.Charm;
            }
            set
            {
                Character.Skills.Charm = (SkillLevel)value;
                SetPropertyChanged(nameof(Charm));
            }
        }

        public int Command
        {
            get
            {
                return (int)Character.Skills.Command;
            }
            set
            {
                Character.Skills.Command = (SkillLevel)value;
                SetPropertyChanged(nameof(Command));
            }
        }

        public int Commerce
        {
            get
            {
                return (int)Character.Skills.Commerce;
            }
            set
            {
                Character.Skills.Commerce = (SkillLevel)value;
                SetPropertyChanged(nameof(Commerce));
            }
        }

        public int Deceive
        {
            get
            {
                return (int)Character.Skills.Deceive;
            }
            set
            {
                Character.Skills.Deceive = (SkillLevel)value;
                SetPropertyChanged(nameof(Deceive));
            }
        }

        public int Dodge
        {
            get
            {
                return (int)Character.Skills.Dodge;
            }
            set
            {
                Character.Skills.Dodge = (SkillLevel)value;
                SetPropertyChanged(nameof(Dodge));
            }
        }

        public int Inquiry
        {
            get
            {
                return (int)Character.Skills.Inquiry;
            }
            set
            {
                Character.Skills.Inquiry = (SkillLevel)value;
                SetPropertyChanged(nameof(Inquiry));
            }
        }

        public int Interrogation
        {
            get
            {
                return (int)Character.Skills.Interrogation;
            }
            set
            {
                Character.Skills.Interrogation = (SkillLevel)value;
                SetPropertyChanged(nameof(Interrogation));
            }
        }

        public int Intimidate
        {
            get
            {
                return (int)Character.Skills.Intimidate;
            }
            set
            {
                Character.Skills.Intimidate = (SkillLevel)value;
                SetPropertyChanged(nameof(Intimidate));
            }
        }

        public int Logic
        {
            get
            {
                return (int)Character.Skills.Logic;
            }
            set
            {
                Character.Skills.Logic = (SkillLevel)value;
                SetPropertyChanged(nameof(Logic));
            }
        }

        public int Medicae
        {
            get
            {
                return (int)Character.Skills.Medicae;
            }
            set
            {
                Character.Skills.Medicae = (SkillLevel)value;
                SetPropertyChanged(nameof(Medicae));
            }
        }

        public int Parry
        {
            get
            {
                return (int)Character.Skills.Parry;
            }
            set
            {
                Character.Skills.Parry = (SkillLevel)value;
                SetPropertyChanged(nameof(Parry));
            }
        }

        public int Psyniscience
        {
            get
            {
                return (int)Character.Skills.Psyniscience;
            }
            set
            {
                Character.Skills.Psyniscience = (SkillLevel)value;
                SetPropertyChanged(nameof(Psyniscience));
            }
        }

        public int Scrutiny
        {
            get
            {
                return (int)Character.Skills.Scrutiny;
            }
            set
            {
                Character.Skills.Scrutiny = (SkillLevel)value;
                SetPropertyChanged(nameof(Scrutiny));
            }
        }

        public int Security
        {
            get
            {
                return (int)Character.Skills.Security;
            }
            set
            {
                Character.Skills.Security = (SkillLevel)value;
                SetPropertyChanged(nameof(Security));
            }
        }

        public int SleightOfHand
        {
            get
            {
                return (int)Character.Skills.SleightOfHand;
            }
            set
            {
                Character.Skills.SleightOfHand = (SkillLevel)value;
                SetPropertyChanged(nameof(SleightOfHand));
            }
        }

        public int Stealth
        {
            get
            {
                return (int)Character.Skills.Stealth;
            }
            set
            {
                Character.Skills.Stealth = (SkillLevel)value;
                SetPropertyChanged(nameof(Stealth));
            }
        }

        public int Survival
        {
            get
            {
                return (int)Character.Skills.Survival;
            }
            set
            {
                Character.Skills.Survival = (SkillLevel)value;
                SetPropertyChanged(nameof(Survival));
            }
        }

        public int TechUse
        {
            get
            {
                return (int)Character.Skills.TechUse;
            }
            set
            {
                Character.Skills.TechUse = (SkillLevel)value;
                SetPropertyChanged(nameof(TechUse));
            }
        }

        // Navigate 
        public int NavigateSurface
        {
            get
            {
                return (int)Character.Skills.NavigateSurface;
            }
            set
            {
                Character.Skills.NavigateSurface = (SkillLevel)value;
                SetPropertyChanged(nameof(NavigateSurface));
            }
        }

        public int NavigateStellar
        {
            get
            {
                return (int)Character.Skills.NavigateStellar;
            }
            set
            {
                Character.Skills.NavigateStellar = (SkillLevel)value;
                SetPropertyChanged(nameof(NavigateStellar));
            }
        }

        public int NavigateWarp
        {
            get
            {
                return (int)Character.Skills.NavigateWarp;
            }
            set
            {
                Character.Skills.NavigateWarp = (SkillLevel)value;
                SetPropertyChanged(nameof(NavigateWarp));
            }
        }

        // Operate 
        public int OperateAeronautica
        {
            get
            {
                return (int)Character.Skills.OperateAeronautica;
            }
            set
            {
                Character.Skills.OperateAeronautica = (SkillLevel)value;
                SetPropertyChanged(nameof(OperateAeronautica));
            }
        }

        public int OperateSurface
        {
            get
            {
                return (int)Character.Skills.OperateSurface;
            }
            set
            {
                Character.Skills.OperateSurface = (SkillLevel)value;
                SetPropertyChanged(nameof(OperateSurface));
            }
        }

        public int OperateVoidship
        {
            get
            {
                return (int)Character.Skills.OperateVoidship;
            }
            set
            {
                Character.Skills.OperateVoidship = (SkillLevel)value;
                SetPropertyChanged(nameof(OperateVoidship));
            }
        }

        public List<SkillInListViewModel> Linguistics
        {
            get
            {
                var vmList = new List<SkillInListViewModel>();
                Character.Skills.Linguistics.ForEach(x => vmList.Add(new SkillInListViewModel(this, x)));
                return vmList;
            }
        }

        public List<SkillInListViewModel> Trade
        {
            get
            {
                var vmList = new List<SkillInListViewModel>();
                Character.Skills.Trade.ForEach(x => vmList.Add(new SkillInListViewModel(this, x)));
                return vmList;
            }
        }

        // Lore
        public List<SkillInListViewModel> CommonLore
        {
            get
            {
                var vmList = new List<SkillInListViewModel>();
                Character.Skills.CommonLore.ForEach(x => vmList.Add(new SkillInListViewModel(this, x)));
                return vmList;
            }
        }


        public List<SkillInListViewModel> ScholasticLore
        {
            get
            {
                var vmList = new List<SkillInListViewModel>();
                Character.Skills.ScholasticLore.ForEach(x => vmList.Add(new SkillInListViewModel(this, x)));
                return vmList;
            }
        }

        public List<SkillInListViewModel> ForbiddenLore
        {
            get
            {
                var vmList = new List<SkillInListViewModel>();
                Character.Skills.ForbiddenLore.ForEach(x => vmList.Add(new SkillInListViewModel(this, x)));
                return vmList;
            }
        }


        #endregion

    }
}

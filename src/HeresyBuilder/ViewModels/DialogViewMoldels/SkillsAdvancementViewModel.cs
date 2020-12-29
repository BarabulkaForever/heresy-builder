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

        public List<SkillInListViewModel> NormalSkills
        {
            get
            {
                var vmList = new List<SkillInListViewModel>();
                Character.Skills.NormalSkills.ForEach(x => vmList.Add(new SkillInListViewModel(this, x)));
                return vmList;
            }
        }

        public List<SkillInListViewModel> Navigate
        {
            get
            {
                var vmList = new List<SkillInListViewModel>();
                Character.Skills.Navigate.ForEach(x => vmList.Add(new SkillInListViewModel(this, x)));
                return vmList;
            }
        }

        public List<SkillInListViewModel> Operate
        {
            get
            {
                var vmList = new List<SkillInListViewModel>();
                Character.Skills.Operate.ForEach(x => vmList.Add(new SkillInListViewModel(this, x)));
                return vmList;
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

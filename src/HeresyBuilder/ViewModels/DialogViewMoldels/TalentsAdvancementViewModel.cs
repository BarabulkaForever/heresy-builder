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
    public class TalentsAdvancementViewModel : BaseViewModel
    {
        public Character Character { get; set; }
        private FileAccessService _fileAccessService;
        private int _XPToSpend;
        private int _spendedXP;
        private List<TalentListViewModel> _talents;

        public TalentsAdvancementViewModel()
        {
            _fileAccessService = new FileAccessService();
            Init();
        }

        private void Init()
        {
            Character = CurrentCharacterData.Instance.Character.Clone();
            XPToSpend = Character.XPToSpend;
            var talents = _fileAccessService.LoadTalents();
            var talentsVMs = new List<TalentListViewModel>();
            talents.ForEach(x => 
            {
                talentsVMs.Add(new TalentListViewModel(this, x, Character.Talents.Contains(x.Name)));
            });
            Talents = talentsVMs;
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
            Talents.ForEach(x => x.SetPropertyChanged(nameof(x.CanPurchase)));
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

        public List<TalentListViewModel> Talents
        {
            get => _talents;
            set
            {
                _talents = value;
                SetPropertyChanged(nameof(Talents));
            }
        }
    }
}

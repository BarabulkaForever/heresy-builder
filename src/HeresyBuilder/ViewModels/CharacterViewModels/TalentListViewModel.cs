using HeresyBuilder.Enums;
using HeresyBuilder.Helpers;
using HeresyBuilder.Implementations;
using HeresyBuilder.Models;
using HeresyBuilder.ViewModels.DialogViewMoldels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HeresyBuilder.ViewModels.CharacterViewModels
{
    public class TalentListViewModel : BaseViewModel
    {

        private TalentsAdvancementViewModel _parrent;

        private TalentAdvancement _talent;

        private bool _alreadyKnown;
        private ContainsAptitudes numberOfApptitudes;

        public TalentListViewModel(TalentsAdvancementViewModel parrent, TalentAdvancement talent, bool alreadyKnown)
        {
            _parrent = parrent;
            _talent = talent;
            _alreadyKnown = alreadyKnown;
            PurchaseCommand = new CustomCommand(_ => Purchase());
        }


        public string Name
        {
            get
            {
                return _talent.Name;
            }
        }

        public string Tier
        {
            get
            {
                return _talent.Tier.ToString();
            }
        }

        public string Benefit
        {
            get
            {
                return _talent.Benefit;
            }
        }

        public string Prise
        {
            get
            {
                return CalculatePrice().ToString();
            }
        }

        public ContainsAptitudes NumberOfApptitudes
        {
            get => numberOfApptitudes;
            private set 
            {
                numberOfApptitudes = value;
                SetPropertyChanged(nameof(NumberOfApptitudes));
            }
        }

        public bool AlreadyKnown
        {
            get => _alreadyKnown;
            set
            {
                _alreadyKnown = value;
                SetPropertyChanged(nameof(AlreadyKnown));
                SetPropertyChanged(nameof(CanPurchase));
            }
        }

        public bool CanPurchase
        {
            get
            {
                return !AlreadyKnown && _parrent.CanSpendXP(CalculatePrice()) && FitPrerequisites();
            }
        }

        public ICommand PurchaseCommand { get; set; }

        private int CalculatePrice()
        {
            if (_parrent.Character.Aptitudes.Contains(_talent.Aptitude1))
            {
                if (_parrent.Character.Aptitudes.Contains(_talent.Aptitude2))
                {
                    NumberOfApptitudes = ContainsAptitudes.Two;
                    return _talent.Tier == 1 ? 200 : _talent.Tier == 2 ? 300 : 400;
                }
                else
                {
                    NumberOfApptitudes = ContainsAptitudes.One;
                    return _talent.Tier == 1 ? 300 : _talent.Tier == 2 ? 450 : 600;
                }
            }
            else
            {
                if (_parrent.Character.Aptitudes.Contains(_talent.Aptitude2))
                {
                    NumberOfApptitudes = ContainsAptitudes.One;
                    return _talent.Tier == 1 ? 300 : _talent.Tier == 2 ? 450 : 600;
                }
                else
                {
                    NumberOfApptitudes = ContainsAptitudes.None;
                    return _talent.Tier == 1 ? 600 : _talent.Tier == 2 ? 900 : 1200;
                }
            }
        }

        private bool FitPrerequisites()
        {
            return PrerequisitesHelper.Validate(_talent, _parrent.Character);
        }

        private void Purchase()
        {
            var price = CalculatePrice();
            if (_parrent.CanSpendXP(price))
            {
                _parrent.SpendXP(price);
                AlreadyKnown = true;
                _parrent.Character.Talents.Add(Name);
            }
        }
    }
}

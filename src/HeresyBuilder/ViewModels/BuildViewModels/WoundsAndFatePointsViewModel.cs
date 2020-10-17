using HeresyBuilder.Implementations;
using HeresyBuilder.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HeresyBuilder.ViewModels.BuildViewModels
{
    public class WoundsAndFatePointsViewModel : BaseViewModel
    {
        private int _additionalWounds = 0;

        private int _emperorsBlessingRoll = 0;

        public WoundsAndFatePointsViewModel()
        {
            Init();
        }

        private void Init()
        {
            RollAdditionalWoundsCommand = new CustomCommand(_ => RollAdditionalWounds());
            EmperorsBlessingCommand = new CustomCommand(_ => RollEmperorsBlessingCommand());
        }

        public string BaseWoundsString
        {
            get
            {
                return "Base Wounds (From Homeworld): " + CurrentCharacterCreationData.Instance.World.Wounds;
            }
        }

        public ICommand RollAdditionalWoundsCommand { get; set; }
        public ICommand EmperorsBlessingCommand { get; set; }

        private void RollAdditionalWounds()
        {
            _additionalWounds = (new Random()).Next(1, 6);
            SetPropertyChanged(nameof(RollAdditionalWoundsButtonText));
            SetPropertyChanged(nameof(ShouldRollAdditionalWounds));
            SetPropertyChanged(nameof(TotalWoundsStrings));
        }

        private void RollEmperorsBlessingCommand()
        {
            _emperorsBlessingRoll = (new Random()).Next(1, 11);
            SetPropertyChanged(nameof(BaseFateThreshold));
            SetPropertyChanged(nameof(EmperorsBlessing));
            SetPropertyChanged(nameof(EmperorsBlessingButtonText));
            SetPropertyChanged(nameof(ShouldRollEmperorsBlessing));
            SetPropertyChanged(nameof(TotalFateThreshold));
        }

        public string RollAdditionalWoundsButtonText
        {
            get
            {
                if (_additionalWounds == 0)
                {
                    return "Roll 1d5 Additional Wounds";
                }
                else
                {
                    return "You rolled " + _additionalWounds;
                }
            }
        }

        public string TotalWoundsStrings
        {
            get
            {
                if (_additionalWounds == 0)
                {
                    return "";
                }
                else
                {
                    return "Total Wounds " + (_additionalWounds + int.Parse(CurrentCharacterCreationData.Instance.World.Wounds.Split('+').First()));
                }
            }
        }

        public bool ShouldRollAdditionalWounds
        {
            get
            {
                return _additionalWounds == 0;
            }
        }

        public string EmperorsBlessingButtonText
        {
            get
            {
                if (_emperorsBlessingRoll == 0)
                {
                    return "Roll 1d10";
                }
                else
                {
                    return "Emperors Blessing Roll " + (_emperorsBlessingRoll);
                }
            }
        }

        public string BaseFateThreshold
        {
            get
            {
                return "Base Fate Threshold (From Homeworld): " + CurrentCharacterCreationData.Instance.World.FateThreshold;
            }
        }

        public string EmperorsBlessing
        {
            get
            {
                return "Emperors Blessing (From Homeworld): " + CurrentCharacterCreationData.Instance.World.EmperorsBlessing;
            }
        }

        public bool ShouldRollEmperorsBlessing
        {
            get
            {
                return _emperorsBlessingRoll == 0;
            }
        }

        public string TotalFateThreshold
        {
            get
            {
                if (_emperorsBlessingRoll == 0)
                {
                    return "";
                }
                else
                {
                    var emperorsBlessing = (_emperorsBlessingRoll >= CurrentCharacterCreationData.Instance.World.EmperorsBlessing) ? 1 : 0;

                    return "Total Fate Threshold: " + (CurrentCharacterCreationData.Instance.World.FateThreshold + emperorsBlessing);
                }
            }
        }

        public bool Valid
        {
            get
            {
                return _emperorsBlessingRoll != 0 && _additionalWounds != 0;
            }
        }

        public void Save()
        {
            if (Valid)
            {
                var emperorsBlessing = (_emperorsBlessingRoll >= CurrentCharacterCreationData.Instance.World.EmperorsBlessing) ? 1 : 0;
                CurrentCharacterCreationData.Instance.TotalFateThreshold = (CurrentCharacterCreationData.Instance.World.FateThreshold + emperorsBlessing);
                CurrentCharacterCreationData.Instance.TotalWounds = (_additionalWounds + int.Parse(CurrentCharacterCreationData.Instance.World.Wounds.Split('+').First()));
            }
        }
    }
}

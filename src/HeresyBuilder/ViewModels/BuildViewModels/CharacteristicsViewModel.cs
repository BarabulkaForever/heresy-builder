using HeresyBuilder.Enums;
using HeresyBuilder.Implementations;
using HeresyBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HeresyBuilder.ViewModels.BuildViewModels
{
    public class CharacteristicsViewModel : BaseViewModel
    {
        private List<CharacteristicViewModel> _characteristics;
        private Characteristics _characteristicsModel;
        private bool _isManualEnterMode = false;
        private bool _isRollMode = false;
        private bool _haveReroll = true;

        public CharacteristicsViewModel()
        {
            Init();
        }

        private void Init()
        {
            Characteristics = new List<CharacteristicViewModel>();
            CharacteristicsModel = new Characteristics();
            foreach (Characteristic characteristic in Enum.GetValues(typeof(Characteristic)))
            {
                Characteristics.Add(new CharacteristicViewModel(characteristic, this));
            }
            SwitchToRollModeCommand = new CustomCommand(_ => SwitchToRollMode());
            SwitchToManualEnterModeCommand = new CustomCommand(_ => SwitchToManualEnterMode());
        }

        private void SwitchToRollMode()
        {
            IsRollMode = true;
            SetPropertyChanged(nameof(IsRollStatusChangePossible));
        }

        private void SwitchToManualEnterMode()
        {
            IsManualEnterMode = true;
            SetPropertyChanged(nameof(IsRollStatusChangePossible));
        }

        public ICommand SwitchToRollModeCommand { get; set; }

        public ICommand SwitchToManualEnterModeCommand { get; set; }

        public List<CharacteristicViewModel> Characteristics
        {
            get
            {
                return _characteristics;
            }
            set
            {
                _characteristics = value;
                SetPropertyChanged(nameof(Characteristics));
            }
        }

        public Characteristics CharacteristicsModel
        {
            get
            {
                return _characteristicsModel;
            }
            set
            {
                _characteristicsModel = value;
                SetPropertyChanged(nameof(CharacteristicsModel));
            }
        }

        public bool IsManualEnterMode
        {
            get { return _isManualEnterMode; }
            set
            {
                _isManualEnterMode = value;
                SetPropertyChanged(nameof(IsManualEnterMode));
            }
        }

        public bool IsRollMode
        {
            get { return _isRollMode; }
            set
            {
                _isRollMode = value;
                SetPropertyChanged(nameof(IsRollMode));
            }
        }

        public bool IsRollStatusChangePossible
        {
            get { return !IsRollMode && !IsManualEnterMode; }
        }

        public bool HaveReroll 
        {
            get { return _haveReroll; }
            set
            {
                _haveReroll = value;
                SetPropertyChanged(nameof(HaveReroll));
            }
        }

        public bool ShowReroll
        {
            get 
            {
                if (Characteristics.Where(x => x.CanRoll).Count() != 0)
                {
                    return false;
                }
                else if (!HaveReroll)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}

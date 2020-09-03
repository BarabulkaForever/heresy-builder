using HeresyBuilder.Enums;
using HeresyBuilder.Implementations;
using HeresyBuilder.Models;
using HeresyBuilder.Singleton;
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

        public bool Valid
        {
            get 
            {
                return Characteristics.Where(x => x.CharacteristicValue > 22 && x.CharacteristicValue <= 40).Count() > 0;
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

        public void SaveCharacteristics()
        {
            CurrentCharacterCreationData.Instance.Characteristics = new Characteristics();

            Characteristics.ForEach(x => 
            {
                if (x.Characteristic == Characteristic.WeaponSkill)
                {
                    CurrentCharacterCreationData.Instance.Characteristics.WeaponSkill = x.CharacteristicValue;
                }
                else if (x.Characteristic == Characteristic.BallisticSkill)
                {
                    CurrentCharacterCreationData.Instance.Characteristics.BallisticSkill = x.CharacteristicValue;
                }
                else if (x.Characteristic == Characteristic.Strength)
                {
                    CurrentCharacterCreationData.Instance.Characteristics.Strength = x.CharacteristicValue;
                }
                else if (x.Characteristic == Characteristic.Toughness)
                {
                    CurrentCharacterCreationData.Instance.Characteristics.Toughness = x.CharacteristicValue;
                }
                else if (x.Characteristic == Characteristic.Agility)
                {
                    CurrentCharacterCreationData.Instance.Characteristics.Agility = x.CharacteristicValue;
                }
                else if (x.Characteristic == Characteristic.Intelligence)
                {
                    CurrentCharacterCreationData.Instance.Characteristics.Intelligence = x.CharacteristicValue;
                }
                else if (x.Characteristic == Characteristic.Perception)
                {
                    CurrentCharacterCreationData.Instance.Characteristics.Perception = x.CharacteristicValue;
                }
                else if (x.Characteristic == Characteristic.Willpower)
                {
                    CurrentCharacterCreationData.Instance.Characteristics.Willpower = x.CharacteristicValue;
                }
                else if (x.Characteristic == Characteristic.Fellowship)
                {
                    CurrentCharacterCreationData.Instance.Characteristics.Fellowship = x.CharacteristicValue;
                }
                else if (x.Characteristic == Characteristic.Influence)
                {
                    CurrentCharacterCreationData.Instance.Characteristics.Influence = x.CharacteristicValue;
                }
            });
        }
    }
}

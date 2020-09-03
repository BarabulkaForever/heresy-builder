using HeresyBuilder.Enums;
using HeresyBuilder.Extensions;
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
    public class CharacteristicViewModel : BaseViewModel
    {
        private Characteristic characteristic;
        private CharacteristicsViewModel parrent;

        private int characteristicValue;
        private bool _canRoll = true;

        public CharacteristicViewModel(Characteristic characteristic, CharacteristicsViewModel parrent)
        {
            this.characteristic = characteristic;
            this.parrent = parrent;
            RollCommand = new CustomCommand(_ => Roll());
            RerollCommand = new CustomCommand(_ => Reroll());
            parrent.PropertyChanged += ParrentPropertyChanged;
        }

        private void ParrentPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(parrent.IsRollMode) || e.PropertyName == nameof(parrent.IsManualEnterMode))
            {
                SetPropertyChanged(nameof(IsManualEnterMode));
                SetPropertyChanged(nameof(IsRollMode));
            }
            else if (e.PropertyName == nameof(parrent.HaveReroll)) 
            {
                SetPropertyChanged(nameof(HaveReroll));
                SetPropertyChanged(nameof(ShowReroll));
            }
            else if (e.PropertyName == nameof(parrent.ShowReroll)) 
            {
                SetPropertyChanged(nameof(ShowReroll));
            }
        }

        public ICommand RollCommand { get; set; }
        public ICommand RerollCommand { get; set; }

        private void Reroll()
        {
            parrent.HaveReroll = false;
            Roll();
        }

        private void Roll()
        {
            var random = new Random();
            var world = CurrentCharacterCreationData.Instance.World;
            if (world.ModifierOne == Name || world.ModifierTwo == Name)
            {
                var intList = new List<int>() 
                {
                    random.Next(1, 10),
                    random.Next(1, 10),
                    random.Next(1, 10)
                };
                intList.Sort();
                CharacteristicValue = intList[1] + intList[2] + 20;
            }
            else if (world.ModifierNegative == Name)
            {
                var intList = new List<int>()
                {
                    random.Next(1, 10),
                    random.Next(1, 10),
                    random.Next(1, 10)
                };
                intList.Sort();
                CharacteristicValue = intList[0] + intList[1] + 20;
            }
            else
            {
                CharacteristicValue = 20 + random.Next(1, 10) + random.Next(1, 10);
            }
            CanRoll = false;
            parrent.SetPropertyChanged(nameof(parrent.ShowReroll));
        }

        public bool IsManualEnterMode
        {
            get { return parrent.IsManualEnterMode; }
        }

        public bool IsRollMode
        {
            get { return parrent.IsRollMode; }
        }

        public string Name 
        {
            get
            {
                return characteristic.ToString().SplitCamelCase();
            }
        }

        public Characteristic Characteristic
        {
            get
            {
                return characteristic;
            }
        }

        public int CharacteristicValue
        {
            get
            {
                return characteristicValue;
            }
            set
            {
                characteristicValue = value;
                SetPropertyChanged(nameof(CharacteristicValue));
            }
        }

        public string Description
        {
            get
            {
                return characteristic.GetDescription();
            }
        }

        public bool CanRoll
        {
            get 
            {
                return _canRoll; 
            }
            set
            {
                _canRoll = value;
                SetPropertyChanged(nameof(CanRoll));
            }
        }

        public bool HaveReroll 
        {
            get 
            {
                if (CanRoll)
                {
                    return false;
                }
                return parrent.HaveReroll; 
            }
        }

        public bool ShowReroll
        {
            get 
            {
                if (CanRoll)
                {
                    return false;
                }
                return parrent.ShowReroll; 
            }
        }
    }
}

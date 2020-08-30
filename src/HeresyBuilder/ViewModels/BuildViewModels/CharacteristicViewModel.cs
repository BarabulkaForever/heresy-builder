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

        public CharacteristicViewModel(Characteristic characteristic, CharacteristicsViewModel parrent)
        {
            this.characteristic = characteristic;
            this.parrent = parrent;
            RollCommand = new CustomCommand(_ => Roll());
        }

        public ICommand RollCommand { get; set; }

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
        }

        public string Name 
        {
            get
            {
                return characteristic.ToString().SplitCamelCase();
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
    }
}

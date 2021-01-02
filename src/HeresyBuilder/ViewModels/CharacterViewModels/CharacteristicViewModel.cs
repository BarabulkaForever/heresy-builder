using HeresyBuilder.Enums;
using HeresyBuilder.Extensions;
using HeresyBuilder.Models;
using HeresyBuilder.ViewModels.DialogViewMoldels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.ViewModels.CharacterViewModels
{
    public class CharacteristicViewModel : BaseViewModel
    {
        private CharacteristicAdvancementViewModel _parrent;

        private CharacteristicModel _characteristic;

        public CharacteristicViewModel(CharacteristicModel characteristic, CharacteristicAdvancementViewModel parrent = null)
        {
            _parrent = parrent;
            _characteristic = characteristic;
        }

        public string Name
        {
            get
            {
                return _characteristic.CharacteristicType.GetShortName();
            }
        }

        public Enums.Characteristic CharacteristicType
        {
            get
            {
                return _characteristic.CharacteristicType;
            }
        }

        public int Level
        {
            get
            {
                return (int)_characteristic.CharacteristicLevel;
            }
            set
            {
                _characteristic.CharacteristicLevel = (CharacteristicLevel)value;
                SetPropertyChanged(nameof(Level));
            }
        }

        public int Value
        {
            get
            {
                return (int)_characteristic.Value;
            }
            set
            {
                _characteristic.Value = value;
                SetPropertyChanged(nameof(Value));
            }
        }

        public CharacteristicAdvancementViewModel Parrent
        {
            get
            {
                return _parrent;
            }
        }
    }
}

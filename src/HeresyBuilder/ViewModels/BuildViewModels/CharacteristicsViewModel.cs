using HeresyBuilder.Enums;
using HeresyBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.ViewModels.BuildViewModels
{
    public class CharacteristicsViewModel : BaseViewModel
    {
        private List<CharacteristicViewModel> _characteristics;
        private Characteristics _characteristicsModel;
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
        }

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
    }
}

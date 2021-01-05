using HeresyBuilder.ViewModels.BuildViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.ViewModels.DialogViewMoldels
{
    public class ApptitudesPickerViewModel : BaseViewModel
    {
        public List<AptitudeForDuplicatePickerViewModel> _aptitudes;

        private AptitudesViewModel _parrent;

        public ApptitudesPickerViewModel(AptitudesViewModel parrent)
        {
            _parrent = parrent;
            Init();
        }

        private void Init()
        {
            Aptitudes = new List<AptitudeForDuplicatePickerViewModel>();

            var parrentApptitudes = _parrent.GetApptitudes();

            var characteristicApptitudes = new List<string>
            {
                "Weapon Skill",
                "Ballistic Skill",
                "Strength",
                "Toughness",
                "Agility",                
                "Intelligence",                
                "Perception",                
                "Willpower",                
                "Fellowship"
            };

            characteristicApptitudes = characteristicApptitudes.Where(x => !parrentApptitudes.Contains(x)).ToList();
            
            var duplicates = parrentApptitudes.GroupBy(x => x)
              .Where(g => g.Count() > 1)
              .Select(y => new { Element = y.Key, Counter = y.Count() })
              .ToList();

            foreach (var item in duplicates)
            {
                for (int i = 0; i < item.Counter - 1; i++)
                {
                    Aptitudes.Add(new AptitudeForDuplicatePickerViewModel(item.Element, characteristicApptitudes));
                }
            }
        }

        public List<AptitudeForDuplicatePickerViewModel> Aptitudes
        {
            get
            {
                return _aptitudes;
            }
            set
            {
                _aptitudes = value;
                SetPropertyChanged(nameof(Aptitudes));
            }
        }
    }
}

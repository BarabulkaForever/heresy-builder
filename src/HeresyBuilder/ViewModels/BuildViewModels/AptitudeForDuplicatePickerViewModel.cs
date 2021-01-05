using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.ViewModels.BuildViewModels
{
    public class AptitudeForDuplicatePickerViewModel : AptitudeViewModel
    {
        private string _duplicatedAptitude;
        public AptitudeForDuplicatePickerViewModel(string duplicatedAptitude, string aptitude) : base (aptitude)
        {
            DuplicatedAptitude = duplicatedAptitude;
        }

        public AptitudeForDuplicatePickerViewModel(string duplicatedAptitude, List<string> aptitudes) : base(aptitudes)
        {
            DuplicatedAptitude = duplicatedAptitude;
        }

        public string DuplicatedAptitude
        {
            get
            {
                return _duplicatedAptitude;
            }
            set
            {
                _duplicatedAptitude = value;
                SetPropertyChanged(nameof(Aptitude));
            }
        }

    }
}

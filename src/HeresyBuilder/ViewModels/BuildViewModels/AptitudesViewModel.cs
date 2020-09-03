using HeresyBuilder.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.ViewModels.BuildViewModels
{
    
    public class AptitudesViewModel : BaseViewModel
    {
        public List<AptitudeViewModel> _aptitudes;
        public AptitudesViewModel()
        {
            Init();
        }

        private void Init()
        {
            Aptitudes = new List<AptitudeViewModel>();
            Aptitudes.Add(new AptitudeViewModel(CurrentCharacterCreationData.Instance.World.Aptitude));

            foreach (var backgroundAptitude in CurrentCharacterCreationData.Instance.Background.BackgroundAptitude)
            {
                Aptitudes.Add(new AptitudeViewModel(backgroundAptitude));
            }

            foreach (var backgroundAptitudes in CurrentCharacterCreationData.Instance.Background.BackgroundAptitudeToPick)
            {
                Aptitudes.Add(new AptitudeViewModel(backgroundAptitudes));
            }

            foreach (var roleAptitude in CurrentCharacterCreationData.Instance.Role.RoleAptitude)
            {
                Aptitudes.Add(new AptitudeViewModel(roleAptitude));
            }

            foreach (var roleAptitudes in CurrentCharacterCreationData.Instance.Role.RoleAptitudeToPick)
            {
                Aptitudes.Add(new AptitudeViewModel(roleAptitudes));
            }
        }

        public List<AptitudeViewModel> Aptitudes
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

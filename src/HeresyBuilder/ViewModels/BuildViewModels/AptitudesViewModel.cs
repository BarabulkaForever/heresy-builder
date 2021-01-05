using HeresyBuilder.Singleton;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.ViewModels.BuildViewModels
{
    
    public class AptitudesViewModel : BaseViewModel
    {
        public ObservableCollection<AptitudeViewModel> _aptitudes;
        public AptitudesViewModel()
        {
            Init();
        }

        private void Init()
        {
            Aptitudes = new ObservableCollection<AptitudeViewModel>();
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

        public ObservableCollection<AptitudeViewModel> Aptitudes
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

        public bool Valid
        {
            get
            {
                return Aptitudes.Where(x => string.IsNullOrEmpty(x.Aptitude)).Count() == 0;
            }
        }
        public bool HasDuplicates
        {
            get
            {
                return Aptitudes.GroupBy(x => x.Aptitude).Where(g => g.Count() > 1).Select(y => y.Key).ToList().Count > 0;
            }
        }

        public List<string> GetApptitudes()
        {
            return Aptitudes.Select(x => x.Aptitude).ToList();
        }

        public void ChangeDuplicatedApptitudes(List<AptitudeViewModel> apptitudes)
        {
            var oldApptitudesWithoutDuplicates = Aptitudes.GroupBy(x => x.Aptitude).Select(x => x.First()).ToList();
            oldApptitudesWithoutDuplicates.ForEach(x => x.Aptitudes = new List<string>());
            apptitudes.AddRange(oldApptitudesWithoutDuplicates);
            Aptitudes.Clear();
            apptitudes.ForEach(x => Aptitudes.Add(x));
            SetPropertyChanged(nameof(Aptitudes));
        }

        public void SaveAptitudes()
        {
            if (Valid)
            {
                CurrentCharacterCreationData.Instance.Aptitudes = Aptitudes.Select(x => x.Aptitude).ToList();
            }
        }
    }
}

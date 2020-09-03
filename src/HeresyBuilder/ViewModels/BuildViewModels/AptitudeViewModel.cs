using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.ViewModels.BuildViewModels
{
    public class AptitudeViewModel : BaseViewModel
    {
        private string _aptitude;
        private List<string> _aptitudes;

        public AptitudeViewModel(string aptitude)
        {
            Init();
            Aptitude = aptitude;
        }

        public AptitudeViewModel(List<string> aptitudes)
        {
            Init();
            Aptitudes = aptitudes;
        }

        private void Init() 
        {
            Aptitudes = new List<string>();
        }

        public string Aptitude 
        {
            get
            {
                return _aptitude;
            }
            set
            {
                _aptitude = value;
                SetPropertyChanged(nameof(Aptitude));
            }
        }

        public List<string> Aptitudes 
        {
            get
            {
                return _aptitudes;
            }
            set
            {
                _aptitudes = value;
                SetPropertyChanged(nameof(Aptitudes));
                SetPropertyChanged(nameof(IsAptitudesToSellect));
                SetPropertyChanged(nameof(IsAptitudesToShow));
            }
        }

        public bool IsAptitudesToSellect
        {
            get
            {
                return Aptitudes.Count > 0;
            }
        }

        public bool IsAptitudesToShow
        {
            get
            {
                return Aptitudes.Count == 0;
            }
        }
    }
}

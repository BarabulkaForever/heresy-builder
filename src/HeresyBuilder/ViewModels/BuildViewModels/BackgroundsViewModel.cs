using HeresyBuilder.Models;
using HeresyBuilder.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.ViewModels.BuildViewModels
{
    public class BackgroundsViewModel : BaseViewModel
    {

        private FileAccessService _fileAccessService;
        private ObservableCollection<Background> _backgrounds;
        private Background _background;

        public BackgroundsViewModel()
        {
            _fileAccessService = new FileAccessService();
            Init();
        }

        private void Init()
        {
            Backgrounds = new ObservableCollection<Background>(_fileAccessService.GetBackgrounds());
            Background = Backgrounds.FirstOrDefault();
        }

        public ObservableCollection<Background> Backgrounds
        {
            get
            {
                return _backgrounds;
            }
            set
            {
                _backgrounds = value;
                SetPropertyChanged(nameof(Backgrounds));
            }
        }

        public Background Background
        {
            get
            {
                return _background;
            }
            set
            {
                _background = value;
                SetPropertyChanged(nameof(Background));
            }
        }
    }
}

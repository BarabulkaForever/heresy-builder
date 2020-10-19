using HeresyBuilder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.ViewModels.DialogViewMoldels
{
    public class LoadCharacterDialogViewModel : BaseViewModel
    {
        private List<string> _characters;
        private string _sellectedCharacter;

        public LoadCharacterDialogViewModel()
        {
            Init();
        }

        private void Init()
        {
            var fileAccessService = new FileAccessService();
            Characters = fileAccessService.LoadCharacters();
        }

        public List<string> Characters 
        {
            get
            {
                return _characters;
            }
            set
            {
                _characters = value;
                SetPropertyChanged(nameof(Characters));
            }
        }

        public string SellectedCharacter
        {
            get
            {
                return _sellectedCharacter;
            }
            set
            {
                _sellectedCharacter = value;
                SetPropertyChanged(nameof(SellectedCharacter));
                SetPropertyChanged(nameof(CanAccept));
            }
        }

        public bool CanAccept
        {
            get { return !string.IsNullOrWhiteSpace(SellectedCharacter); }
        }
    }
}

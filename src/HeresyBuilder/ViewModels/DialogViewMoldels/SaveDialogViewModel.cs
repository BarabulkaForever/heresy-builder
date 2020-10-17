using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.ViewModels.DialogViewMoldels
{
    public class SaveDialogViewModel : BaseViewModel
    {
        private string _name;

        public SaveDialogViewModel()
        {
            Init();
        }

        private void Init()
        {

        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                SetPropertyChanged(nameof(Name));
                SetPropertyChanged(nameof(CanAccept));
            }
        }

        public bool CanAccept
        {
            get { return !string.IsNullOrWhiteSpace(_name); }
        }
    }
}

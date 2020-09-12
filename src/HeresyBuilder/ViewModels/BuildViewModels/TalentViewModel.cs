using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.ViewModels.BuildViewModels
{
    public class TalentViewModel : BaseViewModel
    {
        private string _talent;
        private List<string> _talents;

        public TalentViewModel(string talent)
        {
            Init();
            Talent = talent;
        }

        public TalentViewModel(List<string> talents)
        {
            Init();
            Talents = talents;
        }

        private void Init()
        {
            Talents = new List<string>();
        }

        public string Talent
        {
            get
            {
                return _talent;
            }
            set
            {
                _talent = value;
                SetPropertyChanged(nameof(Talent));
            }
        }

        public List<string> Talents
        {
            get
            {
                return _talents;
            }
            set
            {
                _talents = value;
                SetPropertyChanged(nameof(Talents));
                SetPropertyChanged(nameof(IsTalentsToSellect));
                SetPropertyChanged(nameof(IsTalentsToShow));
            }
        }

        public bool IsTalentsToSellect
        {
            get
            {
                return Talents.Count > 0;
            }
        }

        public bool IsTalentsToShow
        {
            get
            {
                return Talents.Count == 0;
            }
        }
    }
}

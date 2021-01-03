using HeresyBuilder.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.ViewModels.BuildViewModels
{
    public class TalentsViewModel : BaseViewModel
    {
        public List<TalentViewModel> _talents;
        public TalentsViewModel()
        {
            Init();
        }

        private void Init()
        {
            Talents = new List<TalentViewModel>();
            
            foreach (var backgroundTalent in CurrentCharacterCreationData.Instance.Background.StartingTalents)
            {
                Talents.Add(new TalentViewModel(backgroundTalent));
            }

            foreach (var backgroundTalents in CurrentCharacterCreationData.Instance.Background.StartingTalentsToPick)
            {
                Talents.Add(new TalentViewModel(backgroundTalents));
            }

            foreach (var roleTalent in CurrentCharacterCreationData.Instance.Role.RoleTalent)
            {
                Talents.Add(new TalentViewModel(roleTalent));
            }

            foreach (var roleTalents in CurrentCharacterCreationData.Instance.Role.RoleTalentToPick)
            {
                Talents.Add(new TalentViewModel(roleTalents));
            }
        }

        public List<TalentViewModel> Talents
        {
            get
            {
                return _talents;
            }
            set
            {
                _talents = value;
                SetPropertyChanged(nameof(Talents));
            }
        }
        
        public bool Valid
        {
            get
            {
                return Talents.Where(x => string.IsNullOrEmpty(x.Talent)).Count() == 0;
            }
        }

        public void SaveTalentsAndTraits()
        {
            if (Valid)
            {
                CurrentCharacterCreationData.Instance.Talents = Talents.Select(x => x.Talent).ToList();

                var traits = new List<string>();

                if (CurrentCharacterCreationData.Instance.Background.StartingTrait != null)
                {
                    foreach(var trait in CurrentCharacterCreationData.Instance.Background.StartingTrait)
                    {
                        traits.Add(trait);
                    }
                }
 
                CurrentCharacterCreationData.Instance.Traits = traits;
            }
        }
    }
}

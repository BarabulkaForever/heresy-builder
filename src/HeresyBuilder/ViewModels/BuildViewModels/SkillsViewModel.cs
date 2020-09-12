using HeresyBuilder.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.ViewModels.BuildViewModels
{
    public class SkillsViewModel : BaseViewModel
    {
        private List<SkillViewModel> _skills;

        public SkillsViewModel()
        {
            Init();
        }

        private void Init()
        {
            Skills = new List<SkillViewModel>();

            foreach (var backgroundEquipment in CurrentCharacterCreationData.Instance.Background.StartingSkills)
            {
                Skills.Add(new SkillViewModel(backgroundEquipment));
            }

            foreach (var backgroundEquipments in CurrentCharacterCreationData.Instance.Background.StartingSkillsToPick)
            {
                Skills.Add(new SkillViewModel(backgroundEquipments));
            }
        }

        public List<SkillViewModel> Skills
        {
            get
            {
                return _skills;
            }
            private set
            {
                _skills = value;
                SetPropertyChanged(nameof(Skills));
            }
        }

        public bool Valid
        {
            get
            {
                return Skills.Where(x => string.IsNullOrEmpty(x.Skill)).Count() == 0;
            }
        }

        public void SaveTalents()
        {
            if (Valid)
            {
                CurrentCharacterCreationData.Instance.Items = Skills.Select(x => x.Skill).ToList();
            }
        }
    }
}

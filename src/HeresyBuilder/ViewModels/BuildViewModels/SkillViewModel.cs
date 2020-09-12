using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.ViewModels.BuildViewModels
{
    public class SkillViewModel : BaseViewModel
    {
        private string _skill;
        private List<string> _skills;

        public SkillViewModel(string skill)
        {
            Init();
            Skill = skill;
        }

        public SkillViewModel(List<string> skills)
        {
            Init();
            Skills = skills;
        }

        private void Init()
        {
            Skills = new List<string>();
        }

        public string Skill
        {
            get
            {
                return _skill;
            }
            set
            {
                _skill = value;
                SetPropertyChanged(nameof(Skill));
            }
        }

        public List<string> Skills
        {
            get
            {
                return _skills;
            }
            set
            {
                _skills = value;
                SetPropertyChanged(nameof(Skills));
                SetPropertyChanged(nameof(IsSkillsToSellect));
                SetPropertyChanged(nameof(IsSkillsToShow));
            }
        }

        public bool IsSkillsToSellect
        {
            get
            {
                return Skills.Count > 0;
            }
        }

        public bool IsSkillsToShow
        {
            get
            {
                return Skills.Count == 0;
            }
        }
    }
}

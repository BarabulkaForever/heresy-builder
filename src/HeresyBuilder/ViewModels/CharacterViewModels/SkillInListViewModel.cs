using HeresyBuilder.Enums;
using HeresyBuilder.Models;
using HeresyBuilder.ViewModels.DialogViewMoldels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.ViewModels.CharacterViewModels
{
    public class SkillInListViewModel : BaseViewModel
    {
        private SkillsAdvancementViewModel _parrent;

        private Skill _skill;

        public SkillInListViewModel(SkillsAdvancementViewModel parrent, Skill skill)
        {
            _parrent = parrent;
            _skill = skill;
        }

        public string Name 
        {
            get
            {
                return _skill.Name;
            }
            set
            {
                _skill.Name = value;
                SetPropertyChanged(nameof(Name));
            }
        }

        public int Level 
        {
            get
            {
                return (int) _skill.Level;
            }
            set
            {
                _skill.Level = (SkillLevel)value;
                SetPropertyChanged(nameof(Level));
            }
        }

        public SkillsAdvancementViewModel Parrent
        {
            get
            {
                return _parrent;
            }
        }
    }
}

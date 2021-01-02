using HeresyBuilder.Models;
using HeresyBuilder.Services;
using HeresyBuilder.Singleton;
using HeresyBuilder.ViewModels.CharacterViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.ViewModels.DialogViewMoldels
{
    public class CharacteristicAdvancementViewModel : BaseViewModel
    {
        public Character Character { get; set; }
        private FileAccessService _fileAccessService;
        private int _XPToSpend;
        private int _spendedXP;

        public CharacteristicAdvancementViewModel()
        {
            _fileAccessService = new FileAccessService();
            Init();
        }

        private void Init()
        {
            Character = CurrentCharacterData.Instance.Character.Clone();

            XPToSpend = Character.XPToSpend;
        }

        #region XP

        public int XPToSpend
        {
            get
            {
                return _XPToSpend;
            }
            set
            {
                _XPToSpend = value;
                SetPropertyChanged(nameof(XPToSpend));
                SetPropertyChanged(nameof(XPToSpendText));
            }
        }

        public string XPToSpendText
        {
            get
            {
                return "You have " + _XPToSpend + " XP left";
            }
        }

        public void SpendXP(int xp)
        {
            _XPToSpend -= xp;
            _spendedXP += xp;
            SetPropertyChanged(nameof(XPToSpend));
            SetPropertyChanged(nameof(XPToSpendText));
        }

        public int SpendedXP
        {
            get
            {
                return _spendedXP;
            }
        }

        public bool CanSpendXP(int xp)
        {
            return XPToSpend >= xp;
        }

        #endregion
        #region Characteristics

        public CharacteristicViewModel WeaponSkill
        {
            get
            {
                return new CharacteristicViewModel(Character.Characteristics.WeaponSkill, this);
            }
        }

        public CharacteristicViewModel BallisticSkill
        {
            get
            {
                return new CharacteristicViewModel(Character.Characteristics.BallisticSkill, this);
            }
        }

        public CharacteristicViewModel Strength
        {
            get
            {
                return new CharacteristicViewModel(Character.Characteristics.Strength, this);
            }
        }

        public CharacteristicViewModel Toughness
        {
            get
            {
                return new CharacteristicViewModel(Character.Characteristics.Toughness, this);
            }
        }

        public CharacteristicViewModel Agility
        {
            get
            {
                return new CharacteristicViewModel(Character.Characteristics.Agility, this);
            }
        }

        public CharacteristicViewModel Intelligence
        {
            get
            {
                return new CharacteristicViewModel(Character.Characteristics.Intelligence, this);
            }
        }

        public CharacteristicViewModel Perception
        {
            get
            {
                return new CharacteristicViewModel(Character.Characteristics.Perception, this);
            }
        }

        public CharacteristicViewModel Willpower
        {
            get
            {
                return new CharacteristicViewModel(Character.Characteristics.Willpower, this);
            }
        }

        public CharacteristicViewModel Fellowship
        {
            get
            {
                return new CharacteristicViewModel(Character.Characteristics.Fellowship, this);
            }
        }

        public CharacteristicViewModel Influence
        {
            get
            {
                return new CharacteristicViewModel(Character.Characteristics.Influence, this);
            }
        }
        #endregion

    }
}

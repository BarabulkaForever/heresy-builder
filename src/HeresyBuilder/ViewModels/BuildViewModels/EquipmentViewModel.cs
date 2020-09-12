using HeresyBuilder.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.ViewModels.BuildViewModels
{
    public class EquipmentViewModel : BaseViewModel
    {
        private List<ItemViewModel> _items;

        public EquipmentViewModel()
        {
            Init();
        }

        private void Init()
        {
            Items = new List<ItemViewModel>();

            foreach (var backgroundEquipment in CurrentCharacterCreationData.Instance.Background.StartingEquipment)
            {
                Items.Add(new ItemViewModel(backgroundEquipment));
            }

            foreach (var backgroundEquipments in CurrentCharacterCreationData.Instance.Background.StartingEquipmentToPick)
            {
                Items.Add(new ItemViewModel(backgroundEquipments));
            }
        }

        public List<ItemViewModel> Items 
        {
            get 
            {
                return _items;
            }
            private set 
            {
                _items = value;
                SetPropertyChanged(nameof(Items));
            }
        }

        public bool Valid
        {
            get
            {
                return Items.Where(x => string.IsNullOrEmpty(x.Item)).Count() == 0;
            }
        }

        public void SaveItems()
        {
            if (Valid)
            {
                CurrentCharacterCreationData.Instance.Items = Items.Select(x => x.Item).ToList();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.ViewModels.BuildViewModels
{
    public class ItemViewModel : BaseViewModel
    {
        private string _item;
        private List<string> _items;

        public ItemViewModel(string item)
        {
            Init();
            Item = item;
        }

        public ItemViewModel(List<string> items)
        {
            Init();
            Items = items;
        }



        private void Init()
        {
            Items = new List<string>();
        }

        public string Item
        {
            get
            {
                return _item;
            }
            set
            {
                _item = value;
                SetPropertyChanged(nameof(Item));
            }
        }

        public List<string> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                SetPropertyChanged(nameof(Items));
                SetPropertyChanged(nameof(IsItemsToSellect));
                SetPropertyChanged(nameof(IsItemsToShow));
            }
        }

        public bool IsItemsToSellect
        {
            get
            {
                return Items.Count > 0;
            }
        }

        public bool IsItemsToShow
        {
            get
            {
                return Items.Count == 0;
            }
        }
    }
}

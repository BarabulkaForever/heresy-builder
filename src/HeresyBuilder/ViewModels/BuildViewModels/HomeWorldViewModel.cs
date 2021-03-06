﻿using HeresyBuilder.Models;
using HeresyBuilder.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.ViewModels.BuildViewModels
{
    public class HomeWorldViewModel : BaseViewModel
    {

        private FileAccessService _fileAccessService;
        private ObservableCollection<World> _homeworlds;
        private World _homeworld;

        public HomeWorldViewModel()
        {
            _fileAccessService = new FileAccessService();
            Init();
        }

        private void Init()
        {
            Homeworlds = new ObservableCollection<World>(_fileAccessService.GetHomeworlds());
            Homeworld = Homeworlds.FirstOrDefault();
        }

        public ObservableCollection<World> Homeworlds 
        {
            get
            {
                return _homeworlds;
            }
            set
            {
                _homeworlds = value;
                SetPropertyChanged(nameof(Homeworlds));
            }
        }

        public World Homeworld 
        {
            get
            {
                return _homeworld;
            }
            set
            {
                _homeworld = value;
                SetPropertyChanged(nameof(Homeworld));
            }
        }
    }
}

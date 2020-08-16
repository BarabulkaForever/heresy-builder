using HeresyBuilder.Models;
using HeresyBuilder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.ViewModels.BuildViewModels
{
    public class HomeWorldViewModel
    {

        private FileAccessService _fileAccessService;

        public HomeWorldViewModel()
        {
            _fileAccessService = new FileAccessService();
            Init();
        }

        private async Task Init()
        {
            Homeworlds = _fileAccessService.GetHomeworlds();
        }

        public List<World> Homeworlds { get; set; }

        public List<World> Homeworld { get; set; }
    }
}

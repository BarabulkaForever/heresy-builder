using HeresyBuilder.Models;
using HeresyBuilder.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.ViewModels.BuildViewModels
{
    public class RolesViewModel : BaseViewModel
    {

        private FileAccessService _fileAccessService;
        private ObservableCollection<Role> _roles;
        private Role _role;

        public RolesViewModel()
        {
            _fileAccessService = new FileAccessService();
            Init();
        }

        private void Init()
        {
            Roles = new ObservableCollection<Role>(_fileAccessService.GetRoles());
            Role = Roles.FirstOrDefault();
        }

        public ObservableCollection<Role> Roles
        {
            get
            {
                return _roles;
            }
            set
            {
                _roles = value;
                SetPropertyChanged(nameof(Roles));
            }
        }

        public Role Role
        {
            get
            {
                return _role;
            }
            set
            {
                _role = value;
                SetPropertyChanged(nameof(Role));
            }
        }
    }
}

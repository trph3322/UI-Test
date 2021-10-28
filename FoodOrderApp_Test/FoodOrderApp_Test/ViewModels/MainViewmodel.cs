using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FoodOrderApp_Test.Views.UserControls;

namespace FoodOrderApp_Test.ViewModels
{
    public class MainViewmodel : BaseViewModel
    {
        public ICommand LoadCommand { get; set; }

        public MainViewmodel()
        {
            LoadCommand = new RelayCommand<ControlBarUC>(parameter => true, parameter => load(parameter));
        }

        private void load(ControlBarUC mainWindow)
        {
            mainWindow.centerBar.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FoodOrderApp_Test.Models;
using FoodOrderApp_Test.Views.UserControls;

namespace FoodOrderApp_Test.ViewModels
{
    public class MainViewmodel : BaseViewModel
    {
        public ICommand LoadCommand { get; set; }

        public MainViewmodel()
        {
            LoadCommand = new RelayCommand<ControlBarUC>(parameter => true, parameter => Loaded(parameter));
         
        }

        private void Loaded(ControlBarUC cb)
        {
            cb.centerBar.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
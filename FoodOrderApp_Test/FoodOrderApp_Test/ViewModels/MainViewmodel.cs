using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOrderApp_Test.Views.UserControls;

namespace FoodOrderApp_Test.ViewModels
{
     
    public class MainViewmodel : BaseViewModel
    {
        public ControlBarUC cb;
        
        public MainViewmodel()
        {
            cb = new ControlBarUC();
            cb.centerBar.Visibility = System.Windows.Visibility.Visible;
        }
    }
}

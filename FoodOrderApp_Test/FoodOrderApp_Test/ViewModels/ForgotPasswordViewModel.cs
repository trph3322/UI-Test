using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using FoodOrderApp_Test.Views;
using FoodOrderApp_Test.Validations;
using System.Windows.Controls;
using System.Windows;
using FoodOrderApp_Test.Models;

namespace FoodOrderApp_Test.ViewModels
{
    class ForgotPasswordViewModel : BaseViewModel
    {
        public ICommand ChangePasswordCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand RePasswordChangedCommand { get; set; }


        private string mail;
        public string Mail { get => mail; set { mail = value; OnPropertyChanged(); } }

        
        private string code;
        public string Code { get => code; set { code = value; OnPropertyChanged(); } }

        private string password;
        public string Password { get => password; set { password = value; OnPropertyChanged(); } }

        private string rePassword;
        public string RePassword { get => rePassword; set { rePassword = value; OnPropertyChanged(); } }









        public ForgotPasswordViewModel()
        {
            ChangePasswordCommand = new RelayCommand<ForgotPasswordWindow>((parameter) => true, (parameter) => ChangePassword(parameter));
            PasswordChangedCommand = new RelayCommand<PasswordBox>((parameter) => { return true; }, (parameter) => { Password = parameter.Password; });
            RePasswordChangedCommand = new RelayCommand<PasswordBox>((parameter) => { return true; }, (parameter) => { RePassword = parameter.Password; });
        }
        public void ChangePassword (ForgotPasswordWindow parameter)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using FoodOrderApp_Test.Views;
using FoodOrderApp_Test.Validations;

namespace FoodOrderApp_Test.ViewModels
{
    internal class SignUpViewModel : MainViewmodel
    {
        public ICommand SignUpCommand { get; set; }

        private string userName;
        public string UserName { get => userName; set { userName = value; OnPropertyChanged(); } }

        private string mail;
        public string Mail { get => mail; set { mail = value; } }

        public SignUpViewModel()
        {
            SignUpCommand = new RelayCommand<SignUpWindow>((parameter) => true, (parameter) => SignUp(parameter));
        }

        public void SignUp(SignUpWindow parameter)
        {
            //isSignUp = false;
            if (string.IsNullOrEmpty(parameter.txtEmail.Text))
            {
                parameter.txtEmail.Focus();
                parameter.txtEmail.Text = "";
                return;
            }

            if (!parameter.txtEmail.Text.Contains("@gmail.com"))
            {
                //Object emailValidation = parameter.valid.ValidationRules as EmailValidation;
                //emailValidation.ErrorMessage = "Email k hop le";
                //emailValidation.Validate(parameter.txtEmail.Text, null);
                parameter.txtEmail.Focus();
                return;
            }
            // Check username
            if (string.IsNullOrEmpty(parameter.txtUsername.Text))
            {
                parameter.txtUsername.Focus();
                parameter.txtUsername.Text = "";
                return;
            }

            if (!Regex.IsMatch(parameter.txtUsername.Text, @"^[a-zA-Z0-9_]+$"))
            {
                parameter.txtUsername.Focus();
                return;
            }
        }
    }
}
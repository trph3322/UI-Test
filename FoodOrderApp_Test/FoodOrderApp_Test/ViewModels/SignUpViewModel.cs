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
    internal class SignUpViewModel : MainViewmodel
    {
        public ICommand SignUpCommand { get; set; }

        public ICommand PasswordChangedCommand { get; set; }
        public ICommand RePasswordChangedCommand { get; set; }

        

        private string mail;
        public string Mail { get => mail; set { mail = value; OnPropertyChanged(); } }

        private string phone;
        public string Phone { get => phone; set { phone = value; OnPropertyChanged(); } }
        
        private string userName;
        public string UserName { get => userName; set { userName = value; OnPropertyChanged(); } }

        private string password;
        public string Password { get => password; set { password = value; OnPropertyChanged(); } }
        
        private string rePassword;
        public string RePassword { get => rePassword; set { rePassword = value; OnPropertyChanged(); } }


        public SignUpViewModel()
        {
            SignUpCommand = new RelayCommand<SignUpWindow>((parameter) => true, (parameter) => SignUp(parameter));
            PasswordChangedCommand = new RelayCommand<PasswordBox>((parameter) => { return true; }, (parameter) => { Password = parameter.Password; });
            RePasswordChangedCommand = new RelayCommand<PasswordBox>((parameter) => { return true; }, (parameter) => { RePassword = parameter.Password; });
        }

        public void SignUp(SignUpWindow parameter)
        {
            
            /// Check Mail
            if (string.IsNullOrEmpty(parameter.txtMail.Text))
            {
                parameter.txtMail.Focus();
                parameter.txtMail.Text = "";
                return;
            }
            /// Check Mail exist
            int mailCount = DataManager.Ins.DP.USERS.Where(x => x.USER_EMAIL == Mail).Count();
            if (mailCount > 0)
            {
                parameter.txtMail.Focus();
                MessageBox.Show("Mail đã tồn tại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            //Check Phone
            if (string.IsNullOrEmpty(parameter.txtPhone.Text))
            {
                parameter.txtPhone.Focus();
                parameter.txtPhone.Text = "";
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
            // Check User exist
            int accCount = DataManager.Ins.DP.USERS.Where(x => x.USER_USERNAME == UserName).Count();
            if (accCount > 0)
            {
                parameter.txtUsername.Focus();
                MessageBox.Show("Tài khoản đã tồn tại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            //Check Password
            if (string.IsNullOrEmpty(parameter.PasswordBox.Password))
            {
                parameter.PasswordBox.Focus();
                parameter.PasswordBox.Password = "";
                return;
            }
            if (string.IsNullOrEmpty(parameter.RePasswordBox.Password))
            {
                parameter.RePasswordBox.Focus();
                parameter.RePasswordBox.Password = "";
                return;
            }

            if (Password != RePassword)
            {
                parameter.RePasswordBox.Focus();
                MessageBox.Show("Nhập lại mật khẩu không đúng!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
             {
                 DataManager.Ins.DP.USERS.Add(new USER() { USER_EMAIL = Mail, USER_PHONE = Phone, USER_USERNAME = UserName , USER_PASSWORD = Password , USER_TYPE = "user" });
                 DataManager.Ins.DP.SaveChanges();
                 MessageBox.Show("Đăng ký tài khoản thành công");
                parameter.Close();
             }
             catch
             {
                 MessageBox.Show("Lỗi cơ sở dữ liệu");
             }
        }
    }
}
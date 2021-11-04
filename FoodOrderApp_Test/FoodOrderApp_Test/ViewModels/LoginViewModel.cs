using FoodOrderApp_Test.Models;
using FoodOrderApp_Test.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace FoodOrderApp_Test.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        public ICommand OpenLogInWDCommand { get; set; }
        public ICommand OpenForgotPasswordWDCommand { get; set; }
        public ICommand OpenSignUpWDCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }


        private string password;
        public string Password { get => password; set { password = value; OnPropertyChanged(); } }
        private string userName;
        public string UserName { get => userName; set { userName = value; OnPropertyChanged(); } }
        private bool isLogin;
        public bool IsLogin { get => isLogin; set => isLogin = value; }

        public LoginViewModel()
        {
            
            Password = "";
            OpenLogInWDCommand = new RelayCommand<LoginWindow>((parameter) => { return true; }, (parameter) => Login(parameter));
            OpenForgotPasswordWDCommand = new RelayCommand<LoginWindow>((parameter) => { return true; }, (parameter) => OpenForgotPasswordWindow(parameter));
            OpenSignUpWDCommand = new RelayCommand<LoginWindow>((parameter) => { return true; }, (parameter) => OpenSignUpWindow(parameter));
            PasswordChangedCommand = new RelayCommand<PasswordBox>((parameter) => { return true; }, (parameter) => { Password = parameter.Password; });

        }

        public void Login(LoginWindow parameter)
        {
            
            try
            {
                
                isLogin = false;
                if (parameter == null)
                {
                    return;
                }
                if (string.IsNullOrEmpty(parameter.txtUsername.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    parameter.txtUsername.Focus();
                    return;
                }
                //check password
                if (string.IsNullOrEmpty(parameter.txtPassword.Password))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    parameter.txtPassword.Focus();
                    return;
                }
               
                //string passEncode = MD5Hash(Password)   ;
                int accCount = DataManager.Ins.DP.USERS.Where(x => x.USER_USERNAME == UserName && x.USER_PASSWORD == Password ).Count();
              
                if (accCount > 0)
                {
                    isLogin = true;
                    MainWindow app = new MainWindow();
                    app.ShowDialog();
                    parameter.txtPassword.Clear();
                }
                else
                {
                    isLogin = false;
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    parameter.txtPassword.Focus();
                }

            }
            catch
            {
                MessageBox.Show("lỗi");
            }
            

            



        }
        public string MD5Hash(string str)
        {
            StringBuilder hash = new StringBuilder();
            MD5 md5 = MD5.Create();
            byte[] bytes = md5.ComputeHash(new UTF8Encoding().GetBytes(str));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("X2"));
            }
            return hash.ToString();
        }

        public void OpenForgotPasswordWindow(LoginWindow parameter)
        {
            DoubleAnimation fadeIn = new DoubleAnimation(0.5, 1.0, new Duration(TimeSpan.FromSeconds(0.3)));
            
            ForgotPasswordWindow forgotPasswordWindow = new ForgotPasswordWindow();
            forgotPasswordWindow.BeginAnimation(Window.OpacityProperty, fadeIn);
            forgotPasswordWindow.ShowDialog();
        }

        public void OpenSignUpWindow(LoginWindow parameter)
        {
            DoubleAnimation fadeIn = new DoubleAnimation(0.5, 1.0, new Duration(TimeSpan.FromSeconds(0.3)));

            SignUpWindow signUpWindow = new SignUpWindow();
            signUpWindow.BeginAnimation(Window.OpacityProperty, fadeIn);
            signUpWindow.ShowDialog();
        }
    } 
}

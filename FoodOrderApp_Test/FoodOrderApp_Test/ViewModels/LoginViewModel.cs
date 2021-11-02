using FoodOrderApp_Test.Models;
using FoodOrderApp_Test.Views;
using FoodOrderApp_Test.DAL_tmp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

namespace FoodOrderApp_Test.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        public ICommand LogInCommand { get; set; }
        public ICommand SignUpCommand { get; set; }

        public ICommand PasswordChangedCommand { get; set; }

        List<Account> accounts = ListAccounts.Instance.Accounts;

        private string password;
        public string Password { get => password; set { password = value; OnPropertyChanged(); } }
        private string userName;
        public string UserName { get => userName; set { userName = value; OnPropertyChanged(); } }

        private bool isLogin;
        public bool IsLogin { get => isLogin; set => isLogin = value; }
        public LoginViewModel()
        {
            isLogin = false;
            UserName = "";
            Password = "";
            LogInCommand = new RelayCommand<LoginWindow>((parameter) => true, (parameter) => Login(parameter));
            SignUpCommand = new RelayCommand<LoginWindow>((parameter) => true, (parameter) => SignUp(parameter));

            PasswordChangedCommand = new RelayCommand<PasswordBox>((parameter) => true, (parameter) => { Password = parameter.Password; });
        }

        public void Login(LoginWindow parameter)
        {
            
            isLogin = false;
            if (parameter == null)
            {
                return;
            }
           
            //check username
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
            /*MessageBox.Show(accounts[0].Username + " va " + parameter.txtUsername.Text.ToString());
            MessageBox.Show(accounts[0].Password + " va " + password);
            for (int i = 0; i < accounts.Count; i++)
            {
                MessageBox.Show(accounts[i].Username + " va " + parameter.txtUsername.Text.ToString());
                MessageBox.Show(accounts[i].Password + " va " + parameter.txtPassword.ToString());
            }*/



            foreach (var account in accounts)
            {
                
                if (account.Username == parameter.txtUsername.Text.ToString() /*&& account.Password == password */&& account.Type != 3)
                {
                    /*CurrentAccount.Type = account.Type; // Kiểm tra quyền
                    if (CurrentAccount.Type != 0)
                    {
                        List<Employee> employees = EmployeeDAL.Instance.ConvertDBToList();
                        foreach (var employee in employees)
                        {
                            if (employee.IdAccount == account.IdAccount)
                            {
                                //Lấy thông tin người đăng nhập
                                CurrentAccount.DisplayName = employee.Name;
                                CurrentAccount.Image = employee.ImageFile;
                                CurrentAccount.IdEmployee = employee.IdEmployee;
                                this.employee = employee;
                                break;
                            }
                        }
                    }*/
                    /*CurrentAccount.IdAccount = account.IdAccount;
                    CurrentAccount.Password = password;*/
                    isLogin = true;
                    break;
                }
            }
            
            if (isLogin == true)
            {
                


                MainWindow main = new MainWindow();

                parameter.Hide();
                main.ShowDialog();
                parameter.txtPassword.Password = null;
                parameter.Show();
            }
            else
            {
                MessageBox.Show(accounts[0].Username + " va " + parameter.txtUsername.Text.ToString());
                MessageBox.Show(accounts[0].Password + " va " + password + " ");
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            

        }

        bool findAcc(string user, string pass)
        {
            for (int i = 0; i < accounts.Count; i++)
                if (user == accounts[i].Username &&
                    pass == accounts[i].Password)
                {
                    return true;
                }
            return false;
        }
        private void SignUp(LoginWindow parameter)
        {
            
            if (parameter == null)
            {
                return;
            }
            
            SignUpWindow signUp = new SignUpWindow();
            parameter.Hide();
            signUp.ShowDialog();
            parameter.txtPassword.Password = null;
            parameter.Show();
        }
        public void EncodingPassword(PasswordBox parameter)
        {
            this.password = parameter.Password;
        }

    }
}

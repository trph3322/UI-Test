using FoodOrderApp_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderApp_Test.DAL_tmp
{
    class ListAccounts
    {

        private static ListAccounts instance;
        internal static ListAccounts Instance
        {
            get
            {
                if (instance == null)
                    instance = new ListAccounts();
                return instance;
            }
            set => instance = value;
        }
        List<Account> accounts;

        internal List<Account> Accounts
        {
            get => accounts;
            set => accounts = value;
        }


        ListAccounts()
        {
            accounts = new List<Account>();
            accounts.Add(new Account(1,"admin", "1",1));
            accounts.Add(new Account(2,"admin2", "1",1));
            accounts.Add(new Account(3,"admin3", "1",1));
            accounts.Add(new Account(4,"admin4", "1",1));
        }
    }
}

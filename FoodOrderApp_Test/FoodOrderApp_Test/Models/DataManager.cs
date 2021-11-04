using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderApp_Test.Models
{
    public class DataManager
    {
        private static DataManager _ins;
        public static DataManager Ins 
        { 
            get 
            { 
                if (_ins == null) 
                    _ins = new DataManager(); 
                return _ins; 
            }
            set 
            { 
                _ins = value; 
            }
        }

        public OrderAppEntities2 DP { get; set; }
        private DataManager()
        {
            DP = new OrderAppEntities2();
        }
    }
}

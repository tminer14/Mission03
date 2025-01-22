using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission03
{
   
    public class FoodItem
    {
        //declare variables at the class level that will be used when creating object
        //make sure they are public so they can be used elsewhere!
        public string name = "";
        public string category = "";
        public int quantity = 0;
        public DateTime expDate = DateTime.Today;

        //create a constructor that is called every time an instance is created
        public FoodItem(string tempname, string tempcategory, int tempquantity, DateTime tempexpDate) {
            //assign the temporary variables to the class level variables 
            name = tempname;
            category = tempcategory;
            quantity = tempquantity;
            expDate = tempexpDate;

        }

    }
}

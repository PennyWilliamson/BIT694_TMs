using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIT694_TM1_3431274
{
    class Menu
    {
        Customer[] custData;//allows custData array to be used by methods in class.

        //Constructor for Menu, takes custData as its signature, so it can be passed in menu calls.
        public Menu(Customer[] custData)
        {
            this.custData = custData;//sets signatures custData to equal custData.
        }

        //Constructor with no argument to call Customer class methods.
        Customer r = new Customer();

        /*
         * Menu method that displays a list of options,
         * then calls the option entered by user. 
         * Uses switch statements in a while loop to achieve this.
         */
       public void DisplayMenu()
        {//menu that appears on Console screen.
            Console.WriteLine("------------------------------");
            Console.WriteLine("         Banking System        ");
            Console.WriteLine("------------------------------");
            Console.WriteLine(" ");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Check Max Balance");
            Console.WriteLine("4. Check Most Active Customer Account");
            Console.WriteLine("5. Check Youngest Customer");
            Console.WriteLine("6. Show Customers Born on Leap Year");
            Console.WriteLine(" ");
            Console.WriteLine("Select an Option: ");

            String option = "0";//declares and initialises option to 0.
            option = Console.ReadLine();//sets option to String value entered by user.
                                    
            while (option != "0")//fires so long as exit condition is not met.
            {
                switch(option)//used instead of if-else loops.
                {
                    case "0": //exit method.
                        Console.WriteLine("Press any key to exit");
                        Console.ReadKey();
                        break;//exits the switch statement
                    case "1"://specifies the pattern to be matched.
                        r.Deposit(custData);//Calls the Customer method Deposit().
                        Console.Clear();//Clears the console screen of menu.
                        DisplayMenu();//displays the menu again, once Deposit method has finished.
                        break;
                    case "2":
                        r.Withdraw(custData);//Calls the Customer method Withdraw().
                        Console.Clear();
                        DisplayMenu();
                        break;
                    case "3":
                        r.HighestBal(custData);//Calls the Customer method HighestBal().
                        Console.Clear();
                        DisplayMenu();
                        break;
                    case "4":
                        r.MostActive(custData);//Calls the Customer method MostActive().
                        Console.Clear();
                        DisplayMenu();
                        break;
                    case "5":
                       r. YoungestCustomer(custData);//Calls the Customer method YoungestCustomer().
                        Console.Clear();
                        DisplayMenu();
                        break;
                    case "6":
                        r.LeapYear(custData);//Calls the Customer method LeapYear
                        Console.Clear();
                        DisplayMenu();
                        break;
                    default://fires if no case patterns are matched.
                        {
                            Console.WriteLine("Please enter a number between 0 and 6. Press any key to continue...");
                            Console.ReadKey();
                            Console.Clear();
                            DisplayMenu();//Calls itself, to recover from error.
                            break;
                        }   
                }
                return;//ends while loop.
            }
        }
    }
}

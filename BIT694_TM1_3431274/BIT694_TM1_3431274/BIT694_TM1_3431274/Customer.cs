using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace BIT694_TM1_3431274
{
    class Customer
    {
        //protected so they can be inherited by VIPCustomer Class
        protected String firstName;//Declares variable to hold Customer and VIPCustomer firstName.
        protected String lastName;//Declares variable to hold Customer and VIPCustomer LastName.
        protected String dob;//Declares variable to hold Customer and VIPCustomer date of birth (dob).
        protected String accNum;//Declares variable to hold Customer and VIPCustomer account number (accNum).
        protected Double balance;//Declares variable to hold Customer and VIPCustomer balance.
        protected int tranCount;//Declares variable to hold Customer and VIPCustomer transaction count (tranCount). Set to zero in Class Program method, readingInputFile().
        private double fee = 3.00; //Declares and intailises variable for fee, so it only needs to be changes in one place.
        //Private as it is only used in class.
        Customer[] custData;//Allows Class methods to call and use array.

        //Contructor for Customer that takes in firstName, lastName, dob, accNum, balance and tranCount in its signature.
        public Customer(String firstName, String lastName, String dob, String accNum, double balance, int tranCount)
        {
            this.firstName = firstName;//sets firstName value in signature to firstName.
            this.lastName = lastName;//sets lastName value in signature to LastName.
            this.dob = dob;//sets dob value in signature to dob.
            this.accNum = accNum;//sets accNum value in signature to accNum.
            this.balance = balance;//sets balance value in signature to balance.
            this.tranCount = tranCount;//sets tranCount value in signature to tranCount.
        }
         //A blank constructor, takes no values in, in its signature.
        public Customer() { }

        //Constructor that takes custData array in as its signature.
        public Customer(Customer[] custData)
        {
            this.custData = custData;//sets custData value in signature to CustData.
        }

        //Allows firstName variable to be gotten and set.
        public String AccessFirstName
        {
            set { this.firstName = value; }
            get { return this.firstName; }
        }

        //Allows lastName variable to be gotten and set.
        public String AccessLastName
        {
            set { this.lastName = value; }
            get { return this.lastName; }
        }

        //Allows dob variable to be gotten and set.
        public String AccessDob
        {
            set { this.dob = value; }
            get { return this.dob; }
        }

        //Allows accNum variable to be gotten and set.
        public String AccessAccNum
        {
            set { this.accNum = value; }
            get { return this.accNum; }
        }

        //Allows balance variable to be gotten and set.
        public double AccessBalance
        {
            set { this.balance = value; }
            get { return this.balance; }
        }

        //Allows tranCount variable to be gotten and set.
        public int AccessTranCount
        {
            set { this.tranCount = value; }
            get { return this.tranCount; }
        }


        /*A helper method that displays a customer's basic information.
         * try catch is not being used for convert 
         * as the customer constructor that calls it 
         * requires dob to be in String format. This is caught
         * in the readingInputFile function in Main class.
         */
        protected virtual void DisplayInfo()//protected is the lowest access level that can be used for a virtual method.
        {
            
            DateTime aDob = Convert.ToDateTime(dob);
            String bDob = aDob.ToShortDateString();
            Console.WriteLine("Name: " + firstName + " " + lastName);
            Console.WriteLine("Date of birth: " +bDob);
            Console.WriteLine("Balance: " + balance.ToString("C"));
        }


        /*
         * Is called from Menu Class, by menu selection number 6.
         * Public so it can be called from Menu Class.
         * Takes in Customer[] custData array in method signature, so the
         * array can be used in the method.
         * Displays a list of all customers born in a leap year,
         * their basic information, customer type and star sign.
         * Calls private method IsLeapYear() to determine whether or not 
         * birth year is a leap year, and uses returned Boolean to trigger
         * the zodiac loop and displaying of basic information.
         */
        public void LeapYear(Customer[] custData)
        {
            Console.Clear();//Gives a console screen that only contains this methods output
            //header for Console page.
            Console.WriteLine("-------------------------------");
            Console.WriteLine("  Leap Years and Zodiac signs  ");
            Console.WriteLine("-------------------------------");
            try
            {
                for (int i = 0; i < custData.Length; i++)//iterates through custData array.
                {
                    Customer customer = custData[i];//Declares and sets a customer object to the custData object. Preserves whether or not they are VIP customers
                    this.firstName = customer.firstName;//sets first name variable to custData's value.
                    this.lastName = customer.lastName;//sets last name variable to custData's value.
                    this.dob = customer.dob;//sets dob variable to custData's value.
                    this.accNum = customer.accNum;//sets accNum variable to custData's value.
                    this.balance = customer.balance;//sets balance variable to custData's value.
                    this.tranCount = customer.tranCount;//sets tranCount variable to custData's value.
                    Customer s = new Customer(this.firstName, this.lastName, this.dob, this.accNum, this.balance, this.tranCount);
                    //Declares and initialises a new Customer object that uses the same values as CustData[i]. This is used to call isLeapYear method.

                    if (s.IsLeapYear())//triggered by Boolean returned from IsLeapYear() method. 
                    {
                        String[] year = dob.Split('-');//splits the String variable dob into its three date components, at the - character.
                        String zodiac = null;//Declares and initialises a String variable to hold a zodiac name. Set to null, so it holds no prior value.
                        int day = int.Parse(year[0]);//Declares and initialises an int variable by converting the day String into an int value.
                        int month = int.Parse(year[1]);//Declares and initialises an int variable by converting the month String into an int value.
                        //year is not needed for this method.
                        //if loops using day and month int variables to set the value of zodiac variable.
                        if ((month == 1) && (day < 20) || (month == 12) && (day > 21))//fires for dates December 22 to Jan 19
                        {
                            zodiac = "Capricorn";//sets zodiac variable to String value "Capricorn"
                        }

                        if ((month == 1) && (day > 19) || (month == 2) && (day < 19))//fires for dates Jan 20 to Feb 18
                        {
                            zodiac = "Aquarius";
                        }

                        if ((month == 2) && (day > 18) || (month == 3) && (day < 21))//fires for dates Feb 19 to Mar 20
                        {
                            zodiac = "Pisces";
                        }


                        if ((month == 3) && (day > 20) || (month == 4) && (day < 20))//fires for dates Mar 21 to April 19
                        {
                            zodiac = "Aries";
                        }

                        if ((month == 4) && (day > 19) || (month == 5) && (day < 21))//fires for dates April 20 to May 20
                        {
                            zodiac = "Taurus";
                        }

                        if ((month == 5) && (day > 20) || (month == 6) && (day < 21))//fires for dates May 21 to June 20
                        {
                            zodiac = "Gemini";
                        }

                        if ((month == 6) && (day > 20) || (month == 7) && (day < 23))//fires for dates June 21 to July 22
                        {
                            zodiac = "Cancer";
                        }

                        if ((month == 7) && (day > 22) || (month == 8) && (day < 23))//fires for dates July 23 to Aug 22
                        {
                            zodiac = "Leo";
                        }

                        if ((month == 8) && (day > 22) || (month == 9) && (day < 23))//fires for dates Aug 23 to Sep 22
                        {
                            zodiac = "Virgo";
                        }

                        if ((month == 9) && (day > 20) || (month == 10) && (day < 21))//fires for dates Sep 23 to Oct 22
                        {
                            zodiac = "Libra";
                        }

                        if ((month == 10) && (day > 22) || (month == 11) && (day < 22))//fires for dates Oct 23 to Nov 21
                        {
                            zodiac = "Scorpio";
                        }

                        if ((month == 11) && (day > 21) || (month == 12) && (day < 22))//fires for dates Nov 22 to Dec 21
                        {
                            zodiac = "Sagittarius";
                        }
                        custData[i].DisplayInfo();//uses the class specific DisplayInfo() method.
                        Console.WriteLine("Zodiac sign: " + zodiac);//uses the zodiac value set in the if loops.
                        Console.WriteLine(" ");//gives a blank line between customers on the console for readability.
                    }
                }
            }
            catch(FormatException ex)//catches Parse errors.
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        /*
         * Helper method called by LeapYear() method.
         * Determines whether or not the customer object
         * that is used to call it, is born in a leap year.
         * Returns Boolean which triggers zodiac loop 
         * in LeapYear method.
         * Only used within Customer class, hence private.
         */
        private Boolean IsLeapYear()
        {
            bool isLeap = false;
            try
            {
                String[] year = dob.Split('-');
                int dobYear = int.Parse(year[2]);//Declares and initilises an int value by converting the String year value into an int value.
                if ((dobYear % 4 == 0) && (dobYear % 100 != 0))//formula for calculating leap year, divisible by 4, but not by 100.
                {
                    isLeap = true;
                }
                else
                {
                    isLeap = false;                   
                }                
            }
            catch(FormatException ex)//Parse error
            {
                Console.WriteLine(ex);
            }
            return isLeap;// returns true or false to trigger if loop.
        }

        /*
         * Public method called from Menu Class, by
         * menu selection number 1, hence public access modifier.
         * Takes in Customer[] custData array in method signature
         * so array can be used within the method.
         * Calls DepositHelper() method in Customer class for Customer objects,
         * and in VIPCustomer class for VIPCustomer objects.
         * Iterates through array for account number, and calls that custData[i]
         * objects deposit helper method.
         * Then updates the balance value of the array with the new balance, and
         * updated transaction count (tranCount).
         */
        public void Deposit(Customer[] custData)
        {
            Console.Clear();//Gives a console screen that only contains output from this and depositHelper methods.
            bool contains = false;//triggers an error message if account number not found.
            //Console screen header.
            Console.WriteLine("-------------------------------");
            Console.WriteLine("            Deposit            ");
            Console.WriteLine("-------------------------------");
            try
            {
                Console.WriteLine("Enter accountID: ");
                String accountID = Console.ReadLine();//Declares a String that takes the value entered in response to the previous line.
                if (accountID == null)//checks that a value has been entered.
                {
                    Console.WriteLine("Please enter an account ID");
                }
                for (int i = 0; i < custData.Length; i++)//iterates through array looking for accNum matching accountID value, custData length number of times.
                {
                    Customer customer = custData[i];//see comments in LeapYear method.
                    this.firstName = customer.firstName;
                    this.lastName = customer.lastName;
                    this.dob = customer.dob;
                    this.accNum = customer.accNum;
                    this.balance = customer.balance;
                    this.tranCount = customer.tranCount;
                    Customer s = new Customer(this.firstName, this.lastName, this.dob, this.accNum, this.balance, this.tranCount);
                    if (accountID == accNum)//fires when custData[i] accNum value = entered accountID value.
                    {
                        custData[i] = custData[i].DepositHelper();
                        contains = true;//sets Boolean for account number found to true.
                    }
                }
            }
            catch(ArgumentOutOfRangeException exDep)//ReadLine error
            {
                Console.WriteLine(exDep);//This is not recovered from as it is a read error. Input errors are handled in method.
            }

            if (contains == false)//triggers error message if account number not found.
            {
                Console.WriteLine("Account ID invalid, press any key to try again");
                Console.ReadKey();
                Deposit(custData);//Recovers from error by recalling itself.
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
        
        /*
         * Helper method that handles class specific deposit
         * method. Charges a fee that is set in class variables,
         * for each deposit transaction.
         * Takes in and uses the values for the custData[i]
         * object that was used to call it.
         * Returns a Customer object to Customer Class's Deposit() method.
         * Protected as it is a virtual method, that is only used within class
         * and overridden in subclass.
         */
        protected virtual Customer DepositHelper()
        {
            Customer s = new Customer(this.firstName, this.lastName, this.dob, this.accNum, this.balance, this.tranCount);
            //Customer object set to the calling custData[i] objects values. 
            try
            {
                Console.WriteLine("Depositing into the account of " + firstName + " " + lastName + ". Current balance is: " + balance.ToString("C"));
                //displays calling Customer objects, first name, last name and current balance in $'s.
                Console.WriteLine("Enter amount to deposit: ");
                double amount = double.Parse(Console.ReadLine());
                //Declares a double variable and initialises it by converting String amount entered in response to previous lines code into a double value.
                if (amount < 0) // handles operator error of entering a negative number.
                {
                    Console.WriteLine("Please enter a non negative amount. Press any key to continue");
                    Console.ReadKey();
                    s.DepositHelper();//recovers from error by calling itself
                }
                else //allows the program to continue if number is non-negative, and after amount has been corrected.
                {
                    double aBalance = balance + amount - fee;//Declares and sets variable aBalance to amount entered by operator, plus fee set in class variables, plus the current balance.
                    Console.WriteLine("Success fully deposited " + amount.ToString("C") + ". Current balance: " + aBalance.ToString("C"));//displays amount entered, plus the new balance.
                    int aTranCount = tranCount + 1;//Declares an int variable to hold the increased by 1 value of tranCount.
                    Customer t = new Customer(this.firstName, this.lastName, this.dob, this.accNum, aBalance, aTranCount);
                    //a new Customer object with custData[i] objects name variables, dob, accNum and updated balance and tranCount variables.
                    s = t; //sets the values of the initial Customer object, s, to the values of the new Customer object, t.
                    //Allows the values for t to be called from outside the loop.
                }          
            }
            catch(ArgumentOutOfRangeException)//ReadLine error
            {
                Console.WriteLine("Please enter a valid amount. Press any key to continue");
                Console.ReadKey();
                s.DepositHelper();//Operator error, allows recovery.
            }
            catch(FormatException)//Parse error
            {
                Console.WriteLine("Please enter a valid amount. Press any key to continue");
                Console.ReadKey();
                s.DepositHelper();//Operator error, allows recovery.
            }
            return s; //returns the customer object with new balance and tranCount values.
        }

        /*
         * Public method called from Menu Class, by
         * menu selection number 2.
         * Takes in Customer[] custData array in method signature
         * so array can be used within the method.
         * Calls WithdrawHelper() method in Customer class for Customer objects,
         * and in VIPCustomer class for VIPCustomer objects.
         * Iterates through array for account number, and calls that custData[i]
         * objects WithdrawHelper() method.
         * Then updates the balance value of the array with the new balance, and
         * updated transaction count (tranCount).
         * See Deposit() method for comments and logic.
         */
        public void Withdraw(Customer[] custData)
        {
            Console.Clear();//See deposit method for comments and logic.
            bool contains = false;           
            Console.WriteLine("-------------------------------");
            Console.WriteLine("            Withdraw            ");
            Console.WriteLine("-------------------------------");
            try
            {
                Console.WriteLine("Enter accountID: ");
                String accountID = Console.ReadLine();
                if (accountID == null)
                {
                    Console.WriteLine("Please enter an account ID");
                }
                for (int i = 0; i < custData.Length; i++)
                {
                    Customer customer = custData[i];
                    this.firstName = customer.firstName;
                    this.lastName = customer.lastName;
                    this.dob = customer.dob;
                    this.accNum = customer.accNum;
                    this.balance = customer.balance;
                    this.tranCount = customer.tranCount;
                    Customer s = new Customer(this.firstName, this.lastName, this.dob, this.accNum, this.balance, this.tranCount);

                    if (accountID == accNum)
                    {
                        custData[i] = custData[i].WithdrawHelper();
                        contains = true;
                    }               
                    }
                }  
                      
            catch(ArgumentOutOfRangeException exWith)//ReadLine error
            {
                Console.WriteLine(exWith);//This is not recovered from as it is a read error. Input errors are handled in method.
            }

            if (contains == false)
            {
                Console.WriteLine("Account ID invalid, press any key to try again");
                Console.ReadKey();
                Withdraw(custData);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        /*
         * Helper method that handles class specific withdrawal
         * method. Charges a fee that is set in class variables,
         * for each withdraw transaction. Does not allow a withdrawal if 
         * amount (plus fee) to be withdrawn would take balance below $0.00.
         * Takes in and uses that values for the custData[i]
         * object that was used to call it.
         * Returns a Customer object to Customer Class's Withdraw() method.
         * Protected as it is a virtual method, that is only used within class
         * and overridden in subclass.
         * See method DepositHelper() for most comments and logic.
         */
        protected virtual Customer WithdrawHelper()
        {  
            bool successfull = false;//Declares and initialises to false, a Boolean for whether or not the transaction was successful (amount to be withdrawn is less than or equal to balance).
            Customer s = new Customer(this.firstName, this.lastName, this.dob, this.accNum, this.balance, this.tranCount);
            try
            {
                Console.WriteLine("Withdrawing from the account of " + firstName + " " + lastName + ". Current balance is: " + balance.ToString("C"));
                Console.WriteLine("Enter amount to withdraw: ");
                double amount = double.Parse(Console.ReadLine());
                if (amount < 0)//error handling for negative amounts.
                {
                    Console.WriteLine("Please enter a non-negative amount. Press any key to continue");
                    Console.ReadKey();
                    s.WithdrawHelper();
                }
                else//allows the program to continue with positive amounts.
                {
                    double totalAmount = amount + fee;//Declares a double variable and sets amount to be withdrawn to amount entered plus fee set in class variables.
                    if (totalAmount <= balance)//checks whether total amount to be withdrawn is less than or equal to current balance.
                    {
                        double aBalance = balance - totalAmount;//Declares and sets variable aBalance to current balance minus totalAmount to be withdrawn
                        int aTranCount = tranCount + 1;
                        Console.WriteLine("Successfully withdrew " + amount.ToString("C") + ". Current balance: " + aBalance.ToString("C"));
                        Customer t = new Customer(this.firstName, this.lastName, this.dob, this.accNum, aBalance, aTranCount);
                        successfull = true;
                        s = t;
                        return t;//returns customer object t, so that every code path returns a Customer object.
                    }

                    if (successfull == false)//fires if transaction was declined.
                    {
                        Console.WriteLine("Sorry, insufficient balance");
                        return s;//returns initial customer s, so that every code path returns a Customer object.
                    }
                }
            }
            catch(ArgumentOutOfRangeException)//ReadLine error
            {
                Console.WriteLine("Please enter a valid amount. Press any key to continue");
                Console.ReadKey();
                s.WithdrawHelper();//Operator error, allows program to recover.
            }
            catch(FormatException)//Parse error
            {
                Console.WriteLine("Please enter a valid amount. Press any key to continue");
                Console.ReadKey();
                s.WithdrawHelper();//Operator error, allows recovery.
            }
             return s;//returns either updated customer s, or initial customer s, depending on value of successfull.
            }

        /*
         * Public method called from Menu Class, by
         * menu selection number 5.
         * Takes in Customer[] custData array in method signature
         * so array can be used within the method.      
         * Iterates through array for youngest customer, and calls that custData[i]
         * objects displayInfo method.
         * See Deposit() and LeapYear() methods for relevant comments and logic.
         */
        public void YoungestCustomer(Customer[] custData)
        {
            Console.Clear();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("      Youngest Customer        ");
            Console.WriteLine("-------------------------------");
            Customer youngest = new Customer(custData);//Declares and initialises a Customer object variable.
            DateTime aAge = Convert.ToDateTime("1-1-1800");//Declares and initialises initial age value to a String value, converted to a DateTime object.
            //Error not being handled as this a local variable initialisation.
            for (int i = 0; i < custData.Length; i++)
            {
                Customer customer = custData[i];
                this.firstName = customer.firstName;
                this.lastName = customer.lastName;
                this.dob = customer.dob;
                this.accNum = customer.accNum;
                this.balance = customer.balance;
                this.tranCount = customer.tranCount;
                Customer s = new Customer(this.firstName, this.lastName, this.dob, this.accNum, this.balance, this.tranCount);
                DateTime bDay = Convert.ToDateTime(dob);//Declares a DateTime object variable and sets to custData[i] objects dob value converted to a DateTime object.
                
                if (bDay > aAge) //fires if dob is more than value held in age (younger than).
                {
                    youngest = custData[i];//sets the youngest Customer object variable to the custData[i] Customer object.
                    aAge = bDay;//sets the value of aAge variable to the current youngest objects date of birth.
                }
            }
            youngest.DisplayInfo();//displays the class appropriate customer information.
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        /*
         * Public method called from Menu Class, by
         * menu selection number 3.
         * Takes in Customer[] custData array in method signature
         * so array can be used within the method.
         * Iterates through array for looking for highest balance value, and sets that
         * to a variable. Then uses this variable to iterate through the array again,
         * so all customers with that balance can be dispayed, by calling
         * the class appropriate DisplayInfo() method.
         * See LeapYear() and Deposit() methods for relevant comments.
         */
        public void HighestBal(Customer[] custData)
        {
            Console.Clear();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("          Max Balance          ");
            Console.WriteLine("-------------------------------");
            double aBal = 0.00;//Declares and initialises the variable to hold the current highest balance. 
            for (int i = 0; i < custData.Length; i++)
            {
                Customer customer = custData[i];
                this.firstName = customer.firstName;
                this.lastName = customer.lastName;
                this.dob = customer.dob;
                this.accNum = customer.accNum;
                this.balance = customer.balance;
                this.tranCount = customer.tranCount;
                Customer s = new Customer(this.firstName, this.lastName, this.dob, this.accNum, this.balance, this.tranCount);

                if (balance > aBal)//Checks to see if the Customer objects balance is higher than the currently held aBal value.
                {
                    aBal = balance;//sets the aBal value to the new highest balance value.
                }
            }
            for (int i = 0; i < custData.Length; i++)
            {
                Customer customer = custData[i];
                this.firstName = customer.firstName;
                this.lastName = customer.lastName;
                this.dob = customer.dob;
                this.accNum = customer.accNum;
                this.balance = customer.balance;
                this.tranCount = customer.tranCount;
                Customer s = new Customer(this.firstName, this.lastName, this.dob, this.accNum, this.balance, this.tranCount);

                if (balance == aBal)//fires if a Customer objects balance equals the previously set highest balance.
                {
                    DateTime today = DateTime.Now;//Declares and initialises a DateTime object to current system time
                    DateTime bDay = Convert.ToDateTime(s.dob);//Declares a DateTime object and initialises it by converting Customer objects dob to a DateTime object.
                    int day = today.Day;//Declares and initialises the int value for todays day (date)
                    int month = today.Month;//Declares and initialises the int value for current month
                    int dobDay = bDay.Day;//Declares and initialises the day value of Customer objects dob
                    int dobMonth = bDay.Month;//Declares and initialises the month value of Customer objects dob
                    //Year values are not needed in this method.
                    custData[i].DisplayInfo();//calls the appropriate DisplayInfo() method.
                    if((day == dobDay) && (month == dobMonth))//fires if Customer objects dob day and month values match todays day and month values.
                    {
                        Console.WriteLine("Happy Birthday " + custData[i].firstName);
                    }
                    Console.WriteLine(""); //Places a line between Customers information on Console screen for readability.                  
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        /*
         * Public method called from Menu Class, by
         * menu selection number 4.
         * Takes in Customer[] custData array in method signature
         * so array can be used within the method.
         * Iterates through array for highest tranCount value, and calls that custData[i]
         * objects DisplayInfo() method.
         * For relevant comments see LeapYear() and Deposit() methods.
         */
        public void MostActive(Customer[] custData)
        {
            Console.Clear();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("          Most Active          ");
            Console.WriteLine("-------------------------------");
            int mostActive = 0;//Declares and initialises variable for highest tranCount to 0.
            Customer mostActiveCust = new Customer();//Declares and initialises a Customer Object to hold current most active custData[i] object.
            for (int i = 0; i < custData.Length; i++)
            {
                Customer customer = custData[i];
                this.firstName = customer.firstName;
                this.lastName = customer.lastName;
                this.dob = customer.dob;
                this.accNum = customer.accNum;
                this.balance = customer.balance;
                this.tranCount = customer.tranCount;
                Customer s = new Customer(this.firstName, this.lastName, this.dob, this.accNum, this.balance, this.tranCount);
                if (tranCount > mostActive)//Fires when tranCount of a custData[i] object is higher than current value of mostActive.
                {
                    mostActiveCust = custData[i];//sets mostActiveCust Object variable to value of custData[i]'s object.
                    mostActive = tranCount;//sets mostActive variable to tranCount of current custData[i] object.
                }
            }
            mostActiveCust.DisplayInfo();//calls class appropriate DisplayInfo() method.
            Console.WriteLine("Number of transactions: " + mostActiveCust.tranCount);//writes tranCount for the most active customer
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            } 
    }
}


    


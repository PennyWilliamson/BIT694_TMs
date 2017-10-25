using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIT694_TM1_3431274
{
    class VIPCustomer: Customer
    {
        //Most Class variables inherited from Customer.
        private String custType;//Declares VIP customer variable. Private as it is only used in VIPCustomer.
        Customer[] custData;//allows method to call and use array.

        //Constructer that takes in firstName, lastName, dob, accNum, balance, custType and tranCount as method signature. Inherits from Customer constructor
        public VIPCustomer(String firstName, String lastName, String dob, String accNum, double balance, String custType, int tranCount) : base(firstName, lastName, dob, accNum, balance, tranCount)
        {
         //other variables inherited from Customer via : Base call.
         this.custType = custType;//sets custType to custType in signature
        }

        //A constructor that takes the custData array in its signature.
        public VIPCustomer(Customer[] custData)
        {
            this.custData = custData;//sets array value in signature to array value.
        }

        //A constructor with no signature.
        public VIPCustomer() { }

        //Most get and set methods inherited from Customer class.

        //Allows customer type to be gotten and set.
        public String AccessCustType
        {
            set { this.custType = value; }
            get { return this.custType; }
        }

        //A helper method that displays a VIP customers basic information.
        //No error handling reasons, see virtual method in Customer. 
        protected override void DisplayInfo() //protected is the lowest access level that can be used for an override method.
        {
            DateTime aDob = Convert.ToDateTime(dob);
            String bDob = aDob.ToShortDateString();
            Console.WriteLine(custType);
            Console.WriteLine("Name: " + firstName + " " + lastName);
            Console.WriteLine("Date of birth: " + bDob);
            Console.WriteLine("Balance: " + balance.ToString("C"));
        }

        /*
         * Helper method that handles class specific deposit
         * method. Charges no fees.
         * Takes in and uses that values for the custData[i]
         * object that was used to call it.
         * Returns a Customer object to Customer Class's Deposit() method.
         * Protected as it is an overridden method, that is only used within class
         * and subclass.
         * See virtual method in Customer for comments and logic.
         */
        protected override Customer DepositHelper()
        {
            VIPCustomer s = new VIPCustomer(this.firstName, this.lastName, this.dob, this.accNum, this.balance, this.custType, this.tranCount);
            try
            {
                Console.WriteLine("Depositing into the account of " + firstName + " " + lastName + ". Current balance is: " + balance.ToString("C"));
                Console.WriteLine("Enter amount to deposit: ");
                double amount = double.Parse(Console.ReadLine());
                if (amount < 0)//error handling, does not allow negative amounts to be deposited.
                {
                    Console.WriteLine("Please enter a non negative amount. Press any key to continue");
                    Console.ReadKey();
                    s.DepositHelper();
                }
                else//allows the program to continue if number is non-negative, and after amount has been corrected.
                {
                    double aBalance = balance + amount;
                    int aTranCount = tranCount + 1;
                    Console.WriteLine("Success fully deposited " + amount.ToString("C") + ". Current balance: " + aBalance.ToString("C"));
                    VIPCustomer t = new VIPCustomer(this.firstName, this.lastName, this.dob, this.accNum, aBalance, this.custType, aTranCount);
                    s = t;
                }
            }
            catch(ArgumentOutOfRangeException)//ReadLine error
            {
                Console.WriteLine("Please enter a valid amount. Press any key to continue");
                Console.ReadKey();
                s.DepositHelper();//Catching operator error, allows program recovery.
            }
            catch(FormatException)//Parse error
            {
                Console.WriteLine("Please enter a valid amount. Press any key to continue");
                Console.ReadKey();
                s.DepositHelper();//Catching operator error, allows program recovery.
            }
            return s;
        }

        /*
         * Helper method that handles class specific withdrawal
         * method. Charges no fee, and allows accounts to become 
         * overdrawn.
         * Takes in and uses that values for the custData[i]
         * object that was used to call it.
         * Returns a Customer object to Customer Class's Withdraw() method.
         * Protected as it is an overridden method, that is only used within class
         * and subclass.
         * See virtual method in Customer for most comments and logic.
         */
        protected override Customer WithdrawHelper()
        {
            bool successfull = false;
            VIPCustomer s = new VIPCustomer(this.firstName, this.lastName, this.dob, this.accNum, this.balance, this.custType, this.tranCount);
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
                    double totalAmount = amount;
                    double aBalance = balance - amount;
                    int aTranCount = tranCount + 1;
                    Console.WriteLine("Successfully withdrew " + amount.ToString("C") + ". Current balance: " + aBalance.ToString("C"));
                    VIPCustomer t = new VIPCustomer(this.firstName, this.lastName, this.dob, this.accNum, aBalance, this.custType, aTranCount);
                    s = t;
                    successfull = true;
                    if (successfull == false)//handles unexpected processing errors.
                    {
                        Console.WriteLine("Sorry, due to a bank error, the transaction did not work");
                        return s;
                    }
                }
            }
            catch(ArgumentOutOfRangeException)//ReadLine error
            {
                Console.WriteLine("Please enter a valid amount. Press any key to continue");
                Console.ReadKey();
                s.WithdrawHelper();//Catching operator error, allows program recovery.
            }
            catch(FormatException)//Parse error
            {
                Console.WriteLine("Please enter a valid amount. Press any key to continue");
                Console.ReadKey();
                s.WithdrawHelper();//Catching operator error, allows program recovery.
            }
            return s;
        }

        

    }
}

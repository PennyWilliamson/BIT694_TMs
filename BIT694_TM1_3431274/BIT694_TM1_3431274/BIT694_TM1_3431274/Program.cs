using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;


namespace BIT694_TM1_3431274
{
    class Program
    {
        /*
         * Reads data lines from a text file, split at ',' into
         * an array line[]. Then sets them as
         * either a Customer or VIPCustomer object, based on 
         * length of line array. Then adds them to
         * an array of Customer objects. Both types of objects can be held,
         * as VIPCustomer is a subclass of Customer. 
         */
        static void ReadingInputFile(Customer[] custData)
        {
            try
            {
                TextReader tr = new StreamReader("C:/BIT694_TM1_3431274/input_assignment_1.txt");
                //reads data from file in location in StreamReaders signature.
                for (int i = 0; i < custData.Length; i++)//iterates custData length number of times.
                {
                    String currentLine;//declares a String variable
                    String[] line;//declares a string array
                    int tranCount = 0;//declares and sets an int variable
                    currentLine = tr.ReadLine();//sets a String variable to a line of text from StreamReaders file.
                    line = currentLine.Split(',');//Splits a string, and adds each variable as a separate array item.
                    
                    if(line.Length > 5)//fires if line array contains the sixth field, VIP.
                    {
                        line[5] = "VIP Customer";//changes VIP to VIP Customer
                        VIPCustomer t = new VIPCustomer(line[0], line[1], line[2], line[3], double.Parse(line[4]), line[5], tranCount);
                        //Sets a new VIPCustomer object to values from line array, and variable tranCount.
                        custData[i] = t;//Adds the VIPCustomer object to the custData array.
                    }
                    if(line.Length < 6)//fires if array does not contain the sixth field.
                    {
                        Customer s = new Customer(line[0], line[1], line[2], line[3], double.Parse(line[4]), tranCount);
                        //sets a new customer object to values from line array, and variable tranCount.
                        custData[i] = s;//Adds the Customer object to the custData array.
                    }
                }
                tr.Close();//closes the TextReader.
            }
            catch (FileNotFoundException exA)//StreamReader error
            {
                Console.WriteLine("" + exA);
            }
            catch(FormatException exB)//Parse error
            {
                Console.WriteLine(exB);
            }
            catch(ArgumentNullException exC)//ReadLine and StreamReader error
            {
                Console.WriteLine(exC);
            }
            catch(ArgumentOutOfRangeException exD)//ReadLine and StreamReader error
            {
                Console.WriteLine(exD);
            }
            catch(IOException exE)//ReadLine and StreamReader error
            {
                Console.WriteLine(exE);
            }
            
        }


        static void Main(string[] args)
        {
            Customer[] custData = new Customer[20];//declares and initialises the array.
            ReadingInputFile(custData);//calls the method to read the text file into the array
            Menu menu = new Menu(custData);//creates a Menu object
            menu.DisplayMenu(); //calls the Menu method, DisplayMenu().          
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        
        }
    }


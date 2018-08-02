using System;

namespace DateChecker
{
    class Program
    {
        const long LENGTH_OF_DAY = 86400000L;
        static void Main(string[] args)
        {
            //Introduction
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Date Calculator");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Please answer the questions below.  If you get confused, type ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("?");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(".\n\n");

            Console.ForegroundColor = ConsoleColor.White;

            int sizeOfScript = 30;
            int refills = 3;
            int totalDays = 0;
            bool failure = true;

            //First up- get the size of the script
            while (failure == true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("How many capsules are in the prescription: ");
                string s = Console.ReadLine();
                if(s == "?")
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("On the script you wrote, how many capsules does it authorize before refills?  Type in a number like ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("30");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(".\n");
                }
                else
                {
                    int x = 0;
                    if (int.TryParse(s, out x) == true)
                    {
                        if (x > 0)
                        {
                            sizeOfScript = x;
                            failure = false;
                        }
                        else
                        {
                            Console.WriteLine("Values should only be greater than zero.");
                        }
                    }
                    else
                    {
                        InvalidEntry();
                    }
                }

            }

            //Next up, number of refills
            failure = true;
            while(failure == true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("How many refills are given in the script: ");
                string s = Console.ReadLine();
                if (s == "?")
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("On the script you wrote, how many refills does it authorize before the patient sees the doctor again?  Type in a number like ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("3");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(".\n");
                }
                else
                {
                    int x = 0;
                    if (int.TryParse(s, out x) == true)
                    {
                        if (x > 0)
                        {
                            refills = x;
                            failure = false;
                        }
                        else
                        {
                            Console.WriteLine("Values should only be greater than zero.");
                        }
                    }
                    else
                    {
                        InvalidEntry();
                    }
                }
            }

            //Now we get the total days...
            totalDays = refills * sizeOfScript;

            DateTime d = DateTime.Now.AddDays((double) totalDays); 
            Console.Write("The patient will run out of medication on ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(DateToString(d) + "\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Type anything to quit the program.");
            Console.ReadLine();
        }

        static void InvalidEntry()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("That is an invalid entry.  If you get confused, type ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("?");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(".\n");
        }

        /// <summary>
        /// Insert a long (the date), get a string
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        static string DateToString(DateTime d)
        {
            int month = d.Month;
            int day = d.Day;
            int year = d.Year;


            string s = "";
            if (month == 1)
                s = "Jan";
            if (month == 2)
                s = "Feb";
            if (month == 3)
                s = "Mar";
            if (month == 4)
                s = "Apr";
            if (month == 5)
                s = "May";
            if (month == 6)
                s = "Jun";
            if (month == 7)
                s = "Jul";
            if (month == 8)
                s = "Aug";
            if (month == 9)
                s = "Sept";
            if (month == 10)
                s = "Oct";
            if (month == 11)
                s = "Nov";
            if (month == 12)
                s = "Dec";

            s = s + " " + day + ", " + year;
            return s;
        }
    }
}

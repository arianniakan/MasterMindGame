
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Master_Mind
{
    class Program
    {
        static void Main(string[] args)
        {
            String number;
            int digits;
            string dig;
            string guess;
            int tries = 10;
            Console.WriteLine("choose the level of the game: |5|6|7|8|9| ");
            while (true)
            {

                dig = Console.ReadLine();
                if (Is_Num(dig))
                {
                    digits = Convert.ToInt32(dig);
                    if (digits <= 9 && digits >= 5)
                    {
                        break;
                    }
                    else
                    {

                        Console.Write("invalid input (must be between 5 and 9)!\ntry again!: ");
                    }
                }
                else
                {
                    Console.Write("invalid input(must be a number)\ntry again!: ");
                }

            }
            number = Convert.ToString(Random_Num(digits));
            Console.WriteLine("______________________________________________________________");

            Console.WriteLine("you have " + tries + " tries to guess the number");
            Console.WriteLine("green means the number exists and is in the right place!");
            Console.WriteLine("red means the number does not exist!");
            Console.WriteLine("yellow means the number exists but is not in its right place!");
            Console.WriteLine("your time starts now!");
            Console.WriteLine("______________________________________________________________");




            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < tries; i++)
            {
                guess = GetNums(digits);
                if (guess == number)
                {
                    Console.WriteLine("!!!congrats!!!" + "\n" + "you guessed the number!");
                    break;
                }
                for (int j = 0; j < guess.Length; j++)
                {
                    if (number.IndexOf(guess[j]) != -1)
                    {
                        if (Is_in_right(number,guess[j],i))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(guess[j]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (!Is_in_right(number, guess[j], i))
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(guess[j]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    else if (number.IndexOf(guess[j]) == -1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(guess[j]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                Console.Write("\n");
                if (i == tries - 1)
                {
                    Console.WriteLine("you are out of tries!\nGame Over!");
                    Console.WriteLine("the correct number was: " + number);
                    Console.WriteLine("it took you " + i + " tries to guess the number");

                }

            }
       
            sw.Stop();
            Console.Write(sw.Elapsed.TotalSeconds + " Sec    / " +
                    ((float)sw.Elapsed.TotalSeconds / (float)60).ToString("N2") +
                    " min");

            Console.ReadLine();
        }
        static int Random_Num(int digits)
        {
            Random rnd = new Random();
            int num = 0;
            if (digits == 5)
            {
                num = rnd.Next(9999, 99999);
            }
            else if (digits == 6)
            {
                num = rnd.Next(99999, 999999);
            }
            else if (digits == 7)
            {
                num = rnd.Next(999999, 9999999);
            }
            else if (digits == 8)
            {
                num = rnd.Next(9999999, 99999999);
            }
            else if (digits == 9)
            {
                num = rnd.Next(99999999, 999999999);
            }
            return num;
        }
        static bool Is_Num(string num)
        {
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] != '0' && num[i] != '1' && num[i] != '2' && num[i] != '3' && num[i] != '4' && num[i] != '5' && num[i] != '6' && num[i] != '7' && num[i] != '8' && num[i] != '9')
                {
                    return false;
                }
            }
            if (num == "") return false;
            return true;
        }
        static string GetNums(int digits)
        {
            string str;
            while (true)
            {
                str = Console.ReadLine();
                if (Is_Num(str) && str.Length == digits)
                {
                    return str;
                }
                else if (Is_Num(str) && str.Length != digits)
                {
                    Console.WriteLine("invalid input (must be a number of " + digits + "digits!)");
                }
                else if (!Is_Num(str) && str.Length == digits)
                {
                    Console.WriteLine("invalid input (must be a number)");
                }
                else
                {
                    Console.WriteLine("invalid input (must be a number of " + digits + " digits!)");
                }
            }



        }
        static bool Is_in_right(string num , char guess , int i)
        {
            if(guess==num[i])
            {
                return true;
            }
            return false;
        }
    }

}

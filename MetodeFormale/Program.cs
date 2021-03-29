using System;
using System.IO;
using System.Text;

namespace MetodeFormale
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Scrie expresia:");
            string input = Console.ReadLine();
            string[] c = input.Split(",");
            Console.WriteLine(c.Length);
            if (validareZeroUnu(input))
            {
                int stare = automat2(input);
                if(stare == 4)
                {
                    Console.WriteLine("VALID, FINAL: " + stare);
                }
                else
                {
                    Console.WriteLine("INVALID, FINAL: " + stare);
                }
            }
            else
            {
                Console.WriteLine("INVALID");
            }
            //Store the path of the textfile in your system
            string file = @"C:\Users\Bogdan Elvis-Sorin\source\repos\MetodeFormale\MetodeFormale\TextFile1.txt";



            // By using StreamReader 
            if (File.Exists(file))
            {
                // Reads file line by line 

                StreamReader Textfile = new StreamReader(file);
                string line;

                while ((line = Textfile.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }

                Textfile.Close();

                Console.ReadKey();
            }
            Console.WriteLine();

            


            /////////////////////////////

            string file2 = @"C:\Users\Bogdan Elvis-Sorin\source\repos\MetodeFormale\MetodeFormale\TextFile2.txt";
            /////writing in textfile
            ///
            int stare2 = automat2(input);
            string[] textLines2 = { "Starea la care s-a ajuns este : " + stare2 };

            using (StreamWriter writer = new StreamWriter(file2))
            {
                foreach (string ln in textLines2)
                {
                    writer.WriteLine(ln);
                }
            }
            // To display current contents of the file 
            Console.WriteLine(File.ReadAllText(file2));
        }


        private static bool validareZeroUnu(string input)
        {
            for (int i = 0; i < input.Length; i++)
                if (input[i] != '0' && input[i] != '1')
                {
                    return false;
                }
            return true;
        }
        private static int automat1(string input)
        {
            int stare = 0;
            for (int i = 0; i < input.Length; i++) 
                if (stare == 0 && Char.IsLetter(input[i])) 
                {
                    stare = 1;
                }
                else if (stare == 0 && Char.IsDigit(input[i])) 
                {
                    stare = 1;
                    break;
                }
                else if (stare == 1 && Char.IsLetterOrDigit(input[i])) 
                {
                    stare = 1;
                }
            return stare;

            
        }


        private static int automat2(string input)
        {
            int stare = 1;
            for (int i = 0; i < input.Length; i++)
            if(stare == 1 && input[i] == '0')
                {
                    stare = 2;
                }else if(stare == 1 && input[i] == '1')
                {
                    stare = 3;
                }
           else  if(stare == 1 &&  input[i]== '0')
            {
                stare = -1;
                break;
            }
            else if(stare == 2 && input[i] == '1')
                {
                    stare = 4;
                }
                else if (stare == 3 && input[i] == '0')
                {
                    stare = 4;
                }
                else if (stare == 3 && input[i] == '1')
                {
                    stare = -1;
                    break;
                }
                else if (stare == 4 && input[i] == '0')
                {
                    stare = 1;
                }
                else if (stare == 4 && input[i] == '1')
                {
                    stare = 2;
                }
            return stare;
        }
        private static bool validareLitereDigitale(string input)
        {
            for (int i = 0; i < input.Length; i++)
                if (!Char.IsLetterOrDigit(input[i]))
                {
                    return false;
                }
            return true;
        }

    }
}


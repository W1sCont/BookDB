using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace lesson10task2
{
    internal class Logic
    {
        public void Run()
        {
            StreamWriter sw = null;
            StreamWriter sw1 = null;
            try
            {
                sw = new StreamWriter("fileOdd.txt", false);
                sw1 = new StreamWriter("fileEven.txt", false);

                Random rnd = new();
                int len = 10000;
                int temp = 0;

                for (int i = 0; i < len; i++)
                {
                    temp = rnd.Next(1, 10001);
                    if (temp % 2 == 0) sw1.WriteLine(temp);
                    else sw.WriteLine(temp);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sw != null) sw.Close();
                if (sw1 != null) sw1.Close();
                Console.WriteLine("Файлові потоки закриті.");
            }
        }

        public void Statistics()
        {
            StreamReader sr = null;
            StreamReader sr1 = null;
            try
            {
                sr = new StreamReader("fileOdd.txt");
                Console.WriteLine("Вивід файлу fileOdd.txt");
                int count = 0;
                while (!sr.EndOfStream)
                {
                    if (count % 10 == 0) Console.WriteLine();
                    Console.Write(sr.ReadLine() + "\t");
                    count++;
                }
                Console.WriteLine($"\nУ файлі fileOdd.txt {count} не парних чисел");

                sr1 = new StreamReader("fileEven.txt");
                Console.WriteLine("Вивід файлу fileEven.txt\n");
                int count1 = 0;
                while (!sr1.EndOfStream)
                {
                    if (count1 % 10 == 0) Console.WriteLine();
                    Console.Write(sr1.ReadLine() + "\t");
                    count1++;
                }
                Console.WriteLine($"\nУ файлі fileEven.txt {count1} парних чисел");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sr != null) sr.Close();
                if (sr1 != null) sr1.Close();
                Console.WriteLine("Файлові потоки закриті.");
            }
        }
    }
}

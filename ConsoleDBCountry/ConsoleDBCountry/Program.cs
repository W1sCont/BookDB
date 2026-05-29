using ClassLib;
using ContinentContextNS;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace lesson1
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            
            try
            {
                var builder = new ConfigurationBuilder();
                builder.SetBasePath(Directory.GetCurrentDirectory());
                builder.AddJsonFile("appsettings.json");
                var config = builder.Build();
                string? connectionString = config.GetConnectionString("DefaultConnection");

                var optionsBuilder = new DbContextOptionsBuilder<ContinentContext>();
                var options = optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies().Options;

                using (ContinentContext db = new ContinentContext(options))
                {
                    while (true)
                    {
                        Console.Clear();
                        var qweryAll = db.Countries;
                        foreach (var country in qweryAll)
                        {
                            Console.WriteLine($"Country {country.Name} - Capital city {country.CapitalCity}");
                            Console.WriteLine($"Area {country.Area} - Population {country.Population}");
                            Console.WriteLine($"Continent {country.Continent?.Name}\n");
                        }

                        Console.WriteLine("1. Додати країну");
                        Console.WriteLine("2. Редагувати країну");
                        Console.WriteLine("3. Видалити країну");
                        Console.WriteLine("0. Вихід");
                        int result = int.Parse(Console.ReadLine()!);
                        switch (result)
                        {
                            case 1:
                                try
                                {
                                    Console.WriteLine("Введіть назву країни:");
                                    string? str = Console.ReadLine();
                                    string? name = ToTitleCaseRegex(str);
                                    Console.WriteLine("Введіть назву столиці:");
                                    str = Console.ReadLine();
                                    string? capital = ToTitleCaseRegex(str);
                                    Console.WriteLine("Введіть площу території:");
                                    int area;
                                    int.TryParse(Console.ReadLine(), out area);
                                    Console.WriteLine("Введіть к-сть населення:");
                                    int population;
                                    int.TryParse(Console.ReadLine(), out population);
                                    Console.WriteLine("Введіть назву континента:");
                                    str = Console.ReadLine();
                                    string? continent = ToTitleCaseRegex(str);
                                    if (string.IsNullOrWhiteSpace(continent))
                                    {
                                        Console.WriteLine("Помилка: Назва континенту не може бути порожньою!");
                                        return;
                                    }
                                    if (db.AddCountry(name, capital, area, population, continent))
                                    {
                                        Console.WriteLine("Країну успішно додано");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Така країна вже існує");
                                        Console.ReadKey();
                                    }
                                }
                                catch (Exception ex) { Console.WriteLine(ex.Message); }
                                break;
                            case 2:
                                try
                                {
                                    Console.WriteLine("Введіть назву країни яку бажаєте редагувати:");
                                    string? str = Console.ReadLine();
                                    string? name = ToTitleCaseRegex(str);
                                    if (db.Countries.FirstOrDefault(c => c.Name == name) == null)
                                    {
                                        Console.WriteLine("Такої країни не знайдено");
                                        break;
                                    }
                                    Console.WriteLine("Введіть нову назву країни:");
                                    str = Console.ReadLine();
                                    string? newName = ToTitleCaseRegex(str);
                                    Console.WriteLine("Введіть нову назву столиці:");
                                    str = Console.ReadLine();
                                    string? capital = ToTitleCaseRegex(str);
                                    Console.WriteLine("Введіть нову площу території:");
                                    int area;
                                    int.TryParse(Console.ReadLine(), out area);
                                    Console.WriteLine("Введіть нову к-сть населення:");
                                    int population;
                                    int.TryParse(Console.ReadLine(), out population);

                                    if (db.EditCountry(name,newName, capital, area, population))
                                    {
                                        Console.WriteLine("Країну успішно редаговано");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Не вірні дані");
                                        Console.ReadKey();
                                    }
                                }
                                catch (Exception ex) { Console.WriteLine(ex.Message); }
                                break;
                            case 3:
                                try
                                {
                                    Console.WriteLine("Введіть назву країни яку бажаєте видалити:");
                                    string? str = Console.ReadLine();
                                    string? name = ToTitleCaseRegex(str);
                                    if (db.Countries.FirstOrDefault(c => c.Name == name) == null)
                                    {
                                        Console.WriteLine("Такої країни не знайдено");
                                        break;
                                    }
                                    bool approve = false;
                                    Console.WriteLine("Якщо ви дійсно бажаєте видалити країну введіть +");
                                    string? approveStr = Console.ReadLine();
                                    if(approveStr?.Trim() == "+") { approve = true; }
                                    if (approve)
                                    {
                                        if (db.RemoveCountry(name))
                                        {
                                            Console.WriteLine("Країну успішно видалено");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Не вірні дані");
                                            Console.ReadKey();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Видалення відмінено");
                                        Console.ReadKey();
                                    }
                                   
                                }
                                catch (Exception ex) { Console.WriteLine(ex.Message); }
                                break;                    
                            case 0:
                                return;
                        }
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public static string ToTitleCaseRegex(string? str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;
            string lower = str.Trim().ToLower();
            string pattern = @"\b\w";
            string result = Regex.Replace(lower, pattern, m => m.Value.ToUpper());

            return result;
        }
    }
}
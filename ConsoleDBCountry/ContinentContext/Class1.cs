using ClassLib;
using Microsoft.EntityFrameworkCore;

namespace ContinentContextNS
{
    public class ContinentContext : DbContext
    {
        public ContinentContext(DbContextOptions<ContinentContext> options)
        : base(options)
        {   
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public DbSet<Continent> Continents { get; set; }
        public DbSet<Country> Countries { get; set; }

        public bool AddCountry(string? name, string? capital, int area, int population, string? continent)
        {
            Country? dbCountry = Countries.FirstOrDefault(c => c.Name == name);
            if (dbCountry == null)
            {
                Continent? dbContinent = Continents.FirstOrDefault(c => c.Name == continent);
                if (dbContinent != null)
                {
                    Country newCountry = new Country { Name = name, CapitalCity = capital, Area = area, Population = population, Continent = dbContinent };
                    Countries.Add(newCountry);
                    SaveChanges();
                    return true;
                }
                else
                {
                    Continent newContinent = new Continent() { Name = continent };
                    Country newCountry = new Country { Name = name, CapitalCity = capital, Area = area, Population = population, Continent = newContinent };
                    Countries.Add(newCountry);
                    SaveChanges();
                    return true;
                }
            }
            else return false;  
        }

        public bool EditCountry(string? oldName, string? newName, string? newCapital, int newArea, int newPopulation)
        {
            Country? dbCountry = Countries.FirstOrDefault(c => c.Name == oldName);
            if (dbCountry != null)
            {
                dbCountry.Name = newName;
                dbCountry.CapitalCity = newCapital;
                dbCountry.Area = newArea;
                dbCountry.Population = newPopulation;

                SaveChanges();
                return true;
            }
            else return false;
        }
        public bool RemoveCountry(string? name)
        {
            Country? dbCountry = Countries.FirstOrDefault(c => c.Name == name);
            if (dbCountry != null)
            {
                Countries.Remove(dbCountry);
               
                SaveChanges();
                return true;
            }
            else return false;
        }
    }
}

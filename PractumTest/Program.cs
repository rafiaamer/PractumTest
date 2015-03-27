using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractumTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            var diner = SetupDiner();
            
            Console.WriteLine("Press Q and enter to quit.");
            string input = string.Empty;
            do
            {
                Console.Write("\t=>");
                input = Console.ReadLine();
                Console.WriteLine();
        
                try
                {
                    Console.WriteLine("\t{0}", diner.Serve(input));
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
        

            } while (input.ToUpper() != "Q");

         
        }

        public static Diner SetupDiner() //Populate the menu
        {
            Diner diner = new Diner();
            
            if (diner.Menus != null) return null;

            var morning = new Dictionary<EntreCategory, Entre>();
            morning.Add(EntreCategory.Entree, new Entre(EntreCategory.Entree, "Eggs"));
            morning.Add(EntreCategory.Side, new Entre(EntreCategory.Entree, "Toast"));
            morning.Add(EntreCategory.Drink, new Entre(EntreCategory.Entree, "Coffee") { CanServeMultiple = true });


            var night = new Dictionary<EntreCategory, Entre>();
            night.Add(EntreCategory.Entree, new Entre(EntreCategory.Entree, "Steak"));
            night.Add(EntreCategory.Side, new Entre(EntreCategory.Entree, "Potato") { CanServeMultiple = true });
            night.Add(EntreCategory.Drink, new Entre(EntreCategory.Entree, "Wine"));
            night.Add(EntreCategory.Dessert, new Entre(EntreCategory.Entree, "Cake"));

            diner.Menus = new Dictionary<TimeOfDay, IDictionary<EntreCategory, Entre>>();
            diner.Menus.Add(TimeOfDay.Morning, morning);
            diner.Menus.Add(TimeOfDay.Night, night);
            return diner;
        }
    }
}


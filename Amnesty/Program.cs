using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchCriminals
{
    class Progam
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            List<Prisoner> prisoners = new List<Prisoner>();
            int maximumPrisoners = 30;
            int maximumCrimes = Enum.GetNames(typeof(Crimes)).Length;

            for (int i = 0; i < maximumPrisoners; i++)
            {
                prisoners.Add(new Prisoner($"Заключенный_{i + 1}", (Crimes)random.Next(0, maximumCrimes)));
            }

            var filteredPrisoners = prisoners.OrderBy(prisoner => prisoner.Crime).SkipWhile(prisoner => prisoner.Crime == Crimes.AntiGovernment);

            foreach (var prisoner in filteredPrisoners)
            {
                prisoner.ShowInfo();
            }
        }
    }

    enum Crimes
    {
        AntiGovernment,
        DrugTrade,
        HumanTrafficking,
        IllegalArmsTrade,
        Rape,
        Theft,
        Murder
    }
    
    class Prisoner
    {
        public string Name { get; private set; }
        public Crimes Crime { get; private set; }

        public Prisoner(string name, Crimes crime)
        {
            Name = name;
            Crime = crime;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Преступник - {Name} | Преступление - {Crime}");
        }
    }
}
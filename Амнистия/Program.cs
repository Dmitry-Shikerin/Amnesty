using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Амнистия
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CriminalFactory criminalFactory = new CriminalFactory();
            Jail jail = new Jail(criminalFactory.Create());

            jail.Work();
        }
    }

    class Criminal
    {
        public Criminal(string name, string crime)
        {
            Name = name;
            Crime = crime;
        }

        public string Name { get; private set; }
        public string Crime { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя: {Name}, Преступление: {Crime}");
        }
    }

    class CriminalFactory
    {
        public List<Criminal> Create()
        {
            List<Criminal> criminals = new List<Criminal>() 
            {
                new Criminal("Лаврентий", "Антиправительственное"),
                new Criminal("Иосиф", "Антиправительственное"),
                new Criminal("Стивен", "Кража"),
                new Criminal("Инакентий", "Дебош"),
                new Criminal("Илларион", "Антиправительственное"),
                new Criminal("Георгий", "Тунеядство")
            };

            return criminals;
        }
    }

    class Jail
    {
        private List<Criminal> _criminals = new List<Criminal>();

        public Jail(List<Criminal> criminals) 
        { 
            _criminals = criminals;
        }

        public void Work()
        {
            Console.WriteLine("Список до амнистии");
            ShowAllCriminals();
            Console.WriteLine($"\nСписок после амнистии");
            SortListOfCriminals();
        }

        private void ShowAllCriminals()
        {
            foreach(Criminal criminal in _criminals)
            {
                Console.WriteLine($"Имя: {criminal.Name}, Статья: {criminal.Crime}");
            }
        }

        private void SortListOfCriminals()
        {
            string amnestyCrime = "Антиправительственное";

            var sortListOfCriminals = _criminals.Where(criminal => criminal.Crime != amnestyCrime);

            foreach (Criminal criminal in sortListOfCriminals)
            {
                criminal.ShowInfo();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_53_Hospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();
            hospital.StartGame();
        }
    }

    class Ill
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Disease { get; private set; }

        public Ill(string name, int age, string disease)
        {
            Name = name;
            Age = age;
            Disease = disease;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя: {Name}. Возраст: {Age}. Болезнь: {Disease}.");
        }
    }

    class Hospital
    {
        private List<Ill> _ills = new List<Ill>();

        public Hospital()
        {
            AddIlls();
        }

        public void StartGame()
        {
            bool isWork = true;

            while (isWork == true)
            {
                ShowInfo();
                Console.WriteLine("\n1. Отсортировать всех больных по ФИО  \n2. Отсортировать всех больных по возрасту \n3. Вывести больных с определенным заболеванием \n4. Выход");

                switch (Console.ReadLine())
                {
                    case "1":
                        SortByName();
                        break;

                    case "2":
                        SortByAge();
                        break;

                    case "3":
                        ShowCertainPatients();
                        break;

                    case "4":
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("\nНеккоректный ввод\n");
                        break;
                }
            }
        }

        private void ShowCertainPatients()
        {
            Console.WriteLine("Введите наименование болезни: ");
            string disease = Console.ReadLine();

            var certainIlls = _ills.Where(x => x.Disease == disease);

            foreach (var ill in certainIlls)
            {
                ill.ShowInfo();
            }

            Console.WriteLine("\n\n");
        }

        private void SortByName()
        {
            var sortedIlls = _ills.OrderBy(x => x.Name).ToList();
            _ills = sortedIlls;
        }

        private void SortByAge()
        {
            var sortedIlls = _ills.OrderBy(x => x.Age).ToList();
            _ills = sortedIlls;
        }

        private void ShowInfo()
        {
            foreach (var ill in _ills)
            {
                ill.ShowInfo();
            }
        }

        private void AddIlls()
        {
            _ills.Add(new Ill("Антон", 32, "Сотрясение"));
            _ills.Add(new Ill("Денис", 21, "Перелом"));
            _ills.Add(new Ill("Макс", 45, "Растяжение"));
            _ills.Add(new Ill("Артём", 37, "Грипп"));
            _ills.Add(new Ill("Лиза", 18, "Отравление"));
            _ills.Add(new Ill("Настя", 25, "Корона"));
            _ills.Add(new Ill("Кирилл", 67, "Корона"));
            _ills.Add(new Ill("Тимур", 54, "Туберкулез"));
            _ills.Add(new Ill("Влад", 43, "Ротовирус"));
            _ills.Add(new Ill("Кристина", 19, "Перелом"));
        }
    }
}

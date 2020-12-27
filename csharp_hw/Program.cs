using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

//******************************
// ДЗ по C#
// Вариант А1
// Исакова Д.О. ИУ6-74Б
//******************************

namespace csharp_hw
{
    [Serializable]
    public class Company
    {
        public string Name { get; set; }
        public List<Subdivision> Subdivisions { get; set; }
        public Company() { }
        public Company(string name, List<Subdivision> sb)
        {
            Name = name;
            Subdivisions = sb;
        }
    }

    [Serializable]
    public class Subdivision
    {
        public string Name { get; set; }
        public List<Subdivision> Subdivisions { get; set; }
        public List<Employee> Employees { get; set; }
        public Subdivision() { }
        public Subdivision(string name, List<Subdivision> sb, List<Employee> em)
        {
            Name = name;
            Subdivisions = sb;
            Employees = em;
        }
    }

    [Serializable]
    public class Employee
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Position { get; set; }
        public string Birthday { get; set; }
        public bool IsBoss { get; set; }
        public Employee() { }
        public Employee(string name, string surname, string position, string birthday, bool boss)
        {
            Name = name;
            SurName = surname;
            Position = position;
            Birthday = birthday;
            IsBoss = boss;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, C3pg31 !");

            Employee emp1 = new Employee
            {
                Name = "emp1_name",
                SurName = "emp1_surname",
                Position = "emp1_pos",
                Birthday = "01.01.2021",
                IsBoss = true
            };
            Employee emp2 = new Employee
            {
                Name = "em2_name",
                SurName = "emp2_surname",
                Position = "emp2_pos",
                Birthday = "02.01.2021",
                IsBoss = false
            };

            Subdivision sd1 = new Subdivision
            {
                Name = "sd1_name",
                Subdivisions = new List<Subdivision>(),
                Employees = new List<Employee>()
            };
            sd1.Employees.Add(emp1);

            Subdivision sd2 = new Subdivision
            {
                Name = "sd2_name",
                Subdivisions = new List<Subdivision>(),
                Employees = new List<Employee>()
            };
            sd2.Employees.Add(emp2);
            sd2.Subdivisions.Add(sd1);

            Company the_company = new Company
            {
                Name = "The Company !!!",
                Subdivisions = new List<Subdivision>()
            };
            the_company.Subdivisions.Add(sd2);

            // передать в конструктор тип класса
            XmlSerializer formatter = new XmlSerializer(typeof(Company));
            //  поток, куда будет записан сериализованный объект
            using (FileStream fs = new FileStream("company.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, the_company);

                Console.WriteLine("Объект сериализован");
            }

        }
    }
}

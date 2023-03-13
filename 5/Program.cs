using System;
using System.Drawing;
using System.Xml.Linq;

namespace _5
{
    class Sotrudnik : ICloneable, IComparable<Sotrudnik>
    {
        string _names;
        int _age;
        Conpani _conpani;

        public string Names
        {
            get { return _names; }
            set { _names = value; }
        }
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public Conpani Conpani
        {
            get { return _conpani; }
            set { _conpani = value; }
        }
        public Sotrudnik(string type, int age, Conpani conpani)
        {
            _names = type;
            _age = age;
            _conpani = conpani;
        }

        //метод ToString() для вывода информации
        public override string ToString()
        {
            return $"Сотрудник {_names}, возрост {_age} лет, работает в комнании: {_conpani.Name}";
        }

        // интерфейса IClonable
        public object Clone()
        {
            return new Sotrudnik(_names, _age, new Conpani(_conpani.Name));
        }

        public int CompareTo(Sotrudnik? sotrudnik)
        {
            if (sotrudnik is null)
                throw new ArgumentException("Некорректное значение  параметра");
            return Age.CompareTo(sotrudnik.Age);
        }
    }

    internal class Conpani
    {
        string _name;

        public Conpani(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var conpani1 = new Conpani("Газпром");
            var conpani2 = new Conpani("Нефтьпром");
            var sotrudnik = new Sotrudnik("Антонов А.А", 35, conpani1);
            var clone = (Sotrudnik)sotrudnik.Clone();
            clone.Conpani = conpani2;

            Console.WriteLine(sotrudnik.ToString());
            Console.WriteLine(clone.ToString());

            Console.WriteLine(sotrudnik.CompareTo(clone));
        }
    }
}

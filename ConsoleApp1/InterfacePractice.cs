using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpPractice
{
    public interface IDrivable
    {
        public void Drive();
    }

    public class Car : IDrivable
    {
        public string Model { get; private set; }

        public Car(string model)
        {
            Model = model;
        }

        public virtual void Drive()
        {
            Console.Write("Машина ");
        }
    }

    public class RaceCar : Car
    {
        public string TypeCar { get; private set; }

        public RaceCar(string model, string typeCar) : base(model)
        {
            TypeCar = typeCar;
        }

        public override void Drive()
        {
            base.Drive();
            Console.WriteLine($"\"{TypeCar} {Model}\"");
            Console.WriteLine("Нужно притормаживать на поворотах!");
        }
    }

    public class GolfCar : Car
    {
        public string TypeCar { get; private set; }

        public GolfCar(string model, string typeCar) : base(model)
        {
            TypeCar = typeCar;
        }

        public override void Drive()
        {
            base.Drive();
            Console.WriteLine($"\"{TypeCar} {Model}\"");
            Console.WriteLine("Надо собирать попутно встречающиеся мячики!");
        }
    }

    public class Person
    {
        protected string Name { get; private set; }

        protected Person(string name)
        {
            Name = name;
        }
    }

    public class Driver : Person
    {
        public int WorkExperience { get; private set; }
        public Car Car { get; set; }

        public Driver(string name, Car car, int workExperience = 0) : base(name)
        {
            WorkExperience = workExperience;
            Car = car;
        }

        public void DriveCar()
        {
            //Пример полиморфизма в C#. В зависимости от разных типов объекта Car будут вызываться соответствующие имплементации
            Console.WriteLine($"Еду на машине {Car.Model}!");
            Car.Drive();
            Console.WriteLine();
        }
    }

    public class InterfacePractice
    {
        public static void ShowResults()
        {
            Car simpleCar = new Car("Ford Focus");
            RaceCar raceCar = new RaceCar("Болид", "Гоночный");
            GolfCar golfCar = new GolfCar("Гольфкар", "Транспортировочный");

            Person personDriver = new Driver("David", simpleCar, 3);
            Driver driver = new Driver("Alex", raceCar, 15);

            //У объекта класса Person нет метода DriveCar, хоть ему и присвоен объект типа Driver
            //personDriver.DriveCar();

            driver.DriveCar();
            driver.Car = golfCar;
            driver.DriveCar();

            Driver newDriver = (Driver)personDriver;
            newDriver.DriveCar();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpPractice
{
    public interface ICarInfo
    {
        public void ShowInfo();
    }

    public class Car : ICarInfo
    {
        public string Model { get; private set; }

        public Car(string model)
        {
            Model = model;
        }

        public virtual void ShowInfo()
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

        public override void ShowInfo()
        {
            base.ShowInfo();
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

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"\"{TypeCar} {Model}\"");
            Console.WriteLine("Надо собирать попутно встречающиеся мячики!");
        }
    }

    public interface IDriver
    {
        void DriveCar();
        void DriveForeingCar(Car car);
    }

    public abstract class Person
    {
        protected string Name { get; private set; }

        protected Person(string name)
        {
            Name = name;
        }
    }

    public class Driver : Person, IDriver
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
            //Полиморфизм в C#. В зависимости от разных типов объекта Car будут вызываться соответствующие имплементации
            Console.WriteLine($"Еду на машине {Car.Model}!");
            Car.ShowInfo();
            Console.WriteLine();
        }

        //В сигнатуре такого метода можно указывать интерфейс и реализовывать параметрический полиморфизм, но быть аккуратным с логикой
        public void DriveForeingCar(Car car)
        {
            Console.WriteLine($"Веду чужую машину - {car.Model}");
            car.ShowInfo();
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

            //Ошибка. На основе абстрактного класса нельзя создать объект
            //Person person = new Person("David");

            //Но абстрактный класс можно использовать в качестве типа, для реализации параметрического полиморфизма в C#
            Person personDriver = new Driver("David", simpleCar, 3);
            Driver driver = new Driver("Alex", raceCar, 15);

            //У объекта класса Person нет метода DriveCar, хоть ему и присвоен объект типа Driver
            //personDriver.DriveCar();

            driver.DriveCar();
            driver.Car = golfCar;
            driver.DriveCar();

            Driver newDriver = (Driver)personDriver;
            newDriver.DriveCar();
            Console.WriteLine();
            newDriver.DriveForeingCar(raceCar);
            newDriver.DriveForeingCar(golfCar);
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSetExtension
{
     public class Garage : IEnumerable,ICloneable
    {
        public delegate void GarageStateChange(object sender, GarageEventArgs e);
        // private GarageStateChange del;
        public event GarageStateChange Added;
        public event GarageStateChange Removed;

        public static int numberOfInstances;
        private Stack<Car> cars = new Stack<Car>();
        private string name = String.Empty;

        static Garage()
        {
            numberOfInstances = 0;
        }

        public Garage()
        {
            numberOfInstances++;
        }

        public Garage(string name,Car[]newCars)
        {
            foreach (var item in newCars)
            {
                AddCar = item;
            }
            Name = name;
            numberOfInstances++;
        }

        public Garage(Car[] cars) : this("Garage", cars)
        {
        }

        //public void RegisterHandler(GarageStateChange _del)
        //{
        //    del += _del;
        //}

        public Car AddCar
        {
            set
            {
                if (value is Car)
                { 
                    cars.Push(value);
                    if (Added != null)
                    {
                        Added(this, new GarageEventArgs($" Add car: {value}",value.Model));
                    }
                }
            }
        }

        public Car BringTheCar
        {
            get=> cars.Pop();
        }

        public Car SeeTheCar
        {
            get=> cars.Peek();
        }

        public int NumberOfInstatces
        {
            get => numberOfInstances;
        }

        public string Name
        {
            get => name;
            set
            {
                name = value.Length > 20 ? value.Substring(0, 20) : value;
            }

        }

        public bool IsEmpty()
        {
            return cars.Count != 0 ? false : true;
        }

        //public Car this[int index]
        //{
        //    get => index > cars.Length ? null : cars[index];
        //    set
        //    {
        //        var temp = value as Car;
        //        if (temp != null&&index<cars.Length)
        //        {
        //            cars[index] = temp;
        //        }

        //    }
        //}

        IEnumerator IEnumerable.GetEnumerator()
        {
            return cars.GetEnumerator();
        }

        object ICloneable.Clone()
        {
            //Garage newGarage = new Garage(cars.Length, Name);
            return null;//newGarage;
        }
    }

    public class GarageEventArgs
    {
        // Сообщение
        public string Message { get; }
        public string CarModel { get; }
        // Сумма, на которую изменился счет

        public GarageEventArgs(string mes,string model)
        {
            CarModel = model;
            Message = mes;
        }
    }

}

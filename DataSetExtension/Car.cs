using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSetExtension
{
    public class Car : IComparable,ICloneable
    {
        public string Model { get; set; } = "Lada";
        public int Number { get; set; } = 1111;

        public Car() { }

        public Car(string model, int number)
        {
            Model = model;
            Number = number;
        }

        int IComparable.CompareTo(object obj)
        {
            var temp = obj as Car;
            if (Model.CompareTo(temp.Model) == 0)
                return 0;
            if (Model.CompareTo(temp.Model) == 1)
                return 1;
            return -1;
        }
        public override string ToString()
        {
            return $"Model: {Model}, Number: {Number}";
        }

        object ICloneable.Clone()
        {
            Car carNew = new Car { Model = this.Model, Number = this.Number };
            return carNew;
        }
    }
}

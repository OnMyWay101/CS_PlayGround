using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarGuide
{
    public class Car
    {
        public Car(string name)
        {
            Name = name;
            PicturePath = GenPicturePath(name);
        }
        public String Name { get; set; }
        public String Type { get; set; }
        public String Consumption { get; set; }
        public String Price { get; set; }
        public String Year { get; set; }
        public String PicturePath { get; private set; }

        private string GenPicturePath(string name)
        {
            return $@"..\..\Resources\Image\{name}.png";
        }
    }
}

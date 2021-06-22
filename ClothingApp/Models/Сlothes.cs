using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingApp.Models
{
    public abstract class Сlothes
    {
        public int Id { get; private set; }
        public string Url { get; private set; }

        //диапазон температуры, в которой стоит носить эту одежду
        public  int minTemp { get; set; }
        public int maxTemp { get; set; }
        //можно ли надеть в дождь? 
        public bool forRain { get; set; }

    }

    public class Shoes : Сlothes
    {
        //обувь
    }

    public class LegsClothes : Сlothes
    {
        //низ
        //штаны/шорты/юбки
    }

    public class OutWear : Сlothes
    {
        //верхняя одежда
        //куртки, пальто, и т.д.
    }

    public class BodyClothes : Сlothes
    {
        //верх
        //футболка, рубашка, свитер и т.д.
    }

    public class Accessory : Сlothes
    {
        //аксессуары
        //зонты, шарфы, шляпы, шапки и т.д.
    }
}

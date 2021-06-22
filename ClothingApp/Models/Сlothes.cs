using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingApp.Models
{
    public abstract class Сlothes
    {
        public int Id { get; set; }

        /// <summary>
        /// пол (мужской, женский)
        /// </summary>
        public string Gender { get; set; }
        public string Url { get; set; }

        /// <summary>
        /// диапазон температуры, в котором стоит носить эту одежду
        /// </summary>
        public int MinTemp { get; set; }
        public int MaxTemp { get; set; }

        /// <summary>
        /// можно ли надеть в дождь? 
        /// </summary>
        public bool IsforRain { get; set; }

        /// <summary>
        /// совет по модели, цвету
        /// </summary>
        public string Advice { get; set; }

    }

    /// <summary>
    /// обувь
    /// </summary>
    public class Shoes : Сlothes
    {

    }

    /// <summary>
    /// низ
    /// штаны/шорты/юбки
    /// </summary>
    public class LegsClothes : Сlothes
    {

    }

    /// <summary>
    /// верхняя одежда
    /// куртки, пальто, и т.д.
    /// </summary>
    public class OutWear : Сlothes
    {

    }

    /// <summary>
    /// верх
    /// футболка, рубашка, свитер и т.д.
    /// </summary>
    public class BodyClothes : Сlothes
    {

    }

    /// <summary>
    /// аксессуары
    /// зонты, шарфы, шляпы, шапки и т.д.
    /// </summary>
    public class Accessory : Сlothes
    {

    }
}

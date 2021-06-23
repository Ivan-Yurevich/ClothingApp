using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Data.Common.Models
{
    public class Clothes
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
        public string Shoes { get; set; }
        /// <summary>
        /// головной убор
        /// </summary>
        public string Headwear { get; set; }
        /// <summary>
        /// аксессуары
        /// </summary>
        public string Accessories { get; set; }
        public bool IsforRain { get; set; }

        /// <summary>
        /// совет по модели, цвету
        /// </summary>
        public string Advice { get; set; }
    }
    public class Shoes : Clothes
    {

    }

    /// <summary>
    /// низ
    /// штаны/шорты/юбки
    /// </summary>
    public class LegsClothes : Clothes
    {

    }

    /// <summary>
    /// верхняя одежда
    /// куртки, пальто, и т.д.
    /// </summary>
    public class OutWear : Clothes
    {

    }

    /// <summary>
    /// верх
    /// футболка, рубашка, свитер и т.д.
    /// </summary>
    public class BodyClothes : Clothes
    {

    }

    /// <summary>
    /// аксессуары
    /// зонты, шарфы, шляпы, шапки и т.д.
    /// </summary>
    public class Accessory : Clothes
    {

    }
}

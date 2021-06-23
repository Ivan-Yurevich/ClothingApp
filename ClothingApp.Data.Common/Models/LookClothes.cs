using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Data.Common.Models
{
    /// <summary>
    /// образ,который мы возвращаем клиенту,  исходя из погодных условий
    /// </summary>
    public  class LookClothes
    {
        public Shoes Shoes { get; set; }
        public LegsClothes LegsClothes { get; set; }
        public OutWear OutWear { get; set; }
        public BodyClothes BodyClothes { get; set; }
        public Accessory Accessory { get; set; }

    }
       
}

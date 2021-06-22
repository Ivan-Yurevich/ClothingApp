using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingApp.Models
{
    public class Сlothes
    {
        public int Id { get; set; }
        /// <summary>
        /// верх 
        /// </summary>
        public string BodyClothes { get; set; }
        /// <summary>
        /// низ
        /// </summary>
        public string LegsClothes { get; set; }
        /// <summary>
        /// обувь
        /// </summary>
        public string Shoes { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingApp.Interfaces
{
    interface IClothes
    {
        /// <summary>
        /// получение из БД одежду/образ(шаблон)
        /// </summary>
        void GetClothes();
        /// <summary>
        /// изменение из БД одежды/образа(шаблона)
        /// </summary>
        void ChangeClothes();
        /// <summary>
        /// удаление из БД одежды/образа(шаблона)
        /// </summary>
        void DeleteClothes();
        

    }
}

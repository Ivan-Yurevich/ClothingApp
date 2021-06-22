namespace ClothingApp.Interfaces
{
    internal interface IClothes
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

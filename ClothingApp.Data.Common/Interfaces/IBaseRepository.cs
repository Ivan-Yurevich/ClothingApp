using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClothingApp.Data.Common.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {

        /// <summary>Создание объекта</summary>
        Task CreateAsync(T item);

        /// <summary>Обновление объекта</summary>
        Task UpdateAsync(T item);

        /// <summary>Получение объекта</summary>
        Task<T> GetByIdAsync(int id);

        /// <summary> Запись существует, проверка по Id </summary>
        Task<bool> ExistsAsync(int id);
        /// <summary>Удаление объекта</summary>
        Task DeleteAsync(int id);

    }
}

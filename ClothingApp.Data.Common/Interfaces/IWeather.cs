using ClothingApp.Data.Common.Models;

namespace ClothingApp.Data.Common.Interfaces
{
    public interface IWeather:IBaseRepository<Weather>
    {
        /// <summary>
        /// Получение текущей погоды
        /// </summary>
        void CurrentWeather();

        /// <summary>
        /// Получение погоды на сегодня, завтра, неделю
        /// </summary>
        void FutureWeather();

        /// <summary>
        /// Выбор/определение региона
        /// </summary>
        void CurrentRegion();
    }
}

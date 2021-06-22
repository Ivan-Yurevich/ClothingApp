namespace ClothingApp.Interfaces
{
    internal interface IWeather
    {
        /// <summary>
        /// получение текущей погоды
        /// </summary>
        void CurrentWeather();

        /// <summary>
        /// получение погоды на сегодня, завтра, неделю
        /// </summary>
        void FutureWeather();

        /// <summary>
        /// выбор/определение региона
        /// </summary>
        void CurrentRegion();
    }
}

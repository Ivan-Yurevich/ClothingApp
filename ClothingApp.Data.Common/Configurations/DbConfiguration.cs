namespace ClothingApp.Data.Common.Configurations
{
    /// <summary>
    /// Конфигурация БД
    /// </summary>
    public class DbConfiguration
    {
        /// <summary>
        /// Имя сервера
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// Порт сервера
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Имя БД
        /// </summary>
        public string Database { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Возвращает строку соединения с БД по шаблону
        /// </summary>
        public string GetConnectionString(string connectionStringFormat)
        {
            return connectionStringFormat
                .Replace($"@{nameof(Server)}@", Server)
                .Replace($"@{nameof(Port)}@", Port.ToString())
                .Replace($"@{nameof(Database)}@", Database)
                .Replace($"@{nameof(User)}@", User)
                .Replace($"@{nameof(Password)}@", Password);
        }
    }
}

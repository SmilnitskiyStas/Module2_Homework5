using Logger__2.DataWriter;
using Logger__2.Enums;

namespace Logger__2.Models
{
    internal class Logger
    {
        private static Logger instance;

        private string[] _dataLog = new string[200];

        private int _count = 0;

        private Logger()
        {
        }

        public static Logger Instance()
        {
            if (instance == null)
            {
                instance = new Logger();
            }

            return instance;
        }

        /// <summary>
        /// Формування масиву із Логами, ти виводимо на консоль.
        /// </summary>
        /// <param name="enumLogStatus">Тип логу.</param>
        /// <param name="message">Повідомлення помилки.</param>
        public void WriteLog(EnumLogStatus enumLogStatus, string message)
        {
            string logMessage = $"{DateTime.Now}: {enumLogStatus}: {message}";

            Console.WriteLine(logMessage);

            _dataLog[_count++] = logMessage;
        }

        /// <summary>
        /// Повернення масиву із списком логів.
        /// </summary>
        /// <returns>Строковий масив.</returns>
        public string[] GetDataLog()
        {
            Array.Resize(ref _dataLog, _count);

            return _dataLog;
        }
    }
}

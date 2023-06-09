﻿using Logger__2.Enums;
using Logger__2.Exceptions;

namespace Logger__2.Models
{
    internal class Actions
    {
        public Actions()
        {
        }

        /// <summary>
        /// Перший метод, записує звичайне повідомлення в Логер.
        /// </summary>
        /// <returns>Прапор із повідомленням.</returns>
        public Result InfoMethod()
        {
            string message = "Start method: InfoMethod()";
            Logger.Instance().WriteLog(EnumLogStatus.Info, message);

            return new Result(message, true);
        }

        /// <summary>
        /// Другий метод, який повертає BusinessException із помилкою.
        /// </summary>
        /// <exception cref="BusinessException">Повідомлення помилки.</exception>
        public void WarningMethod()
        {
            throw new BusinessException("Skipped logic in method");
        }

        /// <summary>
        /// Третій метод, який повертає Exception із помилкою.
        /// </summary>
        /// <exception cref="Exception">Повідомлення помилки.</exception>
        public void ErrorMethod()
        {
            throw new Exception("I broke a logic");
        }
    }
}

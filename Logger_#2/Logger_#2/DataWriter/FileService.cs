using System.Text;
using Logger__2.Models;
using Newtonsoft.Json;

namespace Logger__2.DataWriter
{
    internal class FileService
    {
        public string Message { get; set; }

        public string FileName { get; set; }

        private PathDirectory PathDirectory { get; set; }

        public FileService(string fileName)
        {
            DeserializeJSONConfigFile();

            FileName = fileName;

            StringLogContent();

            CreateDirectory();

            CheckingFiles();
        }

        /// <summary>
        /// Запис в файл списку логів.
        /// </summary>
        public void WriteLogInTheFile()
        {
            using (StreamWriter fileStream = new StreamWriter($"{PathDirectory.PathDirectoryForSaveFiles}/{FileName}", false))
            {
                fileStream.Write(Message);
            }
        }

        /// <summary>
        /// Преобразування із масиву в StringBuilder.
        /// </summary>
        private void StringLogContent()
        {
            string[] logMessage = Logger.Instance().GetDataLog();

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < logMessage.Length; i++)
            {
                stringBuilder.AppendLine(logMessage[i]);
            }

            Message = stringBuilder.ToString();
        }

        /// <summary>
        /// Створення папки для файлів із логами.
        /// </summary>
        private void CreateDirectory()
        {
            if (!Directory.Exists(PathDirectory.PathDirectoryForSaveFiles))
            {
                Directory.CreateDirectory(PathDirectory.PathDirectoryForSaveFiles);
            }
        }

        /// <summary>
        /// Перевірка файлів із логами, та відалення найстарішого файлу.
        /// </summary>
        private void CheckingFiles()
        {
            bool isWorking = true;

            while (true)
            {
                FileInfo fileInfo;

                string[] files = Directory.GetFiles(PathDirectory.PathDirectoryForSaveFiles, PathDirectory.SearchFileWithExtension);

                DateTime temp = new FileInfo(files[0]).LastWriteTime;

                int indexForDelete = 0;

                if (files.Length <= 2)
                {
                    isWorking = false;
                    break;
                }
                else
                {
                    for (int i = 1; i < files.Length; i++)
                    {
                        fileInfo = new FileInfo(files[i]);

                        DateTime dateTime = fileInfo.LastWriteTime;

                        if (dateTime < temp)
                        {
                            indexForDelete = i;
                            temp = dateTime;
                        }
                    }

                    fileInfo = new FileInfo(files[indexForDelete]);
                    fileInfo.Delete();
                }
            }
        }

        /// <summary>
        /// Отримуємо інформацію із Config.json файлу (шлях директорії для запису файлів, розширення файлів, які потрібно шукати).
        /// </summary>
        private void DeserializeJSONConfigFile()
        {
            var config = File.ReadAllText(@"C:\Users\Stas2\source\repos\GitProject\Module2_Homework5\Logger_#2\Logger_#2\Appconfig.json");
            PathDirectory = JsonConvert.DeserializeObject<PathDirectory>(config);
        }
    }
}

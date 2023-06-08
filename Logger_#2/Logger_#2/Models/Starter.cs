using System.Text;
using Logger__2.DataWriter;
using Logger__2.Enums;
using Logger__2.Exceptions;

namespace Logger__2.Models
{
    internal class Starter
    {
        private readonly string _fileName;

        public Starter()
        {
            _fileName = $"{DateTime.Now.ToString("hh.mm.ss dd.MM.yyyy")}.txt";
        }

        public void Run()
        {
            Random random = new Random();

            Actions actions = new Actions();

            Result result = null;

            for (int i = 0; i < 100; i++)
            {
                try
                {
                    switch (random.Next(0, 3))
                    {
                        case 0:
                            result = actions.InfoMethod();
                            break;
                        case 1:
                            actions.WarningMethod();
                            break;
                        case 2:
                            actions.ErrorMethod();
                            break;
                    }
                }
                catch (BusinessException businessException)
                {
                    Console.WriteLine(businessException.Message);

                    Logger.Instance().WriteLog(EnumLogStatus.Warning, $"Action got this custom Exception: {businessException.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message, ex.Source);

                    Logger.Instance().WriteLog(EnumLogStatus.Error, $"Action failed by reason: {ex.Source}");
                }
            }

            FileService fileService = new FileService(_fileName);

            fileService.WriteLogInTheFile();
        }
    }
}

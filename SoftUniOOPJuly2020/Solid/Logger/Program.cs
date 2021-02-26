using System;
using System.Collections.Generic;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            // factory creator za layout,appender, report level i da suobrazq ceh sa v CAPSLOCK
            int n = int.Parse(Console.ReadLine());

            List<IAppender> apps = new List<IAppender>();


            for (int i = 0; i < n; i++)
            {
                string[] loggersInput = Console.ReadLine().Split();

                string appenderType = loggersInput[0];
                string layoutType = loggersInput[1];
                string reportLevel = string.Empty;

                if (loggersInput.Length==3)
                {
                    reportLevel = loggersInput[2];
                }

                AppenderFactory appenderFactory = new AppenderFactory();
                IAppender appender = appenderFactory.GetAppender(appenderType, layoutType, reportLevel);
               
                apps.Add(appender);

            }

            
            string messages = Console.ReadLine();

            List<Logger> loggers = new List<Logger>();
            List<string> errorMessages = new List<string>();

            while (messages != "END")
            {
                errorMessages.Add(messages);

                messages = Console.ReadLine();
            }

            foreach (string mess in errorMessages)
            {
                string[] messageArgs = mess.Split("|");

                string reportLevel = messageArgs[0];
                DateTime date = DateTime.Now;
                string message = messageArgs[2];

                foreach (IAppender appender in apps)
                {
                    Logger logger = new Logger(appender);
                    LoggerAction(logger, reportLevel, date, message);
                }
            }
            Console.WriteLine("Logger info");
            foreach (var appender in apps)
            {
                Console.WriteLine(appender);
            }
        }
       static private void LoggerAction(ILogger logger,string errorType,DateTime date, string message)
        {
            switch (errorType.ToLower())
            {
                case "info":
                    logger.Info(date,message);
                    break;
                case "warning":
                    logger.Warning(date, message);
                    break;
                case "error":
                    logger.Error(date, message);
                    break;
                case "critical":
                    logger.Critical(date, message);
                    break;
                case "fatal":
                    logger.Fatal(date, message);
                    break;

                default:
                    break;
            }
        }
    }
}

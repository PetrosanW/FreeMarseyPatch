using System.Threading.Tasks;
using Content.Shared.Administration;
using Robust.Shared.Console;

namespace SimpleCommand.Commands
{
    [AnyCommand]
    public class CatHelloCommand : IConsoleCommand
    {
        public static string TestMessage = "Never gonna give you up";
        public static int MessageCount = 10;
        public static int DelayMilliseconds = 50;

        public string Command => "startspam";
        public string Description => "Запуск заданных параметров, By catlisan";
        public string Help => "просто напишите startspam";

        public async void Execute(IConsoleShell shell, string argStr, string[] args)
        {
            for (int i = 0; i < MessageCount; i++)
            {
                await Task.Delay(DelayMilliseconds);
                shell.ExecuteCommand($"say {TestMessage}");
            }
        }
    }

    [AnyCommand]
    public class EditMessageCommand : IConsoleCommand
    {
        public string Command => "editspam";
        public string Description => "Настройки спама";
        public string Help => "Использование: !editmessage \"Новое сообщение\" [количество сообщений] [задержка в миллисекундах]";

        public void Execute(IConsoleShell shell, string argStr, string[] args)
        {
            if (args.Length < 1)
            {
                shell.WriteLine("Необходимо указать новое сообщение.");
                return;
            }

            CatHelloCommand.TestMessage = args[0];

            if (args.Length > 1 && int.TryParse(args[1], out int messageCount))
            {
                CatHelloCommand.MessageCount = messageCount;
            }

            if (args.Length > 2 && int.TryParse(args[2], out int delayMilliseconds))
            {
                CatHelloCommand.DelayMilliseconds = delayMilliseconds;
            }

            shell.WriteLine($"Сообщение изменено на: {CatHelloCommand.TestMessage}");
            shell.WriteLine($"Количество сообщений: {CatHelloCommand.MessageCount}");
            shell.WriteLine($"Задержка между сообщениями: {CatHelloCommand.DelayMilliseconds} мс");
        }
    }
}
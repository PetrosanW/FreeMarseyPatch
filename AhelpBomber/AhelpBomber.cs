using Content.Client.Administration.Systems;
using Content.Shared.Administration;
using Robust.Client.Player;
using Robust.Shared.Console;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Network;

public static class SubverterPatch
{
    public static string Name = "AHelpBomber";
    public static string Description = "Используйте: ahelpbomber <сообщение> | by Petrosan";
}


[AnyCommand]
public class SpamAhelpCommand : IConsoleCommand
{
    [Dependency] private readonly IPlayerManager _playerManager = default!;
    [Dependency] private readonly IEntitySystemManager _entitySystem = default!;

    public string Command => "ahelpbomber";
    public string Description => "Спамит в ахелп сообщениями";
    public string Help => "Используйте: ahelpbomber <сообщение>";

    private static bool _isSpamming = false;
    private static string _message = " ";

    public void Execute(IConsoleShell shell, string argStr, string[] args)
    {
        if (args.Length == 0)
        {
            shell.WriteLine("Используйте: spamahelp <сообщение>");
            return;
        }

        _message = string.Join(" ", args);

        if (!_isSpamming)
        {
            _isSpamming = true;
            Task.Run(() => StartSpamming(shell));
            shell.WriteLine("Начинаю спамить в ахелп");
        }
        else
        {
            _isSpamming = false;
            shell.WriteLine("Прекращаю спамить в ахелп");
        }
    }

    private async Task StartSpamming(IConsoleShell shell)
    {
        var bwoinkSystem = _entitySystem.GetEntitySystem<BwoinkSystem>();
        var adminSystem = _entitySystem.GetEntitySystem<AdminSystem>();

        while (_isSpamming)
        {
            await Task.Delay(10);
            foreach (var session in _playerManager.Sessions)
            {
                bwoinkSystem.Send(session.UserId, _message, true);
            }
        }
    }
}

/// <summary>
///     Не дописано
/// </summary>
/*
[AnyCommand]
public class TestCommand : IConsoleCommand
{
    [Dependency] private readonly IPlayerManager _playerManager = default!;
    [Dependency] private readonly IEntitySystemManager _entitySystem = default!;

    public string Command => "ahelpsliv";
    public string Description => "Спамит всем игрокам на сервере если есть админка";
    public string Help => "Используйте: ahelpsliv <сообщение>";

    public void Execute(IConsoleShell shell, string argStr, string[] args)
    {
        if (args.Length == 0)
        {
            shell.WriteLine("Используйте: ahelpsliv <сообщение>");
            return;
        }

        var message = string.Join(" ", args);
        var bwoinkSystem = _entitySystem.GetEntitySystem<BwoinkSystem>();

        foreach (var session in _playerManager.Sessions)
        {
            bwoinkSystem.Send(session.UserId, message, true);
            shell.WriteLine($"Отправил бомбу: {session.UserId}");
        }
    }
}
*/

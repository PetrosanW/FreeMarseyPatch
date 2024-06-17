using System.Reflection;
using Content.Client.Administration.Managers;
using Content.Client.ContextMenu.UI;
using Content.Shared.Anomaly.Effects.Components;
using HarmonyLib;
using Robust.Shared.GameObjects;

public static class MarseyPatch
{

    public static string Name = "AdminFlagsPatch";

    public static string Description = "by Petrosan";

    public static bool ignoreFields = true;

}

[HarmonyPatch]
internal class IsActive
{
    [HarmonyTargetMethod]
    private static MethodBase TargetMethod()
    {
        return (MethodBase)AccessTools.Method(AccessTools.TypeByName("Content.Client.Administration.Managers.ClientAdminManager"), "IsActive");
    }

    [HarmonyPrefix]
    private static bool PrefSkip(ref bool __result, ClientAdminManager __instance)
    {
        __result = true;
        return false;
    }
}

[HarmonyPatch]
internal class CanCommand
{
    [HarmonyTargetMethod]
    private static MethodBase TargetMethod()
    {
        return (MethodBase)AccessTools.Method(AccessTools.TypeByName("Content.Client.Administration.Managers.ClientAdminManager"), "CanCommand");
    }

    [HarmonyPrefix]
    private static bool PrefSkip(ref bool __result, ClientAdminManager __instance)
    {
        __result = true;
        return false;
    }
}

[HarmonyPatch]
internal class CanAdminPlace
{
    [HarmonyTargetMethod]
    private static MethodBase TargetMethod()
    {
        return (MethodBase)AccessTools.Method(AccessTools.TypeByName("Content.Client.Administration.Managers.ClientAdminManager"), "CanAdminPlace");
    }

    [HarmonyPrefix]
    private static bool PrefSkip(ref bool __result, ClientAdminManager __instance)
    {
        __result = true;
        return false;
    }
}

[HarmonyPatch]
internal class CanScript
{
    [HarmonyTargetMethod]
    private static MethodBase TargetMethod()
    {
        return (MethodBase)AccessTools.Method(AccessTools.TypeByName("Content.Client.Administration.Managers.ClientAdminManager"), "CanScript");
    }

    [HarmonyPrefix]
    private static bool PrefSkip(ref bool __result, ClientAdminManager __instance)
    {
        __result = true;
        return false;
    }
}

[HarmonyPatch]
internal class CanSay
{
    [HarmonyTargetMethod]
    private static MethodBase TargetMethod()
    {
        return (MethodBase)AccessTools.Method(AccessTools.TypeByName("Content.Client.Administration.Managers.ClientAdminManager"), "CanScript");
    }

    [HarmonyPrefix]
    private static bool PrefSkip(ref bool __result, ClientAdminManager __instance)
    {
        __result = true;
        return false;
    }
}

[HarmonyPatch]
internal class CanAdminMenu
{
    [HarmonyTargetMethod]
    private static MethodBase TargetMethod()
    {
        return (MethodBase)AccessTools.Method(AccessTools.TypeByName("Content.Client.Administration.Managers.ClientAdminManager"), "CanAdminMenu");
    }

    [HarmonyPrefix]
    private static bool PrefSkip(ref bool __result, ClientAdminManager __instance)
    {
        __result = true;
        return false;
    }
}

[HarmonyPatch]
internal class EntityMenuElementPatch
{
    [HarmonyTargetMethod]
    private static MethodBase TargetMethod()
    {
        return (MethodBase)AccessTools.Method(AccessTools.TypeByName("Content.Client.ContextMenu.UI.EntityMenuElement"), "GetEntityDescription");
    }

    [HarmonyPostfix]
    private static void Postfix(EntityUid entity, EntityMenuElement __instance, ref string __result)
    {
        object obj = AccessTools.Method(__instance.GetType(), "GetEntityDescriptionAdmin").Invoke((object)__instance, new object[1]
        {
            (object) entity
        });
        __result = (string)obj;
    }
}

[HarmonyPatch]
static class CommandPermissionPatch
{
    [HarmonyTargetMethod]
    private static MethodBase TargetMethod()
    {
        return AccessTools.Method(AccessTools.TypeByName("Robust.Client.Console.ClientConsoleHost"), "CanExecute");
    }

    [HarmonyPostfix]
    private static void Postfix(ref bool __result)
    {
        __result = true;
    }
}
using System.Reflection;
using HarmonyLib;

public static class MarseyPatch
{
    public static string Name = "Flash Overlay disabler";
    public static string Description = "Disables flash overlay.";
    public static bool ignoreFields = true;
}

public static class OverlaysPatch
{
    private static MethodInfo GetOverlayDraw(string type)
    {
        return AccessTools.Method(AccessTools.TypeByName(type), "OnAppearanceChange");
    }

    private static IEnumerable<MethodBase> TargetMethods()
    {
        yield return GetOverlayDraw("Content.Client.Chemistry.Visualizers.SmokeVisualizerSystem");
    }

    [HarmonyPrefix]
    static bool Prefix() => false;
}
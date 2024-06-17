using System.Reflection;
using HarmonyLib;

public static class MarseyPatch
{
    
    public static Assembly RobustClient = null; 
    public static Assembly RobustShared = null;
    public static Assembly ContentShared = null;
    public static Assembly ContentClient = null;

    public static string Name = "DamageOverlay Patch";
    public static string Description = "Disable damage";
}

[HarmonyPatch]
public static class DamageOverlayPatch
{
    private static MethodBase TargetMethod() 
    {
        var DamageOverlay = MarseyPatch.ContentClient.GetType("Content.Client.UserInterface.Systems.DamageOverlays.Overlays.DamageOverlay")!;
        return DamageOverlay.GetMethod("Draw", BindingFlags.NonPublic | BindingFlags.Instance);
    }

  
    [HarmonyPrefix]
    private static bool PrefSkip()
    {
        return false;
    }
}
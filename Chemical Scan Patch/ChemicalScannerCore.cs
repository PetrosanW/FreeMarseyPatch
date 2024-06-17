using Content.Shared.Chemistry.Components;
using Robust.Shared.GameObjects;
using Robust.Shared.Player;


public static class SubverterPatch
{
    public static string Name = "Chemical Scan patch";
    public static string Description = "Include SolutionScannerComponent";
}


public sealed class SolutionScannerSystem : EntitySystem
{
    
    public override void Initialize()
    {
        SubscribeLocalEvent<LocalPlayerAttachedEvent>(OnLocalPlayerAttached);
    }

    void OnLocalPlayerAttached(LocalPlayerAttachedEvent args)
    {
        ChemicalScanTrue(args.Entity);

    }
    void ChemicalScanTrue(EntityUid uid)
    {
        if (!HasComp<SolutionScannerComponent>(uid))
        {
            AddComp(uid, new SolutionScannerComponent
            {
                NetSyncEnabled = false,
            });
        }
    }
}
using Sons.Weapon;

namespace RedNodeLoader.RangedWeaponsNodes;

public class CanReloadNode : SonsNode
{
    [IsArgOut]
    public bool CanReload { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var rangedWeaponController = (RangedWeaponController)args[0];
        CanReload = rangedWeaponController.CanReload();
    }
}

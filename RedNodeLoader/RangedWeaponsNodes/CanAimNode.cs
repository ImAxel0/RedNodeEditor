using Sons.Weapon;

namespace RedNodeLoader.RangedWeaponsNodes;

public class CanAimNode : SonsNode
{
    [IsArgOut]
    public bool CanAim { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var rangedWeaponController = (RangedWeaponController)args[0];
        CanAim = rangedWeaponController.CanAim();
    }
}

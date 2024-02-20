using Sons.Weapon;

namespace RedNodeLoader.RangedWeaponsNodes;

public class IsAimingNode : SonsNode
{
    [IsArgOut]
    public bool IsAiming { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var rangedWeaponController = (RangedWeaponController)args[0];
        IsAiming = rangedWeaponController.IsAiming;
    }
}

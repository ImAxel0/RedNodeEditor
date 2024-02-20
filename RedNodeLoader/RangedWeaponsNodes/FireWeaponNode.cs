using Sons.Weapon;

namespace RedNodeLoader.RangedWeaponsNodes;

public class FireWeaponNode : SonsNode
{
    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var rangedWeaponController = (RangedWeaponController)args[0];
        rangedWeaponController.TriggerFireWeapon();
    }
}

using Sons.Weapon;

namespace RedNodeLoader.RangedWeaponsNodes;

public class AmmoGetRemainingAmmoNode : SonsNode
{
    [IsArgOut]
    public int Remaining { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var ammo = (RangedWeapon.Ammo)args[0];
        Remaining = ammo.GetRemainingAmmo();
    }
}

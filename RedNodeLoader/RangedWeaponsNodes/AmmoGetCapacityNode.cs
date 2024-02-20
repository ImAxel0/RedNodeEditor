using Sons.Weapon;

namespace RedNodeLoader.RangedWeaponsNodes;

public class AmmoGetCapacityNode : SonsNode
{
    [IsArgOut]
    public int Capacity { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var ammo = (RangedWeapon.Ammo)args[0];
        Capacity = ammo.GetCapacity();
    }
}

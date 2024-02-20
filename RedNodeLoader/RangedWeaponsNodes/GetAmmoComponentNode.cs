using Sons.Weapon;
using System.Xml.Serialization;

namespace RedNodeLoader.RangedWeaponsNodes;

public class GetAmmoComponentNode : SonsNode
{
    [XmlIgnore]
    [IsArgOut]
    public RangedWeapon.Ammo AmmoComponent { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var rangedWeapon = (RangedWeapon)args[0];
        AmmoComponent = rangedWeapon.GetAmmo();
    }
}

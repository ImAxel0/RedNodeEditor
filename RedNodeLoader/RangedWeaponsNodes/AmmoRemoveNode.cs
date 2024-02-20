using Sons.Weapon;
using System.Xml.Serialization;

namespace RedNodeLoader.RangedWeaponsNodes;

public class AmmoRemoveNode : SonsNode
{
    [XmlIgnore]
    public RangedWeapon.Ammo AmmoComponent { get; set; }
    public int Amount { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var ammo = (RangedWeapon.Ammo)args[0];
        ammo.Remove((int)args[1]);
    }
}

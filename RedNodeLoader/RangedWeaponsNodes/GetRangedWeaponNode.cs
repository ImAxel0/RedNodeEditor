using Sons.Weapon;
using System.Xml.Serialization;

namespace RedNodeLoader.RangedWeaponsNodes;

public class GetRangedWeaponNode : SonsNode
{
    [XmlIgnore]
    [IsArgOut]
    public RangedWeapon RangedWeapon { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var rangedWeaponController = (RangedWeaponController)args[0];
        RangedWeapon = rangedWeaponController.GetRangedWeapon();
    }
}

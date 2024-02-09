using Sons.Weapon;

namespace RedNodeEditor.RangedWeaponsNodes;

public class GetRangedWeaponNode : SonsNode
{
    public GetRangedWeaponNode()
    {
        Name = "GetRangedWeapon";
        Description = "Gets the RangedWeapon component of the passed RangedWeaponController";
        NodeCategory = NodeCategories.RangedWeapons;

        ArgsOut.Add(new ArgOut { Type = typeof(RangedWeapon) });
    }
}

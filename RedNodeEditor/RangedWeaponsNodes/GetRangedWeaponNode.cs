using Sons.Weapon;

namespace RedNodeEditor.RangedWeaponsNodes;

public class GetRangedWeaponNode : SonsNode
{
    public GetRangedWeaponNode()
    {
        Name = "GetRangedWeapon";
        Description = "Gets the RangedWeapon component of the passed RangedWeaponController";
        NodeCategory = NodeCategories.RangedWeapons;

        ArgsIn.Add(new ArgIn { Type = typeof(RangedWeaponController), ArgName = nameof(RangedWeaponController) });
        ArgsOut.Add(new ArgOut { Type = typeof(RangedWeapon) });
    }
}

using Sons.Weapon;

namespace RedNodeEditor.RangedWeaponsNodes;

public class FireWeaponNode : SonsNode
{
    public FireWeaponNode()
    {
        Name = "FireWeapon";
        Description = "Triggers firing of the passed RangedWeaponController weapon (ammo will be consumed)";
        NodeCategory = NodeCategories.RangedWeapons;;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(RangedWeaponController), ArgName = nameof(RangedWeaponController) });
    }
}

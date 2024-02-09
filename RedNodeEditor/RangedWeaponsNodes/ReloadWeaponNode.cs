using Sons.Weapon;

namespace RedNodeEditor.RangedWeaponsNodes;

public class ReloadWeaponNode : SonsNode
{
    public ReloadWeaponNode()
    {
        Name = "ReloadWeapon";
        Description = "Reloads the equipped and passed RangedWeaponController";
        NodeCategory = NodeCategories.RangedWeapons;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(RangedWeaponController), ArgName = nameof(RangedWeaponController) });
    }
}

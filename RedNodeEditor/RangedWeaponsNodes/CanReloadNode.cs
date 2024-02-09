using Sons.Weapon;

namespace RedNodeEditor.RangedWeaponsNodes;

public class CanReloadNode : SonsNode
{
    public CanReloadNode()
    {
        Name = "CanReload";
        Description = "Check if player can reload with the equipped and passed RangedWeaponController";
        NodeCategory = NodeCategories.RangedWeapons;

        ArgsIn.Add(new ArgIn { Type = typeof(RangedWeaponController), ArgName = nameof(RangedWeaponController) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}

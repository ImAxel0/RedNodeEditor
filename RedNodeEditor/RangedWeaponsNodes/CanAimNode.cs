using Sons.Weapon;

namespace RedNodeEditor.RangedWeaponsNodes;

public class CanAimNode : SonsNode
{
    public CanAimNode()
    {
        Name = "CanAim";
        Description = "Check if player can aim with the equipped and passed RangedWeaponController";
        NodeCategory = NodeCategories.RangedWeapons;

        ArgsIn.Add(new ArgIn { Type = typeof(RangedWeaponController), ArgName = nameof(RangedWeaponController) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}

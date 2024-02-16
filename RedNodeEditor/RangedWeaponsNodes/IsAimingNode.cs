using Sons.Weapon;

namespace RedNodeEditor.RangedWeaponsNodes;

public class IsAimingNode : SonsNode
{
    public IsAimingNode()
    {
        Name = "IsAiming";
        Description = "Check if player is aiming with the equipped and passed RangedWeaponController";
        NodeCategory = NodeCategories.RangedWeapons;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(RangedWeaponController), ArgName = nameof(RangedWeaponController) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}

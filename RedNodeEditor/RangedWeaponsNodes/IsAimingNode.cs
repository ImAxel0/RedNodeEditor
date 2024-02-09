namespace RedNodeEditor.RangedWeaponsNodes;

public class IsAimingNode : SonsNode
{
    public IsAimingNode()
    {
        Name = "IsAiming";
        Description = "Check if player is aiming with the equipped and passed RangedWeaponController";
        NodeCategory = NodeCategories.RangedWeapons;

        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}

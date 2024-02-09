using Sons.Weapon;

namespace RedNodeEditor.RangedWeaponsNodes;

public class AmmoGetRemainingAmmo : SonsNode
{
    public AmmoGetRemainingAmmo()
    {
        Name = "Ammo.GetRemainingAmmo";
        Description = "Gets the remaining ammunations in the magazine of the passed Ammo component";
        NodeCategory = NodeCategories.RangedWeapons;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(RangedWeapon.Ammo), ArgName = nameof(RangedWeapon.Ammo) });
        ArgsOut.Add(new ArgOut { Type = typeof(int) });
    }
}

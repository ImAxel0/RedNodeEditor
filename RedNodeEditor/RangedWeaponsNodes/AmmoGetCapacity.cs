using Sons.Weapon;

namespace RedNodeEditor.RangedWeaponsNodes;

public class AmmoGetCapacity : SonsNode
{
    public AmmoGetCapacity()
    {
        Name = "Ammo.GetCapacity";
        Description = "Gets the max ammunations capacity of the passed Ammo component";
        NodeCategory = NodeCategories.RangedWeapons;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(RangedWeapon.Ammo), ArgName = nameof(RangedWeapon.Ammo) });
        ArgsOut.Add(new ArgOut { Type = typeof(int) });
    }
}

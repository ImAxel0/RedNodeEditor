using Sons.Weapon;

namespace RedNodeEditor.RangedWeaponsNodes;

public class GetAmmoComponentNode : SonsNode
{
    public GetAmmoComponentNode()
    {
        Name = "GetAmmoComponent";
        Description = "Gets the Ammo component of the passed RangedWeapon, which contains informations about the weapon ammunations";
        NodeCategory = NodeCategories.RangedWeapons;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(RangedWeapon), ArgName = nameof(RangedWeapon) });
        ArgsOut.Add(new ArgOut { Type = typeof(RangedWeapon.Ammo) });
    }
}

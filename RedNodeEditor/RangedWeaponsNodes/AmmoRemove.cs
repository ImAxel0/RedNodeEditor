using Sons.Weapon;
using System.Xml.Serialization;

namespace RedNodeEditor.RangedWeaponsNodes;

public class AmmoRemove : SonsNode
{
    [XmlIgnore]
    public RangedWeapon.Ammo AmmoComponent { get; set; }
    public int Amount { get; set; }

    public AmmoRemove()
    {
        Name = "Ammo.Remove";
        Description = "Remove ammunations of the specified amount from the passed Ammo component";
        NodeCategory = NodeCategories.RangedWeapons;

        ArgsIn.Add(new ArgIn { Type = typeof(RangedWeapon.Ammo), ArgName = nameof(RangedWeapon.Ammo) });
        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(Amount) });
    }
}

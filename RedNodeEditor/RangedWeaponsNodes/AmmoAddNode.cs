using Sons.Weapon;
using System.Xml.Serialization;

namespace RedNodeEditor.RangedWeaponsNodes;

public class AmmoAddNode : SonsNode
{
    [XmlIgnore]
    public RangedWeapon.Ammo AmmoComponent { get; set; }
    public int Amount { get; set; }

    public AmmoAddNode()
    {
        Name = "Ammo.Add";
        Description = "Adds ammos of the specified amount to the passed Ammo component";
        NodeCategory = NodeCategories.RangedWeapons;

        ArgsIn.Add(new ArgIn { Type = typeof(RangedWeapon.Ammo), ArgName = nameof(RangedWeapon.Ammo) });
        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(Amount) });
    }
}

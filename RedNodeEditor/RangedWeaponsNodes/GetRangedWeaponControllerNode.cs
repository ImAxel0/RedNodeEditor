using Newtonsoft.Json;
using System.Xml.Serialization;
using Sons.Weapon;
using static RedNodeEditor.GlobalEnums;

namespace RedNodeEditor.RangedWeaponsNodes;

public class GetRangedWeaponControllerNode : SonsNode
{
    [IgnoreProperty]
    public RangedWeaponEnum EnumValue { get; set; } = RangedWeaponEnum.Bow;

    [XmlIgnore]
    [JsonIgnore]
    public List<Enum> RangedWeaponList { get; set; } = new()
    {
        RangedWeaponEnum.Bow, RangedWeaponEnum.CompactPistol, RangedWeaponEnum.Crossbow, RangedWeaponEnum.Grenade, RangedWeaponEnum.Molotov, RangedWeaponEnum.Revolver,
        RangedWeaponEnum.Rifle, RangedWeaponEnum.RopeGun, RangedWeaponEnum.Shotgun, RangedWeaponEnum.Slingshot, RangedWeaponEnum.SmallRock, RangedWeaponEnum.StungGun,
        RangedWeaponEnum.TimeBomb
    };

    public GetRangedWeaponControllerNode() 
    {
        Name = "GetRangedWeaponController";
        Description = "Gets the RangedWeaponController component of the selected weapon\nThe weapon must be equipped when executing this node";
        NodeCategory = NodeCategories.RangedWeapons;

        ArgsIn.Add(new ArgIn { Type = typeof(RangedWeaponEnum), ArgName = nameof(RangedWeaponEnum) });
        ArgsOut.Add(new ArgOut { Type = typeof(RangedWeaponController) });
    }
}

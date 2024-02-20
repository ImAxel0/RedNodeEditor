using Sons.Weapon;
using System.Xml.Serialization;
using TheForest.Utils;
using static RedNodeLoader.GlobalEnums;

namespace RedNodeLoader.RangedWeaponsNodes;

public class GetRangedWeaponControllerNode : SonsNode
{
    public RangedWeaponEnum EnumValue { get; set; } = RangedWeaponEnum.Bow;

    [XmlIgnore]
    [IsArgOut]
    public RangedWeaponController RangedWeaponController { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        RangedWeaponEnum rangedWeapon = (RangedWeaponEnum)args[0];

        switch (rangedWeapon)
        {
            case RangedWeaponEnum.Bow:
                RangedWeaponController = LocalPlayer.Transform.GetComponentInChildren<BowWeaponController>();
                break;
            case RangedWeaponEnum.CompactPistol:
                RangedWeaponController = LocalPlayer.Transform.GetComponentInChildren<CompactPistolWeaponController>();
                break;
            case RangedWeaponEnum.Crossbow:
                RangedWeaponController = LocalPlayer.Transform.GetComponentInChildren<CrossbowWeaponController>();
                break;
            case RangedWeaponEnum.Grenade:
                RangedWeaponController = LocalPlayer.Transform.GetComponentInChildren<GrenadeWeaponController>();
                break;
            case RangedWeaponEnum.Molotov:
                RangedWeaponController = LocalPlayer.Transform.GetComponentInChildren<MolotovWeaponController>();
                break;
            case RangedWeaponEnum.Revolver:
                RangedWeaponController = LocalPlayer.Transform.GetComponentInChildren<RevolverWeaponController>();
                break;
            case RangedWeaponEnum.Rifle:
                RangedWeaponController = LocalPlayer.Transform.GetComponentInChildren<RifleAnimatorController>();
                break;
            case RangedWeaponEnum.RopeGun:
                RangedWeaponController = LocalPlayer.Transform.GetComponentInChildren<RopeGunController>();
                break;
            case RangedWeaponEnum.Shotgun:
                RangedWeaponController = LocalPlayer.Transform.GetComponentInChildren<ShotgunWeaponController>();
                break;
            case RangedWeaponEnum.Slingshot:
                RangedWeaponController = LocalPlayer.Transform.GetComponentInChildren<SlingshotWeaponController>();
                break;
            case RangedWeaponEnum.SmallRock:
                RangedWeaponController = LocalPlayer.Transform.GetComponentInChildren<SmallRockWeaponController>();
                break;
            case RangedWeaponEnum.StungGun:
                RangedWeaponController = LocalPlayer.Transform.GetComponentInChildren<StunGunWeaponController>();
                break;
            case RangedWeaponEnum.TimeBomb:
                RangedWeaponController = LocalPlayer.Transform.GetComponentInChildren<TimeBombWeaponController>();
                break;
        }
    }
}

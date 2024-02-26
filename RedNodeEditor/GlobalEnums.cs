namespace RedNodeEditor;

public class GlobalEnums
{
    public enum BaseNode
    {
        OnInitializeMod, OnSdkInitialized, OnGameStart, OnWorldUpdate, OnUpdate, OnFixedUpdate
    }

    public enum RangedWeaponEnum
    {
        Bow, CompactPistol, Crossbow, Grenade, Molotov, Revolver,
        Rifle, RopeGun, Shotgun, Slingshot, SmallRock, StungGun, TimeBomb
    }

    public enum SoundType
    {
        Music = 0,
        Sfx = 1,
    }
}

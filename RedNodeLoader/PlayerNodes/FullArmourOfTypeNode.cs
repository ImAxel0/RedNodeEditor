using Sons.Wearable.Armour;
using SonsSdk;
using TheForest.Utils;

namespace RedNodeLoader.PlayerNodes;

public class FullArmourOfTypeNode : SonsNode
{
    public int ArmourId { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);

        ArmourPiece armour = LocalPlayer.Stats.ArmourSystem.GetArmourPieceById((int)args[0]);
        if (!armour)
        {
            SonsTools.ShowMessage($"Invalid parameter, {ArmourId} is not a valid armour id");
            return;
        }
        foreach (var slot in (Sons.Wearable.WearableSlots[])Enum.GetValues(typeof(Sons.Wearable.WearableSlots)))
        {
            LocalPlayer.Stats.ArmourSystem.TryUnequipSlot(slot, true);
        }
        for (int i = 0; i < 10; i++)
        {
            if (!LocalPlayer.Stats.ArmourSystem.EquipToNextAvailableSlot(armour))
                break;
        }
    }
}

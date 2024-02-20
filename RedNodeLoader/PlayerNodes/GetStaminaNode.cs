using TheForest.Utils;

namespace RedNodeLoader.PlayerNodes;

public class GetStaminaNode : SonsNode
{
    [IsArgOut]
    public float Stamina { get; set; }

    public override void Execute()
    {
        Stamina = LocalPlayer.Vitals.GetStamina();
    }
}

using TheForest.Utils;

namespace RedNodeLoader.PlayerNodes;

public class SetJumpMultiplierNode : SonsNode
{
    public float Value { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        LocalPlayer.FpCharacter.SetSuperJump((float)args[0]);
    }
}

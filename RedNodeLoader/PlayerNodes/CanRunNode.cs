using TheForest.Utils;

namespace RedNodeLoader.PlayerNodes;

public class CanRunNode : SonsNode
{
    [IsArgOut]
    public bool CanRun { get; set; }

    public override void Execute()
    {
        CanRun = LocalPlayer.FpCharacter.CanRun;
    }
}

using TheForest.Utils;

namespace RedNodeLoader.PlayerNodes;

public class LockViewNode : SonsNode
{
    public bool RigidbodyLock { get; set; }
    public bool IgnoreGrounded { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        LocalPlayer.FpCharacter.LockView((bool)args[0], (bool)args[1]);
    }
}

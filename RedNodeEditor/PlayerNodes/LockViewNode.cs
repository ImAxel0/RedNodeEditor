namespace RedNodeEditor.PlayerNodes;

public class LockViewNode : SonsNode
{
    public bool RigidbodyLock { get; set; }
    public bool IgnoreGrounded { get; set; }

    public LockViewNode()
    {
        Name = "LockView";
        Description = "Locks player";
        NodeCategory = NodeCategories.Player;

        ArgsIn.Add(new ArgIn { Type = typeof(bool), ArgName = nameof(RigidbodyLock) });
        ArgsIn.Add(new ArgIn { Type = typeof(bool), ArgName = nameof(IgnoreGrounded) });
    }
}

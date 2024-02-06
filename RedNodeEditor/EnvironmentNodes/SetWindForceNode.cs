namespace RedNodeEditor.EnvironmentNodes;

public class SetWindForceNode : SonsNode
{
    public float Force { get; set; }

    public SetWindForceNode()
    {
        Name = "SetWindForce";
        Description = "Sets the current wind force. Set to negative to unlock it";
        NodeCategory = NodeCategories.Environment;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Force) });
    }
}

namespace RedNodeEditor.UnityNodes.Rigidbody;

public class RbGetMass : SonsNode
{
    public RbGetMass()
    {
        Name = nameof(RbGetMass);
        Description = "Returns the mass of the rigidbody.";
        NodeCategory = NodeCategories.Unity;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Rigidbody), ArgName = nameof(Rigidbody) });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}

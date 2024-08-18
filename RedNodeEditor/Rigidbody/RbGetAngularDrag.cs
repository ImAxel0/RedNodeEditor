namespace RedNodeEditor.UnityNodes.Rigidbody;

public class RbGetAngularDrag : SonsNode
{
    public RbGetAngularDrag()
    {
        Name = nameof(RbGetAngularDrag);
        Description = "Returns the angular drag of the object.";
        NodeCategory = NodeCategories.Unity;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Rigidbody), ArgName = nameof(Rigidbody) });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}

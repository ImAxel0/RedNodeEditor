
namespace RedNodeEditor.UnityNodes.Rigidbody;

public class RbIsKinematic : SonsNode
{
    public RbIsKinematic()
    {
        Name = nameof(RbIsKinematic);
        Description = "Does physics affects the rigidbody?";
        NodeCategory = NodeCategories.Unity;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Rigidbody), ArgName = nameof(Rigidbody) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}

using System.Numerics;

namespace RedNodeEditor.ActorsNodes;

public class DismemberActorsInRadiusNode : SonsNode
{
    public Vector3 Center { get; set; }
    public float Radius { get; set; }

    public DismemberActorsInRadiusNode()
    {       
        Name = "DismemberActorsInRadius";
        Description = "Dismember all actors in radius";
        NodeCategory = NodeCategories.Actors;

        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Center) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Radius) });
    }
}

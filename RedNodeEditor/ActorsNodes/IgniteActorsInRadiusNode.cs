using System.Numerics;

namespace RedNodeEditor.ActorsNodes;

public class IgniteActorsInRadiusNode : SonsNode
{
    public Vector3 Center { get; set; }
    public float Radius { get; set; }
    public float Lifetime { get; set; }

    public IgniteActorsInRadiusNode()
    {
        Name = "IgniteActorsInRadius";
        Description = "Ignites all actors in radius";
        NodeCategory = NodeCategories.Actors;

        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Center) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Radius) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Lifetime) });
    }
}

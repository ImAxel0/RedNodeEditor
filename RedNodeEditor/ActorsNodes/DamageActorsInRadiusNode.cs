using System.Numerics;

namespace RedNodeEditor.ActorsNodes;

public class DamageActorsInRadiusNode : SonsNode
{
    public Vector3 Center { get; set; }
    public float Radius { get; set; }
    public float Damage { get; set; }

    public DamageActorsInRadiusNode()
    {
        Name = "DamageActorsInRadius";
        Description = "Damages all actors in radius by the given amount";
        NodeCategory = NodeCategories.Actors;

        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Center) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Radius) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Damage) });
    }
}

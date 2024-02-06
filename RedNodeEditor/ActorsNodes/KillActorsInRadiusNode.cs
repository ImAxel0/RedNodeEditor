using Newtonsoft.Json;
using Sons.Ai.Vail;
using System.Numerics;
using System.Xml.Serialization;

namespace RedNodeEditor.ActorsNodes;

public class KillActorsInRadiusNode : SonsNode
{
    public Vector3 Center { get; set; }
    public float Radius { get; set; }

    [IgnoreProperty]
    public VailActorClassId EnumValue { get; set; } = VailActorClassId.None;

    [XmlIgnore]
    [JsonIgnore]
    public List<Enum> ActorsEnums { get; set; } = new();

    public KillActorsInRadiusNode()
    {
        Name = "KillActorsInRadius";
        Description = "Kills all actors in radius of specified type.\nNone = ALL";
        NodeCategory = NodeCategories.Actors;

        foreach (var season in Enum.GetValues(typeof(VailActorClassId)))
            ActorsEnums.Add((VailActorClassId)season);
        
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Center) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Radius) });
        ArgsIn.Add(new ArgIn { Type = typeof(VailActorClassId), ArgName = nameof(VailActorClassId) });
    }
}

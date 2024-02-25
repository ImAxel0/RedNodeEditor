using Newtonsoft.Json;
using Sons.Ai.Vail;
using Sons.Atmosphere;
using System.Xml.Serialization;

namespace RedNodeEditor.ActorsNodes;

public class SpawnActorNode : SonsNode
{
    [IgnoreProperty]
    public VailActorTypeId EnumValue { get; set; } = VailActorTypeId.Robby;

    [XmlIgnore]
    [JsonIgnore]
    public List<Enum> ActorsEnum { get; set; } = new();

    public SpawnActorNode()
    {
        Name = "SpawnActor";
        Description = "Spawns the selected actor (SP or HOST only)";
        NodeCategory = NodeCategories.Actors;

        foreach (var actor in Enum.GetValues(typeof(VailActorTypeId)))
            ActorsEnum.Add((VailActorTypeId)actor);

        ArgsIn.Add(new ArgIn { Type = typeof(VailActorTypeId), ArgName = nameof(Type) });
    }
}

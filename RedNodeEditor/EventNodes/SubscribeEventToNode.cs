using Newtonsoft.Json;
using Sons.Atmosphere;
using System.Xml.Serialization;
using static RedNodeEditor.GlobalEnums;

namespace RedNodeEditor.EventNodes;

public class SubscribeEventToNode : SonsNode
{
    [IgnoreProperty]
    public string EventId { get; set; }
    [IsEventName]
    public string EventName { get; set; }

    [IgnoreProperty]
    public BaseNode EnumValue { get; set; } = BaseNode.OnUpdate;

    [XmlIgnore]
    [JsonIgnore]
    public List<Enum> BaseNodeList { get; set; } = new();

    public SubscribeEventToNode() 
    {
        Name = "SubscribeEventTo";
        Description = "Subscribes a CustomEvent node to one of the base nodes";
        NodeCategory = NodeCategories.FlowChange;
        SizeOverride = new(270, 190);

        foreach (var baseNode in Enum.GetValues(typeof(BaseNode)))
            BaseNodeList.Add((BaseNode)baseNode);

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(EventName), Hide = true });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(EventName), Hide = true });
        ArgsIn.Add(new ArgIn { Type = typeof(BaseNode), ArgName = nameof(BaseNode) });
    }
}

using Newtonsoft.Json;
using System.Xml.Serialization;

namespace RedNodeEditor.EventNodes;

public class UnsubscribeEventFromNode : SonsNode
{
    [IgnoreProperty]
    public string EventId { get; set; }
    [IsEventName]
    public string EventName { get; set; }

    [IgnoreProperty]
    public BaseNode EnumValue { get; set; } = BaseNode.OnUpdate;

    [XmlType("UnsubscribeEventFromNode_BaseNode")]
    public enum BaseNode
    {
        OnInitializeMod, OnSdkInitialized, OnGameStart, OnWorldUpdate, OnUpdate
    }

    [XmlIgnore]
    [JsonIgnore]
    public List<Enum> BaseNodeList { get; set; } = new() { BaseNode.OnInitializeMod, BaseNode.OnSdkInitialized, BaseNode.OnGameStart, BaseNode.OnWorldUpdate, BaseNode.OnUpdate };

    public UnsubscribeEventFromNode()
    {
        Name = "UnsubscribeEventFrom";
        Description = "Unsubscribes a CustomEvent node from one of the base nodes";
        NodeCategory = NodeCategories.FlowChange;
        SizeOverride = new(270, 190);

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(EventName), Hide = true });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(EventName), Hide = true });
        ArgsIn.Add(new ArgIn { Type = typeof(BaseNode), ArgName = nameof(BaseNode) });
    }
}

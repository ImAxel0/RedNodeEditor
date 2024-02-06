using Newtonsoft.Json;
using System.Xml.Serialization;

namespace RedNodeEditor.EventNodes;

public class SubUnsubEventNode : SonsNode
{
    [IgnoreProperty]
    public string EventId { get; set; }
    [IsEventName]
    public string EventName { get; set; }
    public bool SubUnsub { get; set; }

    [IgnoreProperty]
    public BaseNode EnumValue { get; set; } = BaseNode.OnUpdate;

    [XmlType("SubUnsubEventNode_BaseNode")]
    public enum BaseNode
    {
        OnInitializeMod, OnSdkInitialized, OnGameStart, OnWorldUpdate, OnUpdate
    }

    [XmlIgnore]
    [JsonIgnore]
    public List<Enum> BaseNodeList { get; set; } = new() { BaseNode.OnInitializeMod, BaseNode.OnSdkInitialized, BaseNode.OnGameStart, BaseNode.OnWorldUpdate, BaseNode.OnUpdate };

    public SubUnsubEventNode()
    {
        Name = "SubUnsubEvent";
        Description = "Subscribes (true) or unsubscribes (false) a CustomEvent node to one of the base nodes";
        NodeCategory = NodeCategories.FlowChange;

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(EventName), Hide = true });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(EventName), Hide = true });
        ArgsIn.Add(new ArgIn { Type = typeof(bool), ArgName = nameof(SubUnsub) });
        ArgsIn.Add(new ArgIn { Type = typeof(BaseNode), ArgName = nameof(BaseNode) });
    }
}

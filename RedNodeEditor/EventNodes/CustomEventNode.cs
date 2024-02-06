using CSharpVitamins;
using System.Xml.Serialization;

namespace RedNodeEditor.EventNodes;

public class CustomEventNode : SonsNode
{
    [IgnoreProperty]
    public string EventId { get; set; } = ShortGuid.NewGuid().ToString();
    public string EventName { get; set; }

    [XmlArray("EventNodes")]
    [XmlArrayItem("Node", typeof(SonsNode))]
    [IgnoreProperty]
    public List<SonsNode> EventNodes { get; set; } = new List<SonsNode>();

    public CustomEventNode() 
    {
        Name = "CustomEvent";
        Description = "A custom event with optional boolean and float outputs";
        NodeType = NodeTypes.Starter;
        NodeCategory = NodeCategories.FlowChange;

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(EventName), Hide = true });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(EventName), Hide = true });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}

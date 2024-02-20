using System.Xml.Serialization;

namespace RedNodeLoader.EventsNodes;

public class CustomEventNode : SonsNode
{
    public string EventId { get; set; }
    public string EventName { get; set; }

    [XmlArray("EventNodes")]
    [XmlArrayItem("Node", typeof(SonsNode))]
    public List<SonsNode> EventNodes { get; set; } = new List<SonsNode>();

    [IsArgOut]
    public bool BoolParam { get; set; }

    [IsArgOut]
    public float FloatParam { get; set; }

    public override void Execute()
    {
        EventNodes.ForEach(node => node.Execute());
    }

    public override bool Execute(string args)
    {
        EventNodes.ForEach(node => node.Execute());
        return true;
    }
}

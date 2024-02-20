using System.Xml.Serialization;

namespace RedNodeLoader.FlowNodes;

public class IfStatementNode : SonsNode
{
    public bool Value { get; set; }

    [XmlArray("TrueBranch")]
    [XmlArrayItem("Node", typeof(SonsNode))]
    public List<SonsNode> TrueBranchNodes { get; set; } = new List<SonsNode>();

    [XmlArray("FalseBranch")]
    [XmlArrayItem("Node", typeof(SonsNode))]
    public List<SonsNode> FalseBranchNodes { get; set; } = new List<SonsNode>();

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        if ((bool)args[0])
        {
            TrueBranchNodes.ForEach(node => node.Execute());
        }
        else
        {
            FalseBranchNodes.ForEach(node => node.Execute());
        }
    }
}

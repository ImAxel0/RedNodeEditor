using System.Xml.Serialization;

namespace RedNodeEditor.FlowNodes;

public class IfStatementNode : SonsNode
{
    public bool Value { get; set; }

    [XmlArray("TrueBranch")]
    [XmlArrayItem("Node", typeof(SonsNode))]
    [IgnoreProperty]
    public List<SonsNode> TrueBranchNodes { get; set; } = new List<SonsNode>();

    [XmlArray("FalseBranch")]
    [XmlArrayItem("Node", typeof(SonsNode))]
    [IgnoreProperty]
    public List<SonsNode> FalseBranchNodes { get; set; } = new List<SonsNode>();

    public IfStatementNode()
    {
        Name = "IfStatement";
        Description = "If condition is true go to 1 (first output), else go to 2 (second output)";
        NodeType = NodeTypes.Flow;
        NodeCategory = NodeCategories.FlowChange;

        Outputs.Add(new OutputNode());

        ArgsIn.Add(new ArgIn { Type = typeof(bool) });
    }
}

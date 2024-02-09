using System.Numerics;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RedNodeEditor;

public class SonsNode
{
    public string Id = Guid.NewGuid().ToString();

    [XmlIgnore]
    [JsonIgnore]
    public string Description { get; set; }

    [XmlIgnore]
    public Vector2 Position { get; set; }

    [XmlIgnore]
    public Vector2 SizeOverride { get; set; } = Vector2.Zero;

    [XmlIgnore]
    [JsonIgnore]
    public bool IsDragging { get; set; }

    [XmlIgnore]
    public string Name { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public NodeTypes NodeType = NodeTypes.Middle;

    public enum NodeTypes
    {
        Starter,
        Middle,
        Flow,
        Variable,
    }

    /// <summary>
    /// Informations about the Input of the node
    /// </summary>
    [XmlIgnore]
    public InputNode Input = new();

    /// <summary>
    /// Informations about the Outputs of the node
    /// </summary>
    [XmlIgnore]
    public List<OutputNode> Outputs = new()
    {
        new OutputNode()
    };

    [JsonIgnore]
    [XmlIgnore]
    public NodeCategories NodeCategory = NodeCategories.Others;

    public enum NodeCategories
    {
        Others,
        Actors,
        Environment,
        Player,
        Inventory,
        RangedWeapons,
        BaseNodes,
        Math,
        FlowChange,
        Input,
        UI,
        Unity,
        Utilities,
    }

    [XmlArray("ArgsIn"), XmlArrayItem(typeof(ArgIn))]
    public List<ArgIn> ArgsIn = new();

    [XmlArray("ArgsOut"), XmlArrayItem(typeof(ArgOut))]
    public List<ArgOut> ArgsOut = new();
}

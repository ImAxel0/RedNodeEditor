using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeLoader.UnityNodes;

public class TransformFindNode : SonsNode
{
    [XmlIgnore]
    public Transform Transform { get; set; }
    public string PathName { get; set; }

    [XmlIgnore]
    [IsArgOut]
    public Transform FoundTr { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var tr = (Transform)args[0];
        FoundTr = tr.Find((string)args[1]);
    }
}

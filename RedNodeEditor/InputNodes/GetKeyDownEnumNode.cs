using Newtonsoft.Json;
using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeEditor.InputNodes;

public class GetKeyDownEnumNode : SonsNode
{
    [IgnoreProperty]
    public KeyCode EnumValue { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public List<Enum> KeyEnums { get; set; } = new();

    public GetKeyDownEnumNode()
    {
        Name = "GetKeyDownEnum";
        Description = "Returns true once if the key is pressed";
        NodeCategory = NodeCategories.Input;

        foreach (var key in Enum.GetValues(typeof(KeyCode)))
            KeyEnums.Add((KeyCode)key);

        ArgsIn.Add(new ArgIn { Type = typeof(KeyCode), ArgName = nameof(KeyCode) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}

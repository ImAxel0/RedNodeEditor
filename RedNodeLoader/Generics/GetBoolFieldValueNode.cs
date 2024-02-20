using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeLoader.Generics;

public class GetBoolFieldValueNode : SonsNode
{
    [XmlIgnore]
    public Component Component { get; set; }
    public string FieldName { get; set; }

    [IsArgOut]
    public bool Value { get; set; } 

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var com = (Component)args[0];
        var field = com.GetIl2CppType().GetField((string)args[1], Il2CppSystem.Reflection.BindingFlags.NonPublic |
            Il2CppSystem.Reflection.BindingFlags.Instance | Il2CppSystem.Reflection.BindingFlags.Public | Il2CppSystem.Reflection.BindingFlags.Static);
        Value = field.GetValue(com).Unbox<bool>();
    }
}

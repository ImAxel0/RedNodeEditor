using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeLoader.Generics;

public class GetFloatPropertyValueNode : SonsNode
{
    [XmlIgnore]
    public Component Component { get; set; }
    public string PropertyName { get; set; }

    [IsArgOut]
    public float Value { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var com = (Component)args[0];
        var property = com.GetIl2CppType().GetProperty((string)args[1], Il2CppSystem.Reflection.BindingFlags.NonPublic |
            Il2CppSystem.Reflection.BindingFlags.Instance | Il2CppSystem.Reflection.BindingFlags.Public | Il2CppSystem.Reflection.BindingFlags.Static);
        Value = property.GetValue(com).Unbox<float>();
    }
}

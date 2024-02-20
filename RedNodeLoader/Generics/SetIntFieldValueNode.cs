using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeLoader.Generics;

public class SetIntFieldValueNode : SonsNode
{
    [XmlIgnore]
    public Component Component { get; set; }
    public string FieldName { get; set; }
    public int Value { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var com = (Component)args[0];
        var field = com.GetIl2CppType().GetField((string)args[1], Il2CppSystem.Reflection.BindingFlags.NonPublic |
            Il2CppSystem.Reflection.BindingFlags.Instance | Il2CppSystem.Reflection.BindingFlags.Public | Il2CppSystem.Reflection.BindingFlags.Static);
        field.SetValue(com, (int)args[2]);
    }
}

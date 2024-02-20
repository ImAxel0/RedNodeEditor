using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeLoader.Generics;

public class CallMethodIntNode : SonsNode
{
    [XmlIgnore]
    public Component Component { get; set; }

    public string MethodName { get; set; }
    public int Value { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var com = (Component)args[0];
        com.GetIl2CppType().GetMethod((string)args[1], Il2CppSystem.Reflection.BindingFlags.NonPublic | Il2CppSystem.Reflection.BindingFlags.Instance
            | Il2CppSystem.Reflection.BindingFlags.Public | Il2CppSystem.Reflection.BindingFlags.Static)
            .Invoke(com, new Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray<Il2CppSystem.Object>(new Il2CppSystem.Object[] { (int)args[2] }));
    }
}

namespace RedNodeEditor.InputNodes;

public class GetKeyUpNode : SonsNode
{
    public string KeyName { get; set; }

    public GetKeyUpNode()
    {
        Name = "GetKeyUp";
        Description = "Returns true once when the key is released\n" +
            "For the available key names see: https://docs.unity3d.com/Manual/class-InputManager.html";
        NodeCategory = NodeCategories.Input;

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(KeyName) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}

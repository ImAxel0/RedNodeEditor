namespace RedNodeEditor.InputNodes;

public class GetKeyNode : SonsNode
{
    public string KeyName { get; set; }

    public GetKeyNode()
    {
        Name = "GetKey";
        Description = "Returns true if the key is pressed\n" +
            "For the available key names see: https://docs.unity3d.com/Manual/class-InputManager.html";
        NodeCategory = NodeCategories.Input;

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(KeyName) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}

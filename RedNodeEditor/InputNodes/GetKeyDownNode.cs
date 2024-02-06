namespace RedNodeEditor.InputNodes;

public class GetKeyDownNode : SonsNode
{
    public string KeyName { get; set; }

    public GetKeyDownNode()
    {
        Name = "GetKeyDown";
        Description = "Returns true once if the key is pressed\n" +
            $"For the available key names see: https://docs.unity3d.com/Manual/class-InputManager.html else use the [{nameof(GetKeyDownEnumNode)}]";
        NodeCategory = NodeCategories.Input;

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(KeyName) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}

using RedNodeEditor.EventNodes;
using RedNodeEditor.UnityNodes;

namespace RedNodeEditor;

public class CharsNoBlankTypes
{
    /// <summary>
    /// List of node types where string inputs can't have spaces
    /// </summary>
    public static List<Type> CharsNoBlank = new()
    {
        typeof(CustomEventNode), typeof(GetComponentNode),
    };
}

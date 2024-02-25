using System.Numerics;

namespace RedNodeEditor.PlayerNodes;

public class SafeGotoCoordsNode : SonsNode
{
    public Vector3 xyz {get; set;}

    public SafeGotoCoordsNode() 
    {
        Name = "SafeGotoCoords";
        Description = "Teleports player to the specified (x, y, z) coordinates. Slower than [GotoCoords] but prevents falling underworld if teleporting in a cave";
        NodeCategory = NodeCategories.Player;

        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(xyz) });
    }
}

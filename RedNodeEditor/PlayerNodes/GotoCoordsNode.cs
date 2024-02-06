using System.Numerics;

namespace RedNodeEditor.PlayerNodes;

public class GotoCoordsNode : SonsNode
{
    public Vector3 xyz {get; set;}

    public GotoCoordsNode() 
    {
        Name = "GotoCoords";
        Description = "Teleports player to the specified (x, y, z) coordinates";
        NodeCategory = NodeCategories.Player;

        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(xyz) });
    }
}

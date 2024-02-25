using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RedNodeEditor.PlayerNodes;

public class GotoCoordsNode : SonsNode
{
    public Vector3 xyz { get; set; }

    public GotoCoordsNode()
    {
        Name = "GotoCoordsNode";
        Description = "Teleports player to the specified (x, y, z) coordinates. If teleporting in a cave use [SafeGotoCoords] instead";
        NodeCategory = NodeCategories.Player;

        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(xyz) });
    }
}
